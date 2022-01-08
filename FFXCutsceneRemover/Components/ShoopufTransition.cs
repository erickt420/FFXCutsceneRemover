using System.Diagnostics;
using FFX_Cutscene_Remover.ComponentUtil;
using FFXCutsceneRemover.Logging;

namespace FFXCutsceneRemover
{
    class ShoopufTransition : Transition
    {
        public override void Execute(string defaultDescription = "")
        {
            Process process = memoryWatchers.Process;

            if (base.memoryWatchers.Dialogue1.Current == 2 && base.memoryWatchers.DialogueBoxOpen.Current == 1 && Stage == 0)
            {
                base.Execute();
                Stage += 1;

            }
            else if (base.memoryWatchers.Dialogue1.Current == 2 && base.memoryWatchers.DialogueBoxOpen.Current == 0 && base.memoryWatchers.DialogueOption.Current == 1 && Stage == 1)
            {
                process.Suspend();

                new Transition { RoomNumber = 99, Description = "All Aboards!" }.Execute();

                Stage += 1;

                process.Resume();
            }/*/
            else if (base.memoryWatchers.Dialogue1.Current == 51 && base.memoryWatchers.DialogueBoxOpen.Current == 0 && base.memoryWatchers.DialogueOption.Current == 1 && Stage == 1)
            {
                new Transition { RoomNumber = 99, Description = "All Aboards!" }.Execute();

                Stage += 1;
            }//*/
            else if (base.memoryWatchers.Dialogue1.Current == 2 && base.memoryWatchers.DialogueBoxOpen.Current == 0 && base.memoryWatchers.DialogueOption.Current == 1 && Stage == 1)
            {
                Stage = 0;
            }
        }
    }
}