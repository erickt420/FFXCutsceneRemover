using System.Collections.Generic;
using FFXCutsceneRemover.Logging;

namespace FFXCutsceneRemover
{
    class KilikaTrialsTransition : Transition
    {
        static private List<short> CutsceneAltList = new List<short>(new short[] { 1137 });
        public override void Execute(string defaultDescription = "")
        {
            if (base.memoryWatchers.KilikaTrialsTransition.Current > 0)
            {
                if (Stage == 0)
                {
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.KilikaTrialsTransition.Current;
                    DiagnosticLog.Information(BaseCutsceneValue.ToString("X2"));
                    Stage += 1;

                }
                else if (base.memoryWatchers.KilikaTrialsTransition.Current == (BaseCutsceneValue + 0x61) && Stage == 1) // 486
                {
                    DiagnosticLog.Information("Stage: " + Stage.ToString());
                    WriteValue<int>(base.memoryWatchers.KilikaTrialsTransition, BaseCutsceneValue + 0x108);

                    Stage += 1;
                }
            }
        }
    }
}