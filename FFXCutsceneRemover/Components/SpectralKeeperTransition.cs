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

                if (Stage == 0)
                {
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.SpectralKeeperTransition.Current;
                    Console.WriteLine(BaseCutsceneValue.ToString("X2"));

                    Stage = 1;

                }
                else if (base.memoryWatchers.SpectralKeeperTransition.Current >= (BaseCutsceneValue + 0x2FE) && Stage == 1)
                {
                    WriteValue<int>(base.memoryWatchers.SpectralKeeperTransition, BaseCutsceneValue + 0x3B1);
                    Stage = 2;
                }

            }
        }
    }
}