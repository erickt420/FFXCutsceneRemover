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
        private Transition VersionInfo = new Transition { ForceLoad = false, Description = "New Game - Version Information"};
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
                    {;
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
                    // Custom Check #1 - New Game Version Info
                    if (new GameState { RoomNumber = 0, Storyline = 0, CutsceneAlt = 18, Dialogue1 = 6 }.CheckState())
                    {
                        byte language = MemoryWatchers.Language.Current;
                        byte[] NewGameBytes = System.IO.File.ReadLines("./NewGameDialogue.txt").ElementAtOrDefault(language).Split(" ").Select(s => Byte.Parse(s, NumberStyles.HexNumber)).ToArray();
                        VersionInfo.DialogueFile = NewGameBytes;
                        ExecuteTransition(VersionInfo);
                    }

                    // Custom Check #2 - Airship
                    if (new GameState { RoomNumber = 194, Storyline = 2000, State = 0}.CheckState() && MemoryWatchers.XCoordinate.Current > 300f)
                    {
                        ExecuteTransition(new Transition {RoomNumber = 194, Storyline = 2020, SpawnPoint = 1, PositionTidusAfterLoad = true, Target_x = -242.6673126f, Target_y = 12.51491833f, Target_z = 398.0950317f, Target_rot = -1.659699082f, Target_var1 = 1463, Description = "Zoom in on Bevelle"});
                    }

                    // Custom Check #3 - Djose
                    if (new GameState { RoomNumber = 161, Storyline = 1010, MovementLock = 48}.CheckState() && MemoryWatchers.YCoordinate.Current > 10.0f)
                    {
                        ExecuteTransition(new Transition { RoomNumber = 82, Storyline = 1015, SpawnPoint = 2, Description = "Tidus wakes Yuna up"});
                    }

                    // Custom Check #4 - Buff Brotherhood in Farplane and skip scenes
                    if (new GameState { RoomNumber = 193, Storyline = 1154 }.CheckState())
                    {
                        Game.Suspend();
                        IntPtr EquipMenu = new IntPtr(MemoryWatchers.GetBaseAddress() + 0xD30F2C); // Address of beginning of Equipment menu
                        bool foundBrotherhood = false;
                        var brotherhood = new byte[2] { 0x1, 0x50 }; // Brotherhood name identifier in hex

                        while (!foundBrotherhood)
                        {
                            // Check first two bytes for name identifier and compare against Brotherhood
                            var equipment = Game.ReadBytes(EquipMenu, 2);

                            if (equipment.SequenceEqual<byte>(brotherhood))
                            {
                                // Not sure what this value is, but it does change during the scene, so adding just in case!
                                IntPtr aNumber = IntPtr.Add(EquipMenu, 3);
                                Game.WriteBytes(aNumber, new byte[1] { 0x9 });

                                // Second slot for Brotherhood, +10% Strength
                                IntPtr slot2 = IntPtr.Add(EquipMenu, 16);
                                Game.WriteBytes(slot2, new byte[2] { 0x64, 0x80 });

                                // Third slot for Brotherhood, Waterstrike
                                IntPtr slot3 = IntPtr.Add(EquipMenu, 18);
                                Game.WriteBytes(slot3, new byte[2] { 0x2A, 0x80 });

                                // Fourth slot for Brotherhood, Sensor
                                IntPtr slot4 = IntPtr.Add(EquipMenu, 20);
                                Game.WriteBytes(slot4, new byte[2] { 0x00, 0x80 });

                                // Finally skip the Farplane scenes
                                new Transition { RoomNumber = 134, Storyline = 1170, TidusWeaponDamageBoost = 15, Description = "Farplane scenes + Brotherhood buff" }.Execute();
                                foundBrotherhood = true;
                                Game.Resume();
                                break;
                            }
                            else
                            {
                                // Number of bytes for each piece of equipment is 22, so if not found, go to the next piece of equipment
                                EquipMenu = IntPtr.Add(EquipMenu, 22);
                            }
                        }
                    }
                    
                    // Custom Check #5 - Baaj Menu patch
                    // This check disables the menu for the two screens before Geosgaeno. Opening the menu here hardlocks the game
                    if (new GameState {RoomNumber = 48, MenuLock = 152}.CheckState() ||
                        new GameState {RoomNumber = 49, MenuLock = 152}.CheckState())
                    {
                        Game.WriteValue(MemoryWatchers.MenuLock.Address, 136);
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

            if (transition != PreviouslyExecutedTransition)
            {
                if (transition.Suspendable)
                {
                    Game.Suspend();
                    suspended = true;
                    DiagnosticLog.Information("Game Suspended");
                }

                transition.Execute(defaultDescription);

                if (!transition.Repeatable)
                {
                    PreviouslyExecutedTransition = transition;
                }

                if (suspended)
                {
                    Game.Resume();
                    DiagnosticLog.Information("Game Resumed");
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
                DiagnosticLog.Information("FFX not found! Waiting for 10 seconds.");

                Thread.Sleep(10 * 1000);
            }
            else
            {
                DiagnosticLog.Information("Connected to FFX!");
            }
        }
    }
}
