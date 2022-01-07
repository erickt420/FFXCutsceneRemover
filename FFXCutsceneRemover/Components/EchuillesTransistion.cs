using FFXCutsceneRemover.Logging;

namespace FFXCutsceneRemover
{
    class EchuillesTransition : Transition
    {
        public override void Execute(string defaultDescription = "")
        {
            if (base.memoryWatchers.EchuillesTransition.Current > 0)
            {
                if (Stage == 0)
                {
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.EventFileStart.Current;
                    DiagnosticLog.Information(BaseCutsceneValue.ToString("X2"));
                    Stage += 1;

                }
                else if (base.memoryWatchers.EchuillesTransition.Current >= (BaseCutsceneValue + 0x20D0) && Stage == 1)
                {
                    WriteValue<int>(base.memoryWatchers.EchuillesTransition, BaseCutsceneValue + 0x248A); // 0x2490

                    Transition actorPositions;

                    //Position Echuilles
                    actorPositions = new Transition { ForceLoad = false, ConsoleOutput = false, TargetActorIDs = new short[] { 4210 }, Target_x = 0.0f, Target_y = -124.0f, Target_z = -40.0f };
                    actorPositions.Execute();

                    Stage += 1;
                }
            }
        }
    }
}