using FFXCutsceneRemover.Logging;
using FFX_Cutscene_Remover.ComponentUtil;
using System.Diagnostics;
using System.Collections.Generic;

namespace FFXCutsceneRemover
{
    class KilikaPrayTransition : Transition
    {
        public override void Execute(string defaultDescription = "")
        {
            Process process = memoryWatchers.Process;

            if (base.memoryWatchers.Dialogue1.Current == 13 && base.memoryWatchers.DialogueBoxOpen.Current == 1 && Stage == 0)
            {
                Stage += 1;
            }
            else if (base.memoryWatchers.Dialogue1.Current == 13 && base.memoryWatchers.DialogueBoxOpen.Current == 0 && Stage == 1)
            {
                new Transition { RoomNumber = 96, Storyline = 335, SpawnPoint = 0, Description = "Pray", PositionTidusAfterLoad = true, Target_x = -17.87940216f, Target_z = 43.65753174f, Target_var1 = 74 }.Execute();
                Stage += 1;
            }
        }
    }
}
