using FFX_Cutscene_Remover.ComponentUtil;
using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

namespace FFXCutsceneRemover
{
    class FinLeftAirshipTransition : Transition
    {
        static private List<short> CutsceneAltList = new List<short>(new short[] { 777, 4593, 100 });
        public override void Execute(string defaultDescription = "")
        {
            int baseAddress = base.memoryWatchers.GetBaseAddress();

            if (base.memoryWatchers.FinsAirshipTransition.Current > 0)
            {
                if (CutsceneAltList.Contains(base.memoryWatchers.CutsceneAlt.Current) && Stage == 0)
                {
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.FinsAirshipTransition.Current;

                    Stage = 1;

                }
                else if (base.memoryWatchers.FinsAirshipTransition.Current >= (BaseCutsceneValue + 0x01) && Stage == 1)
                {
                    WriteValue<int>(base.memoryWatchers.FinsAirshipTransition, BaseCutsceneValue + 0x1CF0);
                    Stage = 2;
                }
            }
        }
    }
}