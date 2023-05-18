using FFXCutsceneRemover.Logging;

namespace FFXCutsceneRemover;

class DefenderXTransition : Transition
{
    public override void Execute(string defaultDescription = "")
    {
        int baseAddress = base.memoryWatchers.GetBaseAddress();

        if (Stage == 0 && base.memoryWatchers.FrameCounterFromLoad.Current < 10)
        {
            base.Execute();

            BaseCutsceneValue = base.memoryWatchers.EventFileStart.Current;
            DiagnosticLog.Information(BaseCutsceneValue.ToString("X8"));
            Stage = 1;

        }
        else if (base.memoryWatchers.DefenderXTransition.Current >= (BaseCutsceneValue + 0x5451) && Stage == 1)
        {
            WriteValue<int>(base.memoryWatchers.DefenderXTransition, BaseCutsceneValue + 0x586F);
            Stage = 2;
        }
    }
}