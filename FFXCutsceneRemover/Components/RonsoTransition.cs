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