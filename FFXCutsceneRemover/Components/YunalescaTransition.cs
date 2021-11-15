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
                    Console.WriteLine(BaseCutsceneValue.ToString("X2"));

                    Stage = 1;

                }
                else if (base.memoryWatchers.YunalescaTransition.Current >= (BaseCutsceneValue + 0x75A) && Stage == 1)
                {
                    WriteValue<int>(base.memoryWatchers.YunalescaTransition, BaseCutsceneValue + 0xDC4);
                    Stage = 2;
                }
                else if (base.memoryWatchers.YunalescaTransition.Current >= (BaseCutsceneValue + 0xE24) && Stage == 2)
                {
                    WriteValue<int>(base.memoryWatchers.YunalescaTransition, BaseCutsceneValue + 0x111E);
                    Stage = 3;
                }

            }
        }
    }
}