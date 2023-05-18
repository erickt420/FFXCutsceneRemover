using System.Collections.Generic;

namespace FFXCutsceneRemover;

class IxionTransition : Transition
{
    static private List<short> CutsceneAltList = new List<short>(new short[] { 1641, 16, 96 });
    public override void Execute(string defaultDescription = "")
    {
        if (base.memoryWatchers.IxionTransition.Current > 0)
        {
            if (base.memoryWatchers.State.Current != -1 && Stage == 0)
            {
                base.Execute();

                BaseCutsceneValue = base.memoryWatchers.EventFileStart.Current;
                Stage += 1;

            }
            else if (base.memoryWatchers.IxionTransition.Current == (BaseCutsceneValue + 0x2241) && Stage == 1)
            {
                WriteValue<int>(base.memoryWatchers.IxionTransition, BaseCutsceneValue + 0x2529);
                Stage += 1;
            }
        }
    }
}