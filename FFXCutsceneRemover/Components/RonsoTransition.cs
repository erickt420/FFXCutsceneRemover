using FFX_Cutscene_Remover.ComponentUtil;
using System;
using System.Diagnostics;
using System.Linq;

namespace FFXCutsceneRemover
{
    class RonsoTransition : Transition
    {
        public override void Execute(string defaultDescription = "")
        {
            int baseAddress = base.memoryWatchers.GetBaseAddress();

            if (base.memoryWatchers.RonsoTransition.Current > 0)
            {
                if (Stage == 0)
                {
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.RonsoTransition.Current;

                    Stage = 1;

                }
                else if (base.memoryWatchers.RonsoTransition.Current == (BaseCutsceneValue + 0x123C) && Stage == 1)
                {
                    WriteValue<int>(base.memoryWatchers.RonsoTransition, BaseCutsceneValue + 0x1698);
                    Stage = 2;
                }
            }
        }
    }
}