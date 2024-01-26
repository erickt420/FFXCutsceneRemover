using FFXCutsceneRemover.ComponentUtil;
using System.Diagnostics;

namespace FFXCutsceneRemover;

class KilikaPrayTransition : Transition
{
    byte dialogBoxIndex = 1;
    int dialogBoxStructSize = 312;

    public override void Execute(string defaultDescription = "")
    {
        Process process = MemoryWatchers.Process;

        byte[] dialogBoxStruct = process.ReadBytes(MemoryWatchers.DialogueBoxStructs.Address + dialogBoxIndex * dialogBoxStructSize, dialogBoxStructSize);

        byte dialogBoxStatus = dialogBoxStruct[0x01];
        byte dialogBoxSelection = dialogBoxStruct[0x18];

        // Selection is unimportant so just check a selection has been made
        if (dialogBoxStatus == 0x02)
        {
            process.Suspend();
            new Transition { RoomNumber = 96, Storyline = 335, SpawnPoint = 0, Description = "Pray or Stand and Watch", PositionTidusAfterLoad = true, Target_x = -17.879f, Target_z = 43.657f, Target_var1 = 74 }.Execute();
            process.Resume();
        }
    }
}
