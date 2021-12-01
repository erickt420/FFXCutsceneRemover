using FFX_Cutscene_Remover.ComponentUtil;
using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using FFXCutsceneRemover.Logging;

namespace FFXCutsceneRemover
{
    class GeneauxTransition : Transition
    {
        static private List<short> CutsceneAltList = new List<short>(new short[] { 265, 1173, 1174 });
        public override void Execute(string defaultDescription = "")
        {
            int baseAddress = base.memoryWatchers.GetBaseAddress();
            if (base.memoryWatchers.GeneauxTransition.Current > 0)
            {
                if (CutsceneAltList.Contains(base.memoryWatchers.CutsceneAlt.Current) && Stage == 0)
                {
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.GeneauxTransition.Current;
                    DiagnosticLog.Information(BaseCutsceneValue.ToString("X2"));
                    Stage = 1;

                }
                else if (base.memoryWatchers.GeneauxTransition.Current == (BaseCutsceneValue + 0x4D8) && Stage == 1)
                {
                    DiagnosticLog.Information("Stage: " + Stage.ToString());
                    WriteValue<int>(base.memoryWatchers.GeneauxTransition, BaseCutsceneValue + 0x6B8);
                    Stage += 1;
                }
                else if (base.memoryWatchers.GeneauxTransition.Current == (BaseCutsceneValue + 0x6DC) && base.memoryWatchers.HpEnemyA.Current < 3000 && base.memoryWatchers.HpEnemyA.Old == 3000 && Stage == 2)
                {
                    DiagnosticLog.Information("Stage: " + Stage.ToString());
                    WriteValue<int>(base.memoryWatchers.GeneauxTransition, BaseCutsceneValue + 0x958);
                    Stage += 1;
                }
                else if (base.memoryWatchers.Gil.Current > base.memoryWatchers.Gil.Old && Stage == 3)
                {
                    Stage += 1;
                }
                else if (base.memoryWatchers.Gil.Current == base.memoryWatchers.Gil.Old && Stage == 4)
                {
                    Menu = 0;
                    Description = "Exit Menu";
                    ForceLoad = false;
                    base.Execute();
                    Stage = 8;
                }
            }
        }
    }
}