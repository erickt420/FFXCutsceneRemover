using FFXCutsceneRemover.ComponentUtil;
using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using FFXCutsceneRemover.Logging;

namespace FFXCutsceneRemover
{
    class KilikaAntechamberTransition : Transition
    {
        public override void Execute(string defaultDescription = "")
        {
            Process process = memoryWatchers.Process;
            int baseAddress = base.memoryWatchers.GetBaseAddress();


            if (Stage == 0)
            {
                base.Execute();

                BaseCutsceneValue = base.memoryWatchers.EventFileStart.Current;

                Stage += 1;
            }
            else if (base.memoryWatchers.KilikaAntechamberTransition.Current == (BaseCutsceneValue + 0X3CDA) && Stage == 1)
            {
                WriteValue<int>(base.memoryWatchers.KilikaAntechamberTransition, BaseCutsceneValue + 0X3DC6);

                Stage += 1;
            }
        }
    }
}