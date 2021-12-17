using System.Collections.Generic;
using FFXCutsceneRemover.Logging;

namespace FFXCutsceneRemover
{
    class GeosTransition : Transition
    {
        static private List<short> CutsceneAltList = new List<short>(new short[] { 1137 });
        public override void Execute(string defaultDescription = "")
        {
            if (base.memoryWatchers.GeosTransition.Current > 0)
            {
                if (Stage == 0)
                {
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.GeosTransition.Current;
                    DiagnosticLog.Information(BaseCutsceneValue.ToString("X2"));
                    Stage += 1;

                }
                else if (base.memoryWatchers.GeosTransition.Current == (BaseCutsceneValue + 0x486) && Stage == 1) // 486
                {
                    DiagnosticLog.Information("Stage: " + Stage.ToString());
                    WriteValue<int>(base.memoryWatchers.GeosTransition, BaseCutsceneValue + 0x920);// 920

                    Transition actorPositions;
                    //Position Tidus
                    actorPositions = new Transition { ForceLoad = false, ConsoleOutput = false, TargetActorIDs = new short[] { 1 }, Target_x = 0.0f, Target_y = -50.0f, Target_z = -20.0f };
                    actorPositions.Execute();

                    Stage += 1;
                }
                else if (base.memoryWatchers.GeosTransition.Current == (BaseCutsceneValue + 0x941) && base.memoryWatchers.TidusActionCount.Current == 1 && Stage == 2)
                {
                    DiagnosticLog.Information("Stage: " + Stage.ToString());
                    WriteValue<int>(base.memoryWatchers.GeosTransition, BaseCutsceneValue + 0xD90);// D90
                    Stage += 1;
                }
            }
        }
    }
}