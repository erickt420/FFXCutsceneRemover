﻿using System.Diagnostics;
using FFXCutsceneRemover.Logging;
using FFX_Cutscene_Remover.ComponentUtil;

namespace FFXCutsceneRemover
{
    class AftermathTransition : Transition
    {
        static private byte[] formation = new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0xFF };
        public override void Execute(string defaultDescription = "")
        {
            Process process = memoryWatchers.Process;

            if (base.memoryWatchers.DjoseTransition.Current > 0)
            {
                if (Stage == 0)
                {
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.DjoseTransition.Current;

                    Stage += 1;

                }
                else if (base.memoryWatchers.DjoseTransition.Current == (BaseCutsceneValue + 0x13D3) && Stage == 1)
                {
                    process.Suspend();

                    new Transition { RoomNumber = 93, Storyline = 960, SpawnPoint = 0, Description = "Tidus talks to Kimahri" }.Execute();

                    Stage += 1;

                    process.Resume();
                }
            }
        }
    }
}