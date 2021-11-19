using FFX_Cutscene_Remover.ComponentUtil;
using System;
using System.Diagnostics;
using System.Linq;

namespace FFXCutsceneRemover
{
    class SpectralKeeperTransition : Transition
    {
        public override void Execute(string defaultDescription = "")
        {
            int baseAddress = base.memoryWatchers.GetBaseAddress();
            
            if (base.memoryWatchers.SpectralKeeperTransition.Current > 0)
            {

                if (base.memoryWatchers.CutsceneAlt.Current == 355 && Stage == 0)
                {
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.SpectralKeeperTransition.Current;
                    Console.WriteLine(BaseCutsceneValue.ToString("X2"));

                    Stage = 1;

                }
                else if (base.memoryWatchers.SpectralKeeperTransition.Current >= (BaseCutsceneValue + 0x78) && Stage == 1)
                {
                    Console.WriteLine("Stage 1");
                    WriteValue<int>(base.memoryWatchers.SpectralKeeperTransition, BaseCutsceneValue + 0x197);
                    Stage = 2;
                }
                
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