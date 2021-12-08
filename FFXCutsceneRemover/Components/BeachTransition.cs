using System.Collections.Generic;
using FFXCutsceneRemover.Logging;

namespace FFXCutsceneRemover
{
    class BeachTransition : Transition
    {
        static private List<short> CutsceneAltList = new List<short>(new short[] { 1263 });
        public override void Execute(string defaultDescription = "")
        {
            if (base.memoryWatchers.BeachTransition.Current > 0)
            {
                if (CutsceneAltList.Contains(base.memoryWatchers.CutsceneAlt.Current) && Stage == 0)
                {
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.BeachTransition.Current;
                    DiagnosticLog.Information(BaseCutsceneValue.ToString("X2"));
                    Stage += 1;

                }
                else if (base.memoryWatchers.BeachTransition.Current >= (BaseCutsceneValue + 0x1CA) && Stage == 1) // 486
                {
                    DiagnosticLog.Information("Stage: " + Stage.ToString());
                    WriteValue<int>(base.memoryWatchers.BeachTransition, BaseCutsceneValue + 0x4C4);// 1B44

                    Stage += 1;
                }
                else if (base.memoryWatchers.BeachTransition.Current >= (BaseCutsceneValue + 0x510) && Stage == 2) // 486
                {
                    DiagnosticLog.Information("Stage: " + Stage.ToString());
                    WriteValue<int>(base.memoryWatchers.BeachTransition, BaseCutsceneValue + 0x6BE);// 1B44

                    Stage += 1;
                }
                if (base.memoryWatchers.CutsceneAlt.Current != base.memoryWatchers.CutsceneAlt.Old || base.memoryWatchers.BeachTransition.Current != base.memoryWatchers.BeachTransition.Old)
                {
                    DiagnosticLog.Information(base.memoryWatchers.CutsceneAlt.Current.ToString() + " / " + base.memoryWatchers.BeachTransition.Current.ToString("X2"));
                }
            }
        }
    }
}