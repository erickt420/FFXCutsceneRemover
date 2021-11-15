using FFX_Cutscene_Remover.ComponentUtil;
using System;
using System.Diagnostics;
using System.Linq;

namespace FFXCutsceneRemover
{
    class IsaaruTransition : Transition
    {
        public override void Execute(string defaultDescription = "")
        {
            int baseAddress = base.memoryWatchers.GetBaseAddress();

            if (base.memoryWatchers.IsaaruTransition.Current > 0)
            {
                if (Stage == 0)
                {
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.IsaaruTransition.Current;
                    Console.WriteLine(BaseCutsceneValue.ToString("X2"));

                    Stage = 1;

                }
                else if (base.memoryWatchers.IsaaruTransition.Current >= (BaseCutsceneValue + 0x104) && Stage == 1)
                {
                    Console.WriteLine("Pre");

                    Formation = new byte[] { 0x01, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
                    base.Execute();

                    WriteValue<int>(base.memoryWatchers.IsaaruTransition, BaseCutsceneValue + 0x2F1);
                    Stage = 2;
                }
                else if (base.memoryWatchers.IsaaruTransition.Current >= (BaseCutsceneValue + 0x3BC) && Stage == 2)
                {
                    Console.WriteLine("Post");
                    WriteValue<int>(base.memoryWatchers.IsaaruTransition, BaseCutsceneValue + 0x5C4);
                    Stage = 3;
                }
            }
        }
    }
}