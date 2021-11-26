using FFX_Cutscene_Remover.ComponentUtil;
using System;
using System.Diagnostics;
using System.Linq;

namespace FFXCutsceneRemover
{
    class GeneauxTransition : Transition
    {
        public override void Execute(string defaultDescription = "")
        {
            int baseAddress = base.memoryWatchers.GetBaseAddress();
            if (base.memoryWatchers.GeneauxTransition.Current > 0)
            {
                if (Stage == 0)
                {
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.GeneauxTransition.Current;

                    Stage = 1;

                }
                else if (base.memoryWatchers.GeneauxTransition.Current == (BaseCutsceneValue + 0x4D8) && Stage == 1)
                {
                    WriteValue<int>(base.memoryWatchers.GeneauxTransition, BaseCutsceneValue + 0x6B8);
                    Stage = 2;
                }
                else if (base.memoryWatchers.GeneauxTransition.Current == (BaseCutsceneValue + 0x6F7) && base.memoryWatchers.HpEnemyA.Current == 0 && Stage == 2)
                {
                    WriteValue<int>(base.memoryWatchers.GeneauxTransition, BaseCutsceneValue + 0x946);
                    Stage = 3;
                }
            }
        }
    }
}