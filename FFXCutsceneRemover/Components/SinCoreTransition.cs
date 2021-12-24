using FFX_Cutscene_Remover.ComponentUtil;
using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

namespace FFXCutsceneRemover
{
    class SinCoreTransition : Transition
    {
        public override void Execute(string defaultDescription = "")
        {
            if (Stage == 0)
            {
                base.Execute();

                BaseCutsceneValue = base.memoryWatchers.EventFileStart.Current;

                Stage += 1;

            }
            else if (base.memoryWatchers.SinCoreTransition.Current == (BaseCutsceneValue + 0x185F) && Stage == 1)
            {
                WriteValue<int>(base.memoryWatchers.SinCoreTransition, BaseCutsceneValue + 0x1A37);
                Stage += 1;
            }
            else if (base.memoryWatchers.PlayerTurn.Current == 1 && Stage == 2)
            {
                WriteValue<int>(base.memoryWatchers.SinCoreTransition, BaseCutsceneValue + 0x1B0D);
                Stage += 1;
            }
        }
    }
}