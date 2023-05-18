namespace FFXCutsceneRemover;

class IsaaruTransition : Transition
{
    public override void Execute(string defaultDescription = "")
    {
        int baseAddress = base.memoryWatchers.GetBaseAddress();

            if (Stage == 0)
            {
                base.Execute();

                BaseCutsceneValue = base.memoryWatchers.EventFileStart.Current;

                Stage += 1;

            }
            else if (base.memoryWatchers.IsaaruTransition.Current == BaseCutsceneValue + 0x7F6C + 0x32 && Stage == 1)
            {
                Formation = new byte[] { 0x01, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
                ConsoleOutput = false;
                FullHeal = true;
                base.Execute();

                WriteValue<int>(base.memoryWatchers.IsaaruTransition, BaseCutsceneValue + 0x7F6C + 0x2F8);
                Stage += 1;
            }
            else if (base.memoryWatchers.IsaaruTransition.Current == (BaseCutsceneValue + 0x7F6C + 0x37A) && Stage == 2)
            {
                WriteValue<int>(base.memoryWatchers.IsaaruTransition, BaseCutsceneValue + 0x7F6C + 0x5C4);
                Stage += 1;
            }
    }
}