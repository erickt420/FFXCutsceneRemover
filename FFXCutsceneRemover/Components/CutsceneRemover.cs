using FFX_Cutscene_Remover.ComponentUtil;
using FFXCutsceneRemover.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading;
using FFXCutsceneRemover.Logging;

/*
 * Main loops for the Cutscene Remover program.
 */
namespace FFXCutsceneRemover
{
    class CutsceneRemover
    {
        private static readonly string TARGET_NAME = "FFX";

        // Print out the name and value of every memory
        // address each iteration of the main loop
        private readonly bool PrintDebugValues = true;

        private readonly MemoryWatchers MemoryWatchers = MemoryWatchers.Instance;

        private Process Game;
        private bool InBossFight = false;
        private Transition PostBossFightTransition;
        // Keep track of the previously executed transition
        // so we don't execute the same transition twice
        private Transition PreviouslyExecutedTransition;
        private int LoopSleepMillis;

        public CutsceneRemover(bool debug, int loopSleepMillis)
        {
            PrintDebugValues = debug;
            LoopSleepMillis = loopSleepMillis;
        }

        public void MainLoop()
        {
            while (true)
            {
                ConnectToTarget();

                if (Game == null)
                {
                    continue;
                }

                MemoryWatchers.Initialize(Game);

                DiagnosticLog.Information("Starting main loop!");
                while (!Game.HasExited)
                {
                    // Update the values of our memory watchers.
                    // This is really important.
                    MemoryWatchers.Watchers.UpdateAll(Game);

                    if (PrintDebugValues)
                    {
                        MemoryWatcherList watchers = MemoryWatchers.Watchers;

                        // Report the current status of all of our watched memory. For debug purposes
                        foreach (MemoryWatcher watcher in watchers)
                        {
                            DiagnosticLog.Information(watcher.Name + ": " + watcher.Current);
                        }
                        DiagnosticLog.Information("InBossFight: " + InBossFight);
                    }

                    /* This loop iterates over the list of standard transitions
                     * and applies them when necessary. Most transitions can be performed here.*/
                    Dictionary<IGameState, Transition> standardTransitions = Transitions.StandardTransitions;
                    foreach (var transition in standardTransitions)
                    {
                        if (transition.Key.CheckState() && MemoryWatchers.ForceLoad.Current == 0)
                        {
                            ExecuteTransition(transition.Value, "Executing Standard Transition - No Description");
                        }
                    }

                    if (new GameState { RoomNumber = 23 }.CheckState())
                    {
                        foreach (var transition in standardTransitions)
                        {
                            transition.Value.Stage = 0;
                        }
                    }

                    /* Loop for post boss fights transitions. Once we enter the fight we set the boss bit and the transition
                     * to perform once we exit the AP menu. */
                    Dictionary<IGameState, Transition> postBossBattleTransitions = Transitions.PostBossBattleTransitions;
                    if (!InBossFight)
                    {
                        foreach (var transition in postBossBattleTransitions)
                        {
                            if (transition.Key.CheckState())
                            {
                                InBossFight = true;
                                PostBossFightTransition = transition.Value;
                                DiagnosticLog.Information("Entered Boss Fight: " + transition.Value.Description);
                            }
                        }
                    }
                    else if (InBossFight && new GameState {RoomNumber = 23}.CheckState())
                    {
                        DiagnosticLog.Information("Main menu detected. Exiting boss loop (This means you died or soft-reset)");
                        InBossFight = false;
                    }
                    else if (new GameState { Menu = 0 }.CheckState() && new PreviousGameState { Menu = 1 }.CheckState())
                    {
                        ExecuteTransition(PostBossFightTransition, "Executing Post Boss Fight Transition - No Description");
                        InBossFight = false;
                        PostBossFightTransition = null;
                    }

                    // SPECIAL CHECKS
                    /*
                     * A GameState object is created in order to verify the current state of the game
                     * based on the inputs provided. Inputs not provided will be ignored.
                     * Once the CheckState() returns true, indicating the game is in the state we want,
                     * then a Transition object is created with inputs required to execute the transition.
                     * The Execute() method causes the transition to write the updated values to memory.
                     *
                     * IF YOU ONLY NEED TO CHECK IF ADDRESSES ARE CERTAIN VALUES (ALMOST ALL CASES), THEN ADD YOUR
                     * TRANSITION INTO THE 'Resources\Transitions.cs' FILE.
                     *
                     * Rarely there are conditions where the check we want is not equality. In that case you can write your
                     * own condition. An example is below.
                     * 
                     * Make sure to call ExecuteTransition() instead of calling the Transition.Execute() method directly.
                     */
                    // Soft reset by holding L1 R1 L2 R2 + Start - Disabled in battle because game crashes
#if DEBUG
                    if (new GameState { Input = 2063 }.CheckState() && MemoryWatchers.BattleState.Current != 10)
                    {
                        ExecuteTransition(new Transition { RoomNumber = 23, BattleState = 778, Description = "Soft reset by holding L1 R1 L2 R2 + Start", Repeatable = true });
                    }
#endif

                    // Custom Check - Airship
                    if (new GameState { RoomNumber = 194, Storyline = 2000, State = 0}.CheckState() && MemoryWatchers.XCoordinate.Current > 300f)
                    {
                        ExecuteTransition(new Transition {RoomNumber = 194, Storyline = 2020, SpawnPoint = 1, PositionTidusAfterLoad = true, Target_x = -242.6673126f, Target_y = 12.51491833f, Target_z = 398.0950317f, Target_rot = -1.659699082f, Target_var1 = 1463, Description = "Zoom in on Bevelle"});
                    }

                    // Custom Check - Djose
                    if (new GameState { RoomNumber = 161, Storyline = 1010, MovementLock = 48}.CheckState() && MemoryWatchers.YCoordinate.Current > 10.0f)
                    {
                        ExecuteTransition(new Transition { RoomNumber = 82, Storyline = 1015, SpawnPoint = 2, Description = "Tidus wakes Yuna up"});
                    }

                    // Custom Check - Zanarkand 
                    if (new GameState { RoomNumber = 368, Storyline = 3, FangirlsOrKidsSkip = 3 }.CheckState())
                    {
                        if (MemoryWatchers.TidusXCoordinate.Current < 5.0f && MemoryWatchers.TidusZCoordinate.Current < 8.0f && MemoryWatchers.TidusZCoordinate.Current > -8.0f)
                        {
                            ExecuteTransition(new Transition { RoomNumber = 376, Storyline = 4, SpawnPoint = 0, Description = "Tidus leaves fans" });
                        }
                    }

                    // Sleep for a bit so we don't destroy CPUs
                    Thread.Sleep(LoopSleepMillis);
                }
            }
        }

        // Save the previous transition so that we don't execute the same transition multiple times in a row.
        private void ExecuteTransition(Transition transition, string defaultDescription = "")
        {
            bool suspended = false;

            if (transition != PreviouslyExecutedTransition || transition.Repeatable)
            {
                if (transition.Suspendable)
                {
                    Game.Suspend();
                    suspended = true;
                }

                transition.Execute(defaultDescription);

                PreviouslyExecutedTransition = transition;

                if (suspended)
                {
                    Game.Resume();
                }
            }
        }

        private void ConnectToTarget()
        {
            DiagnosticLog.Information("Connecting to FFX...");
            try
            {
                Game = Process.GetProcessesByName(TARGET_NAME).OrderByDescending(x => x.StartTime)
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
        }
    }
}
