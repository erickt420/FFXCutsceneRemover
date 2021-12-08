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

                }
                else if (base.memoryWatchers.ExtractorTransition.Current >= (BaseCutsceneValue + 0x125) && Stage == 1) // 
                {
                    DiagnosticLog.Information("Stage: " + Stage.ToString());
                    WriteValue<int>(base.memoryWatchers.ExtractorTransition, BaseCutsceneValue + 0x198);// 

                    Stage += 1;
                }
                else if (base.memoryWatchers.ExtractorTransition.Current == (BaseCutsceneValue + 0x1E3) && base.memoryWatchers.HpEnemyA.Current < 4000 && base.memoryWatchers.HpEnemyA.Old == 4000 && Stage == 2) // 1200 is HP of Guado
                {
                    DiagnosticLog.Information("Stage: " + Stage.ToString());
                    WriteValue<int>(base.memoryWatchers.ExtractorTransition, BaseCutsceneValue + 0x28B);// 28E
                    Stage += 1;
                }
            }
        }
    }
}