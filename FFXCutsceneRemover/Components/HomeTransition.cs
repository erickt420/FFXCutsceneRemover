using FFXCutsceneRemover.Logging;

namespace FFXCutsceneRemover;

class HomeTransition : Transition
{
    public override void Execute(string defaultDescription = "")
    {
        // If currently in the main hallway and Stage != 3, i.e went in side room or loaded from a save in hallway, get Event File address and set Stage
        if (Stage != 3 && MemoryWatchers.MovementLock.Current == 0x20 && MemoryWatchers.RoomNumber.Current == 280 && MemoryWatchers.Storyline.Current == 1885)
        {
            base.Execute();
            BaseCutsceneValue = MemoryWatchers.EventFileStart.Current;
            Stage = 3;
        }

        // Get Event File Address Data
        if (Stage == 0 && MemoryWatchers.CutsceneAlt.Current == 5043 && MemoryWatchers.Storyline.Current == 1820)
        {
            base.Execute();

            BaseCutsceneValue = MemoryWatchers.EventFileStart.Current;
            Stage += 1;

        }
        // Skip cutscene after walking through door post bombs
        else if (MemoryWatchers.HomeTransition.Current == (BaseCutsceneValue + 0x5FDB) && Stage == 1)
        {
            WriteValue<int>(MemoryWatchers.HomeTransition, BaseCutsceneValue + 0x61CE);
            Stage += 1;
        }
        // Set camera lock value after defeating Dual Horns so the camera faces up the stairs
        else if (MemoryWatchers.BattleState2.Current == 1 && Stage == 2)
        {
            WriteValue<int>(MemoryWatchers.Camera, 0);
            Stage += 1;
        }
        // Skip cutscene before the Chimeras encounter
        else if (MemoryWatchers.HomeTransition.Current == (BaseCutsceneValue + 0x63AA) && Stage == 3)
        {
            // Remove cutscene timing to remove low fps
            WriteValue<byte>(MemoryWatchers.CutsceneTiming, 0);

            // Trigger Chimeras encounter
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

        // If going into a side room set a bogus Stage value until returning to main hallway
        if ((MemoryWatchers.RoomNumber.Current == 275 || MemoryWatchers.RoomNumber.Current == 286) && Stage != 99)
        {
            Stage = 99;
        }
        // Clean Encounter Data after battle in a side room
        else if (MemoryWatchers.EncounterMapID.Current != 0 && MemoryWatchers.BattleState2.Current == 1 && Stage == 99)
        {
            new Transition { EncounterMapID = 0, EncounterFormationID1 = 0, EncounterFormationID2 = 0, ForceLoad = false, /*ConsoleOutput = false,*/ Description = "Clean Encounter Data" }.Execute();
        }
    }
}