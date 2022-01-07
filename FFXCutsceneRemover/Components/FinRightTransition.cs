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
            Process process = memoryWatchers.Process;

            if (Stage == 0)
            {
                base.Execute();

                BaseCutsceneValue = base.memoryWatchers.EventFileStart.Current;

                Stage += 1;

            }
            else if (base.memoryWatchers.FinsTransition.Current == (BaseCutsceneValue + 0x5908) && Stage == 1)
            {
                WriteValue<int>(base.memoryWatchers.FinsTransition, BaseCutsceneValue + 0x5BB6);
                WriteValue<int>(base.memoryWatchers.Camera, 1);

                Transition actorPositions;
                //Position Sin
                actorPositions = new Transition { ForceLoad = false, ConsoleOutput = false, TargetActorIDs = new short[] { 4233 }, Target_x = -1205.0f, Target_y = -440.0f, Target_z = 428.0f };
                actorPositions.Execute();

                Stage += 1;
            }
            else if (base.memoryWatchers.FinsTransition.Current == (BaseCutsceneValue + 0x5D0D) && Stage == 3)
            {
                process.Suspend();

                new Transition { RoomNumber = 255, Storyline = 3095 }.Execute();

                Stage += 1;

                process.Resume();
            }
        }
    }
}