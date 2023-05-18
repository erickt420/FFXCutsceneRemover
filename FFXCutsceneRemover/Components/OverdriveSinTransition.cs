namespace FFXCutsceneRemover;

class OverdriveSinTransition : Transition
{
    public override void Execute(string defaultDescription = "")
    {
        if (base.memoryWatchers.FrameCounterFromLoad.Current >= 10 && Stage == 0)
        {
            base.Execute();

            BaseCutsceneValue = base.memoryWatchers.EventFileStart.Current;
            Stage += 1;

        }
        else if (base.memoryWatchers.OverdriveSinTransition.Current >= (BaseCutsceneValue + 0x5BF8) && Stage == 1)
        {
            WriteValue<int>(base.memoryWatchers.OverdriveSinTransition, BaseCutsceneValue + 0x5E2E);
            Stage += 1;
        }
        else if (base.memoryWatchers.BattleState2.Current == 1 && Stage == 2)
        {
            WriteValue<int>(base.memoryWatchers.OverdriveSinTransition, BaseCutsceneValue + 0x5F79);
            Stage += 1;
        }
    }
}