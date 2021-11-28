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

                    Transition actorPositions;
                    //Position Ammes
                    actorPositions = new Transition { ForceLoad = false, ConsoleOutput = false, TargetActorID = 4255, Target_x = 843.5f, Target_y = -42.0f, Target_z = -126.7f };
                    actorPositions.Execute();

                    WriteValue<int>(base.memoryWatchers.AmmesTransition, BaseCutsceneValue + 0x2AB);// 2AB , 255 , 21A

                    Stage += 1;
                }
                else if (base.memoryWatchers.AmmesTransition.Current == (BaseCutsceneValue + 0x3A1) && Stage == 2)
                {
                    Console.WriteLine("Stage: " + Stage.ToString());

                    ForceLoad = true;
                    SpawnPoint = 1;
                    ConsoleOutput = false;
                    base.Execute();

                    Stage += 1;
                }
                else if (Stage == 3)
                {
                    Console.WriteLine("Stage: " + Stage.ToString());

                    Transition actorPositions;
                    //Position Tidus
                    actorPositions = new Transition { ForceLoad = false, ConsoleOutput = false, TargetActorID = 1, Target_x = 749.636f, Target_y = -41.589f, Target_z = -71.674f };
                    actorPositions.Execute();

                    Stage += 1;
                }
                //*/
            }
        }
    }
}