using FFXCutsceneRemover.ComponentUtil;
using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using FFXCutsceneRemover.Logging;

namespace FFXCutsceneRemover
{
    class YojimboFaythTransition : Transition
    {
        static private List<short> CutsceneAltList = new List<short>(new short[] { 1281 });
        public override void Execute(string defaultDescription = "")
        {
            if ((base.memoryWatchers.CalmLandsFlag.Current & 0x80) == 0x00 && base.memoryWatchers.YojimboFaythTransition.Current > 0)
            {
                if (Stage == 0)
                {
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.EventFileStart.Current;
                    DiagnosticLog.Information($"Base Cutscene Value: {BaseCutsceneValue:X8}");

                    Stage += 1;

                }
                else if (base.memoryWatchers.YojimboFaythTransition.Current == (BaseCutsceneValue + 0x2C19) && Stage == 1)
                {
                    WriteValue<int>(base.memoryWatchers.YojimboFaythTransition, BaseCutsceneValue + 0x2DFF);
                    Stage += 1;
                    DiagnosticLog.Information($"Test Stage {Stage}");
                }
            }
        }
    }
}