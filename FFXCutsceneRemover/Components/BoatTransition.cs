using FFX_Cutscene_Remover.ComponentUtil;
using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace FFXCutsceneRemover
{
    class BoatTransition : Transition
    {

        static private List<short> CutsceneAltList = new List<short>(new short[] { 200, 191, 5421 });

        public override void Execute(string defaultDescription = "")
        {
            if (CutsceneAltList.Contains(base.memoryWatchers.CutsceneAlt.Current) && Stage == 0)
            {
                base.Execute();

                BaseCutsceneValue = base.memoryWatchers.YunaBoatTransition.Current;

                Stage += 1;

            }
            else if (base.memoryWatchers.YunaBoatTransition.Current == (BaseCutsceneValue + 0x2C3) && Stage == 1)
            {
                Storyline = 857;
                base.Execute();

                WriteValue<int>(base.memoryWatchers.YunaBoatTransition, BaseCutsceneValue + 0x2F4);

                Stage += 1;
            }
        }
    }
}
