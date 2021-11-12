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
                    WriteValue<int>(base.memoryWatchers.AeonTransition, BaseCutsceneValue + 0x3B4);

                    Stage = 2;
                }
                else if (Stage == 2 && base.memoryWatchers.AeonTransition.Current >= BaseCutsceneValue + 0x4AE) {
                    //WriteValue<int>(base.memoryWatchers.AeonTransition, BaseCutsceneValue + 0x560);

                    Stage = 3;
                }
                else if (base.memoryWatchers.AeonTransition.Old <= BaseCutsceneValue + 0x700 && base.memoryWatchers.AeonTransition.Current > BaseCutsceneValue + 0x700 && Stage == 5)
                {
                    WriteValue<int>(base.memoryWatchers.AeonTransition, BaseCutsceneValue2 + 0x5C);
                    Stage = 3;
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
                        BaseCutsceneValue2 = base.memoryWatchers.AeonTransition.Current;
                        Stage = 4;
                    }
                    else if (Stage == 4 && base.memoryWatchers.AeonTransition.Current > BaseCutsceneValue2 + 0x90)
                    {
                        BaseCutsceneValue2 = BaseCutsceneValue2 + 0xFB;
                        WriteValue<int>(base.memoryWatchers.AeonTransition, BaseCutsceneValue2);
                        Stage = 5;
                    }
                }
                else
                {
                    if (new GameState { HpEnemyA = 0 }.CheckState() && !(new PreviousGameState { HpEnemyA = 0 }.CheckState())) {
                        Console.WriteLine("This is the last time we fight together");
                        BaseCutsceneValue2 = base.memoryWatchers.AeonTransition.Current;
                        Stage = 4;
                    }
                    else if (Stage == 4 && base.memoryWatchers.AeonTransition.Current > BaseCutsceneValue2 + 0x90) {
                        WriteValue<int>(base.memoryWatchers.AeonTransition, BaseCutsceneValue + 0x19D3);
                        Stage = 5;
                    }
                }
            }

                
        }
    }
}