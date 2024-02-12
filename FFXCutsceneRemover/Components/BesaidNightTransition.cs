using System.Collections.Generic;

namespace FFXCutsceneRemover;

class BesaidNightTransition : Transition
{
    public override void Execute(string defaultDescription = "")
    {
        if (Stage == 0)
        {
            base.Execute();

            BaseCutsceneValue = MemoryWatchers.EventFileStart.Current;
            Stage += 1;

        }
        //else if (MemoryWatchers.BesaidNightTransition1.Current == (BaseCutsceneValue + 0x6973) && Stage == 1)
        else if (MemoryWatchers.BesaidNightTransition1.Current > (BaseCutsceneValue + 0x68C2) && Stage == 1)
        {
            WriteValue<int>(MemoryWatchers.BesaidNightTransition1, BaseCutsceneValue + 0x6DFB);
            Stage += 1;
        }
        else if (MemoryWatchers.BesaidNightTransition2.Current == (BaseCutsceneValue + 0x6F32) && Stage == 2)
        {
            WriteValue<int>(MemoryWatchers.BesaidNightTransition2, BaseCutsceneValue + 0x773D);
            Stage += 1;
        }
    }
}