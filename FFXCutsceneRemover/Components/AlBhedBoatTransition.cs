using FFXCutsceneRemover.ComponentUtil;
using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using FFXCutsceneRemover.Logging;

namespace FFXCutsceneRemover
{
    class AlBhedBoatTransition : Transition
    {
        static private List<short> CutsceneAltList = new List<short>(new short[] { 1281 });
        public override void Execute(string defaultDescription = "")
        {
            if (base.memoryWatchers.AlBhedBoatTransition.Current > 0)
            {
                if (CutsceneAltList.Contains(base.memoryWatchers.CutsceneAlt.Current) && Stage == 0)
                {
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.EventFileStart.Current;

                    Stage += 1;

                }
                else if (base.memoryWatchers.AlBhedBoatTransition.Current == (BaseCutsceneValue + 0xEF32) && Stage == 1)
                {
                    WriteValue<int>(base.memoryWatchers.AlBhedBoatTransition, BaseCutsceneValue + 0xF127);
                    Stage += 1;
                }
            }
        }
    }
}