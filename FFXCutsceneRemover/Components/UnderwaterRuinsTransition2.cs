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

                    BaseCutsceneValue = base.memoryWatchers.UnderwaterRuinsTransition2.Current;

                    Stage += 1;

                }
                //*/
                else if (base.memoryWatchers.CutsceneAlt.Current == 6843 && Stage == 1)
                {
                    DiagnosticLog.Information("Stage: " + Stage.ToString());
                    WriteValue<int>(base.memoryWatchers.UnderwaterRuinsTransition2, BaseCutsceneValue + 0xDD);
                    Stage += 1;
                }
                //*/
            }
        }
    }
}