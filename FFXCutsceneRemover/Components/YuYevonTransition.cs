using FFXCutsceneRemover.ComponentUtil;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using FFXCutsceneRemover.Logging;

namespace FFXCutsceneRemover
{
    class YuYevonTransition : Transition
    {
        private string activeAeon = "";

        private readonly Dictionary<string, Dictionary<string, int>> AeonOffsets = new Dictionary<string, Dictionary<string, int>>()
        {
            {
                "Valefor", new Dictionary<string, int>
                {
                    {"BattleOffset", 0x6DB5 },
                    {"DeathOffset", 0x6DEE },
                    {"NextSummonOffset", 0x6EB3 },
                    {"ActorID", 0x10A3 }
                }
            },

            {
                "Ifrit", new Dictionary<string, int>
                {
                    {"BattleOffset", 0x6F60 },
                    {"DeathOffset", 0x6F99 },
                    {"NextSummonOffset", 0x705B },
                    {"ActorID", 0x10A4 }
                }
            },

            {
                "Ixion", new Dictionary<string, int>
                {
                    {"BattleOffset", 0x7112 },
                    {"DeathOffset", 0x714B },
                    {"NextSummonOffset", 0x7210 },
                    {"ActorID", 0x10A5 }
                }
            },

            {
                "Shiva", new Dictionary<string, int>
                {
                    {"BattleOffset", 0x72BD },
                    {"DeathOffset", 0x72F6 },
                    {"NextSummonOffset", 0x73B8 },
                    {"ActorID", 0x10A6 }
                }
            },

            {
                "Bahamut", new Dictionary<string, int>
                {
                    {"BattleOffset", 0x7468 },
                    {"DeathOffset", 0x74A1 },
                    {"NextSummonOffset", 0x7560},
                    {"ActorID", 0x10A7 }
                }
            },

            {
                "Anima", new Dictionary<string, int>
                {
                    {"BattleOffset", 0x760D },
                    {"DeathOffset", 0x7646 },
                    {"NextSummonOffset", 0x770B},
                    {"ActorID", 0x10A8 }
                }
            },

            {
                "Yojimbo", new Dictionary<string, int>
                {
                    {"BattleOffset", 0x77B8 },
                    {"DeathOffset", 0x77F1 },
                    {"NextSummonOffset", 0x78B6},
                    {"ActorID", 0x10A9 }
                }
            },

            {
                "Magus Sisters", new Dictionary<string, int>
                {
                    {"BattleOffset", 0x799B },
                    {"DeathOffset", 0x79D4 },
                    {"NextSummonOffset", 0x7AE1},
                    {"ActorID", 0x10A3 }
                }
            },
        };

        public override void Execute(string defaultDescription = "")
        {
            if (activeAeon == "")
            {
                if (base.memoryWatchers.EnableValefor.Current == 16 & base.memoryWatchers.EnableValefor.Old == 17)
                {
                    activeAeon = "Valefor";
                    DiagnosticLog.Information(activeAeon + " Summoned");
                }
                else if (base.memoryWatchers.EnableIfrit.Current == 16 & base.memoryWatchers.EnableIfrit.Old == 17)
                {
                    activeAeon = "Ifrit";
                    DiagnosticLog.Information(activeAeon + " Summoned");
                }
                else if (base.memoryWatchers.EnableIxion.Current == 16 & base.memoryWatchers.EnableIxion.Old == 17)
                {
                    activeAeon = "Ixion";
                    DiagnosticLog.Information(activeAeon + " Summoned");
                }
                else if (base.memoryWatchers.EnableShiva.Current == 16 & base.memoryWatchers.EnableShiva.Old == 17)
                {
                    activeAeon = "Shiva";
                    DiagnosticLog.Information(activeAeon + " Summoned");
                }
                else if (base.memoryWatchers.EnableBahamut.Current == 16 & base.memoryWatchers.EnableBahamut.Old == 17)
                {
                    activeAeon = "Bahamut";
                    DiagnosticLog.Information(activeAeon + " Summoned");
                }
                else if (base.memoryWatchers.EnableAnima.Current == 16 & base.memoryWatchers.EnableAnima.Old == 17)
                {
                    activeAeon = "Anima";
                    DiagnosticLog.Information(activeAeon + " Summoned");
                }
                else if (base.memoryWatchers.EnableYojimbo.Current == 16 & base.memoryWatchers.EnableYojimbo.Old == 17)
                {
                    activeAeon = "Yojimbo";
                    DiagnosticLog.Information(activeAeon + " Summoned");
                }
                else if (base.memoryWatchers.EnableMagus.Current == 16 & base.memoryWatchers.EnableMagus.Old == 17)
                {
                    activeAeon = "Magus Sisters";
                    DiagnosticLog.Information(activeAeon + " Summoned");
                }
            }


            if (Stage == 0)
            {
                base.Execute();
                BaseCutsceneValue = base.memoryWatchers.EventFileStart.Current;
                Stage += 1;
                    
            }
            else if (base.memoryWatchers.AeonTransition.Current >= (BaseCutsceneValue + 0x69BD) && Stage == 1) // 0x68A4
            {
                WriteValue<int>(base.memoryWatchers.AeonTransition, BaseCutsceneValue + 0x6A9F); // 0x6A90

                Stage += 1;
            }
            else if (activeAeon != "")
            {
                if (new GameState { HpEnemyA = 0 }.CheckState() && !(new PreviousGameState { HpEnemyA = 0 }.CheckState()))
                {
                    DiagnosticLog.Information(activeAeon + " Dead");
                    Stage += 1;
                }
                else if (Stage == 3 && base.memoryWatchers.AeonTransition.Current == BaseCutsceneValue + AeonOffsets[activeAeon]["DeathOffset"])
                {
                    WriteValue<int>(base.memoryWatchers.AeonTransition, BaseCutsceneValue + AeonOffsets[activeAeon]["NextSummonOffset"]);
                    activeAeon = "";
                    Stage -= 1;
                }
            }
            else if (base.memoryWatchers.AeonTransition.Current == (BaseCutsceneValue + 0x7B30))
            {
                WriteValue<int>(base.memoryWatchers.AeonTransition, BaseCutsceneValue + 0x86D0); // 0x85EA
                WriteValue<short>(base.memoryWatchers.Storyline, 3380);
            }
        }
    }
}