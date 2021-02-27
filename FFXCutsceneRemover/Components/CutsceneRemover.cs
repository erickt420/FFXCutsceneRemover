using FFX_Cutscene_Remover.ComponentUtil;
using FFXCutsceneRemover.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;

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

                Console.WriteLine("Starting main loop!");
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
                            Console.WriteLine(watcher.Name + ": " + watcher.Current);
                        }
                        Console.Write("InBossFight: " + InBossFight);
                    }

                    /* This loop iterates over the list of standard transitions
                     * and applies them when necessary. Most transitions can be performed here.*/
                    Dictionary<IGameState, Transition> standardTransitions = Transitions.StandardTransitions;
                    foreach (var transition in standardTransitions)
                    {
                        if (transition.Key.CheckState() && MemoryWatchers.ForceLoad.Current == 0)
                        {
                            Game.Suspend();
                            transition.Value.Execute();
                            string output = string.IsNullOrEmpty(transition.Value.Description) ? "Executing Standard Transition - No Description" : transition.Value.Description;
                            Console.WriteLine(output);
                            Game.Resume();
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
                                Console.WriteLine("Entered Boss Fight: " + transition.Value.Description);
                            }
                        }
                    }
                    else if (new GameState { Menu = 0 }.CheckState() && new PreviousGameState { Menu = 1 }.CheckState())
                    {
                        Game.Suspend();
                        PostBossFightTransition.Execute();
                        InBossFight = false;
                        PostBossFightTransition = null;
                        Console.WriteLine("Executing Post Boss Fight Transition");
                        Game.Resume();
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
                     */
                    // Soft reset by holding L1 R1 L2 R2 + Start - Disabled in battle because game crashes
                    if (new GameState { Input = 2063 }.CheckState() && MemoryWatchers.BattleState.Current != 10)
                    {
                        Game.Suspend();
                        new Transition { RoomNumber = 23, BattleState = 778, Description = "Soft reset by holding L1 R1 L2 R2 + Start" }.Execute();
                        Game.Resume();
                    }
                    
                    // Custom Check #1 - Sandragoras
                    if (new GameState { RoomNumber = 138, Storyline = 1720, State = 1}.CheckState() && MemoryWatchers.Sandragoras.Current >= 4)
                    {
                        Game.Suspend();
                        new Transition { RoomNumber = 130, Storyline = 1800, SpawnPoint = 0 }.Execute();
                        Console.WriteLine("Sanubia to Home (Custom skip)");
                        Game.Resume();
                    }
                    
                    // Custom Check #2 - Airship
                    if (new GameState { RoomNumber = 194, Storyline = 2000, State = 0}.CheckState() && MemoryWatchers.XCoordinate.Current > 300f)
                    {
                        Game.Suspend();
                        new Transition { RoomNumber = 194, Storyline = 2020, SpawnPoint = 1 }.Execute();
                        Console.WriteLine("Zoom in on Bevelle (Custom skip)");
                        Game.Resume();
                    }
                    
                    // Custom Check #3 - Pre-Gagazet
                    if (new GameState { RoomNumber = 279, Storyline = 2420, MovementLock = 48}.CheckState() && MemoryWatchers.XCoordinate.Current > 250f)
                    {
                        Game.Suspend();
                        new Transition { RoomNumber = 259, Storyline = 2510, SpawnPoint = 0 }.Execute();
                        Console.WriteLine("Yuna looks at Defender X's corpse (Custom skip)");
                        // Bug: If you enter sunken cave and return to this screen, you will skip to Gagazet (issue with using coords - need to find another method)
                        Game.Resume();
                    }

                    // Sleep for a bit so we don't destroy CPUs
                    Thread.Sleep(LoopSleepMillis);
                }
            }
        }

        private void ConnectToTarget()
        {
            Console.WriteLine("Connecting to FFX...");
            try
            {
                Game = Process.GetProcessesByName(TARGET_NAME).OrderByDescending(x => x.StartTime)
                         .FirstOrDefault(x => !x.HasExited);
            }
            catch (Win32Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

            if (Game == null || Game.HasExited)
            {
                Game = null;
                Console.WriteLine("FFX not found! Waiting for 10 seconds.");

                Thread.Sleep(10 * 1000);
            }
            else
            {
                Console.WriteLine("Connected to FFX!");
            }
        }
    }
}
