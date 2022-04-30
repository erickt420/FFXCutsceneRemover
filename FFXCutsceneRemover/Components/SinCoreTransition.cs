using FFX_Cutscene_Remover.ComponentUtil;
using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

namespace FFXCutsceneRemover
{
    class SinCoreTransition : Transition
    {
        public override void Execute(string defaultDescription = "")
        {
            Process process = memoryWatchers.Process;

            if (Stage == 0)
            {
                process.Suspend();

                new Transition { EncounterMapID = 75, EncounterFormationID = 0, ScriptedBattleFlag1 = 0, ScriptedBattleFlag2 = 1, ScriptedBattleVar1 = 0x00010501, EncounterTrigger = 2, Description = "Sin Core", ForceLoad = false }.Execute();

                Stage += 1;

                process.Resume();
            }
        }
    }
}