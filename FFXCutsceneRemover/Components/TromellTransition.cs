using FFX_Cutscene_Remover.ComponentUtil;
using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

namespace FFXCutsceneRemover
{
    class TromellTransition : Transition
    {
        static private List<short> CutsceneAltList = new List<short>(new short[] { 190, 661, 21 });
        public override void Execute(string defaultDescription = "")
        {
            int baseAddress = base.memoryWatchers.GetBaseAddress();
            if (base.memoryWatchers.TromellTransition.Current > 0)
            {
                if (CutsceneAltList.Contains(base.memoryWatchers.CutsceneAlt.Current) && Stage == 0)
                {
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.TromellTransition.Current;
                    Console.WriteLine(BaseCutsceneValue.ToString("X2"));

                    Stage = 1;

                }
                else if (base.memoryWatchers.TromellTransition.Current >= (BaseCutsceneValue + 0x01) && Stage == 1)
                {
                    Console.WriteLine("Test " + Stage.ToString());
                    WriteValue<int>(base.memoryWatchers.TromellTransition, BaseCutsceneValue + 0xA90);
                    Stage = 2;
                }
            }
        }
    }
}