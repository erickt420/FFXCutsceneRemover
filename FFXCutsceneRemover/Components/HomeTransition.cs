using FFX_Cutscene_Remover.ComponentUtil;
using System;
using System.Diagnostics;
using System.Linq;

namespace FFXCutsceneRemover
{
    class HomeTransition : Transition
    {
        public override void Execute(string defaultDescription = "")
        {
            int baseAddress = base.memoryWatchers.GetBaseAddress();

            if (base.memoryWatchers.HomeTransition.Current > 0)
            {
                if (Stage == 0 && base.memoryWatchers.CutsceneAlt.Current == 5043)
                {
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.HomeTransition.Current;
                    Stage += 1;

                }
                else if (base.memoryWatchers.HomeTransition.Current == (BaseCutsceneValue + 0x18E) && Stage == 1)
                {
                    WriteValue<int>(base.memoryWatchers.HomeTransition, BaseCutsceneValue + 0x381);
                    Stage += 1;
                }
                else if (base.memoryWatchers.HomeTransition.Current == (BaseCutsceneValue + 0x55D) && Stage == 2)
                {
                    WriteValue<int>(base.memoryWatchers.HomeTransition, BaseCutsceneValue + 0x6FE);
                    WriteValue<byte>(base.memoryWatchers.CutsceneTiming, 0);
                    Stage += 1;
                }
            }
        }
    }
}