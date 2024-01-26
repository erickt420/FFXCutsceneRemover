using System.Collections.Generic;

namespace FFXCutsceneRemover;

class TromellTransition : Transition
{
    static private List<short> CutsceneAltList = new List<short>(new short[] { 190, 661, 21 });
    public override void Execute(string defaultDescription = "")
    {
        if (MemoryWatchers.CutsceneAlt.Current == 2955 && Stage == 0)
        {
            base.Execute();
            BaseCutsceneValue = MemoryWatchers.EventFileStart.Current;
            Stage += 1;

        }
        else if (MemoryWatchers.TromellTransition.Current > (BaseCutsceneValue + 0x88A9) && Stage == 1)
        {
            WriteValue<int>(MemoryWatchers.TromellTransition, BaseCutsceneValue + 0x9339);
            Stage += 1;
        }

        if (MemoryWatchers.RoomNumber.Current == 215 || MemoryWatchers.RoomNumber.Current == 221)
        {
            Stage = 99;
        }
        else if (MemoryWatchers.RoomNumber.Current == 164 && Stage == 99)
        {
            Stage = 0;
        }
    }
}