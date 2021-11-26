using FFX_Cutscene_Remover.ComponentUtil;
using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
namespace FFXCutsceneRemover
{
    class TankerTransition : Transition
    {
        static private List<short> CutsceneAltList = new List<short>(new short[] { 6609, 210, 70 });
        public override void Execute(string defaultDescription = "")
        {
            int baseAddress = base.memoryWatchers.GetBaseAddress();
            if (base.memoryWatchers.AmmesTransition.Current > 0)
            {
                if (base.memoryWatchers.TidusActionCount.Current == 1 && Stage == 0)
                {
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.AmmesTransition.Current;
                    Console.WriteLine(BaseCutsceneValue.ToString("X2"));
                    Stage = 1;

                }
                else if (base.memoryWatchers.AmmesTransition.Current == (BaseCutsceneValue + 0x17F) && Stage == 1)
                {
                    Console.WriteLine("Stage: " + Stage.ToString());
                    WriteValue<int>(base.memoryWatchers.AmmesTransition, BaseCutsceneValue + 0x358);
                    Stage += 1;
                }
            }
        }
    }
}