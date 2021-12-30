using System.Collections.Generic;
using FFXCutsceneRemover.Logging;

namespace FFXCutsceneRemover
{
    class DiveTransition : Transition
    {
        static private List<short> CutsceneAltList = new List<short>(new short[] { 1137 });
        public override void Execute(string defaultDescription = "")
        {
            if (Stage == 0)
            {
                base.Execute();

                BaseCutsceneValue = base.memoryWatchers.EventFileStart.Current;
                DiagnosticLog.Information(BaseCutsceneValue.ToString("X2"));
                Stage += 1;

            }
            else if (base.memoryWatchers.DiveTransition.Current >= (BaseCutsceneValue + 0xA073) && Stage == 1)
            {
                DiagnosticLog.Information("Stage: " + Stage.ToString());
                WriteValue<int>(base.memoryWatchers.DiveTransition, BaseCutsceneValue + 0xA4E8);

                Stage += 1;
            }
        }
    }
}