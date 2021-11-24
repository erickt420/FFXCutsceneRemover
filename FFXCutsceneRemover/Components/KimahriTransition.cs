using FFX_Cutscene_Remover.ComponentUtil;
using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

namespace FFXCutsceneRemover
{
    class KimahriTransition : Transition
    {
        static private List<short> CutsceneAltList = new List<short>(new short[] { 5, 139, 720 });
        public override void Execute(string defaultDescription = "")
        {
            int baseAddress = base.memoryWatchers.GetBaseAddress();

            if (base.memoryWatchers.KimahriTransition.Current > 0)
            {
                if (CutsceneAltList.Contains(base.memoryWatchers.CutsceneAlt.Current) && Stage == 0)
                {
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.KimahriTransition.Current;
                    Console.WriteLine(BaseCutsceneValue.ToString("X2"));

                    Stage = 1;

                }
                else if (base.memoryWatchers.KimahriTransition.Current >= (BaseCutsceneValue + 0x6C) && Stage == 1)
                {
                    Console.WriteLine("Test " + Stage.ToString());
                    WriteValue<int>(base.memoryWatchers.KimahriTransition, BaseCutsceneValue + 0x145);
                    Stage = 2;
                }
                else if (base.memoryWatchers.KimahriTransition.Current == (BaseCutsceneValue + 0x178) && base.memoryWatchers.HpEnemyA.Current == 750 && Stage == 2)
                {
                    Console.WriteLine("Test " + Stage.ToString());
                    WriteValue<int>(base.memoryWatchers.KimahriTransition, BaseCutsceneValue + 0x75C);
                    Stage = 3;
                }
            }
        }
    }
}