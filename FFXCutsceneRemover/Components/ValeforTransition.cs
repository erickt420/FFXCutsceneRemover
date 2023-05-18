namespace FFXCutsceneRemover;

class ValeforTransition : Transition
{
    public override void Execute(string defaultDescription = "")
    {
        int baseAddress = base.memoryWatchers.GetBaseAddress();
        if (base.memoryWatchers.ValeforTransition.Current > 0)
        {
            if (Stage == 0)
            {
                base.Execute();

                BaseCutsceneValue = base.memoryWatchers.ValeforTransition.Current;
                WriteValue<int>(base.memoryWatchers.ValeforTransition, BaseCutsceneValue + 0xAA4);

                Stage = 1;

            }
        }
    }
}