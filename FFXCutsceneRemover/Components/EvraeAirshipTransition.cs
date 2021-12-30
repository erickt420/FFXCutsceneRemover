using FFXCutsceneRemover.Logging;

namespace FFXCutsceneRemover
{
    class EvraeAirshipTransition : Transition
    {
        public override void Execute(string defaultDescription = "")
        {
            if (Stage == 0)
            {
                base.Execute();

                BaseCutsceneValue = base.memoryWatchers.EventFileStart.Current;
                DiagnosticLog.Information(BaseCutsceneValue.ToString("X2"));
                Stage += 1;

            }
            else if (base.memoryWatchers.EvraeAirshipTransition.Current == (BaseCutsceneValue + 0x15FFC) && Stage == 1)
            {
                DiagnosticLog.Information("Stage: " + Stage.ToString());
                WriteValue<int>(base.memoryWatchers.EvraeAirshipTransition, BaseCutsceneValue + 0x16217);
                Stage += 1;
            }
            else if (base.memoryWatchers.Gil.Current > base.memoryWatchers.Gil.Old && Stage == 2)
            {
                Stage += 1;
            }
            else if (base.memoryWatchers.Gil.Current == base.memoryWatchers.Gil.Old && Stage == 3)
            {
                Menu = 0;
                Description = "Exit Menu";
                ForceLoad = false;
                base.Execute();
                Stage += 1;
            }
        }
    }
}