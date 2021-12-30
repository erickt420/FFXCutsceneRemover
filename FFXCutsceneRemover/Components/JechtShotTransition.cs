using FFXCutsceneRemover.Logging;
using System.Collections.Generic;

namespace FFXCutsceneRemover
{
    class JechtShotTransition : Transition
    {
        static private List<short> CutsceneAltList = new List<short>(new short[] { 70, 71, 75, 76 });
        public override void Execute(string defaultDescription = "")
        {
            int baseAddress = base.memoryWatchers.GetBaseAddress();

            if (base.memoryWatchers.JechtShotTransition.Current > 0)
            {
                
                if (Stage == 0)
                {
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.EventFileStart.Current;
                    DiagnosticLog.Information(BaseCutsceneValue.ToString("X2"));
                    Stage += 1;

                }//*/
                else if (base.memoryWatchers.JechtShotTransition.Current == (BaseCutsceneValue + 0xF3A7) && Stage == 1)
                {
                    DiagnosticLog.Information("Stage: " + Stage.ToString());
                    WriteValue<int>(base.memoryWatchers.JechtShotTransition, BaseCutsceneValue + 0xF9E4);

                    Stage += 1;
                }
                else if (base.memoryWatchers.JechtShotTransition.Current == (BaseCutsceneValue + 0xFAAE) && Stage == 2)
                {
                    DiagnosticLog.Information("Stage: " + Stage.ToString());

                    Transition actorPositions;
                    //Position Tidus
                    actorPositions = new Transition { ForceLoad = false, ConsoleOutput = false, TargetActorIDs = new short[] { 1 }, Target_x = 1.0f, Target_y = -49.99626923f, Target_z = 172.0000153f, Target_var1 = 100 };
                    actorPositions.Execute();

                    //Position Yuna
                    actorPositions = new Transition { ForceLoad = false, ConsoleOutput = false, TargetActorIDs = new short[] { 2 }, Target_x = 22.70000076f, Target_y = -49.99626923f, Target_z = 104.5999985f, Target_var1 = 120 };
                    actorPositions.Execute();

                    Stage += 1;
                }
            }
        }
    }
}