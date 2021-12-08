﻿using FFXCutsceneRemover.Logging;

namespace FFXCutsceneRemover
{
    class BikanelTransition : Transition
    {
        public override void Execute(string defaultDescription = "")
        {
            if (base.memoryWatchers.BikanelTransition.Current > 0)
            {
                if (base.memoryWatchers.MovementLock.Current == 0x20 && Stage == 0)
                {
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.BikanelTransition.Current;
                    DiagnosticLog.Information(BaseCutsceneValue.ToString("X2"));
                    Stage += 1;

                }
                else if (base.memoryWatchers.BikanelTransition.Current == (BaseCutsceneValue + 0x11F) && Stage == 1)
                {
                    DiagnosticLog.Information("Stage: " + Stage.ToString());
                    WriteValue<int>(base.memoryWatchers.BikanelTransition, BaseCutsceneValue + 0x214); // 1DC

                    Transition actorPositions;
                    // After the transition Kimahri's model is still visible so we bin him off to Narnia
                    actorPositions = new Transition { ForceLoad = false, ConsoleOutput = false, TargetActorID = 4, Target_x = 1000.0f, Target_y = 0.0f, Target_z = -1000.0f };
                    actorPositions.Execute();

                    Stage += 1;
                }
            }
        }
    }
}