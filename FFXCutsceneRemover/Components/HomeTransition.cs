namespace FFXCutsceneRemover;

class HomeTransition : Transition
{
    public override void Execute(string defaultDescription = "")
    {
        if (Stage == 0 && base.memoryWatchers.CutsceneAlt.Current == 5043)
        {
            base.Execute();

            BaseCutsceneValue = base.memoryWatchers.EventFileStart.Current;
            Stage += 1;

        }
        else if (base.memoryWatchers.HomeTransition.Current == (BaseCutsceneValue + 0x5FDB) && Stage == 1)
        {
            WriteValue<int>(base.memoryWatchers.HomeTransition, BaseCutsceneValue + 0x61CE);
            Stage += 1;
        }
        else if (base.memoryWatchers.BattleState2.Current == 1 && Stage == 2)
        {
            WriteValue<int>(base.memoryWatchers.Camera, 0);
            Stage += 1;
        }
        else if (base.memoryWatchers.HomeTransition.Current == (BaseCutsceneValue + 0x63AA) && Stage == 3)
        {
            WriteValue<byte>(base.memoryWatchers.CutsceneTiming, 0);

            new Transition
            {
                EncounterMapID = 87,
                EncounterFormationID2 = 3,
                ScriptedBattleFlag1 = 0,
                ScriptedBattleFlag2 = 0,
                ScriptedBattleVar1 = 0x00000500,
                ScriptedBattleVar3 = 0x00000000,
                ScriptedBattleVar4 = 0x00000000,
                EncounterTrigger = 1,
                Description = "Home Chimeras",
                ForceLoad = false
            }.Execute();

            Stage += 1;
        }

        if (base.memoryWatchers.RoomNumber.Current == 275 || base.memoryWatchers.RoomNumber.Current == 286)
        {
            Stage = 99;
        }
        else if (base.memoryWatchers.RoomNumber.Current == 280 && Stage == 99)
        {
            BaseCutsceneValue = base.memoryWatchers.EventFileStart.Current;
            Stage = 3;
        }
    }
}