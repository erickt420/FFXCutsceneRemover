namespace FFXCutsceneRemover;

class UnderwaterRuinsTransition : Transition
{
    public override void Execute(string defaultDescription = "")
    {
        if (MemoryWatchers.UnderwaterRuinsTransition.Current > 0)
        {
            if (Stage == 0)
            {
                base.Execute();

                BaseCutsceneValue = MemoryWatchers.EventFileStart.Current;

                Stage += 1;

            }
            else if (MemoryWatchers.UnderwaterRuinsTransition.Current == BaseCutsceneValue + 0x515B && Stage == 1) //0x584
            {
                WriteValue<int>(MemoryWatchers.UnderwaterRuinsTransition, BaseCutsceneValue + 0x520D); //Possible other values 0x5167 or 0x51FB
                Stage += 1;
            }
            else if (MemoryWatchers.Menu.Current == 0 && MemoryWatchers.Menu.Old == 1 && Stage == 2)
            {
                Transition actorPositions;
                //Position ??? (Rikku)
                actorPositions = new Transition { ForceLoad = false, ConsoleOutput = false, TargetActorIDs = new short[] { 41 }, Target_x = 75.648f, Target_y = 6.306f, Target_z = 16.575f };
                actorPositions.Execute();

                //Position Tros
                actorPositions = new Transition { ForceLoad = false, ConsoleOutput = false, TargetActorIDs = new short[] { 4197 }, Target_y = -100.0f};
                actorPositions.Execute();

                Stage += 1;
            }
        }
    }
}