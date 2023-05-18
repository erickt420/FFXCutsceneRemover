using System.Collections.Generic;

namespace FFXCutsceneRemover;

class ExtractorTransition : Transition
{
    static private List<short> CutsceneAltList = new List<short>(new short[] { 1137 });
    public override void Execute(string defaultDescription = "")
    {
        if (base.memoryWatchers.ExtractorTransition.Current > 0)
        {
            if (Stage == 0)
            {
                base.Execute();

                BaseCutsceneValue = base.memoryWatchers.ExtractorTransition.Current;
                Stage += 1;

            }
            else if (base.memoryWatchers.ExtractorTransition.Current == (BaseCutsceneValue + 0x1E3) && base.memoryWatchers.BattleState2.Current == 1 && Stage == 1)
            {
                WriteValue<int>(base.memoryWatchers.ExtractorTransition, BaseCutsceneValue + 0x28B);// 28E
                Stage += 1;
            }
        }
    }
}