using FFX_Cutscene_Remover.ComponentUtil;
using System;
using System.Diagnostics;
using System.Linq;

namespace FFXCutsceneRemover
{
    class SpectralKeeperTransition2 : Transition
    {
        public override void Execute(string defaultDescription = "")
        {
            int baseAddress = base.memoryWatchers.GetBaseAddress();

            if (base.memoryWatchers.SpectralKeeperTransition2.Current > 0)
            {
                
                if (base.memoryWatchers.CutsceneAlt.Current == 70 && Stage == 0)
                {
                    base.Execute();
                    
                    BaseCutsceneValue = base.memoryWatchers.SpectralKeeperTransition2.Current;
                    Console.WriteLine(BaseCutsceneValue.ToString("X2"));
                    
                    Stage = 1;

                }
                else if (base.memoryWatchers.SpectralKeeperTransition2.Current >= (BaseCutsceneValue + 0x18C) && Stage == 1)
                {
                    Console.WriteLine("Stage 1");
                    WriteValue<int>(base.memoryWatchers.SpectralKeeperTransition2, BaseCutsceneValue + 0x2E4);
                    Stage = 2;
                }
                else if (base.memoryWatchers.SpectralKeeperTransition2.Current >= (BaseCutsceneValue + 0x30B) && Stage == 2)
                {
                    Console.WriteLine("Stage 2");
                    WriteValue<int>(base.memoryWatchers.SpectralKeeperTransition2, BaseCutsceneValue + 0x492);
                    Stage = 3;
                }
                /*
                if (base.memoryWatchers.CutsceneAlt.Current != base.memoryWatchers.CutsceneAlt.Old || base.memoryWatchers.SpectralKeeperTransition.Current != base.memoryWatchers.SpectralKeeperTransition.Old)
                {
                    Console.WriteLine(base.memoryWatchers.CutsceneAlt.Current.ToString() + " / " + base.memoryWatchers.SpectralKeeperTransition.Current.ToString("X2"));
                }
                //*/
            }
        }
    }
}