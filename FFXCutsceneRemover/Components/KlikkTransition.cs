using FFX_Cutscene_Remover.ComponentUtil;
using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using FFXCutsceneRemover.Logging;

namespace FFXCutsceneRemover
{
    class KlikkTransition : Transition
    {
        static private List<short> CutsceneAltList = new List<short>(new short[] { 1137 });
        public override void Execute(string defaultDescription = "")
        {
            if (base.memoryWatchers.KlikkTransition.Current > 0)
            {

                if (base.memoryWatchers.CutsceneAlt.Current != base.memoryWatchers.CutsceneAlt.Old || base.memoryWatchers.KlikkTransition.Current != base.memoryWatchers.KlikkTransition.Old)
                {
                    DiagnosticLog.Information(base.memoryWatchers.CutsceneAlt.Current.ToString() + " / " + base.memoryWatchers.KlikkTransition.Current.ToString("X2"));
                }

                if (CutsceneAltList.Contains(base.memoryWatchers.CutsceneAlt.Current) && Stage == 0)
                {
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.KlikkTransition.Current;
                    DiagnosticLog.Information(BaseCutsceneValue.ToString("X2"));
                    Stage += 1;

                }
                else if (base.memoryWatchers.KlikkTransition.Current == (BaseCutsceneValue + 0x675) && Stage == 1)
                {
                    DiagnosticLog.Information("Stage: " + Stage.ToString());
                    WriteValue<int>(base.memoryWatchers.KlikkTransition, BaseCutsceneValue + 0x935);//972 , 999
                    Stage += 1;
                }
                else if (base.memoryWatchers.KlikkTransition.Current >= (BaseCutsceneValue + 0x936) && Stage == 2)
                {
                    DiagnosticLog.Information("Stage: " + Stage.ToString());
                    WriteValue<int>(base.memoryWatchers.KlikkTransition, BaseCutsceneValue + 0x999);//972 , 999
                    Stage += 1;
                }
                else if (base.memoryWatchers.KlikkTransition.Current == (BaseCutsceneValue + 0xA1A) && base.memoryWatchers.HpEnemyA.Current < 1500 && base.memoryWatchers.HpEnemyA.Old == 1500  && Stage == 3)
                {
                    DiagnosticLog.Information("Stage: " + Stage.ToString());
                    WriteValue<int>(base.memoryWatchers.KlikkTransition, BaseCutsceneValue + 0x1079); //104E
                    Stage += 1;
                }
            }
        }
    }
}