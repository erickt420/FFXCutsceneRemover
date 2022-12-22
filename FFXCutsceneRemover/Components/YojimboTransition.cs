using FFX_Cutscene_Remover.ComponentUtil;
using FFXCutsceneRemover.Logging;
using System.Diagnostics;
using System.Linq;

namespace FFXCutsceneRemover
{
    class YojimboTransition : Transition
    {
        public override void Execute(string defaultDescription = "")
        {
            Process process = memoryWatchers.Process;

            if (base.memoryWatchers.TidusZCoordinate.Current > 1655.0f && Stage == 0)
            {
                process.Suspend();

                new Transition
                {
                    EncounterMapID = 63,
                    EncounterFormationID1 = 1,
                    EncounterFormationID2 = 0,
                    ScriptedBattleFlag1 = 0,
                    ScriptedBattleFlag2 = 0,
                    ScriptedBattleVar1 = 0x00000501,
                    ScriptedBattleVar3 = 0x00000000,
                    ScriptedBattleVar4 = 0x00000014,
                    EncounterTrigger = 2,
                    Description = "Lady Ginnem Attacks",
                    ForceLoad = false
                }.Execute();

                Stage += 1;

                process.Resume();
            }
        }
    }
}