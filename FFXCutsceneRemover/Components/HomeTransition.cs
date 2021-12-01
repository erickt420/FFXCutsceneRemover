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
                    Stage = 1;

                }
                else if (base.memoryWatchers.HomeTransition.Current == (BaseCutsceneValue + 0x18E) && Stage == 1)
                {
                    WriteValue<int>(base.memoryWatchers.HomeTransition, BaseCutsceneValue + 0x381);
                    Stage = 3;
                }
                /* We can skip post Dual Horns mini cutscene but it spawns us way back in the hall so we don't really save time. Also might impact airship encounters but unsure.
                else if (base.memoryWatchers.HomeTransition.Current >= (BaseCutsceneValue + 0x427) && Stage == 2)
                {
                    DiagnosticLog.Information("Test2");
                    WriteValue<int>(base.memoryWatchers.HomeTransition, BaseCutsceneValue + 0x439);
                    Stage = 3;
                }
                */
                else if (base.memoryWatchers.HomeTransition.Current == (BaseCutsceneValue + 0x55D) && Stage == 3)
                {
                    WriteValue<int>(base.memoryWatchers.HomeTransition, BaseCutsceneValue + 0x6FE);
                    Stage = 4;
                }
            }
        }
    }
}