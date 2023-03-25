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
                Stage += 1;

            }
            else if (base.memoryWatchers.DiveTransition.Current >= (BaseCutsceneValue + 0xA208) && Stage == 1)
            {
                WriteValue<int>(base.memoryWatchers.DiveTransition, BaseCutsceneValue + 0xA493);

                Stage += 1;
            }
        }
    }
}