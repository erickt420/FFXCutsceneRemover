using FFX_Cutscene_Remover.ComponentUtil;
using System;
using System.Diagnostics;
using System.Linq;

namespace FFXCutsceneRemover
{
    class IfritTransition : Transition
    {
        public override void Execute(string defaultDescription = "")
        {
            int baseAddress = base.memoryWatchers.GetBaseAddress();
            if (base.memoryWatchers.IfritTransition.Current > 0)
            {
                if (Stage == 0)
                {
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.IfritTransition.Current;
                    Console.WriteLine(BaseCutsceneValue.ToString("X2"));

                    Stage = 1;

                }
                else if (base.memoryWatchers.IfritTransition.Current >= (BaseCutsceneValue + 0x34) && Stage == 1)
                {
                    WriteValue<int>(base.memoryWatchers.IfritTransition, BaseCutsceneValue + 0x1E4);

                    Stage = 2;
                }
                else if (base.memoryWatchers.IfritTransition.Current >= (BaseCutsceneValue + 0x1F9) && Stage == 2)
                {
                    Console.WriteLine("Test");
                    Storyline = 348;
                    base.Execute();

                    Stage = 3;
                }
            }
        }
    }
}