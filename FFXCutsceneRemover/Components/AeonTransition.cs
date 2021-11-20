using FFX_Cutscene_Remover.ComponentUtil;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace FFXCutsceneRemover
{
    class AeonTransition : Transition
    {
        string activeAeon = "";

        private readonly Dictionary<string, Dictionary<string, int>> StandardTransitions = new Dictionary<string, Dictionary<string, int>>()
        {
            {
                "Valefor", new Dictionary<string, int>
                {
                    {"DeathOffset", 0xFB }
                }
            },

            {
                "Ifrit", new Dictionary<string, int>
                {
                    {"DeathOffset", 0xFB }
                }
            },

            {
                "Ixion", new Dictionary<string, int>
                {
                    {"DeathOffset", 0xFB }
                }
            },

            {
                "Shiva", new Dictionary<string, int>
                {
                    {"DeathOffset", 0xFB }
                }
            },

            {
                "Bahamut", new Dictionary<string, int>
                {
                    {"DeathOffset", 0xF5 }
                }
            },

            {
                "Yojimbo", new Dictionary<string, int>
                {
                    {"DeathOffset", 0xFB }
                }
            },

            {
                "Anima", new Dictionary<string, int>
                {
                    {"DeathOffset", 0xFB }
                }
            },

            {
                "Magus", new Dictionary<string, int>
                {
                    {"DeathOffset", 0xFB }
                }
            },
        };

        public override void Execute(string defaultDescription = "")
        {
            int baseAddress = base.memoryWatchers.GetBaseAddress();

            if (base.memoryWatchers.AeonTransition.Current > 0)
            {
                if (activeAeon == "")
                {
                    if (base.memoryWatchers.EnableValefor.Current == 16 & base.memoryWatchers.EnableValefor.Old == 17)
                    {
                        activeAeon = "Valefor";
                    }
                    else if (base.memoryWatchers.EnableIfrit.Current == 16 & base.memoryWatchers.EnableIfrit.Old == 17)
                    {
                        activeAeon = "Ifrit";
                    }
                    else if (base.memoryWatchers.EnableIxion.Current == 16 & base.memoryWatchers.EnableIxion.Old == 17)
                    {
                        activeAeon = "Ixion";
                    }
                    else if (base.memoryWatchers.EnableShiva.Current == 16 & base.memoryWatchers.EnableShiva.Old == 17)
                    {
                        activeAeon = "Shiva";
                    }
                    else if (base.memoryWatchers.EnableBahamut.Current == 16 & base.memoryWatchers.EnableBahamut.Old == 17)
                    {
                        activeAeon = "Bahamut";
                    }
                    else if (base.memoryWatchers.EnableYojimbo.Current == 16 & base.memoryWatchers.EnableYojimbo.Old == 17)
                    {
                        activeAeon = "Yojimbo";
                    }
                    else if (base.memoryWatchers.EnableAnima.Current == 16 & base.memoryWatchers.EnableAnima.Old == 17)
                    {
                        activeAeon = "Anima";
                    }
                    else if (base.memoryWatchers.EnableMagus.Current == 16 & base.memoryWatchers.EnableMagus.Old == 17)
                    {
                        activeAeon = "Magus";
                    }
                }


                if (base.memoryWatchers.CutsceneAlt.Current == 815 && Stage == 0)
                {
                    base.Execute();
                    BaseCutsceneValue = base.memoryWatchers.AeonTransition.Current;
                    Stage = 1;
                    
                }
                else if (base.memoryWatchers.AeonTransition.Current >= (BaseCutsceneValue + 0x00) && Stage == 1)
                {
                    WriteValue<int>(base.memoryWatchers.AeonTransition, BaseCutsceneValue + 0xB4);

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
                        Console.WriteLine(activeAeon + " Dead");
                        activeAeon = "";
                        BaseCutsceneValue2 = base.memoryWatchers.AeonTransition.Current;
                        Stage = 4;
                    }
                    else if (Stage == 4 && base.memoryWatchers.AeonTransition.Current > BaseCutsceneValue2 + 0x90)
                    {
                        BaseCutsceneValue2 = BaseCutsceneValue2 + 0xF5;
                        WriteValue<int>(base.memoryWatchers.AeonTransition, BaseCutsceneValue2);
                        Stage = 5;
                    }
                }
                else if (base.memoryWatchers.AeonTransition.Old <= BaseCutsceneValue + 0x330 && base.memoryWatchers.AeonTransition.Current > BaseCutsceneValue + 0x330 && Stage == 5) {
                    WriteValue<int>(base.memoryWatchers.AeonTransition, BaseCutsceneValue2 + 0x5C);
                    Stage = 3;
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
                //*/
                /*
                if (base.memoryWatchers.CutsceneAlt.Current != base.memoryWatchers.CutsceneAlt.Old || base.memoryWatchers.AeonTransition.Current != base.memoryWatchers.AeonTransition.Old)
                {
                    Console.WriteLine(base.memoryWatchers.CutsceneAlt.Current.ToString() + " / " + base.memoryWatchers.AeonTransition.Current.ToString());
                }
                //*/
            }


        }
    }
}