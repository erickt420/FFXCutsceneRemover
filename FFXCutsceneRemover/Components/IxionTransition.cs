using FFX_Cutscene_Remover.ComponentUtil;
using System;
using System.Diagnostics;
using System.Linq;

namespace FFXCutsceneRemover
{
    class IxionTransition : Transition
    {
        public override void Execute(string defaultDescription = "")
        {
            int baseAddress = base.memoryWatchers.GetBaseAddress();
            if (base.memoryWatchers.IxionTransition.Current > 0)
            {
                if (Stage == 0)
                {
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.IxionTransition.Current;

                    Stage = 1;

                }
                else if (base.memoryWatchers.IxionTransition.Current >= (BaseCutsceneValue + 0xFC) && Stage == 1)
                {
                    WriteValue<int>(base.memoryWatchers.IxionTransition, BaseCutsceneValue + 0x3DC);
                    Stage = 2;
                }
            }
        }
    }
}