using System.Collections.Generic;

using FFXCutsceneRemover.Logging;

namespace FFXCutsceneRemover
{
    class BlitzballTransition2 : Transition
    {
        public override void Execute(string defaultDescription = "")
        {
            int baseAddress = base.memoryWatchers.GetBaseAddress();

            List<short> CutsceneAltList = new List<short>(new short[] { 347, 2235 });

            if (base.memoryWatchers.BlitzballTransition.Current > 0)
            {
                if (CutsceneAltList.Contains(base.memoryWatchers.CutsceneAlt.Current) && Stage == 0)
                {
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.BlitzballTransition.Current;
                    DiagnosticLog.Information(BaseCutsceneValue.ToString("X2"));
                    Stage = 1;

                }
                else if (base.memoryWatchers.BlitzballTransition.Current == (BaseCutsceneValue + 0x2EA1) && Stage == 1)
                {
                    DiagnosticLog.Information("Stage: " + Stage.ToString());
                    WriteValue<int>(base.memoryWatchers.BlitzballTransition, BaseCutsceneValue + 0x301C);
                    Stage = 2;
                }
            }
        }
    }
}