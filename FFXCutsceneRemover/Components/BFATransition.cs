using FFX_Cutscene_Remover.ComponentUtil;
using System;
using System.Diagnostics;
using System.Linq;

namespace FFXCutsceneRemover
{
    class BFATransition : Transition
    {
        public override void Execute(string defaultDescription = "")
        {
            int baseAddress = base.memoryWatchers.GetBaseAddress();

            if (base.memoryWatchers.BFATransition.Current > 0)
            {

                if (base.memoryWatchers.CutsceneAlt.Current == 71 && base.Stage == 0)
                {
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.BFATransition.Current;

                    base.Stage = 1;

                }
                else if (base.memoryWatchers.BFATransition.Current >= (BaseCutsceneValue + 0x42) && Stage == 1)
                {
                    //WriteValue<int>(base.memoryWatchers.BFATransition, BaseCutsceneValue + 0xE1); //Not currently working as desired
                    Stage = 2;
                }
                else if (base.memoryWatchers.BFATransition.Current >= (BaseCutsceneValue + 0x478) && Stage == 2)
                {
                    WriteValue<int>(base.memoryWatchers.BFATransition, BaseCutsceneValue + 0xD7F);
                    Stage = 3;
                }
                else if (base.memoryWatchers.BFATransition.Current >= (BaseCutsceneValue + 0xD80) && Stage == 3)
                {
                    WriteValue<int>(base.memoryWatchers.BFATransition, BaseCutsceneValue + 0x10BA);
                    Stage = 4;
                }
                else if (base.memoryWatchers.BFATransition.Current >= (BaseCutsceneValue + 0x1135) && Stage == 4)
                {
                    WriteValue<int>(base.memoryWatchers.BFATransition, BaseCutsceneValue + 0x1442);
                    Stage = 5;
                }
            }
        }
    }
}