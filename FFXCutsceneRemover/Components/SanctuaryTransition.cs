using FFX_Cutscene_Remover.ComponentUtil;
using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

namespace FFXCutsceneRemover
{
    class SanctuaryTransition : Transition
    {
        static private List<short> CutsceneAltList = new List<short>(new short[] { 225, 987, 5601 });
        public override void Execute(string defaultDescription = "")
        {
            int baseAddress = base.memoryWatchers.GetBaseAddress();

            if (base.memoryWatchers.SanctuaryTransition.Current > 0)
            {
                if (Stage == 0)
                {
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.SanctuaryTransition.Current;

                    Stage = 1;

                }
                else if (base.memoryWatchers.SanctuaryTransition.Current == (BaseCutsceneValue + 0x582) && Stage == 1)
                {
                    WriteValue<int>(base.memoryWatchers.SanctuaryTransition, BaseCutsceneValue + 0x698);
                    Stage = 2;
                }
            }
        }
    }
}