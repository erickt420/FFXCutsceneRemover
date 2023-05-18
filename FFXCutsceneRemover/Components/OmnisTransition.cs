using FFXCutsceneRemover.ComponentUtil;
using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using FFXCutsceneRemover.Logging;

namespace FFXCutsceneRemover
{
    class OmnisTransition : Transition
    {
        static private List<short> CutsceneAltList = new List<short>(new short[] { 5331 });
        public override void Execute(string defaultDescription = "")
        {
            int baseAddress = base.memoryWatchers.GetBaseAddress();
            if (base.memoryWatchers.OmnisTransition.Current > 0)
            {
                if (CutsceneAltList.Contains(base.memoryWatchers.CutsceneAlt.Current) && Stage == 0)
                {
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.OmnisTransition.Current;
                    Stage += 1;

                }
                else if (base.memoryWatchers.OmnisTransition.Current >= (BaseCutsceneValue + 0x7C) && Stage == 1)
                {
                    WriteValue<int>(base.memoryWatchers.OmnisTransition, BaseCutsceneValue + 0xA16);

                    Stage += 1;
                }
                else if (base.memoryWatchers.OmnisTransition.Current >= (BaseCutsceneValue + 0xA52) && base.memoryWatchers.HpEnemyA.Current < 80000 && base.memoryWatchers.HpEnemyA.Old == 80000 && Stage == 2)
                {
                    WriteValue<int>(base.memoryWatchers.OmnisTransition, BaseCutsceneValue + 0x1050);

                    Stage += 1;
                }
            }
        }
    }
}