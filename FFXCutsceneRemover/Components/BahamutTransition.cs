using FFX_Cutscene_Remover.ComponentUtil;
using System;
using System.Diagnostics;
using System.Linq;

namespace FFXCutsceneRemover
{
    class BahamutTransition : Transition
    {
        public override void Execute(string defaultDescription = "")
        {
            int baseAddress = base.memoryWatchers.GetBaseAddress();
            if (base.memoryWatchers.BahamutTransition.Current > 0)
            {
                if (Stage == 0)
                {
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.BahamutTransition.Current;

                    Stage = 1;

                }
                else if (base.memoryWatchers.BahamutTransition.Current >= (BaseCutsceneValue + 0x680) && Stage == 1)
                {
                    WriteValue<int>(base.memoryWatchers.BahamutTransition, BaseCutsceneValue + 0x86E);
                    Stage = 2;
                }
            }
        }
    }
}