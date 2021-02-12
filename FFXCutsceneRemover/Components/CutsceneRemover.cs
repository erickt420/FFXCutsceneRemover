using FFX_Cutscene_Remover.ComponentUtil;
using FFXCutsceneRemover.Resources;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace FFXCutsceneRemover
{
    class CutsceneRemover
    {
        private static readonly string TARGET_NAME = "FFX";

        private readonly MemoryWatchers MemoryWatchers = MemoryWatchers.Instance;

        private Process Game;

        private bool InBossFight = false;

        public void ConnectToTarget()
        {
            Console.WriteLine("Connecting to FFX...");
            Game = Process.GetProcessesByName(TARGET_NAME).OrderByDescending(x => x.StartTime)
                     .FirstOrDefault(x => !x.HasExited);

            if (Game == null || Game.HasExited)
            {
                Console.WriteLine("FFX not found! Waiting for 10 seconds.");

                Thread.Sleep(10 * 1000);
            }
            else
            {
                Console.WriteLine("Connected to FFX!");
            }
        }

        public void Initialize()
        {
            if (Game == null || Game.HasExited)
            {
                ConnectToTarget();
                if (Game == null)
                {
                    return;
                }
            }
        }

        public void MainLoop()
        {
            while (true)
            {
                Initialize();

                if (Game == null)
                {
                    continue;
                }

                MemoryWatchers.Initialize(Game);

                Console.WriteLine("Starting main loop!");
                while (!Game.HasExited)
                {
                    MemoryWatchers.Watchers.UpdateAll(Game);
                    MemoryWatcherList watchers = MemoryWatchers.Watchers;

                    // Report the current status of all of our watched memory. For debug purposes
                    foreach (MemoryWatcher watcher in watchers)
                    {
                        Console.WriteLine(watcher.Name + ": " + watcher.Current);
                    }

                    /* This loop iterates over the list of standard transitions
                     * and applies them when necessary. Most transitions can be performed here.*/
                    Dictionary<GameState, Transition> standardTransitions = Transitions.StandardTransitions;
                    foreach (var transition in standardTransitions)
                    {
                        if (transition.Key.CheckState())
                        {
                            transition.Value.Execute();
                            Console.WriteLine("Executing Standard Transition");
                        }
                    }

                    Dictionary<GameState, Transition> postBossBattleTransitions = Transitions.PostBossBattleTransitions;
                    foreach (var transition in postBossBattleTransitions)
                    {
                        if (transition.Key.CheckState())
                        {
                            InBossFight = true;
                            Console.WriteLine("Entered Boss Fight");
                        }

                        if (InBossFight && new GameState { Menu = 0 }.CheckState() && MemoryWatchers.Menu.Old == 1)
                        {
                            transition.Value.Execute();
                            InBossFight = false;
                            Console.WriteLine("Executing Post Boss Fight Transition");
                        }
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
                        new Transition { RoomNumber = 23, BattleState = 778 }.Execute();
                    }
                }
            }
        }
    }
}
