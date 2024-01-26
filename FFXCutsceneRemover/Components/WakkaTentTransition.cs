using System.Diagnostics;

using FFXCutsceneRemover.ComponentUtil;

namespace FFXCutsceneRemover;

class WakkaTentTransition : Transition
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
        if (dialogBoxStatus == 0x02 && dialogBoxSelection == 0x00)
        {
            process.Suspend();
            new Transition { Storyline = 154, Description = "Priest enters Wakka's tent", PositionTidusAfterLoad = true, Target_x = 14.700f, Target_y = 1.000f, Target_z = 12.813f, Target_var1 = 33 }.Execute();
            process.Resume();
        }
    }
}