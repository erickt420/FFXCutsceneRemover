using FFXCutsceneRemover.ComponentUtil;
using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using FFXCutsceneRemover.Logging;

namespace FFXCutsceneRemover
{
    class RinTransition : Transition
    {
        static private List<short> CutsceneAltList = new List<short>(new short[] { 16, 1047, 210, 130 });

        public override void Execute(string defaultDescription = "")
        {
            Process process = base.memoryWatchers.Process;

            if (base.memoryWatchers.RinTransition.Current > 0)
            {
                if (base.memoryWatchers.MovementLock.Current == 0x20 && Stage == 0)
                {
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.RinTransition.Current;
                    Stage += 1;

                }
                else if (base.memoryWatchers.RinTransition.Current >= (BaseCutsceneValue + 0x271) && Stage == 1)
                {
                    WriteValue<int>(base.memoryWatchers.RinTransition, BaseCutsceneValue + 0x466);

                    Stage += 1;
                }
                else if (base.memoryWatchers.Dialogue1.Current == 92 && Stage == 2)
                {
                    WriteValue<int>(base.memoryWatchers.RinTransition, BaseCutsceneValue + 0x58B);

                    Stage += 1;
                }
                else if (base.memoryWatchers.RinTransition.Current == (BaseCutsceneValue + 0x5B1) && Stage == 3)
                {
                    process.Suspend();

                    new Transition { Storyline = 767, SpawnPoint = 0 }.Execute();

                    Stage += 1;

                    process.Resume();
                }
            }
        }
    }
}