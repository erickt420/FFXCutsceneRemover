using FFX_Cutscene_Remover.ComponentUtil;
using System;
using System.Diagnostics;
using System.Linq;

namespace FFXCutsceneRemover
{
    class ValeforTransition : Transition
    {
        public override void Execute(string defaultDescription = "")
        {
            int baseAddress = base.memoryWatchers.GetBaseAddress();
            if (base.memoryWatchers.ValeforTransition.Current > 0)
            {
                if (Stage == 0)
                {
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.ValeforTransition.Current;

                    Stage = 1;

                }
                else if (base.memoryWatchers.ValeforTransition.Current >= (BaseCutsceneValue + 0x00) && Stage == 1)
                {
                    WriteValue<int>(base.memoryWatchers.ValeforTransition, BaseCutsceneValue + 0xAA4);
                    Stage = 2;
                }
            }
        }
    }
}