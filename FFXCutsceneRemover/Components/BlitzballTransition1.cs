using FFX_Cutscene_Remover.ComponentUtil;
using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using FFXCutsceneRemover.Logging;

namespace FFXCutsceneRemover
{
    class BlitzballTransition1 : Transition
    {
        public override void Execute(string defaultDescription = "")
        {
            //List<short> CutsceneAltList = new List<short>(new short[] { 347, 2235 });

            if (base.memoryWatchers.BlitzballTransition.Current > 0)
            {
                if (Stage == 0)
                {
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.EventFileStart.Current;
                    DiagnosticLog.Information(BaseCutsceneValue.ToString("X2"));
                    Stage += 1;

                }
                else if (base.memoryWatchers.BlitzballTransition.Current == (BaseCutsceneValue + 0xED9) && Stage == 1)
                {
                    DiagnosticLog.Information("Stage: " + Stage.ToString());
                    WriteValue<int>(base.memoryWatchers.BlitzballTransition, BaseCutsceneValue + 0x10B5); // 0x38DA, 0x38D7
                    Stage += 1;
                }
            }
        }
    }
}