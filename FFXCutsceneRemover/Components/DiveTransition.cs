using System.Collections.Generic;

namespace FFXCutsceneRemover;

class DiveTransition : Transition
{
    public override void Execute(string defaultDescription = "")
    {
        if (MemoryWatchers.MovementLock.Current == 0x20 && Stage == 0)
        {
            base.Execute();

            BaseCutsceneValue = MemoryWatchers.EventFileStart.Current;
            Stage += 1;

        }
        else if (MemoryWatchers.DiveTransition3.Current == (BaseCutsceneValue + 0x2935) && Stage == 1)
        {
            WriteValue<int>(MemoryWatchers.DiveTransition, BaseCutsceneValue + 0xA468);
            WriteValue<int>(MemoryWatchers.DiveTransition2, BaseCutsceneValue + 0x5BCF);
            Stage += 1;
        }
        else if (MemoryWatchers.DiveTransition.Current == (BaseCutsceneValue + 0xA4C8) && Stage == 2)
        {
            WriteValue<int>(MemoryWatchers.DiveTransition, BaseCutsceneValue + 0xA4C9);
            Stage += 1;
        }
    }
}