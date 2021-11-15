using FFX_Cutscene_Remover.ComponentUtil;
using System;
using System.Diagnostics;
using System.Linq;

namespace FFXCutsceneRemover
{
    class DefenderXTransition : Transition
    {
        public override void Execute(string defaultDescription = "")
        {
            int baseAddress = base.memoryWatchers.GetBaseAddress();

            if (base.memoryWatchers.DefenderXTransition.Current > 0)
            {
                if (Stage == 0)
                {
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.DefenderXTransition.Current;
                    Console.WriteLine(BaseCutsceneValue.ToString("X2"));

                    Stage = 1;

                }
                else if (base.memoryWatchers.DefenderXTransition.Current >= (BaseCutsceneValue + 0x424) && Stage == 1)
                {
                    Console.WriteLine("Pre");

                    WriteValue<int>(base.memoryWatchers.DefenderXTransition, BaseCutsceneValue + 0x842);
                    Stage = 2;
                }
            }
        }
    }
}