using System.Diagnostics;

using FFXCutsceneRemover.ComponentUtil;

namespace FFXCutsceneRemover;

class ShoopufTransition : Transition
{
    byte dialogBoxIndex = 1;
    int dialogBoxStructSize = 312;

    public override void Execute(string defaultDescription = "")
    {
        Process process = MemoryWatchers.Process;

        byte[] dialogBoxStruct = process.ReadBytes(MemoryWatchers.DialogueBoxStructs.Address + dialogBoxIndex * dialogBoxStructSize, dialogBoxStructSize);

        byte dialogBoxStatus = dialogBoxStruct[0x01];
        byte dialogBoxSelection = dialogBoxStruct[0x18];

        // Check for selection made and the first item has been selected
        if (MemoryWatchers.Dialogue1.Current == 2 && dialogBoxStatus == 0x02 && dialogBoxSelection == 0x01)
        {
            process.Suspend();
            new Transition { RoomNumber = 99, Description = "All Aboards!" }.Execute();
            process.Resume();
        }
    }
}