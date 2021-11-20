using FFX_Cutscene_Remover.ComponentUtil;
using System;
using System.Diagnostics;
using System.Linq;

namespace FFXCutsceneRemover
{
    class FluxTransition : Transition
    {
        public override void Execute(string defaultDescription = "")
        {
            int baseAddress = base.memoryWatchers.GetBaseAddress();

            if (base.memoryWatchers.FluxTransition.Current > 0)
            {
                if (Stage == 0)
                {
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.FluxTransition.Current;

                    Stage = 1;

                }
                else if (base.memoryWatchers.FluxTransition.Current >= (BaseCutsceneValue + 0x3CF) && Stage == 1)
                {
                    WriteValue<int>(base.memoryWatchers.FluxTransition, BaseCutsceneValue + 0x127A);
                    Stage = 2;
                }

            }
        }
    }
}