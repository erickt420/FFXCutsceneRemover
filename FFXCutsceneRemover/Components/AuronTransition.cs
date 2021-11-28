using FFX_Cutscene_Remover.ComponentUtil;
using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
namespace FFXCutsceneRemover
{
    class AuronTransition : Transition
    {
        static private List<short> CutsceneAltList = new List<short>(new short[] { 6663 });
        public override void Execute(string defaultDescription = "")
        {
            int baseAddress = base.memoryWatchers.GetBaseAddress();
            if (base.memoryWatchers.AuronTransition.Current > 0)
            {
                if (CutsceneAltList.Contains(base.memoryWatchers.CutsceneAlt.Current) && Stage == 0)
                {
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.AuronTransition.Current;
                    Console.WriteLine(BaseCutsceneValue.ToString("X2"));
                    Stage = 1;

                }
                /*/ Skipping Tidus standing up doesn't seem to work
                else if (base.memoryWatchers.AuronTransition.Current == (BaseCutsceneValue + 0x271) && Stage == 1)
                {
                    Console.WriteLine("Stage: " + Stage.ToString());
                    WriteValue<int>(base.memoryWatchers.AuronTransition, BaseCutsceneValue + 0x306);
                    Stage += 1;
                }
                //*/
                else if (base.memoryWatchers.AuronTransition.Current == (BaseCutsceneValue + 0x34F) && Stage == 1)
                {
                    Console.WriteLine("Stage: " + Stage.ToString());
                    WriteValue<int>(base.memoryWatchers.AuronTransition, BaseCutsceneValue + 0x40A);
                    Stage += 1;
                }
            }
        }
    }
}