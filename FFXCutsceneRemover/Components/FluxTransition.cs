using System.Diagnostics;
using System.Linq;

using FFXCutsceneRemover.ComponentUtil;

namespace FFXCutsceneRemover;

class FluxTransition : Transition
{
    public override void Execute(string defaultDescription = "")
    {
        Process process = MemoryWatchers.Process;
        
        if (MemoryWatchers.MovementLock.Current == 0x20 && Stage == 0)
        {
            base.Execute();

            BaseCutsceneValue = MemoryWatchers.EventFileStart.Current;

            Stage += 1;

        }
        else if (MemoryWatchers.FluxTransition.Current == (BaseCutsceneValue + 0x5D5C) && Stage == 1)
        {
            WriteValue<int>(MemoryWatchers.FluxTransition, BaseCutsceneValue + 0x6BC7);
            Stage += 1;
        }
        else if (MemoryWatchers.BattleState2.Current == 1 && Stage == 2)
        {
            WriteValue<int>(MemoryWatchers.FluxTransition, BaseCutsceneValue + 0x6E23);
            Stage += 1;
        }
        else if (MemoryWatchers.GilRewardCounter.Current > 0 && Stage == 3)
        {
            Stage += 1;
        }
        else if (MemoryWatchers.GilRewardCounter.Current == 0 && Stage == 4)
        {
            process.Suspend();

            new Transition { MenuCleanup = true, AddRewardItems = true, Description = "Exit Menu", ForceLoad = false }.Execute();

            Stage += 1;

            process.Resume();
        }
    }
}