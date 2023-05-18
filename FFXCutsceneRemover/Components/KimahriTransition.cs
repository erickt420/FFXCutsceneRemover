using FFXCutsceneRemover.ComponentUtil;
using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

namespace FFXCutsceneRemover
{
    class KimahriTransition : Transition
    {
        public override void Execute(string defaultDescription = "")
        {
            if (base.memoryWatchers.MovementLock.Current == 0x20 && Stage == 0)
            {
                base.Execute();

                BaseCutsceneValue = base.memoryWatchers.EventFileStart.Current;

                Stage += 1;

            }
            else if (base.memoryWatchers.KimahriTransition.Current >= (BaseCutsceneValue + 0x231A) && Stage == 1)
            {
                WriteValue<int>(base.memoryWatchers.KimahriTransition, BaseCutsceneValue + 0x23F3);
                Stage += 1;
            }
            else if (base.memoryWatchers.BattleState2.Current == 1 && Stage == 2)
            {
                WriteValue<int>(base.memoryWatchers.KimahriTransition, BaseCutsceneValue + 0x2AE3);
                Stage += 1;
            }
        }
    }
}