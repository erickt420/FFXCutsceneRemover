namespace FFXCutsceneRemover;

class ValeforTransition : Transition
{
    public override void Execute(string defaultDescription = "")
    {
        if (Stage == 0)
        {
            base.Execute();

            BaseCutsceneValue = MemoryWatchers.ValeforTransition.Current;
            WriteValue<int>(MemoryWatchers.ValeforTransition, BaseCutsceneValue + 0xAA4);

            Stage += 1;

        }
        else if (Stage == 1 && MemoryWatchers.Menu.Current == 1)
        {
            new Transition { Storyline = 182, RoomNumber = 100, Description = "Tidus joins the Aurochs" }.Execute();

            Stage += 1;

        }
    }
}