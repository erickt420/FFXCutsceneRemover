using FFX_Cutscene_Remover.ComponentUtil;
using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

namespace FFXCutsceneRemover
{
    class FinRightTransition : Transition
    {
        static private List<short> CutsceneAltList = new List<short>(new short[] { 685, 1133, 3603 });
        public override void Execute(string defaultDescription = "")
        {
            int baseAddress = base.memoryWatchers.GetBaseAddress();

            if (base.memoryWatchers.FinsTransition.Current > 0)
            {
                if (Stage == 0)
                {
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.FinsTransition.Current;
                    Console.WriteLine(BaseCutsceneValue.ToString("X2"));

                    Stage += 1;

                }
                else if (base.memoryWatchers.FinsTransition.Current == (BaseCutsceneValue + 0x15D) && Stage == 1)
                {
                    Console.WriteLine("Test " + Stage.ToString());
                    WriteValue<int>(base.memoryWatchers.FinsTransition, BaseCutsceneValue + 0x4B0);

                    Transition actorPositions;
                    //Position Sin
                    actorPositions = new Transition { ForceLoad = false, ConsoleOutput = false, TargetActorID = 4233, Target_x = -1205.0f, Target_y = -440.0f, Target_z = 428.0f };
                    actorPositions.Execute();

                    Stage += 1;
                }
                else if (base.memoryWatchers.FinsTransition.Current == (BaseCutsceneValue + 0x562) && Stage == 2)
                {
                    Console.WriteLine("Test " + Stage.ToString());

                    RoomNumber = 255;
                    Storyline = 3095;
                    ForceLoad = true;
                    base.Execute();
                    ForceLoad = false;

                    //WriteValue<int>(base.memoryWatchers.FinsTransition, BaseCutsceneValue + 0x108C);

                    Stage += 1;
                }
            }
        }
    }
}