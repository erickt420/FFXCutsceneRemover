using FFX_Cutscene_Remover.ComponentUtil;
using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using FFXCutsceneRemover.Logging;

namespace FFXCutsceneRemover
{
    class DjoseTransition : Transition
    {
        static private List<short> CutsceneAltList = new List<short>(new short[] { 1623, 16, 96 });
        public override void Execute(string defaultDescription = "")
        {
            int baseAddress = base.memoryWatchers.GetBaseAddress();
            if (base.memoryWatchers.DjoseTransition.Current > 0)
            {
                if (CutsceneAltList.Contains(base.memoryWatchers.CutsceneAlt.Current) && Stage == 0)
                {
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.DjoseTransition.Current;
                    DiagnosticLog.Information(BaseCutsceneValue.ToString("X2"));

                    Stage += 1;

                }
                else if (base.memoryWatchers.DjoseTransition.Current == (BaseCutsceneValue + 0x160) && Stage == 1) // 160
                {
                    WriteValue<int>(base.memoryWatchers.DjoseTransition, BaseCutsceneValue + 0x4ED);

                    Transition actorPositions;
                    //Position Tidus
                    actorPositions = new Transition { ForceLoad = false, ConsoleOutput = false, TargetActorIDs = new short[] { 1 }, Target_x = 1.628f, Target_y = 0.0f, Target_z = -6.528f };
                    actorPositions.Execute();

                    Stage += 1;
                }
            }
        }
    }
}