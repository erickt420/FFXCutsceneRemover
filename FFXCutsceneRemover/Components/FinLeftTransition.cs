using FFX_Cutscene_Remover.ComponentUtil;
using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

namespace FFXCutsceneRemover
{
    class FinLeftTransition : Transition
    {
        static private List<short> CutsceneAltList = new List<short>(new short[] { 1131 });
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

                    Stage = 1;

                }
                else if (base.memoryWatchers.FinsTransition.Current == (BaseCutsceneValue + 0x12C) && Stage == 1)
                {
                    Console.WriteLine("Test " + Stage.ToString());
                    WriteValue<int>(base.memoryWatchers.FinsTransition, BaseCutsceneValue + 0x4B3);
                    Stage = 2;
                }
                else if (base.memoryWatchers.FinsTransition.Current == (BaseCutsceneValue + 0x51E) && Stage == 2)
                {
                    Console.WriteLine("Test " + Stage.ToString());
                    WriteValue<int>(base.memoryWatchers.FinsTransition, BaseCutsceneValue + 0x54F);

                    Transition actorPositions;
                    //Position Sin
                    actorPositions = new Transition { ForceLoad = false, ConsoleOutput = false, TargetActorID = 4232, Target_x = 1207.0f, Target_y = -440.0f, Target_z = 428.0f };
                    actorPositions.Execute();

                    Stage = 3;
                }
                else if (base.memoryWatchers.FinsTransition.Current == (BaseCutsceneValue + 0x5D0) && Stage == 3)
                {
                    Console.WriteLine("Test " + Stage.ToString());

                    RoomNumber = 255;
                    ForceLoad = true;
                    base.Execute();
                    ForceLoad = false;

                    //WriteValue<int>(base.memoryWatchers.FinsTransition, BaseCutsceneValue + 0x607);
                    Stage = 4;
                }
            }
        }
    }
}