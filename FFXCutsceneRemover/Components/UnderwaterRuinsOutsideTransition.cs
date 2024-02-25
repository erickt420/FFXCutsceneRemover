namespace FFXCutsceneRemover;

class UnderwaterRuinsOutsideTransition : Transition
{
    public override void Execute(string defaultDescription = "")
    {
        if (Stage == 0)
        {
            base.Execute();

            BaseCutsceneValue = MemoryWatchers.EventFileStart.Current;
            Stage += 1;

        }
        else if (MemoryWatchers.UnderwaterRuinsOutsideTransition.Current >= (BaseCutsceneValue + 0x3870) && Stage == 1)
        {
            WriteValue<int>(MemoryWatchers.UnderwaterRuinsOutsideTransition, BaseCutsceneValue + 0x3AB2);
            Stage += 1;
        }
    }
}