using FFXCutsceneRemover.ComponentUtil;
using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using FFXCutsceneRemover.Logging;

namespace FFXCutsceneRemover
{
    class AuronTransition : Transition
    {
        public override void Execute(string defaultDescription = "")
        {
            if (base.memoryWatchers.MovementLock.Current == 0x20 && Stage == 0)
            {
                base.Execute();

                BaseCutsceneValue = base.memoryWatchers.EventFileStart.Current;
                Stage = 1;

            }
            else if (base.memoryWatchers.AuronTransition.Current == (BaseCutsceneValue + 0x4233) && Stage == 1)
            {
                WriteValue<int>(base.memoryWatchers.AuronTransition, BaseCutsceneValue + 0x42EE);
                Stage += 1;
            }
        }
    }
}