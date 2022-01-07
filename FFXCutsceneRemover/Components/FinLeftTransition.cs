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
            Process process = memoryWatchers.Process;

            if (base.memoryWatchers.FinsTransition.Current > 0)
            {
                if (Stage == 0)
                {
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.FinsTransition.Current;

                    Stage += 1;

                }
                else if (base.memoryWatchers.FinsTransition.Current == (BaseCutsceneValue + 0x12C) && Stage == 1)
                {
                    WriteValue<int>(base.memoryWatchers.FinsTransition, BaseCutsceneValue + 0x4B3);
                    Stage += 1;
                }
                else if (base.memoryWatchers.FinsTransition.Current == (BaseCutsceneValue + 0x51E) && Stage == 2)
                {
                    WriteValue<int>(base.memoryWatchers.FinsTransition, BaseCutsceneValue + 0x54F);

                    Transition actorPositions;
                    //Position Sin
                    actorPositions = new Transition { ForceLoad = false, ConsoleOutput = false, TargetActorIDs = new short[] { 4232 }, Target_x = 1207.0f, Target_y = -440.0f, Target_z = 428.0f };
                    actorPositions.Execute();

                    Stage += 1;
                }
                else if (base.memoryWatchers.FinsTransition.Current == (BaseCutsceneValue + 0x5D0) && Stage == 3)
                {
                    process.Suspend();

                    new Transition { RoomNumber = 255 }.Execute();

                    //WriteValue<int>(base.memoryWatchers.FinsTransition, BaseCutsceneValue + 0x607);
                    Stage += 1;

                    process.Resume();
                }
            }
        }
    }
}