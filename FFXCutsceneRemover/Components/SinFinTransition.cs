using FFX_Cutscene_Remover.ComponentUtil;
using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

namespace FFXCutsceneRemover
{
    class SinFinTransition : Transition
    {
        static private List<short> CutsceneAltList = new List<short>(new short[] { 205, 195, 16 });
        public override void Execute(string defaultDescription = "")
        {
            int baseAddress = base.memoryWatchers.GetBaseAddress();
            if (base.memoryWatchers.SinFinTransition.Current > 0)
            {
                if (CutsceneAltList.Contains(base.memoryWatchers.CutsceneAlt.Current) && Stage == 0)
                {
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.SinFinTransition.Current;

                    Stage = 1;

                }
                /* This doesn't seem to work without insane jankiness or crashes (Pre-Boss)
                else if (base.memoryWatchers.SinFinTransition.Current >= (BaseCutsceneValue + 0x76F) && Stage == 1)
                {
                    Console.WriteLine("Test");
                    WriteValue<int>(base.memoryWatchers.SinFinTransition, BaseCutsceneValue + 0xA40);
                    Stage = 2;
                } 
                else if (base.memoryWatchers.SinFinTransition.Current >= (BaseCutsceneValue + 0xB93) && Stage == 99) {
                    Console.WriteLine("Test");
                    WriteValue<int>(base.memoryWatchers.SinFinTransition, BaseCutsceneValue + 0xBF0);
                    Stage = 3;
                }
                */
                else if (base.memoryWatchers.SinFinTransition.Current == (BaseCutsceneValue + 0xCFD) && base.memoryWatchers.HpEnemyA.Current == 200 && Stage == 1) //200 = Sinscale HP
                {
                    Storyline = 272;
                    ForceLoad = false;
                    Description = "Post Sin Fin";
                    base.Execute();
                    WriteValue<int>(base.memoryWatchers.SinFinTransition, BaseCutsceneValue + 0x114A);
                    Stage = 4;
                }
            }
        }
    }
}