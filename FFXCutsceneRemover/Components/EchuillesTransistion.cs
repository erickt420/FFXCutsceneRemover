using FFX_Cutscene_Remover.ComponentUtil;
using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

namespace FFXCutsceneRemover
{
    class EchuillesTransition : Transition
    {
        static private List<short> CutsceneAltList = new List<short>(new short[] { 180, 213, 5079 });
        public override void Execute(string defaultDescription = "")
        {
            int baseAddress = base.memoryWatchers.GetBaseAddress();
            if (base.memoryWatchers.EchuillesTransition.Current > 0)
            {
                if (CutsceneAltList.Contains(base.memoryWatchers.CutsceneAlt.Current) && Stage == 0)
                {
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.EchuillesTransition.Current;

                    Stage = 1;

                }
                else if (base.memoryWatchers.EchuillesTransition.Current >= (BaseCutsceneValue + 0x59) && Stage == 1)
                {
                    WriteValue<int>(base.memoryWatchers.EchuillesTransition, BaseCutsceneValue + 0x38A);
                    Stage = 2;
                }
                else if (base.memoryWatchers.EchuillesTransition.Current >= (BaseCutsceneValue + 0x419) && Stage == 2)
                {
                    WriteValue<int>(base.memoryWatchers.EchuillesTransition, BaseCutsceneValue + 0x43F);
                    Stage = 3;
                }
                else if (base.memoryWatchers.EchuillesTransition.Current == (BaseCutsceneValue + 0x4C6) && base.memoryWatchers.HpEnemyA.Current == 2000 && Stage == 3)
                {
                    Console.WriteLine("Rewards Screen");
                    WriteValue<int>(base.memoryWatchers.EchuillesTransition, BaseCutsceneValue + 0x593);
                    Stage = 4;
                }
                else if (base.memoryWatchers.Gil.Current > base.memoryWatchers.Gil.Old && Stage == 4)
                {
                    Console.WriteLine("Test " + Stage.ToString());
                    Stage = 5;
                }
                else if (base.memoryWatchers.Gil.Current == base.memoryWatchers.Gil.Old && Stage == 5)
                {
                    Console.WriteLine("Test " + Stage.ToString());
                    Menu = 0;
                    Description = "Exit Menu";
                    ForceLoad = false;
                    base.Execute();
                    Stage = 6;
                }
            }
        }
    }
}