using FFX_Cutscene_Remover.ComponentUtil;
using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using FFXCutsceneRemover.Logging;

namespace FFXCutsceneRemover
{
    class FluxTransition : Transition
    {
        static private List<short> CutsceneAltList = new List<short>(new short[] { 710, 975, 5133 });
        public override void Execute(string defaultDescription = "")
        {
            int baseAddress = base.memoryWatchers.GetBaseAddress();

            if (base.memoryWatchers.FluxTransition.Current > 0)
            {
                if (CutsceneAltList.Contains(base.memoryWatchers.CutsceneAlt.Current) && Stage == 0)
                {
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.FluxTransition.Current;

                    Stage = 1;

                }
                else if (base.memoryWatchers.FluxTransition.Current == (BaseCutsceneValue + 0x3CF) && Stage == 1)
                {
                    WriteValue<int>(base.memoryWatchers.FluxTransition, BaseCutsceneValue + 0x123A);
                    Stage = 2;
                }
                else if (base.memoryWatchers.FluxTransition.Current == (BaseCutsceneValue + 0x12AA) && base.memoryWatchers.HpEnemyA.Current < 70000 && base.memoryWatchers.HpEnemyA.Old == 70000 && Stage == 2)
                {
                    DiagnosticLog.Information("HP Check");
                    WriteValue<int>(base.memoryWatchers.FluxTransition, BaseCutsceneValue + 0x1496);
                    Stage = 3;
                }
                else if (base.memoryWatchers.Gil.Current > base.memoryWatchers.Gil.Old && Stage == 3)
                {
                    Stage = 4;
                }
                else if (base.memoryWatchers.Gil.Current == base.memoryWatchers.Gil.Old && Stage == 4)
                {
                    Menu = 0;
                    Description = "Exit Menu";
                    ForceLoad = false;
                    base.Execute();
                    Stage = 5;
                }
            }
        }
    }
}