using System.Diagnostics;
using FFXCutsceneRemover.ComponentUtil;
using FFXCutsceneRemover.Logging;
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
                Process process = memoryWatchers.Process;

                if (Stage == 0)
                {
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.EventFileStart.Current;
                    Stage += 1;

                }//*/
                else if (base.memoryWatchers.YunalescaTransition.Current == (BaseCutsceneValue + 0x5DF0) && Stage == 1)
                {
                    WriteValue<int>(base.memoryWatchers.YunalescaTransition, BaseCutsceneValue + 0x645A);
                    Stage += 1;
                }
                else if (base.memoryWatchers.YunalescaTransition.Current == (BaseCutsceneValue + 0x64BA) && Stage == 2)
                {
                    WriteValue<int>(base.memoryWatchers.YunalescaTransition, BaseCutsceneValue + 0x67B4);
                    WriteValue<byte>(base.memoryWatchers.CutsceneTiming, 0);
                    Stage += 1;
                }
                else if (base.memoryWatchers.BattleState2.Current == 1 && Stage == 3)
                {
                    WriteValue<int>(base.memoryWatchers.YunalescaTransition, BaseCutsceneValue + 0x6C8D);
                    Stage += 1;
                }
                else if (base.memoryWatchers.Gil.Current > base.memoryWatchers.Gil.Old && Stage == 4)
                {
                    Stage += 1;
                }
                else if (base.memoryWatchers.Gil.Current == base.memoryWatchers.Gil.Old && Stage == 5)
                {
                    process.Suspend();

                    Transition ExitMenu = new Transition { Menu = 0, Description = "Exit Menu", ForceLoad = false };
                    ExitMenu.Execute();

                    Stage += 1;

                    process.Resume();
                }
            }
        }
    }
}