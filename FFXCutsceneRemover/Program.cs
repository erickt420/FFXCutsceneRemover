using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Collections.Generic;
using FFXCutsceneRemover.Logging;

namespace FFXCutsceneRemover
{
    class Program
    {
        private static bool debug = false;
        private static int loopSleepMillis = 16;

        private static CutsceneRemover cutsceneRemover = null;
        private static RNGMod rngMod = null;

        private static readonly MemoryWatchers MemoryWatchers = MemoryWatchers.Instance;

        private static Process Game = null;

        private static bool removeCutscenes = false;
        private static bool fixRNG = false;
        private static bool newGameMenuUpdated = false;

        // Cutscene Remover Version Number, 0x30 - 0x39 = 0 - 9, 0x48 = decimal point
        private const int majorID = 1;
        private const int minorID = 4;
        private const int patchID = 0;
        private static List<(string, byte)> startGameText;

        static void Main(string[] args)
        {
            DiagnosticLog.Information($"FFX Cutscene Remover Version {majorID}.{minorID}.{patchID}");

            switch(args.Length)
            {
                case 1:
                    if (!bool.TryParse(args[0], out debug))
                    {
                        int.TryParse(args[0], out loopSleepMillis);
                    }
                    break;
                case 2:
                    bool.TryParse(args[0], out debug);
                    int.TryParse(args[1], out loopSleepMillis);
                    break;
            }

            DiagnosticLog.ExtraAnnotations = debug;

            DiagnosticLog.Information("Turn on cutscene removal Y/N?");
            removeCutscenes = Console.ReadLine().ToUpper() == "Y";
            DiagnosticLog.Information($"Remove Cutscenes set to {removeCutscenes}");

            DiagnosticLog.Information("Turn on rngFix Y/N?");
            fixRNG = Console.ReadLine().ToUpper() == "Y";
            DiagnosticLog.Information($"RNG fix set to {fixRNG}");

            while (true)
            {
                Game = ConnectToTarget("FFX");

                if (Game == null)
                {
                    continue;
                }

                startGameText = new List<(string, byte)> { };

                if (removeCutscenes)
                {
                    cutsceneRemover = new CutsceneRemover(debug, loopSleepMillis);
                    cutsceneRemover.Game = Game;
                    startGameText.Add(($"[Cutscene Remover v{majorID}.{minorID}.{patchID}]", 0x41));
                }

                if (fixRNG)
                {
                    rngMod = new RNGMod();
                    rngMod.Game = Game;
                    startGameText.Add(($"[rngFix Mod Applied]", 0x45));
                }

                startGameText.Add(($"Start Game?", 0x49));

                MemoryWatchers.Initialize(Game);

                DiagnosticLog.Information("Starting main loop!");
                while (!Game.HasExited)
                {
                    MemoryWatchers.Watchers.UpdateAll(Game);

                    if (!newGameMenuUpdated && new GameState { RoomNumber = 0, Storyline = 0, Dialogue1 = 6 }.CheckState())
                    {
                        new NewGameTransition { ForceLoad = false, ConsoleOutput = false, startGameText = startGameText }.Execute();
                        newGameMenuUpdated = true;
                    }
                    if (newGameMenuUpdated && new GameState { RoomNumber = 23 }.CheckState())
                    {
                        newGameMenuUpdated = false;
                    }

                    if (removeCutscenes)
                    {
                        cutsceneRemover.MainLoop(MemoryWatchers);
                    }

                    if (fixRNG)
                    {
                        rngMod.MainLoop(MemoryWatchers);
                    }

                    // Sleep for a bit so we don't destroy CPUs
                    Thread.Sleep(loopSleepMillis);
                }
            }
        }

        private static Process ConnectToTarget(string TargetName)
        {
            Process Game = null;

            DiagnosticLog.Information("Connecting to FFX...");
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
                DiagnosticLog.Information("FFX not found! Please launch the game. Waiting for 10 seconds before checking again.");

                Thread.Sleep(10 * 1000);
            }
            else
            {
                DiagnosticLog.Information("Connected to FFX!");
            }

            return Game;

        }
    }
}
