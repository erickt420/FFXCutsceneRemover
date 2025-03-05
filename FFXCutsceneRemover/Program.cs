using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Binding;
using System.CommandLine.Parsing;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;

using FFXCutsceneRemover.Logging;

namespace FFXCutsceneRemover;

internal sealed class CsrConfigBinder : BinderBase<CsrConfig>
{
    private readonly Option<bool?> _optCsrOn;
    private readonly Option<bool?> _optCsrBreakOn;
    private readonly Option<bool?> _optRngOn;
    private readonly Option<int?> _optMtSleepInterval;

    public CsrConfigBinder(Option<bool?> optCsrOn,
                           Option<bool?> optCsrBreakOn,
                           Option<bool?> optRngOn,
                           Option<int?> optMtSleepInterval)
    {
        _optCsrOn = optCsrOn;
        _optCsrBreakOn = optCsrBreakOn;
        _optRngOn = optRngOn;
        _optMtSleepInterval = optMtSleepInterval;
    }

    private static bool ResolveMandatoryBoolArg(Option<bool?> opt)
    {
        Console.WriteLine(opt.Description);
        return Console.ReadLine()?.ToUpper().StartsWith("Y") ?? false;
    }

    protected override CsrConfig GetBoundValue(BindingContext bindingContext)
    {
        var csr_config = new CsrConfig
        {
            CsrOn = bindingContext.ParseResult.GetValueForOption(_optCsrOn) ?? ResolveMandatoryBoolArg(_optCsrOn),
            RngOn = bindingContext.ParseResult.GetValueForOption(_optRngOn) ?? ResolveMandatoryBoolArg(_optRngOn),
            MtSleepInterval = bindingContext.ParseResult.GetValueForOption(_optMtSleepInterval) ?? 16,
        };
        csr_config.CsrBreakOn = csr_config.CsrOn && ResolveMandatoryBoolArg(_optCsrBreakOn);
        return csr_config;
    }
}

internal sealed record CsrConfig
{
    public bool CsrOn { get; init; }
    public bool CsrBreakOn { get; set; }
    public bool RngOn { get; init; }
    public int  MtSleepInterval { get; init; }
};

public class Program
{
    private static CsrConfig csrConfig;
    private static CutsceneRemover cutsceneRemover = null;
    private static RNGMod rngMod = null;

    private static Process Game = null;

    private static bool newGameMenuUpdated = false;

    private static readonly BreakTransition BreakTransition = new BreakTransition { ForceLoad = false, Description = "Break Setup", ConsoleOutput = false, Suspendable = false, Repeatable = true };

    // Cutscene Remover Version Number, 0x30 - 0x39 = 0 - 9, 0x48 = decimal point
    private const int majorID = 1;
    private const int minorID = 6;
    private const int patchID = 0;
    private static List<(string, byte)> startGameText;

    static Mutex mutex = new Mutex(true, "CSR");

    static void Main(string[] args)
    {
        if (CheckExistingCSR()) return;

        DiagnosticLog.Information($"Cutscene Remover for Final Fantasy X, version {majorID}.{minorID}.{patchID}");
        if (args.Length > 0) DiagnosticLog.Information($"!!! LAUNCHED WITH COMMAND-LINE OPTIONS: {string.Join(' ', args)} !!!");

        Option<bool?> optCsrOn           = new Option<bool?>("--csr", "Enable CSR? [Y/N]");
        Option<bool?> optCsrBreakOn      = new Option<bool?>("--csrbreak", "Enable break for CSR? [Y/N]");
        Option<bool?> optRngOn           = new Option<bool?>("--truerng", "Enable True RNG? [Y/N]");
        Option<int?>  optMtSleepInterval = new Option<int?>("--mt_sleep_interval", "Specify the main thread sleep interval. [ms]");

        RootCommand rootCmd = new RootCommand("Launches the FFX Cutscene Remover.")
        {
            optCsrOn,
            optCsrBreakOn,
            optRngOn,
            optMtSleepInterval
        };

        rootCmd.SetHandler(MainLoop, new CsrConfigBinder(optCsrOn, optCsrBreakOn, optRngOn, optMtSleepInterval));

        rootCmd.Invoke(args);
        return;
    }

