using FFX_Cutscene_Remover.ComponentUtil;
using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

namespace FFXCutsceneRemover
{
    class KlikkTransition : Transition
    {
        static private List<short> CutsceneAltList = new List<short>(new short[] { 1137 });
        public override void Execute(string defaultDescription = "")
        {
            if (base.memoryWatchers.BaajIntTransition.Current > 0)
            {
                if (CutsceneAltList.Contains(base.memoryWatchers.CutsceneAlt.Current) && Stage == 0)
                {
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.BaajIntTransition.Current;
                    Console.WriteLine(BaseCutsceneValue.ToString("X2"));
                    Stage += 1;

                }
                else if (base.memoryWatchers.BaajIntTransition.Current == (BaseCutsceneValue + 0x675) && Stage == 1)
                {
                    Console.WriteLine("Stage: " + Stage.ToString());
                    WriteValue<int>(base.memoryWatchers.BaajIntTransition, BaseCutsceneValue + 0x935);//999
                    Stage += 1;
                }
                else if (base.memoryWatchers.BaajIntTransition.Current == (BaseCutsceneValue + 0xA1A) && base.memoryWatchers.HpEnemyA.Current < 1500 && base.memoryWatchers.HpEnemyA.Old == 1500  && Stage == 2)
                {
                    Console.WriteLine("Stage: " + Stage.ToString());
                    WriteValue<int>(base.memoryWatchers.BaajIntTransition, BaseCutsceneValue + 0x1079); //104E
                    Stage += 1;
                }
            }
        }
    }
}