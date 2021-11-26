using FFX_Cutscene_Remover.ComponentUtil;
using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
namespace FFXCutsceneRemover
{
    class AmmesTransition : Transition
    {
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
                else if (base.memoryWatchers.AmmesTransition.Current == (BaseCutsceneValue + 0x16F) && Stage == 1)
                {
                    Console.WriteLine("Stage: " + Stage.ToString());
                    WriteValue<int>(base.memoryWatchers.AmmesTransition, BaseCutsceneValue + 0x2B2);

                    Transition actorPositions;
                    //Position Ammes
                    actorPositions = new Transition { ForceLoad = false, ConsoleOutput = false, TargetActorID = 4255, Target_x = 843.5f, Target_y = -42.0f, Target_z = -126.7f };
                    actorPositions.Execute();

                    Stage += 1;
                }
                /*/ Post Ammes skip doesn't seem to work
                else if (base.memoryWatchers.AmmesTransition.Current == (BaseCutsceneValue + 0x33F) && base.memoryWatchers.HpEnemyA.Current < 2400 && base.memoryWatchers.HpEnemyA.Old == 2400 && Stage == 2)
                {
                    Console.WriteLine("Stage: " + Stage.ToString());
                    WriteValue<int>(base.memoryWatchers.AmmesTransition, BaseCutsceneValue + 0x3FD);
                    Stage += 1;
                }
                //*/
            }
        }
    }
}