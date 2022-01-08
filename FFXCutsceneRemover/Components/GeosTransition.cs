using FFX_Cutscene_Remover.ComponentUtil;
using System.Diagnostics;
using System.Collections.Generic;
using FFXCutsceneRemover.Logging;

namespace FFXCutsceneRemover
{
    class GeosTransition : Transition
    {
        static private List<short> CutsceneAltList = new List<short>(new short[] { 1137 });
        public override void Execute(string defaultDescription = "")
        {
            Process process = memoryWatchers.Process;

            if (Stage == 0)
            {
                base.Execute();

                BaseCutsceneValue = base.memoryWatchers.EventFileStart.Current;
                Stage += 1;

            }
            else if (base.memoryWatchers.GeosTransition.Current == (BaseCutsceneValue + 0xA4F8) && Stage == 1)
            {
                process.Suspend();
                WriteValue<int>(base.memoryWatchers.GeosTransition, BaseCutsceneValue + 0xA7D5); // 0xA992

                Transition actorPositions;
                //Position Tidus
                actorPositions = new Transition { ForceLoad = false, ConsoleOutput = false, TargetActorIDs = new short[] { 1 }, Target_x = 0.0f, Target_y = -50.0f, Target_z = -20.0f };
                actorPositions.Execute();

                Stage += 1;

                process.Resume();
            }
            else if (base.memoryWatchers.PlayerTurn.Current == 1 && Stage == 2)
            {
                process.Suspend();
                WriteValue<int>(base.memoryWatchers.GeosTransition, BaseCutsceneValue + 0xAE02);// D90
                Stage += 1;

                process.Resume();
            }
        }
    }
}