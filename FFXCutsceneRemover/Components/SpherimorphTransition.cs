using System.Collections.Generic;
using FFXCutsceneRemover.Logging;

namespace FFXCutsceneRemover
{
    class SpherimorphTransition : Transition
    {
        static private List<short> CutsceneAltList = new List<short>(new short[] { 1137 });
        public override void Execute(string defaultDescription = "")
        {
            if (base.memoryWatchers.SpherimorphTransition.Current > 0)
            {
                if (base.memoryWatchers.MovementLock.Current == 0x20 && Stage == 0)
                {
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.SpherimorphTransition.Current;
                    DiagnosticLog.Information(BaseCutsceneValue.ToString("X2"));
                    Stage += 1;

                }
                else if (base.memoryWatchers.SpherimorphTransition.Current == (BaseCutsceneValue + 0x3B) && Stage == 1) // 486
                {
                    DiagnosticLog.Information("Stage: " + Stage.ToString());
                    WriteValue<int>(base.memoryWatchers.SpherimorphTransition, BaseCutsceneValue + 0x169);// 1B44

                    Transition actorPositions;
                    //Position Wendigo
                    actorPositions = new Transition { ForceLoad = false, ConsoleOutput = false, TargetActorID = 4217, Target_x = 0.0f, Target_y = -14.0f, Target_z = 140.0f };
                    actorPositions.Execute();

                    Stage += 1;
                }
                else if (base.memoryWatchers.SpherimorphTransition.Current == (BaseCutsceneValue + 0x1D3) && base.memoryWatchers.HpEnemyA.Current < 12000 && base.memoryWatchers.HpEnemyA.Old == 12000 && Stage == 2) // 1200 is HP of Guado
                {
                    DiagnosticLog.Information("Stage: " + Stage.ToString());
                    WriteValue<int>(base.memoryWatchers.SpherimorphTransition, BaseCutsceneValue + 0x290);// 1E34
                    Stage += 1;
                }
            }
        }
    }
}