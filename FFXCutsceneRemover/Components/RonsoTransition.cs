using FFX_Cutscene_Remover.ComponentUtil;
using System;
using System.Diagnostics;
using System.Linq;

namespace FFXCutsceneRemover
{
    class RonsoTransition : Transition
    {
        public override void Execute(string defaultDescription = "")
        {
            int baseAddress = base.memoryWatchers.GetBaseAddress();

            if (base.memoryWatchers.RonsoTransition.Current > 0)
            {
                if (Stage == 0)
                {
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.RonsoTransition.Current;
                    Console.WriteLine(BaseCutsceneValue.ToString("X2"));

                    Stage = 1;

                }
                else if (base.memoryWatchers.RonsoTransition.Current >= (BaseCutsceneValue + 0x1345) && Stage == 1)
                {
                    Console.WriteLine("Test");
                    WriteValue<int>(base.memoryWatchers.RonsoTransition, BaseCutsceneValue + 0x1698);
                    Stage = 2;
                }
            }
        }
    }
}