namespace FFXCutsceneRemover;

class LagoonTransition : Transition
{
    public override void Execute(string defaultDescription = "")
    {
        if (base.memoryWatchers.LagoonTransition2.Current > 0)
        {
            if (Stage == 0)
            {
                base.Execute();

                BaseCutsceneValue = base.memoryWatchers.EventFileStart.Current;
                Stage += 1;

            }
            else if (base.memoryWatchers.LagoonTransition2.Current == (BaseCutsceneValue + 0x3304) && Stage == 1)
            {
                WriteValue<int>(base.memoryWatchers.LagoonTransition2, BaseCutsceneValue + 0x33E6);

                Stage += 1;
            }
        }
    }
}