using System.Collections.Generic;

namespace FFXCutsceneRemover.Resources
{
    /* This class contains most of the transitions. Transitions added here are automatically evalutated in the main loop. */
    static class Transitions
    {
        public static readonly Dictionary<GameState, Transition> StandardTransitions = new Dictionary<GameState, Transition>()
        {
            // SPECIAL
            { new GameState { Input = 2304, BattleState = 10 },  new Transition { BattleState = 778, ForceLoad = false } },                     // End any battle by holding start + select
            { new GameState { RoomNumber = 348 }, new Transition { RoomNumber = 23 } },                                                         // Skip Intro
            // START OF ZANARKAND
            { new GameState { RoomNumber = 132, Storyline = 0 }, new Transition { RoomNumber = 368, Storyline = 3, SpawnPoint = 0 } },          // Beginning
            { new GameState { RoomNumber = 368, Storyline = 3, Menu = 1 }, new Transition { FangirlsOrKidsSkip = 3 , ForceLoad = false } },      // Fangirls or kids, whichever Tidus talks to second
            { new GameState { RoomNumber = 368, Storyline = 4 }, new Transition { RoomNumber = 376, Storyline = 4, SpawnPoint = 0 } },          // Tidus leaves fans
            { new GameState { RoomNumber = 376, Storyline = 4 }, new Transition { RoomNumber = 376, Storyline = 5, SpawnPoint = 0 } },          // Tidus looks at Jecht sign
            { new GameState { RoomNumber = 371, Storyline = 5 }, new Transition { RoomNumber = 370, Storyline = 7, SpawnPoint = 0 } },          // Tidus navigates through the crowd and Blitzball FMV
                                                            // Tidus sees Auron
            { new GameState { RoomNumber = 366, Storyline = 8 }, new Transition { RoomNumber = 389, Storyline = 12, SpawnPoint = 0 } },         // Tidus sees the fayth and follows Auron
            //{ new GameState { RoomNumber = 389, Storyline = 14 }, new Transition { RoomNumber = 389, Storyline = 15, SpawnPoint = 0 } },        // Sinspawn Ammes? - NOT WORKING - This CS ends with a battle.
            { new GameState { RoomNumber = 367, Storyline = 16 }, new Transition { RoomNumber = 367, Storyline = 18, SpawnPoint = 0 } },        // Tidus sees Jecht sign again
                                                            // Pre-Tanker
            { new GameState { RoomNumber = 367, Storyline = 19 }, new Transition { RoomNumber = 367, Storyline = 20, SpawnPoint = 0 } },        // Tidus and Auron run as bridge explodes
            { new GameState { RoomNumber = 367, Storyline = 20 }, new Transition { RoomNumber = 384, Storyline = 20, SpawnPoint = 0 } },        // "This is your story"
                                                            // Tidus wakes up inside Sin
            { new GameState { RoomNumber = 384, Storyline = 20, State = 0 }, new Transition { RoomNumber = 385 } },                             // Tidus swimming looking at himself as a child
            { new GameState { RoomNumber = 385, Storyline = 20 }, new Transition { RoomNumber = 48, Storyline = 30, SpawnPoint = 0 } },         // A dream of being alone
            // END OF ZANARKAND
            // START OF BAAJ TEMPLE
            { new GameState { RoomNumber = 48, Storyline = 30 }, new Transition { RoomNumber = 48, Storyline = 42, SpawnPoint = 0 } },          // Tidus wakes up - Bug: Tidus is walking in water; should be swimming
                                            // Tidus falls into water
                                            // Tidus fights sahagins
                                            // Geogaesno arrives
            { new GameState { RoomNumber = 49, Storyline = 48 }, new Transition { RoomNumber = 50, Storyline = 48, SpawnPoint = 0 } },          // Escape from Geogaesno 
            { new GameState { RoomNumber = 50, Storyline = 48 }, new Transition { RoomNumber = 50, Storyline = 50, SpawnPoint = 0 } },          // Tidus in a collapsed corridor - Bug: Boss music still playing
            { new GameState { RoomNumber = 63, Storyline = 50 }, new Transition { RoomNumber = 63, Storyline = 52, SpawnPoint = 0 } },          // Tidus needs fire - Bug - Wrong SpawnPoint? Spawns at top, should be bottom I think?
            { new GameState { RoomNumber = 63, Storyline = 54 }, new Transition { RoomNumber = 63, Storyline = 55, SpawnPoint = 0 } },          // Tidus makes fire
            { new GameState { RoomNumber = 165, Storyline = 55 }, new Transition { RoomNumber = 63, Storyline = 55, SpawnPoint = 0 } },         // Tidus has a dream about Auron
                                            // Fire goes out and Klikk arrives
                                            // Rikku arrives during Klikk fight
            { new GameState { RoomNumber = 63, Storyline = 58 }, new Transition { RoomNumber = 71, Storyline = 60, SpawnPoint = 0 } },          // Rikku punches Tidus
            { new GameState { RoomNumber = 71, Storyline = 60 }, new Transition { RoomNumber = 71, Storyline = 66, SpawnPoint = 0 } },          // Tidus wakes up on boat
                                            // Sphere Grid Tutorial
                                            // Rikku explains mission
            { new GameState { RoomNumber = 64, Storyline = 70 }, new Transition { RoomNumber = 64, Storyline = 74, SpawnPoint = 0 } },          // They enter the submerged ruins
                                            // Tidus bashes the console
                                            // Tidus bashes the machine + Tros arrives
                                            // They leave the submerged ruins
                                            // Lights come on in submerged ruins
            { new GameState { RoomNumber = 380, Storyline = 84, State = 0 }, new Transition { RoomNumber = 71, Storyline = 90, SpawnPoint = 0, ForceLoad = true } }, // Airship is shown     
            { new GameState { RoomNumber = 71, Storyline = 90, State = 1 }, new Transition { RoomNumber = 71, Storyline = 100, SpawnPoint = 0, ForceLoad = true } }, // Tidus gets back onto the boat                                          
            { new GameState { RoomNumber = 71, Storyline = 100, State = 1 }, new Transition { RoomNumber = 70, Storyline = 110, ForceLoad = true } }, // Rikku suggests going to Luca                                        
            // END OF BAAJ TEMPLE
            // START OF BESAID
            { new GameState { RoomNumber = 70, Storyline = 111 }, new Transition { RoomNumber = 118, SpawnPoint = 0, ForceLoad = true} },        // Tidus wakes up in the sea
                                            // Wakka pushes Tidus ( Wakka joins the party)
            { new GameState { RoomNumber = 41, Storyline = 119, CutsceneAlt = 73 }, new Transition { RoomNumber = 67, Storyline = 124, ForceLoad = true} }, // Wakka asks Tidus to join his team
            { new GameState { RoomNumber = 67, Storyline = 124 }, new Transition { RoomNumber = 69, Storyline = 130, SpawnPoint = 0 } },        // Wakka explains his life story
            { new GameState { RoomNumber = 133, Storyline = 130, }, new Transition { RoomNumber = 17, Storyline = 134, SpawnPoint = 3 } },      // Tidus arrives at Besaid Village
            { new GameState { RoomNumber = 84, Storyline = 134 }, new Transition { RoomNumber = 84, Storyline = 136, SpawnPoint = 0 } },        // Tidus enters the temple
            { new GameState { RoomNumber = 84, Storyline = 136, State = 1 }, new Transition { Storyline = 140, ForceLoad = true } },            // Tidus speaks to the priest
                                            // Priest enters Wakka's tent
            { new GameState { RoomNumber = 191, Storyline = 152 }, new Transition { RoomNumber = 145, Storyline = 154, SpawnPoint = 0 } },      // Tidus dreams about a flashback
            { new GameState { RoomNumber = 42, Storyline = 154, State = 1}, new Transition { RoomNumber = 122, Storyline = 162, ForceLoad = true} }, // Tidus goes back into the temple
                                            // Wakka catches up with Tidus in trials
            { new GameState { RoomNumber = 103, Storyline = 164}, new Transition { RoomNumber = 42, Storyline = 170, ForceLoad = true} },       // Tidus meets Lulu and Kimahri + FMV
            { new GameState { RoomNumber = 42, Storyline = 170 }, new Transition { RoomNumber = 42, Storyline = 172, SpawnPoint = 0 } },        // The gang leave the cloister of trials
                                            // Valefor summon
                                            // Tidus monologue after naming
                                            // Tidus joins the Aurochs
                                            // Tidus speaks to Yuna
            { new GameState { RoomNumber = 68, Storyline = 184 }, new Transition { RoomNumber = 60, Storyline = 200, SpawnPoint = 0 } },        // Tidus sleeping, FMV and chat with Wakka
            { new GameState { RoomNumber = 17, Storyline = 200 }, new Transition { RoomNumber = 69, Storyline = 210, SpawnPoint = 515 } },      // Yuna says goodbye to Besaid
            { new GameState { RoomNumber = 67, Storyline = 210 }, new Transition { RoomNumber = 67, Storyline = 214, SpawnPoint = 0 } },        // Yuna says goodbye to Besaid again
                                            // Kimahri FMV
                                            // Post-Kimahri battle
            { new GameState { RoomNumber = 19, Storyline = 218, State = 0 }, new Transition { RoomNumber = 301, Storyline = 220, ForceLoad = true } }, // S.S. Liki departs
            // END OF BESAID
            // START OF SS LIKI
            { new GameState { RoomNumber = 301, Storyline = 220 }, new Transition { RoomNumber = 301, Storyline = 228, SpawnPoint = 256 } },    // Tidus goofing around
                                           // Tidus learns about Braska
                                           // Tidus talks to Wakka
            { new GameState { RoomNumber = 61, Storyline = 244  }, new Transition {Storyline = 248, ForceLoad = true } },                       // Tidus talks to Yuna
                                           // Sin arrives
                                           // Post Sin Fin battle
                                           // Tidus is gone
                                           // Tidus gets hit by scales
                                           // Post Echuilles
            { new GameState { RoomNumber = 282, Storyline = 285 }, new Transition { RoomNumber = 43, Storyline = 292, ForceLoad = true } },    // Kilika is destroyed
            // END OF SS LIKI
            // START OF KILIKA
            { new GameState { RoomNumber = 43, Storyline = 292 }, new Transition { RoomNumber = 43, Storyline = 294, SpawnPoint = 0 } },               // Undocking in Kilika
            { new GameState { RoomNumber = 53, Storyline = 294, State = 0 }, new Transition { RoomNumber = 152, Storyline = 304, ForceLoad = true } }, // Sending
            { new GameState { RoomNumber = 152, Storyline = 300 }, new Transition { RoomNumber = 152, Storyline = 302, SpawnPoint = 0 } },             // Tidus wakes up
            { new GameState { RoomNumber = 16, Storyline = 304, State = 1 }, new Transition { Storyline = 308, SpawnPoint = 2, ForceLoad = true } },   // Tidus speaks to Wakka
            { new GameState { RoomNumber = 18, Storyline = 308 }, new Transition { RoomNumber = 18, Storyline = 312, SpawnPoint = 0 } },               // Camera pan in Kilika Woods
            { new GameState { RoomNumber = 65, Storyline = 315 }, new Transition { RoomNumber = 65, Storyline = 322, SpawnPoint = 0 } },               // Race up the stairs
                                            // Pre-Geneaux?
                                            // Post-Geneaux?
                                            // Tidus is tired
            { new GameState { RoomNumber = 65, Storyline = 326, State = 1 }, new Transition { RoomNumber = 78, Storyline = 328, SpawnPoint = 1, ForceLoad = true } }, // No replacement for Chappu
            { new GameState { RoomNumber = 78, Storyline = 328 }, new Transition { RoomNumber = 78, Storyline = 330, SpawnPoint = 1 } },                              // Arrival at temple
            { new GameState { RoomNumber = 96, Storyline = 330 }, new Transition { RoomNumber = 96, Storyline = 335, SpawnPoint = 0 } },                              // Camera pan in Kilika Temple + pray
                                            // Tidus is denied access
                                            // Tidus is manhandled by Barthello
                                            // Tidus decides to go inside
                                            // Camera pan inside the trials
            { new GameState { RoomNumber = 45, Storyline = 340 }, new Transition { Storyline = 346} }, // Guardians are annoyed at Tidus + Fayth explanation
                                            // Yuna leaves the fayth room
            { new GameState { RoomNumber = 78, Storyline = 348, State = 1 }, new Transition { RoomNumber = 18, Storyline = 360, SpawnPoint = 1, ForceLoad = true } }, // Tidus misses home
            { new GameState { RoomNumber = 16, Storyline = 360, State = 1 }, new Transition { RoomNumber = 94, Storyline = 370, SpawnPoint = 256, ForceLoad = true } }, // Setting off to Luca
            // END OF KILIKA
            // START OF SS WINNO
            { new GameState { RoomNumber = 94, Storyline = 370 }, new Transition { RoomNumber = 167, Storyline = 372, SpawnPoint = 0 } },       // Opening scenes
                                            // Tidus stands up
                                            // Meet O'aka
            { new GameState { RoomNumber = 94, Storyline = 380, State = 1 }, new Transition { Storyline = 380, SpawnPoint = 2, ForceLoad = true  } }, // Eavesdropping on Lulu and Wakka
                                            // Tidus flashback about Jecht
                                            // Tidus fails Jecht shot + Yuna arrives
            { new GameState { RoomNumber = 94, Storyline = 395, State = 0 }, new Transition { RoomNumber = 267, Storyline = 425, SpawnPoint = 2, ForceLoad = true  } }, // Tidus speaks to Yuna
            // END OF WINNO
            // START OF LUCA
            { new GameState { RoomNumber = 268, Storyline = 427, State = 0 }, new Transition { RoomNumber = 355, Storyline = 430, ForceLoad = true } }, // Seymour arrives
            { new GameState { RoomNumber = 72, Storyline = 430, State = 0 }, new Transition { Storyline = 440, SpawnPoint = 1797, ForceLoad = true } }, // Yuna enters the changing room
            { new GameState { RoomNumber = 72, Storyline = 440, State = 0 }, new Transition { RoomNumber = 123, Storyline = 450, SpawnPoint = 4, ForceLoad = true } }, // Speaking to the Al Bhed
            { new GameState { RoomNumber = 123, Storyline = 450 }, new Transition { LucaFlag = 8 } }, // Camera pan
            { new GameState { RoomNumber = 77, Storyline = 450 }, new Transition { Storyline = 455, SpawnPoint = 1 } }, // Crowd mob Yuna
            { new GameState { RoomNumber = 104, Storyline = 455 }, new Transition { LucaFlag2 = 2 } }, // Tidus and Yuna talk about Luca
            //{ new GameState { RoomNumber = 159, Storyline = 455 }, new Transition { RoomNumber = 77, Storyline = 492, SpawnPoint = 1, EnableYuna = 16, EnableWakka = 16, Formation = new byte[]{0x5, 0x0, 0x3, 0xFF, 0xFF} } }, // Tidus and Yuna go to the cafe
                                            // Machina fights
                                            // Looking at the scoreboard
            { new GameState { RoomNumber = 121, Storyline = 492 }, new Transition { RoomNumber = 88, Storyline = 500 } },                       // Wakka takes a beating
            { new GameState { RoomNumber = 88, Storyline = 500 }, new Transition { LucaFlag = 9 } },                                            // Wakka won't last
            { new GameState { RoomNumber = 299, Storyline = 502 }, new Transition { RoomNumber = 113, Storyline = 502, ForceLoad = true } },    // They jump on the boat
                                            // Pre-Oblitzerator
                                            // Post-Oblitzerator
                                            // Yuna is rescued
            { new GameState { RoomNumber = 121, Storyline = 508 }, new Transition { RoomNumber = 88, Storyline = 514, SpawnPoint = 0 } },       // Aurochs win the game
            { new GameState { RoomNumber = 72, Storyline = 514  }, new Transition { Storyline = 518, LucaFlag = 11, SpawnPoint = 1797 } },      // Wakka is injured
                                            // Wakka subs himself
            { new GameState { RoomNumber = 72, Storyline = 520  }, new Transition { RoomNumber = 124, Storyline = 535, ForceLoad = true } },    // Lulu speaks to Wakka
                                            // Pre-Blitzball
            { new GameState { RoomNumber = 72, Storyline = 540  }, new Transition { RoomNumber = 347, Storyline = 560} },                       // Halftime talk
                                            // Fans are getting impatient
            { new GameState { RoomNumber = 250, Storyline = 565 }, new Transition { RoomNumber = 124, Storyline = 575} },                       // Wakka chants
                                            // Wakka joins the game
            { new GameState { RoomNumber = 250, Storyline = 582 }, new Transition { RoomNumber = 125, Storyline = 583} },                       // Aurochs win/lose the game
                                            // Pre-Sahagin fight
                                            // Post-Sahagin fight
            { new GameState { RoomNumber = 57, Storyline = 588 }, new Transition { Storyline = 600} },                                          // Lulu what's happening
                                            // Tidus and Wakka join Auron
                                            // Seymour summon Anima + FMV
            { new GameState { RoomNumber = 104, Storyline = 610  }, new Transition { RoomNumber = 89, Storyline = 617, SpawnPoint = 1, EnableAuron = 17 } },    // Wakka quits the Aurochs
                                            // Tidus and Auron join the group
            { new GameState { RoomNumber = 107, Storyline = 630, State = 0 }, new Transition { RoomNumber = 95, Storyline = 730, SpawnPoint = 256, ForceLoad = true } },    // HA HA HA HA
            // END OF LUCA
            // START OF MI'IHEN
            { new GameState { RoomNumber = 95, Storyline = 730 }, new Transition { RoomNumber = 95, Storyline = 750, SpawnPoint = 0 } },         // Tidus runs up the stairs
            { new GameState { RoomNumber = 58, Storyline = 750 }, new Transition { RoomNumber = 58, Storyline = 734, SpawnPoint = 0 } },         // Reset it back to avoid a sequence break!
            { new GameState { RoomNumber = 58, Storyline = 734, State = 0 }, new Transition { RoomNumber = 171, Storyline = 755, ForceLoad = true } }, // Auron is tired
            { new GameState { RoomNumber = 112, Storyline = 755 }, new Transition { RoomNumber = 171, Storyline = 760, SpawnPoint = 0 } },       // Tidus chats with Yuna
                                            // Tidus chats to a guy
                                            // Meet Rin
            { new GameState { RoomNumber = 58, Storyline = 767 }, new Transition { MiihenFlag = 1 } },       // To the chocobo corral
                                            // Pre-Chocobo Eater
                                            // Fall down the cliff
            { new GameState { RoomNumber = 59, Storyline = 777 }, new Transition { Storyline = 787 } },       // Seymour helps out
            // END OF MI'IHEN
            // START OF MUSHROOM ROCK ROAD
            { new GameState { RoomNumber = 79, Storyline = 787 }, new Transition { RoomNumber = 79, Storyline = 825, SpawnPoint = 0 } },        // Tidus distrusts Seymour
            { new GameState { RoomNumber = 247, Storyline = 899 }, new Transition { RoomNumber = 131, Storyline = 845, SpawnPoint = 3 } },      // Tuna Summon
            { new GameState { RoomNumber = 218, Storyline = 902 }, new Transition { RoomNumber = 131, Storyline = 928, SpawnPoint = 3 } },      // Chasing after Sin
            // END OF MRR
            // START OF DJOSE HIGHROAD
            { new GameState { RoomNumber = 93, Storyline = 960 }, new Transition { RoomNumber = 93, Storyline = 962, SpawnPoint = 0 } },        // Leave MRR -> Djose
		    { new GameState { RoomNumber = 76, Storyline = 962 }, new Transition { RoomNumber = 76, Storyline = 990, SpawnPoint = 0 } },        // Djose -> Trials
		    { new GameState { RoomNumber = 214, Storyline = 990 }, new Transition { RoomNumber = 214, Storyline = 995, SpawnPoint = 0 } },      // Trials -> Chamber
		    { new GameState { RoomNumber = 161, Storyline = 1010 }, new Transition { RoomNumber = 161, Storyline = 1032, SpawnPoint = 0 } },    // Wake Yuna -> Moonflow
		    { new GameState { RoomNumber = 105, Storyline = 1032 }, new Transition { RoomNumber = 105, Storyline = 1045, SpawnPoint = 0 } },    // Moonflow/Shoopuff
		    { new GameState { RoomNumber = 291, Storyline = 1045 }, new Transition { RoomNumber = 99, Storyline = 1060, SpawnPoint = 0 } },     // Pre-Extractor
		    { new GameState { RoomNumber = 291, Storyline = 1060 }, new Transition { RoomNumber = 236, Storyline = 1070, SpawnPoint = 0 } },    // Post-Extractor
		    { new GameState { RoomNumber = 189, Storyline = 1070 }, new Transition { RoomNumber = 189, Storyline = 1085, SpawnPoint = 0 } },    // Remove Rikku's appearance
		    //{ new GameState { RoomNumber = 141, Storyline = 1104 }, new Transition { RoomNumber = 163, Storyline = 1126, SpawnPoint = 1 } },    // Seymour's Room to Farplane
		    //{ new GameState { RoomNumber = 163, Storyline = 1126 }, new Transition { RoomNumber = 163, Storyline = 1190, SpawnPoint = 0 } },    // Skip Farplane
            { new GameState { RoomNumber = 213, Storyline = 1156 }, new Transition { RoomNumber = 213, Storyline = 1300, SpawnPoint = 0 } },    // Farplane Cutscenes
            { new GameState { RoomNumber = 257, Storyline = 1300 }, new Transition { RoomNumber = 135, Storyline = 1300, SpawnPoint = 2 } },    // Skip Guadosalam Exit
		    { new GameState { RoomNumber = 264, Storyline = 1315 }, new Transition { RoomNumber = 263, Storyline = 1418, SpawnPoint = 0 } },    // Inn Sleep
        };

        public static readonly Dictionary<GameState, Transition> PostBossBattleTransitions = new Dictionary<GameState, Transition>()
        {
            { new GameState { HpEnemyA = 12000, Storyline = 1420 }, new Transition { RoomNumber = 221, Storyline = 1480, SpawnPoint = 2} } // Spherimorph
        };
    }
}
