using FFX_Cutscene_Remover.ComponentUtil;
using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

namespace FFXCutsceneRemover
{
    class YunalescaTransition : Transition
    {
        static private List<short> CutsceneAltList = new List<short>(new short[] { 70, 71, 75, 76 });
        public override void Execute(string defaultDescription = "")
        {
            int baseAddress = base.memoryWatchers.GetBaseAddress();

            if (base.memoryWatchers.YunalescaTransition.Current > 0)
            {
                
                if (CutsceneAltList.Contains(base.memoryWatchers.CutsceneAlt.Current) && Stage == 0)
                {
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.YunalescaTransition.Current;

                    Stage = 1;

                }//*/
                else if (base.memoryWatchers.YunalescaTransition.Current == (BaseCutsceneValue + 0x75A) && Stage == 1)
                {
                    WriteValue<int>(base.memoryWatchers.YunalescaTransition, BaseCutsceneValue + 0xDC4);
                    Stage = 2;
                }
                else if (base.memoryWatchers.YunalescaTransition.Current == (BaseCutsceneValue + 0xE24) && Stage == 2)
                {
                    WriteValue<int>(base.memoryWatchers.YunalescaTransition, BaseCutsceneValue + 0x111E);
                    Stage = 3;
                }
                //*/
                /*/
                if (base.memoryWatchers.CutsceneAlt.Current != base.memoryWatchers.CutsceneAlt.Old)
                {
                    Console.WriteLine(base.memoryWatchers.CutsceneAlt.Current.ToString() + " / " + base.memoryWatchers.YunalescaTransition.Current.ToString());
                }
                //*/
            }
        }
    }
}