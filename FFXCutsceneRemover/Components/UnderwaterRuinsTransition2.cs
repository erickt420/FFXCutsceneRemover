using FFXCutsceneRemover.Logging;

namespace FFXCutsceneRemover
{
    class UnderwaterRuinsTransition2 : Transition
    {
        public override void Execute(string defaultDescription = "")
        {
            if (base.memoryWatchers.UnderwaterRuinsTransition2.Current > 0)
            {
                if (Stage == 0)
                {
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.EventFileStart.Current;
                    DiagnosticLog.Information(BaseCutsceneValue.ToString("X2"));
                    Stage += 1;

                }
                //*/
                else if (base.memoryWatchers.UnderwaterRuinsTransition2.Current == (BaseCutsceneValue + 0x356E) && Stage == 1)
                {
                    DiagnosticLog.Information("Stage: " + Stage.ToString());
                    WriteValue<int>(base.memoryWatchers.UnderwaterRuinsTransition2, BaseCutsceneValue + 0x35F6);
                    Stage += 1;
                }
                //*/
            }
        }
    }
}