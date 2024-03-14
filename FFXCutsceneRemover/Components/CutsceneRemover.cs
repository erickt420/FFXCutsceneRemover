using System;
using System.Collections.Generic;
using System.Diagnostics;

using FFXCutsceneRemover.ComponentUtil;
using FFXCutsceneRemover.Logging;
using FFXCutsceneRemover.Resources;

/*
 * Main loops for the Cutscene Remover program.
 */
namespace FFXCutsceneRemover;

class CutsceneRemover
{
    public Process Game;
    private bool InBossFight = false;
    private bool tidusReset = false;
    private Transition PostBossFightTransition;
    // Keep track of the previously executed transition
    // so we don't execute the same transition twice
    private Transition PreviouslyExecutedTransition;
    private int LoopSleepMillis;

    public CutsceneRemover(int loopSleepMillis)
    {
        LoopSleepMillis = loopSleepMillis;
    }

    public void MainLoop()
    {
        /* This loop iterates over the list of standard transitions
         * and applies them when necessary. Most transitions can be performed here. */
        Dictionary<Func<bool>, Transition> standardTransitions = Transitions.StandardTransitions;
        
        foreach (var transition in standardTransitions)
        {
            if (transition.Key.Invoke() && MemoryWatchers.ForceLoad.Current == 0)
            {
                ExecuteTransition(transition.Value, "Executing Standard Transition - No Description");
            }
        }

        // Reset multi-stage transitions when on the main menu
        if (MemoryWatchers.RoomNumber.Current == 23)
        {
            foreach (var transition in standardTransitions)
            {
                transition.Value.Stage = 0;
            }
        }

        /* Loop for post boss fights transitions. Once we enter the fight we set the boss bit and the transition
            * to perform once we exit the AP menu. */
        Dictionary<Func<bool>, Transition> postBossBattleTransitions = Transitions.PostBossBattleTransitions;
        
        if (!InBossFight)
        {
            foreach (var transition in postBossBattleTransitions)
            {
                if (transition.Key.Invoke())
                {
                    InBossFight = true;
                    PostBossFightTransition = transition.Value;
                    DiagnosticLog.Information("Entered Boss Fight: " + transition.Value.Description);
                }
            }
        }
        else if (InBossFight && MemoryWatchers.RoomNumber.Current == 23)
        {
            DiagnosticLog.Information("Main menu detected. Exiting boss loop (This means you died or soft-reset)");
            new Transition { EncounterMapID = 0, EncounterFormationID1 = 0, EncounterFormationID2 = 0, Description = "Clear boss battle memory" }.Execute();
            InBossFight = false;
        }
        else if (MemoryWatchers.Menu.Current == 0 && MemoryWatchers.Menu.Old == 1)
        {
            ExecuteTransition(PostBossFightTransition, "Executing Post Boss Fight Transition - No Description");
            DiagnosticLog.Information("Post Boss Fight");
            InBossFight = false;
            PostBossFightTransition = null;
        }


        // Soft reset by holding L1 R1 L2 R2 + Start - Disabled in battle because game crashes
#if DEBUG
        if (MemoryWatchers.Input.Current == 2063 && MemoryWatchers.BattleState.Current != 10)
        {
            ExecuteTransition(new Transition { RoomNumber = 23, BattleState = 778, Description = "Soft reset by holding L1 R1 L2 R2 + Start", Repeatable = true });
        }
#endif
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
}
