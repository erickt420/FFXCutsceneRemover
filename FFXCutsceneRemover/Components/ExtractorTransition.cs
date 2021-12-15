using System.Collections.Generic;
using FFXCutsceneRemover.Logging;

namespace FFXCutsceneRemover
{
    class ExtractorTransition : Transition
    {
        static private List<short> CutsceneAltList = new List<short>(new short[] { 1137 });
        public override void Execute(string defaultDescription = "")
        {
            if (base.memoryWatchers.ExtractorTransition.Current > 0)
            {
                if (Stage == 0)
                {
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.ExtractorTransition.Current;
                    DiagnosticLog.Information(BaseCutsceneValue.ToString("X2"));
                    Stage += 1;

                }/*/
                else if (base.memoryWatchers.ExtractorTransition.Current >= (BaseCutsceneValue + 0x14E) && Stage == 1) // 
                {
                    DiagnosticLog.Information("Stage: " + Stage.ToString());

                    Transition actorPositions;

                    //Position Tidus
                    actorPositions = new Transition { ForceLoad = false, ConsoleOutput = false, TargetActorID = 1, Target_x = -20.0f, Target_y = -150.0f, Target_z = 70.0f , Target_swimming = true};
                    actorPositions.Execute();

                    //Position Wakka
                    actorPositions = new Transition { ForceLoad = false, ConsoleOutput = false, TargetActorID = 5, Target_x = 7.560521126f, Target_y = -155.0f, Target_z = 75.40319061f };
                    actorPositions.Execute();

                    WriteValue<int>(base.memoryWatchers.ExtractorTransition, BaseCutsceneValue + 0x166);// 0x198

                    Stage += 1;
                }//*/
                else if (base.memoryWatchers.ExtractorTransition.Current == (BaseCutsceneValue + 0x1E3) && base.memoryWatchers.TidusActionCount.Current == 1 && Stage == 1)
                {
                    DiagnosticLog.Information("Stage: " + Stage.ToString());
                    WriteValue<int>(base.memoryWatchers.ExtractorTransition, BaseCutsceneValue + 0x28B);// 28E
                    Stage += 1;
                }
            }
        }
    }
}