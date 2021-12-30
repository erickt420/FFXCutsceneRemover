using FFXCutsceneRemover.Logging;

namespace FFXCutsceneRemover
{
    class IfritTransition : Transition
    {
        public override void Execute(string defaultDescription = "")
        {
            int baseAddress = base.memoryWatchers.GetBaseAddress();
            if (base.memoryWatchers.IfritTransition.Current > 0)
            {
                if (Stage == 0)
                {
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.IfritTransition.Current;
                    Stage = 1;

                }
                else if (base.memoryWatchers.IfritTransition.Current >= (BaseCutsceneValue + 0x34) && Stage == 1)
                {
                    DiagnosticLog.Information("Stage: " + Stage.ToString());
                    WriteValue<int>(base.memoryWatchers.IfritTransition, BaseCutsceneValue + 0x1E4);

                    Stage = 2;
                }
            }
        }
    }
}