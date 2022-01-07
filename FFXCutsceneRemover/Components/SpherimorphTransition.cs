using System.Collections.Generic;
using FFXCutsceneRemover.Logging;

namespace FFXCutsceneRemover
{
    class SpherimorphTransition : Transition
    {
        public override void Execute(string defaultDescription = "")
        {
            if (base.memoryWatchers.SpherimorphTransition.Current > 0)
            {
                if (base.memoryWatchers.CutsceneAlt.Current == 355 && Stage == 0)
                {
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.EventFileStart.Current;
                    Stage += 1;

                }
                else if (base.memoryWatchers.SpherimorphTransition.Current == (BaseCutsceneValue + 0x3477) && Stage == 1) // 486
                {
                    WriteValue<int>(base.memoryWatchers.SpherimorphTransition, BaseCutsceneValue + 0x35A5);// 1B44

                    Transition actorPositions;
                    //Position Wendigo
                    actorPositions = new Transition { ForceLoad = false, ConsoleOutput = false, TargetActorIDs = new short[] { 4217 }, Target_x = 0.0f, Target_y = -14.0f, Target_z = 140.0f };
                    actorPositions.Execute();

                    Stage += 1;
                }
                else if (base.memoryWatchers.PlayerTurn.Current == 1 && Stage == 2) // 1200 is HP of Guado
                {
                    WriteValue<int>(base.memoryWatchers.SpherimorphTransition, BaseCutsceneValue + 0x36CC);// 1E34
                    Stage += 1;
                }
            }
        }
    }
}