using FFX_Cutscene_Remover.ComponentUtil;
using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

namespace FFXCutsceneRemover
{
    class SahaginTransition : Transition
    {
        public override void Execute(string defaultDescription = "")
        {
            int baseAddress = base.memoryWatchers.GetBaseAddress();

            List<short> CutsceneAltList = new List<short>(new short[] { 780, 347, 2253 });

            if (base.memoryWatchers.SahaginTransition.Current > 0)
            {
                if (CutsceneAltList.Contains(base.memoryWatchers.CutsceneAlt.Current) && Stage == 0)
                {
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.SahaginTransition.Current;
                    Console.WriteLine(BaseCutsceneValue.ToString("X2"));
                    Stage = 1;

                }
                else if (base.memoryWatchers.SahaginTransition.Current == (BaseCutsceneValue + 0xC9) && Stage == 1)
                {
                    Console.WriteLine("Stage: " + Stage.ToString());
                    WriteValue<int>(base.memoryWatchers.SahaginTransition, BaseCutsceneValue + 0x45A);
                    Stage = 2;
                }
                else if (base.memoryWatchers.SahaginTransition.Current == (BaseCutsceneValue + 0x491) && base.memoryWatchers.TidusActionCount.Current == 1 && Stage == 2)
                {
                    Console.WriteLine("Stage: " + Stage.ToString());
                    WriteValue<int>(base.memoryWatchers.SahaginTransition, BaseCutsceneValue + 0x556);
                    Stage = 3;
                }
            }
        }
    }
}