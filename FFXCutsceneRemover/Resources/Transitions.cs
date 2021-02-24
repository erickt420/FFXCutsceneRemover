using System.Collections.Generic;

namespace FFXCutsceneRemover.Resources
{
    /* This class contains most of the transitions. Transitions added here are automatically evalutated in the main loop. */
    static class Transitions
    {
        public static readonly Dictionary<IGameState, Transition> StandardTransitions = new Dictionary<IGameState, Transition>()
        {
            // SPECIAL
            { new GameState { Input = 2304, BattleState = 10 },  new Transition { BattleState = 778, ForceLoad = false } },                     // End any battle by holding start + select
            { new GameState { RoomNumber = 348 }, new Transition { RoomNumber = 23 } },                                                         // Skip Intro
            { new GameState { RoomNumber = 349 }, new Transition { RoomNumber = 23 } },                                                         // Skip Intro
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
            { new GameState { RoomNumber = 63, Storyline = 50 }, new Transition { RoomNumber = 63, Storyline = 52, SpawnPoint = 1 } },          // Tidus needs fire
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
            //{ new GameState { RoomNumber = 380, Storyline = 84, State = 0 }, new Transition { RoomNumber = 71, Storyline = 90, SpawnPoint = 0 } }, // Airship is shown  - Bug: needs to compare old with new Gamestate to work   
            { new GameState { RoomNumber = 71, Storyline = 90, State = 1 }, new Transition { RoomNumber = 71, Storyline = 100, SpawnPoint = 0 } }, // Tidus gets back onto the boat                                          
            { new GameState { RoomNumber = 71, Storyline = 100, State = 1 }, new Transition { RoomNumber = 70, Storyline = 110 } }, // Rikku suggests going to Luca                                        
            // END OF BAAJ TEMPLE
            // START OF BESAID
            { new GameState { RoomNumber = 70, Storyline = 111 }, new Transition { Storyline = 118, SpawnPoint = 0} },        // Tidus wakes up in the sea
                                            // Wakka pushes Tidus ( Wakka joins the party)
            { new GameState { RoomNumber = 41, Storyline = 119, CutsceneAlt = 73 }, new Transition { RoomNumber = 67, Storyline = 124} }, // Wakka asks Tidus to join his team
            { new GameState { RoomNumber = 67, Storyline = 124 }, new Transition { RoomNumber = 69, Storyline = 130, SpawnPoint = 0 } },        // Wakka explains his life story
            { new GameState { RoomNumber = 133, Storyline = 130, }, new Transition { RoomNumber = 17, Storyline = 134, SpawnPoint = 3 } },      // Tidus arrives at Besaid Village
            { new GameState { RoomNumber = 84, Storyline = 134 }, new Transition { RoomNumber = 84, Storyline = 136, SpawnPoint = 0 } },        // Tidus enters the temple
            { new GameState { RoomNumber = 84, Storyline = 136, State = 1 }, new Transition { Storyline = 140 } },            // Tidus speaks to the priest
                                            // Priest enters Wakka's tent
            { new GameState { RoomNumber = 191, Storyline = 152 }, new Transition { RoomNumber = 145, Storyline = 154, SpawnPoint = 0 } },      // Tidus dreams about a flashback
            { new GameState { RoomNumber = 42, Storyline = 154, State = 1}, new Transition { RoomNumber = 122, Storyline = 162} }, // Tidus goes back into the temple
                                            // Wakka catches up with Tidus in trials
            //{ new GameState { RoomNumber = 103, Storyline = 164}, new Transition { RoomNumber = 42, Storyline = 170} },     // Tidus meets Lulu and Kimahri + FMV - Bug: Need to enable Valefor here
            { new GameState { RoomNumber = 42, Storyline = 170 }, new Transition { RoomNumber = 42, Storyline = 172, SpawnPoint = 0 } },        // The gang leave the cloister of trials
                                            // Valefor summon
                                            // Tidus monologue after naming
                                            // Tidus joins the Aurochs
                                            // Tidus speaks to Yuna
            { new GameState { RoomNumber = 68, Storyline = 184 }, new Transition { RoomNumber = 252, Storyline = 190} },                        // Tidus sleeping
            { new GameState { RoomNumber = 252, Storyline = 190, State = 1 }, new Transition { RoomNumber = 60, Storyline = 196 } },            // Tidus has a dream about Yuna, Tidus wakes up + FMV
                                            // Tidus wakes up again (Party healed at this point)
            //{ new GameState { RoomNumber = 17, Storyline = 200 }, new Transition { RoomNumber = 69, Storyline = 210, SpawnPoint = 515 } },    // Yuna says goodbye to Besaid - Bug: Need to Enable + Equip Brotherhood, Lulu, Yuna, lots of things!
            { new GameState { RoomNumber = 67, Storyline = 210 }, new Transition { RoomNumber = 67, Storyline = 214, SpawnPoint = 3 } },        // Yuna says goodbye to Besaid again
                                            // Kimahri FMV
                                            // Post-Kimahri battle
            { new GameState { RoomNumber = 19, Storyline = 218, State = 0 }, new Transition { RoomNumber = 301, Storyline = 220 } }, // S.S. Liki departs
            // END OF BESAID
            // START OF SS LIKI
            { new GameState { RoomNumber = 301, Storyline = 220 }, new Transition { RoomNumber = 301, Storyline = 228, SpawnPoint = 256 } },    // Tidus goofing around
                                           // Tidus learns about Braska
                                           // Tidus talks to Wakka
            { new GameState { RoomNumber = 61, Storyline = 244  }, new Transition {Storyline = 248 } },                       // Tidus talks to Yuna
                                           // Sin arrives
                                           // Post Sin Fin battle
                                           // Tidus is gone
                                           // Tidus gets hit by scales
                                           // Post Echuilles
            //{ new GameState { RoomNumber = 282, Storyline = 285 }, new Transition { RoomNumber = 220, Storyline = 285 } },    // Kilika FMV - Party members added back on reward screen - Bug: Need to enable menu to fix
            { new GameState { RoomNumber = 220, Storyline = 287 }, new Transition { RoomNumber = 139, Storyline = 290 } },    // Recovering on the boat
            { new GameState { RoomNumber = 139, Storyline = 290 }, new Transition { RoomNumber = 43, Storyline = 292 } },    // Map shown
            // END OF SS LIKI
            // START OF KILIKA
            { new GameState { RoomNumber = 43, Storyline = 292 }, new Transition { RoomNumber = 43, Storyline = 294, SpawnPoint = 0 } },               // Undocking in Kilika
            { new GameState { RoomNumber = 53, Storyline = 294, State = 0 }, new Transition { RoomNumber = 152, Storyline = 304 } }, // Sending
            { new GameState { RoomNumber = 152, Storyline = 300 }, new Transition { RoomNumber = 152, Storyline = 302, SpawnPoint = 0 } },             // Tidus wakes up
            { new GameState { RoomNumber = 16, Storyline = 304, State = 1 }, new Transition { Storyline = 308, SpawnPoint = 2 } },   // Tidus speaks to Wakka
            { new GameState { RoomNumber = 18, Storyline = 308 }, new Transition { RoomNumber = 18, Storyline = 312, SpawnPoint = 0 } },               // Camera pan in Kilika Woods
            { new GameState { RoomNumber = 65, Storyline = 315 }, new Transition { RoomNumber = 65, Storyline = 322, SpawnPoint = 0 } },               // Race up the stairs
                                            // Pre-Geneaux?
                                            // Post-Geneaux?
                                            // Tidus is tired
            { new GameState { RoomNumber = 65, Storyline = 326, State = 1 }, new Transition { RoomNumber = 78, Storyline = 328, SpawnPoint = 1 } }, // No replacement for Chappu
            { new GameState { RoomNumber = 78, Storyline = 328 }, new Transition { RoomNumber = 78, Storyline = 330, SpawnPoint = 1 } },                              // Arrival at temple
            { new GameState { RoomNumber = 96, Storyline = 330 }, new Transition { RoomNumber = 96, Storyline = 335, SpawnPoint = 0 } },                              // Camera pan in Kilika Temple + pray
                                            // Tidus is denied access
                                            // Tidus is manhandled by Barthello
                                            // Tidus decides to go inside
                                            // Camera pan inside the trials
            { new GameState { RoomNumber = 45, Storyline = 340 }, new Transition { Storyline = 346} }, // Guardians are annoyed at Tidus + Fayth explanation
                                            // Yuna leaves the fayth room
            { new GameState { RoomNumber = 78, Storyline = 348, State = 1 }, new Transition { RoomNumber = 18, Storyline = 360, SpawnPoint = 1 } }, // Tidus misses home
            { new GameState { RoomNumber = 16, Storyline = 360, State = 1 }, new Transition { RoomNumber = 94, Storyline = 370, SpawnPoint = 256 } }, // Setting off to Luca
            // END OF KILIKA
            // START OF SS WINNO
            { new GameState { RoomNumber = 94, Storyline = 370 }, new Transition { RoomNumber = 167, Storyline = 372, SpawnPoint = 0 } },       // Opening scenes
                                            // Tidus stands up
                                            // Meet O'aka
            //{ new GameState { RoomNumber = 94, Storyline = 380, State = 1 }, new Transition { Storyline = 380, SpawnPoint = 2, ForceLoad = false  } }, // Eavesdropping on Lulu and Wakka
                                            // Tidus flashback about Jecht
                                            // Tidus fails Jecht shot + Yuna arrives
            { new GameState { RoomNumber = 94, Storyline = 395, State = 0 }, new Transition { RoomNumber = 267, Storyline = 425, SpawnPoint = 2  } }, // Tidus speaks to Yuna
            // END OF WINNO
            // START OF LUCA
            { new GameState { RoomNumber = 268, Storyline = 427, State = 0 }, new Transition { RoomNumber = 355, Storyline = 430 } }, // Seymour arrives
            //{ new GameState { RoomNumber = 72, Storyline = 430, State = 0 }, new Transition { Storyline = 440, SpawnPoint = 1797 } }, // Yuna enters the changing room
            { new GameState { RoomNumber = 72, Storyline = 440, State = 0 }, new Transition { RoomNumber = 123, Storyline = 450, SpawnPoint = 4 } }, // Speaking to the Al Bhed
            { new GameState { RoomNumber = 123, Storyline = 450 }, new Transition { LucaFlag = 8, ForceLoad = false} }, // Camera pan
            { new GameState { RoomNumber = 77, Storyline = 450 }, new Transition { Storyline = 455, SpawnPoint = 1 } }, // Crowd mob Yuna
            { new GameState { RoomNumber = 104, Storyline = 455 }, new Transition { LucaFlag2 = 2, ForceLoad = false } }, // Tidus and Yuna talk about Luca
            { new GameState { RoomNumber = 159, Storyline = 455 }, new Transition { RoomNumber = 57, Storyline = 484 } }, // Tidus and Yuna at the cafe
            { new GameState { RoomNumber = 57, Storyline = 484 }, new Transition { RoomNumber = 121, Storyline = 486 } }, // Mika begins the tournament
            { new GameState { RoomNumber = 121, Storyline = 486 }, new Transition { RoomNumber = 159, Storyline = 488 } }, // Al Bhed Auroch game starts
            { new GameState { RoomNumber = 159, Storyline = 488 }, new Transition { RoomNumber = 104, Storyline = 490 } }, // Kimahri Yuna's gone
            { new GameState { RoomNumber = 104, Storyline = 490 }, new Transition { RoomNumber = 77, Storyline = 492, SpawnPoint = 1, EnableYuna = 16, EnableWakka = 16, Formation = new byte[]{0x5, 0x0, 0x3, 0xFF, 0xFF} } }, // Tidus and Yuna go to the cafe
                                            // Machina fights
                                            // Looking at the scoreboard
            { new GameState { RoomNumber = 121, Storyline = 492 }, new Transition { RoomNumber = 88, Storyline = 500 } },                       // Wakka takes a beating
            { new GameState { RoomNumber = 88, Storyline = 500 }, new Transition { LucaFlag = 9, SpawnPoint = 258, ForceLoad = false } },       // Wakka won't last
            { new GameState { RoomNumber = 299, Storyline = 502 }, new Transition { RoomNumber = 113, Storyline = 502 } },    // They jump on the boat
                                            // Pre-Oblitzerator
                                            // Post-Oblitzerator
                                            // Yuna is rescued
            { new GameState { RoomNumber = 121, Storyline = 508 }, new Transition { RoomNumber = 88, Storyline = 514, SpawnPoint = 0 } },       // Aurochs win the game
            { new GameState { RoomNumber = 72, Storyline = 514  }, new Transition { Storyline = 518, LucaFlag = 11, SpawnPoint = 1797 } },      // Wakka is injured
                                            // Wakka subs himself
            { new GameState { RoomNumber = 72, Storyline = 520  }, new Transition { RoomNumber = 124, Storyline = 535 } },    // Lulu speaks to Wakka
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
            { new GameState { RoomNumber = 104, Storyline = 610  }, new Transition { RoomNumber = 107, Storyline = 615 } },                   // Wakka quits the Aurochs
            { new GameState { RoomNumber = 107, Storyline = 615  }, new Transition { RoomNumber = 89, Storyline = 616 } },                    // Wakka joins Yuna
            { new GameState { RoomNumber = 89, Storyline = 616  }, new Transition { Storyline = 617, SpawnPoint = 1, EnableAuron = 17 } },    // Tidus shouts at Auron
                                            // Tidus and Auron join the group
            { new GameState { RoomNumber = 107, Storyline = 630, State = 0 }, new Transition { RoomNumber = 95, Storyline = 730, SpawnPoint = 256 } },    // HA HA HA HA
            // END OF LUCA
            // START OF MI'IHEN
            { new GameState { RoomNumber = 95, Storyline = 730 }, new Transition { Storyline = 734, MiihenFlag1 = 5, MiihenFlag2 = 4, ForceLoad = false} }, // Tidus runs up the stairs
            { new GameState { RoomNumber = 120, Storyline = 734 }, new Transition { MiihenFlag1 = 141, ForceLoad = false} },                                // Meet Calli
            { new GameState { RoomNumber = 127, Storyline = 734 }, new Transition { MiihenFlag1 = 221, MiihenFlag2 = 148, ForceLoad = false} },             // Luzzu, Gatta and Shelinda scenes
            { new GameState { RoomNumber = 58, Storyline = 734, State = 0 }, new Transition { RoomNumber = 171, Storyline = 755 } },      // Auron is tired
            { new GameState { RoomNumber = 112, Storyline = 755 }, new Transition { RoomNumber = 171, Storyline = 760, SpawnPoint = 0 } },                  // Tidus chats with Yuna
                                            // Tidus chats to a guy
                                            // Meet Rin
            { new GameState { RoomNumber = 58, Storyline = 767 }, new Transition { MiihenFlag3 = 1 , ForceLoad = false} },                                  // To the chocobo corral
                                            // Pre-Chocobo Eater
                                            // Fall down the cliff (MiihenFlag = 3 after)
            { new GameState { RoomNumber = 116, Storyline = 772 }, new Transition { MiihenFlag4 = 4 , ForceLoad = false} },                                 // Luzzu and Gatta move a cart
            { new GameState { RoomNumber = 59, Storyline = 777, State = 0}, new Transition { Storyline = 787, SpawnPoint = 3} },          // Seymour helps out
            // END OF MI'IHEN
            // START OF MUSHROOM ROCK ROAD
            { new GameState { RoomNumber = 79, Storyline = 787 }, new Transition { RoomNumber = 79, Storyline = 825, SpawnPoint = 0 } },        // Tidus distrusts Seymour
            { new GameState { RoomNumber = 119, Storyline = 825 }, new Transition { Storyline = 845 } },                                        // Preparing for Sin
                                            // Pre-Sinspawn Gui
                                            // Post-Sinspawn Gui + FMV
            //{ new GameState { RoomNumber = 119, Storyline = 860 }, new Transition { RoomNumber = 247, Storyline = 865 } },    // Auron Look out + FMV - bug: People leave/join the party, need to fix that
                                            // Pre-Sinspawn Gui 2
                                            // Post-Sinspawn Gui 2
            //{ new GameState { RoomNumber = 247, Storyline = 882 }, new Transition { RoomNumber = 254, Storyline = 922 } },    // Trying to beat Sin FMV - bug: FMV playing as you gain control, breaks the game
                                            // Tidus wakes up
                                            // Tidus sees Gatta
                                            // Sin FMV
                                            // Tidus chases after Sin
            { new GameState { RoomNumber = 247, Storyline = 899 }, new Transition { RoomNumber = 218, Storyline = 902 } },      // Yuna tries to summon
            { new GameState { RoomNumber = 218, Storyline = 902 }, new Transition { RoomNumber = 341, Storyline = 910 } },      // Tidus is swimming
            { new GameState { RoomNumber = 341, Storyline = 910 }, new Transition { RoomNumber = 134, Storyline = 910 } },      // Nucleus
            { new GameState { RoomNumber = 134, Storyline = 910 }, new Transition { RoomNumber = 131, Storyline = 910 } },      // Zanarkand flashback
            { new GameState { RoomNumber = 131, Storyline = 910 }, new Transition { RoomNumber = 131, Storyline = 922, SpawnPoint = 3 } },      // Tidus monologue on beach
                                            // Kinoc retreats
                                            // Seymour flirts
                                            // Tidus speaks to Auron
                                            // Leaving Mushroom Rock Road
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

        public static readonly Dictionary<IGameState, Transition> PostBossBattleTransitions = new Dictionary<IGameState, Transition>()
        {
            { new GameState { HpEnemyA = 12000, Storyline = 1420 }, new Transition { RoomNumber = 221, Storyline = 1480, SpawnPoint = 2} } // Spherimorph
        };
    }
}
