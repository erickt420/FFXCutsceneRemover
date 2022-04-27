using FFX_Cutscene_Remover.ComponentUtil;
using System.Diagnostics;
using System.Collections.Generic;
using FFXCutsceneRemover.Logging;

namespace FFXCutsceneRemover
{
    class GeosTransition : Transition
    {
        static private List<short> CutsceneAltList = new List<short>(new short[] { 1137 });
        public override void Execute(string defaultDescription = "")
        {
            Process process = memoryWatchers.Process;

            if (Stage == 0)
            {
                base.Execute();

                BaseCutsceneValue = base.memoryWatchers.EventFileStart.Current;
                Stage += 1;

            }
            else if (base.memoryWatchers.GeosTransition.Current == (BaseCutsceneValue + 0xA4F8) && Stage == 1)
            {
                process.Suspend();

                new Transition { EncounterMapID = 1, EncounterFormationID = 0, ScriptedBattleFlag1 = 1, ScriptedBattleFlag2 = 1, EncounterTrigger = 2, Description = "Sahagins", ForceLoad = false }.Execute();

                Transition actorPositions;
                //Position Tidus
                actorPositions = new Transition { ForceLoad = false, ConsoleOutput = false, TargetActorIDs = new short[] { 1 }, Target_x = 0.0f, Target_y = -50.0f, Target_z = -20.0f };
                actorPositions.Execute();

                Stage += 1;

                process.Resume();
            }
            else if (base.memoryWatchers.BattleState2.Current == 22 && Stage == 2)
            {
                Stage += 1;
            }
            else if (base.memoryWatchers.BattleState2.Current == 0 && Stage == 3)
            {
                process.Suspend();

                new Transition { EncounterMapID = 1, EncounterFormationID = 1, ScriptedBattleFlag1 = 1, ScriptedBattleFlag2 = 1, EncounterTrigger = 2, Description = "Geosgaeno", ForceLoad = false }.Execute();

                Stage += 1;

                process.Resume();
            }
            else if (base.memoryWatchers.BattleState2.Current == 22 && Stage == 4)
            {
                Transition actorPositions;
                //Position Tidus
                actorPositions = new Transition { ForceLoad = false, ConsoleOutput = false, TargetActorIDs = new short[] { 1 }, Target_x = 0.0f, Target_y = -50.0f, Target_z = -20.0f };
                actorPositions.Execute();

                Stage += 1;
            }
            else if (base.memoryWatchers.BattleState2.Current == 0 && Stage == 5)
            {
                process.Suspend();

                new Transition { RoomNumber = 50, Storyline = 48, SpawnPoint = 0, Description = "Escape from Geogaesno" }.Execute();

                Stage += 1;

                process.Resume();
            }
        }
    }
}