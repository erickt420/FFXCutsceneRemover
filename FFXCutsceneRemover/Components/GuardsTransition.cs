using System.Collections.Generic;

namespace FFXCutsceneRemover;

class GuardsTransition : Transition
{
    static private List<short> CutsceneAltList = new List<short>(new short[] { 70, 71, 75, 76 });
    public override void Execute(string defaultDescription = "")
    {
        if (base.memoryWatchers.State.Current == 1 && Stage == 0)
        {
            base.Execute();

            BaseCutsceneValue = base.memoryWatchers.EventFileStart.Current;
            Stage += 1;

        }//*/
        else if (base.memoryWatchers.GuardsTransition.Current > (BaseCutsceneValue + 0x86CA) && Stage == 1)
        {
            WriteValue<int>(base.memoryWatchers.GuardsTransition, BaseCutsceneValue + 0x90DB);

            Stage += 1;
        }
    }
}