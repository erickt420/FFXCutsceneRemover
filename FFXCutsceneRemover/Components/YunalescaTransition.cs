using FFX_Cutscene_Remover.ComponentUtil;
using System;
using System.Diagnostics;
using System.Linq;

namespace FFXCutsceneRemover
{
    class YunalescaTransition : Transition
    {
        public override void Execute(string defaultDescription = "")
        {
            int baseAddress = base.memoryWatchers.GetBaseAddress();

            if (base.memoryWatchers.YunalescaTransition.Current > 0)
            {

                if (Stage == 0)
                {
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.YunalescaTransition.Current;

                    Stage = 1;

                }

                if (base.memoryWatchers.YunalescaTransition.Current >= (BaseCutsceneValue + 0x754) && Stage == 1)
                {
                    WriteValue<int>(base.memoryWatchers.YunalescaTransition, BaseCutsceneValue + 0xDC4);
                    Stage = 2;
                }

                if (base.memoryWatchers.YunalescaTransition.Current >= (BaseCutsceneValue + 0xE24) && Stage == 2)
                {
                    WriteValue<int>(base.memoryWatchers.YunalescaTransition, BaseCutsceneValue + 0x111E);
                    Stage = 3;
                }

            }
        }
    }
}