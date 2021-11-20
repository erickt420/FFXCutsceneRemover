using FFX_Cutscene_Remover.ComponentUtil;
using System;
using System.Diagnostics;
using System.Linq;

namespace FFXCutsceneRemover
{
    class EvraeTransition : Transition
    {
        public override void Execute(string defaultDescription = "")
        {
            int baseAddress = base.memoryWatchers.GetBaseAddress();

            if (base.memoryWatchers.EvraeTransition.Current > 0)
            {
                if (Stage == 0)
                {
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.EvraeTransition.Current;

                    Stage = 1;

                }
                else if (base.memoryWatchers.EvraeTransition.Current >= (BaseCutsceneValue + 0x15D) && Stage == 1)
                {
                    WriteValue<int>(base.memoryWatchers.EvraeTransition, BaseCutsceneValue + 0x40E);
                    Stage = 2;
                }
                else if (base.memoryWatchers.EvraeTransition.Current >= (BaseCutsceneValue + 0x4E0) && Stage == 2)
                {
                    WriteValue<int>(base.memoryWatchers.EvraeTransition, BaseCutsceneValue + 0x682);
                    Stage = 3;
                }
            }
        }
    }
}