    private static void MainLoop(CsrConfig config)
    {
        csrConfig = config;

        while (true)
        {
            Game = ConnectToTarget("FFX");

            if (Game == null)
            {
                continue;
            }

            startGameText = new List<(string, byte)> { };

            if (csrConfig.CsrOn)
            {
                cutsceneRemover = new CutsceneRemover(csrConfig.MtSleepInterval);
                cutsceneRemover.Game = Game;
                startGameText.Add(($"[Cutscene Remover v{majorID}.{minorID}.{patchID}]", 0x49));
            }

            if (csrConfig.CsrBreakOn)
            {
                startGameText.Add(($"[Cutscene Remover Break Enabled]", 0x00));
            }
            else
            {
                startGameText.Add(($"[Cutscene Remover Break Disabled]", 0x00));
            }

            if (csrConfig.RngOn)
            {
                rngMod = new RNGMod();
                rngMod.Game = Game;
                startGameText.Add(($"[True RNG Enabled]", 0x4b));
            }

            startGameText.Add(($"Start Game?", 0x50));

            MemoryWatchers.Initialize(Game);

            DiagnosticLog.Information("Starting main loop!");

            while (!Game.HasExited)
            {
                MemoryWatchers.Watchers.UpdateAll(Game);

                if (!newGameMenuUpdated && MemoryWatchers.RoomNumber.Current == 0 && MemoryWatchers.Storyline.Current == 0 && MemoryWatchers.Dialogue1.Current == 6)
                {
                    new NewGameTransition { ForceLoad = false, ConsoleOutput = false, startGameText = startGameText }.Execute();
                    newGameMenuUpdated = true;
                }
                if (newGameMenuUpdated && MemoryWatchers.RoomNumber.Current == 23)
                {
                    newGameMenuUpdated = false;
                }

                if (csrConfig.CsrBreakOn && MemoryWatchers.ForceLoad.Current == 0)
                {
                    if (MemoryWatchers.RoomNumber.Current == 140 && MemoryWatchers.Storyline.Current == 1300)
                    {
                        new Transition { RoomNumber = 184, SpawnPoint = 0, Description = "Break" }.Execute();
                    }
                    else if (MemoryWatchers.RoomNumber.Current == 184 && MemoryWatchers.Storyline.Current == 1300)
                    {
                        BreakTransition.Execute();
                    }
                    else if (MemoryWatchers.RoomNumber.Current == 158 && MemoryWatchers.Storyline.Current == 1300)
                    {
                        new Transition { RoomNumber = 140, Storyline = 1310, SpawnPoint = 0, Description = "End of Break + Map + Rikku afraid + tutorial" }.Execute();
                    }
                }
                else
                {
                    if (MemoryWatchers.RoomNumber.Current == 140 && MemoryWatchers.Storyline.Current == 1300)
                    {
                        new Transition { RoomNumber = 140, Storyline = 1310, SpawnPoint = 0, Description = "End of Break + Map + Rikku afraid + tutorial" }.Execute();
                    }
                }

                if (csrConfig.CsrOn)
                {
                    cutsceneRemover.MainLoop();
                }

                if (csrConfig.RngOn)
                {
                    rngMod.MainLoop();
                }

                // Sleep for a bit so we don't destroy CPUs
                Thread.Sleep(csrConfig.MtSleepInterval);
            }
        }
    }
    
    private static bool CheckExistingCSR()
    {
        bool isRunning = !mutex.WaitOne(TimeSpan.Zero, true);

        if (isRunning)
        {
            Console.WriteLine("Cutscene Remover is already running!");
            Console.ReadLine();
        }

        return isRunning;
    }

    private static Process ConnectToTarget(string TargetName)
    {
        Process Game = null;

        try
        {
            Game = Process.GetProcessesByName(TargetName).OrderByDescending(x => x.StartTime)
                     .FirstOrDefault(x => !x.HasExited);
        }
        catch (Win32Exception e)
        {
            DiagnosticLog.Information("Exception: " + e.Message);
        }

        if (Game == null || Game.HasExited)
        {
            Game = null;
            Console.Write("\rWaiting to connect to the game. Please launch the game if you haven't yet.");

            Thread.Sleep(500);
        }
        else
        {
            Console.Write("\n");
            DiagnosticLog.Information("Connected to FFX!");
        }

        return Game;
    }
}
