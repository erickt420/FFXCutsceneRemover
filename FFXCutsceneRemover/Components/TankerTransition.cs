using FFX_Cutscene_Remover.ComponentUtil;
using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using FFXCutsceneRemover.Logging;

namespace FFXCutsceneRemover
{
    class TankerTransition : Transition
    {
        static private List<short> CutsceneAltList = new List<short>(new short[] { 6609 });
        public override void Execute(string defaultDescription = "")
        {
            Process process = memoryWatchers.Process;

            if (Stage == 0)
            {
                process.Suspend();

                base.Execute();

                new Transition { EncounterMapID = 86, EncounterFormationID = 0, ScriptedBattleFlag1 = 1, ScriptedBattleFlag2 = 1, EncounterTrigger = 2, Description = "Tanker", ForceLoad = false }.Execute();

                Transition actorPositions;
                actorPositions = new Transition { ForceLoad = false, ConsoleOutput = false, TargetActorIDs = new short[] { 1 }, Target_x = 251.9134674f, Target_y = 0.005895767361f, Target_z = -24.76922226f };
                actorPositions.Execute();

                actorPositions = new Transition { ForceLoad = false, ConsoleOutput = false, TargetActorIDs = new short[] { 3 }, Target_x = 251.2454987f, Target_y = 0.005895767361f, Target_z = 20.62436295f };
                actorPositions.Execute();

                BaseCutsceneValue = base.memoryWatchers.SpectralKeeperTransition.Current;

                Stage += 1;

                process.Resume();
            }
            else if (base.memoryWatchers.BattleState2.Current == 22 && Stage == 1)
            {
                Stage += 1;
            }
            else if (base.memoryWatchers.BattleState2.Current == 0 && Stage == 2)
            {
                process.Suspend();

                new Transition { RoomNumber = 367 ,Storyline = 20, Description = "Post Tanker"}.Execute();

                Stage += 1;

                process.Resume();
            }
        }
    }
}