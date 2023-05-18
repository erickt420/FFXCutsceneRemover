namespace FFXCutsceneRemover;

class SpectralKeeperTransition2 : Transition
{
    public override void Execute(string defaultDescription = "")
    {
        int baseAddress = base.memoryWatchers.GetBaseAddress();

        if (base.memoryWatchers.SpectralKeeperTransition2.Current > 0)
        {
            
            if (Stage == 0)
            {
                base.Execute();
                
                BaseCutsceneValue = base.memoryWatchers.EventFileStart.Current;
                Stage += 1;

            }
            else if (base.memoryWatchers.SpectralKeeperTransition2.Current == (BaseCutsceneValue + 0x672A) && Stage == 1)
            {
                WriteValue<int>(base.memoryWatchers.SpectralKeeperTransition2, BaseCutsceneValue + 0x6882);
                Stage += 1;
            }
            else if (base.memoryWatchers.SpectralKeeperTransition2.Current == (BaseCutsceneValue + 0x6888) && Stage == 2)
            {
                WriteValue<int>(base.memoryWatchers.SpectralKeeperTransition2, BaseCutsceneValue + 0x6A33);
                Stage += 1;
            }
        }
    }
}