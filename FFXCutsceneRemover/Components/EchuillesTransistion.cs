using FFX_Cutscene_Remover.ComponentUtil;
using System;
using System.Diagnostics;
using System.Linq;

namespace FFXCutsceneRemover
{
    class EchuillesTransition : Transition
    {
        public override void Execute(string defaultDescription = "")
        {
            int baseAddress = base.memoryWatchers.GetBaseAddress();
            if (base.memoryWatchers.EchuillesTransition.Current > 0)
            {
                if (Stage == 0)
                {
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.EchuillesTransition.Current;

                    Stage = 1;

                }
                else if (base.memoryWatchers.EchuillesTransition.Current >= (BaseCutsceneValue + 0x33) && Stage == 1)
                {
                    WriteValue<int>(base.memoryWatchers.EchuillesTransition, BaseCutsceneValue + 0x35E);
                    Stage = 2;
                }
                else if (base.memoryWatchers.EchuillesTransition.Current >= (BaseCutsceneValue + 0x413) && Stage == 2)
                {
                    WriteValue<int>(base.memoryWatchers.EchuillesTransition, BaseCutsceneValue + 0x49A);
                    Stage = 3;
                }
                else if (base.memoryWatchers.EchuillesTransition.Current >= (BaseCutsceneValue + 0x532) && Stage == 3)
                {
                    Console.WriteLine("Rewards Screen");
                    WriteValue<int>(base.memoryWatchers.EchuillesTransition, BaseCutsceneValue + 0x593);
                    Stage = 4;
                }
            }
        }
    }
}