using FFX_Cutscene_Remover.ComponentUtil;
using System;
using System.Diagnostics;
using System.Linq;

namespace FFXCutsceneRemover
{
    class AeonTransition : Transition
    {
        public override void Execute(string defaultDescription = "")
        {
            int baseAddress = base.memoryWatchers.GetBaseAddress();

            if (base.memoryWatchers.AeonTransition.Current > 0)
            {
                if (Stage == 0) {
                    base.Execute();
                    BaseCutsceneValue = base.memoryWatchers.AeonTransition.Current;

                    Stage = 1;
                    
                }
                else if (Stage == 1 && base.memoryWatchers.CutsceneAlt.Current == 815)
                {
                    WriteValue<int>(base.memoryWatchers.AeonTransition, BaseCutsceneValue + 0x560);

                    Stage = 2;
                }
                else if ((base.memoryWatchers.EnableValefor.Current == 17) ||
                         (base.memoryWatchers.EnableIfrit.Current == 17) ||
                         (base.memoryWatchers.EnableIxion.Current == 17) ||
                         (base.memoryWatchers.EnableShiva.Current == 17) ||
                         (base.memoryWatchers.EnableBahamut.Current == 17) ||
                         (base.memoryWatchers.EnableYojimbo.Current == 17) ||
                         (base.memoryWatchers.EnableAnima.Current == 17) ||
                         (base.memoryWatchers.EnableMagus.Current == 17)) {
                    if (new GameState { HpEnemyA = 0 }.CheckState() && !(new PreviousGameState { HpEnemyA = 0 }.CheckState())) {
                        Console.WriteLine("Aeon Dead");
                        WriteValue<int>(base.memoryWatchers.AeonTransition, base.memoryWatchers.AeonTransition.Current + 0xFB);
                        Stage = 2;
                    }
                }
                else
                {
                    if (new GameState { HpEnemyA = 0 }.CheckState() && !(new PreviousGameState { HpEnemyA = 0 }.CheckState())) {
                        Console.WriteLine("This is the last time we fight together");
                        WriteValue<int>(base.memoryWatchers.AeonTransition, BaseCutsceneValue + 0x19D3);
                    }
                }
            }

                
        }
    }
}