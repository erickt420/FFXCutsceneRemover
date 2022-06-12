using System.Collections.Generic;
using FFXCutsceneRemover.Logging;

namespace FFXCutsceneRemover
{
    class KlikkTransition : Transition
    {
        static private List<short> CutsceneAltList = new List<short>(new short[] { 1137 });
        public override void Execute(string defaultDescription = "")
        {
            if (CutsceneAltList.Contains(base.memoryWatchers.CutsceneAlt.Current) && Stage == 0)
            {
                base.Execute();

                BaseCutsceneValue = base.memoryWatchers.EventFileStart.Current;
                Stage += 1;

            }
            else if (base.memoryWatchers.KlikkTransition.Current == (BaseCutsceneValue + 0xA523) && Stage == 1)
            {
                WriteValue<int>(base.memoryWatchers.KlikkTransition, BaseCutsceneValue + 0xA7E3);
                Stage += 1;
            }
            else if (base.memoryWatchers.KlikkTransition.Current > (BaseCutsceneValue + 0xA7E3) && Stage == 2)
            {
                WriteValue<int>(base.memoryWatchers.KlikkTransition, BaseCutsceneValue + 0xA847);
                Stage += 1;
            }
            else if (base.memoryWatchers.BattleState2.Current == 1 && Stage == 3)
            {
                WriteValue<int>(base.memoryWatchers.KlikkTransition, BaseCutsceneValue + 0xAF27);
                Stage += 1;
            }
        }
    }
}