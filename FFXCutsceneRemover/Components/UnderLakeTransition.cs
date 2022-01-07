using System.Diagnostics;
using System.Collections.Generic;
using FFX_Cutscene_Remover.ComponentUtil;
using FFXCutsceneRemover.Logging;

namespace FFXCutsceneRemover
{
    class UnderLakeTransition : Transition
    {
        new float TidusXCoordinate = 0.0f;
        new float TidusYCoordinate = 0.0f;
        new float TidusZCoordinate = 0.0f;
        new float TidusRotation = 0.0f;

        static private List<short> CutsceneAltList = new List<short>(new short[] { 1137 });
        public override void Execute(string defaultDescription = "")
        {
            Process process = memoryWatchers.Process;

            if (base.memoryWatchers.Storyline.Current == 1600 && base.memoryWatchers.State.Current == 0 && base.memoryWatchers.NPCLastInteraction.Current == 7) //Rikku is Character 7 on this screen
            {
                process.Suspend();

                base.Execute();

                new Transition { Storyline = 1607, Description = "Rikku wants to be like Yuna" }.Execute();

                process.Resume();

            }
            if (base.memoryWatchers.Storyline.Current == 1607 && base.memoryWatchers.MovementLock.Current == 0x20 && Stage == 0)
            {
                BaseCutsceneValue = base.memoryWatchers.UnderLakeTransition.Current;
                DiagnosticLog.Information(BaseCutsceneValue.ToString("X2"));
                Stage += 1;
            }
            else if (base.memoryWatchers.State.Current == 0 && Stage == 1)
            {
                process.Suspend();

                DiagnosticLog.Information("Stage: " + Stage.ToString());

                TidusXCoordinate = base.memoryWatchers.TidusXCoordinate.Current;
                TidusYCoordinate = base.memoryWatchers.TidusYCoordinate.Current;
                TidusZCoordinate = base.memoryWatchers.TidusZCoordinate.Current;
                TidusRotation = base.memoryWatchers.TidusRotation.Current;

                new Transition { Storyline = 1610, SpawnPoint = 0, Description = "The Hymn is Yevon's gift", PositionTidusAfterLoad = true, Target_x = TidusXCoordinate, Target_y = TidusYCoordinate, Target_z = TidusZCoordinate, Target_rot = TidusRotation }.Execute();

                Stage += 1;

                process.Resume();
            }
            else if (base.memoryWatchers.State.Current == 0 && base.memoryWatchers.NPCLastInteraction.Current == 5 && Stage == 2) // Auron is character 5 on this screen
            {
                process.Suspend();

                DiagnosticLog.Information("Stage: " + Stage.ToString());

                TidusXCoordinate = base.memoryWatchers.TidusXCoordinate.Current;
                TidusYCoordinate = base.memoryWatchers.TidusYCoordinate.Current;
                TidusZCoordinate = base.memoryWatchers.TidusZCoordinate.Current;
                TidusRotation = base.memoryWatchers.TidusRotation.Current;

                new Transition { RoomNumber = 129, Storyline = 1704, SpawnPoint = 0, Description = "Bikanel Intro", FormationSwitch = Transition.formations.BikanelStart }.Execute();

                Stage += 1;

                process.Resume();
            }
        }
    }
}