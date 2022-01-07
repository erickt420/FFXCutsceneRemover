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
        public override void Execute(string defaultDescription = "")
        {
            Process process = memoryWatchers.Process;
            
            if (base.memoryWatchers.MovementLock.Current == 0x20 && Stage == 0)
            {
                base.Execute();

                BaseCutsceneValue = base.memoryWatchers.EventFileStart.Current;

                Stage += 1;

            }
            else if (base.memoryWatchers.FluxTransition.Current == (BaseCutsceneValue + 0x5D5C) && Stage == 1)
            {
                WriteValue<int>(base.memoryWatchers.FluxTransition, BaseCutsceneValue + 0x6BC7);
                Stage += 1;
            }
            else if (base.memoryWatchers.PlayerTurn.Current == 1 && Stage == 2)
            {
                WriteValue<int>(base.memoryWatchers.FluxTransition, BaseCutsceneValue + 0x6E23);
                Stage += 1;
            }
            else if (base.memoryWatchers.Gil.Current > base.memoryWatchers.Gil.Old && Stage == 3)
            {
                Stage += 1;
            }
            else if (base.memoryWatchers.Gil.Current == base.memoryWatchers.Gil.Old && Stage == 4)
            {
                process.Suspend();

                Transition ExitMenu = new Transition { Menu = 0, Description = "Exit Menu", ForceLoad = false };
                ExitMenu.Execute();

                Stage += 1;

                process.Resume();
            }
        }
    }
}