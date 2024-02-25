using System.Collections.Generic;
using System.Diagnostics;

using FFXCutsceneRemover.ComponentUtil;

namespace FFXCutsceneRemover;

class GuiTransition : Transition
{
    static private byte[] GuiFormation = { 0x0, 0x1, 0x2, 0x3, 0x4, 0x5, 0xFF, 0xFF, 0xFF, 0xFF };

    static private List<short> CutsceneAltList2 = new List<short>(new short[] { 4449, 4450 });

    byte dialogBoxIndex = 2;
    int dialogBoxStructSize = 312;

    public override void Execute(string defaultDescription = "")
    {
        Process process = MemoryWatchers.Process;

        byte[] dialogBoxStruct = process.ReadBytes(MemoryWatchers.DialogueBoxStructs.Address + dialogBoxIndex * dialogBoxStructSize, dialogBoxStructSize);

        byte dialogBoxStatus = dialogBoxStruct[0x01];
        byte dialogBoxSelection = dialogBoxStruct[0x18];
        
        if (MemoryWatchers.Dialogue1.Current == 95 && dialogBoxStatus == 0x02 && dialogBoxSelection == 0x01 && Stage == 0)
        {
            process.Suspend();
            
            new Transition
            {
                EncounterMapID = 27,
                EncounterFormationID2 = 0,
                ScriptedBattleFlag1 = 1,
                ScriptedBattleFlag2 = 1,
                ScriptedBattleVar1 = 0x00004501,
                ScriptedBattleVar3 = 0x00000000,
                ScriptedBattleVar4 = 0x00000000,
                EncounterTrigger = 2,
                Description = "Sinspawn Gui 1",
                ForceLoad = false
            }.Execute();

            // Reposition Party Members just off screen to run into battle
            Transition actorPositions = new Transition { ForceLoad = false, ConsoleOutput = false, PartyTarget_x = 427.0f, PartyTarget_z = 3350.0f, PositionPartyOffScreen = true };
            actorPositions.Execute();

            Stage += 1;

            process.Resume();
        }
        else if (MemoryWatchers.BattleState2.Current == 22 && Stage == 1)
        {
            Stage += 1;
        }
        else if (MemoryWatchers.BattleState2.Current == 0 && Stage == 2)
        {
            process.Suspend();

            GuiFormation = process.ReadBytes(MemoryWatchers.Formation.Address, 10);

            new Transition
            {
                RoomNumber = 247,
                Storyline = 865,
                EncounterMapID = 29,
                EncounterFormationID2 = 0,
                ScriptedBattleFlag1 = 0,
                ScriptedBattleFlag2 = 1,
                ScriptedBattleVar1 = 0x00014504,
                ScriptedBattleVar3 = 0x00000129,
                ScriptedBattleVar4 = 0x00000014,
                EncounterTrigger = 2,
                FormationSwitch = formations.PreGui2,
                Description = "Sinspawn Gui 2",
                ForceLoad = false
            }.Execute();

            Stage += 1;

            process.Resume();
        }
        else if (MemoryWatchers.Menu.Current == 1 && Stage == 3)
        {
            process.Suspend();

            new Transition { Formation = GuiFormation, FormationSwitch = formations.PostGui, Description = "Fix Party", ForceLoad = false }.Execute();

            Stage += 1;

            process.Resume();
        }
    }
}
