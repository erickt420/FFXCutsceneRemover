namespace FFXCutsceneRemover;

class InsideSinTransition : Transition
{
    public override void Execute(string defaultDescription = "")
    {
        if (base.memoryWatchers.InsideSinTransition.Current > 0)
        {
            if (Stage == 0)
            {
                base.Execute();

                BaseCutsceneValue = base.memoryWatchers.EventFileStart.Current;
                Stage += 1;

            }
            else if (base.memoryWatchers.InsideSinTransition.Current == (BaseCutsceneValue + 0xE65) && Stage == 1)
            {
                WriteValue<int>(base.memoryWatchers.InsideSinTransition, BaseCutsceneValue + 0xF43);
                Stage += 1;
            }
        }
    }
}