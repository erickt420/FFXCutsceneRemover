using FFXCutsceneRemover.Logging;

namespace FFXCutsceneRemover
{
    class UnderwaterRuinsTransition2 : Transition
    {
        public override void Execute(string defaultDescription = "")
        {
            if (Stage == 0)
            {
                base.Execute();

                BaseCutsceneValue = base.memoryWatchers.EventFileStart.Current;
                DiagnosticLog.Information($"BaseCutsceneValue: {BaseCutsceneValue}");
                Stage += 1;

            }
            else if (base.memoryWatchers.UnderwaterRuinsTransition2.Current >= (BaseCutsceneValue + 0x3870) && Stage == 1)
            {
                WriteValue<int>(base.memoryWatchers.UnderwaterRuinsTransition2, BaseCutsceneValue + 0x3AB2);
                DiagnosticLog.Information("Execute Skip");
                Stage += 1;
            }
        }
    }
}