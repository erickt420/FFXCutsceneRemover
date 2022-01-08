using FFX_Cutscene_Remover.ComponentUtil;
using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using FFXCutsceneRemover.Logging;

namespace FFXCutsceneRemover
{
    class TankerTransition : Transition
    {
        static private List<short> CutsceneAltList = new List<short>(new short[] { 6609 });
        public override void Execute(string defaultDescription = "")
        {
            int baseAddress = base.memoryWatchers.GetBaseAddress();
            if (base.memoryWatchers.TankerTransition.Current > 0)
            {
                if (CutsceneAltList.Contains(base.memoryWatchers.CutsceneAlt.Current) && Stage == 0)
                {
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.TankerTransition.Current;
                    Stage += 1;

                }
                else if (base.memoryWatchers.TankerTransition.Current == (BaseCutsceneValue + 0x18D) && Stage == 1)
                {
                    WriteValue<int>(base.memoryWatchers.TankerTransition, BaseCutsceneValue + 0x358);
                    Stage += 1;
                }
            }
        }
    }
}