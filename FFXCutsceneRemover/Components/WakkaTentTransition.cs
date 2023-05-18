using System.Diagnostics;
using FFXCutsceneRemover.ComponentUtil;
using FFXCutsceneRemover.Logging;

namespace FFXCutsceneRemover
{
    class WakkaTentTransition : Transition
    {
        public override void Execute(string defaultDescription = "")
        {
            Process process = memoryWatchers.Process;

            if (base.memoryWatchers.Dialogue1.Current == 4 && base.memoryWatchers.DialogueBoxOpen.Current == 1 && Stage == 0)
            {
                base.Execute();
                Stage += 1;

            }
            else if (base.memoryWatchers.Dialogue1.Current == 4 && base.memoryWatchers.DialogueBoxOpen.Current == 0 && base.memoryWatchers.DialogueOption.Current == 0 && Stage == 1)
            {
                process.Suspend();

                new Transition { Storyline = 154, Description = "Priest enters Wakka's tent" }.Execute();

                Stage += 1;

                process.Resume();
            }
            else if (base.memoryWatchers.Dialogue1.Current == 4 && base.memoryWatchers.DialogueBoxOpen.Current == 0 && base.memoryWatchers.DialogueOption.Current == 1 && Stage == 1)
            {
                Stage = 0;
            }
        }
    }
}