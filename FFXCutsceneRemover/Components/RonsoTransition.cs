using FFXCutsceneRemover.Logging;

namespace FFXCutsceneRemover
{
    class RonsoTransition : Transition
    {
        public override void Execute(string defaultDescription = "")
        {
            int baseAddress = base.memoryWatchers.GetBaseAddress();

            if (base.memoryWatchers.RonsoTransition.Current > 0)
            {
                if (base.memoryWatchers.CutsceneAlt.Current != base.memoryWatchers.CutsceneAlt.Old || base.memoryWatchers.RonsoTransition.Current != base.memoryWatchers.RonsoTransition.Old)
                {
                    DiagnosticLog.Information(base.memoryWatchers.CutsceneAlt.Current.ToString() + " / " + base.memoryWatchers.RonsoTransition.Current.ToString("X2"));
                }
                if (Stage == 0)
                {
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.RonsoTransition.Current;
                    DiagnosticLog.Information(BaseCutsceneValue.ToString("X2"));

                    Stage = 1;

                }
                else if (base.memoryWatchers.RonsoTransition.Current >= (BaseCutsceneValue + 0x01) && Stage == 1)
                {
                    DiagnosticLog.Information("Stage: " + Stage.ToString());
                    WriteValue<int>(base.memoryWatchers.RonsoTransition, BaseCutsceneValue + 0x1698);
                    Stage = 2;
                }
            }
        }
    }
}