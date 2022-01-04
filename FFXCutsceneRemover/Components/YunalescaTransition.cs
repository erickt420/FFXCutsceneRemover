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
                
                if (Stage == 0)
                {
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.EventFileStart.Current;
                    DiagnosticLog.Information(BaseCutsceneValue.ToString("X2"));
                    Stage += 1;

                }//*/
                else if (base.memoryWatchers.YunalescaTransition.Current == (BaseCutsceneValue + 0x5DF0) && Stage == 1)
                {
                    DiagnosticLog.Information("Stage: " + Stage.ToString());
                    WriteValue<int>(base.memoryWatchers.YunalescaTransition, BaseCutsceneValue + 0x645A);
                    Stage += 1;
                }
                else if (base.memoryWatchers.YunalescaTransition.Current == (BaseCutsceneValue + 0x64BA) && Stage == 2)
                {
                    DiagnosticLog.Information("Stage: " + Stage.ToString());
                    WriteValue<int>(base.memoryWatchers.YunalescaTransition, BaseCutsceneValue + 0x67B4);
                    WriteValue<byte>(base.memoryWatchers.CutsceneTiming, 0);
                    Stage += 1;
                }
                else if (base.memoryWatchers.PlayerTurn.Current == 1 && Stage == 3)
                {
                    DiagnosticLog.Information("Stage: " + Stage.ToString());
                    WriteValue<int>(base.memoryWatchers.YunalescaTransition, BaseCutsceneValue + 0x6C8D);
                    Stage += 1;
                }
                else if (base.memoryWatchers.Gil.Current > base.memoryWatchers.Gil.Old && Stage == 4)
                {
                    DiagnosticLog.Information("Stage: " + Stage.ToString());
                    Stage += 1;
                }
                else if (base.memoryWatchers.Gil.Current == base.memoryWatchers.Gil.Old && Stage == 5)
                {
                    DiagnosticLog.Information("Stage: " + Stage.ToString());
                    Menu = 0;
                    Description = "Exit Menu";
                    ForceLoad = false;
                    base.Execute();
                    Stage += 1;
                }
            }
        }
    }
}