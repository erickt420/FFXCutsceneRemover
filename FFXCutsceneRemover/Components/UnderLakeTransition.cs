using System.Collections.Generic;
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
            if (base.memoryWatchers.UnderLakeTransition.Current > 0)
            {
                if (base.memoryWatchers.Storyline.Current == 1600 && base.memoryWatchers.State.Current == 0 && base.memoryWatchers.NPCLastInteraction.Current == 7) //Rikku is Character 7 on this screen
                {
                    Storyline = 1607;
                    Description = "Rikku wants to be like Yuna";
                    ForceLoad = true;
                    base.Execute();

                }
                if (base.memoryWatchers.Storyline.Current == 1607 && base.memoryWatchers.MovementLock.Current == 0x20 && Stage == 0)
                {
                    Storyline = null;
                    Description = "";
                    ConsoleOutput = false;
                    ForceLoad = false;
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.UnderLakeTransition.Current;
                    DiagnosticLog.Information(BaseCutsceneValue.ToString("X2"));
                    Stage += 1;

                }
                else if (base.memoryWatchers.State.Current == 0 && Stage == 1)
                {
                    DiagnosticLog.Information("Stage: " + Stage.ToString());

                    TidusXCoordinate = base.memoryWatchers.TidusXCoordinate.Current;
                    TidusYCoordinate = base.memoryWatchers.TidusYCoordinate.Current;
                    TidusZCoordinate = base.memoryWatchers.TidusZCoordinate.Current;
                    TidusRotation = base.memoryWatchers.TidusRotation.Current;

                    Storyline = 1610;
                    SpawnPoint = 0;
                    Description = "The Hymn is Yevon's gift";
                    ForceLoad = true;
                    base.Execute();

                    Stage += 1;
                }
                else if (Stage == 2)
                {
                    DiagnosticLog.Information("Stage: " + Stage.ToString());

                    WriteValue<float>(base.memoryWatchers.TidusXCoordinate, TidusXCoordinate);
                    WriteValue<float>(base.memoryWatchers.TidusYCoordinate, TidusYCoordinate);
                    WriteValue<float>(base.memoryWatchers.TidusZCoordinate, TidusZCoordinate);
                    WriteValue<float>(base.memoryWatchers.TidusRotation, TidusRotation);

                    Stage += 1;
                }
                else if (base.memoryWatchers.State.Current == 0 && base.memoryWatchers.NPCLastInteraction.Current == 5 && Stage == 3) // Auron is character 5 on this screen
                {
                    DiagnosticLog.Information("Stage: " + Stage.ToString());

                    ForceLoad = true;
                    RoomNumber = 129;
                    Storyline = 1704;
                    SpawnPoint = 0;
                    Description = "Bikanel Intro";
                    FormationSwitch = formations.BikanelStart;

                    base.Execute();

                    Stage += 1;
                }
            }
        }
    }
}