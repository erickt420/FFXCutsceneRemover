using FFX_Cutscene_Remover.ComponentUtil;
using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

namespace FFXCutsceneRemover
{
    class OblitzeratorTransition : Transition
    {
        static private List<short> CutsceneAltList = new List<short>(new short[] { 2037 });
        public override void Execute(string defaultDescription = "")
        {
            if (base.memoryWatchers.OblitzeratorTransition.Current > 0)
            {
                if (CutsceneAltList.Contains(base.memoryWatchers.CutsceneAlt.Current) && Stage == 0)
                {
                    Formation = new byte[] { 0x00, 0x05, 0x03, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.OblitzeratorTransition.Current;
                    Console.WriteLine(BaseCutsceneValue.ToString("X2"));
                    Stage += 1;

                }
                else if (base.memoryWatchers.OblitzeratorTransition.Current >= (BaseCutsceneValue + 0xEC) && Stage == 1) // 21B , EC
                {
                    Console.WriteLine("Stage: " + Stage.ToString());
                    WriteValue<int>(base.memoryWatchers.OblitzeratorTransition, BaseCutsceneValue + 0x142);// 30A

                    Stage += 1;
                }
                else if (base.memoryWatchers.OblitzeratorTransition.Current == (BaseCutsceneValue + 0x1A0) && Stage == 2) // 21B , EC
                {
                    Console.WriteLine("Stage: " + Stage.ToString());
                    WriteValue<int>(base.memoryWatchers.OblitzeratorTransition, BaseCutsceneValue + 0x30A);// 30A

                    Stage += 1;
                }
                else if (base.memoryWatchers.OblitzeratorTransition.Current == (BaseCutsceneValue + 0x31F) && base.memoryWatchers.HpEnemyA.Current < 6000 && base.memoryWatchers.HpEnemyA.Old == 6000 && Stage == 3)
                {
                    Console.WriteLine("Stage: " + Stage.ToString());
                    WriteValue<int>(base.memoryWatchers.OblitzeratorTransition, BaseCutsceneValue + 0x655);// 
                    Stage += 1;
                }
            }
        }
    }
}