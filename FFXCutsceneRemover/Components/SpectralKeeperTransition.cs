using FFX_Cutscene_Remover.ComponentUtil;
using System;
using System.Diagnostics;
using System.Linq;

namespace FFXCutsceneRemover
{
    class SpectralKeeperTransition : Transition
    {
        public override void Execute(string defaultDescription = "")
        {
            int baseAddress = base.memoryWatchers.GetBaseAddress();
            
            if (base.memoryWatchers.SpectralKeeperTransition.Current > 0)
            {

                if (Stage == 0)
                {
                    base.Execute();
                    
                    new Transition { EncounterMapID = 71, EncounterFormationID = 0, ScriptedBattleFlag1 = 0, ScriptedBattleFlag2 = 1, EncounterTrigger = 2, Description = "Spectral Keeper", ForceLoad = false }.Execute();
                    BaseCutsceneValue = base.memoryWatchers.SpectralKeeperTransition.Current;

                    Stage = 1;

                }
                /*/
                else if (base.memoryWatchers.SpectralKeeperTransition.Current >= (BaseCutsceneValue + 0xE4) && Stage == 1)
                {
                    WriteValue<int>(base.memoryWatchers.SpectralKeeperTransition, BaseCutsceneValue + 0x197);
                    Stage = 2;
                }
                else if (base.memoryWatchers.SpectralKeeperTransition.Current >= (BaseCutsceneValue + 0xE1) && Stage == 1) //Edge case when the first calue on CutsceneAlt 355 is missed due to timing
                {
                    WriteValue<int>(base.memoryWatchers.SpectralKeeperTransition, BaseCutsceneValue + 0x194);
                    Stage = 2;
                }
                //*/
            }
        }
    }
}