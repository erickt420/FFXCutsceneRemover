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
            if (Stage == 0)
            {
                base.Execute();

                BaseCutsceneValue = base.memoryWatchers.EventFileStart.Current;
                WriteValue<int>(base.memoryWatchers.YunaBoatTransition, BaseCutsceneValue + 0xC20D);
                WriteValue<int>(base.memoryWatchers.Camera, 1);

                Stage += 1;

            }/*/
            else if (base.memoryWatchers.YunaBoatTransition.Current == (BaseCutsceneValue + 0xBF19) && Stage == 1)
            {
                Storyline = 857;
                base.Execute();

                WriteValue<int>(base.memoryWatchers.YunaBoatTransition, BaseCutsceneValue + 0xC20D);
                WriteValue<int>(base.memoryWatchers.Camera, 1);

                Stage += 1;
            }//*/
        }
    }
}
