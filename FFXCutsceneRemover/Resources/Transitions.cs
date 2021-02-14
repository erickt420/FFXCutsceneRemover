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
            { new GameState { RoomNumber = 366, Storyline = 8 }, new Transition { RoomNumber = 389, Storyline = 12, SpawnPoint = 0 } },         // Tidus sees the fayth and follows Auron
            //{ new GameState { RoomNumber = 389, Storyline = 14 }, new Transition { RoomNumber = 389, Storyline = 15, SpawnPoint = 0 } },        // Sinspawn Ammes? - NOT WORKING - This CS ends with a battle.
            { new GameState { RoomNumber = 367, Storyline = 16 }, new Transition { RoomNumber = 367, Storyline = 18, SpawnPoint = 0 } },        // Tidus sees Jecht sign again
            { new GameState { RoomNumber = 367, Storyline = 19 }, new Transition { RoomNumber = 367, Storyline = 20, SpawnPoint = 0 } },        // Tidus and Auron run as bridge explodes
            { new GameState { RoomNumber = 367, Storyline = 20 }, new Transition { RoomNumber = 384, Storyline = 20, SpawnPoint = 0 } },        // "This is your story"
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
            // END OF BAAJ TEMPLE
            // START OF BESAID
            { new GameState { RoomNumber = 67, Storyline = 124 }, new Transition { RoomNumber = 69, Storyline = 130, SpawnPoint = 0 } },        // Wakka explains his life story
            { new GameState { RoomNumber = 84, Storyline = 134 }, new Transition { RoomNumber = 84, Storyline = 136, SpawnPoint = 0 } },        // Tidus enters the temple
            { new GameState { RoomNumber = 191, Storyline = 152 }, new Transition { RoomNumber = 145, Storyline = 154, SpawnPoint = 0 } },      // Tidus dreams about a flashback
            { new GameState { RoomNumber = 42, Storyline = 170 }, new Transition { RoomNumber = 42, Storyline = 172, SpawnPoint = 0 } },        // The gang leave the cloister of trials
            { new GameState { RoomNumber = 68, Storyline = 184 }, new Transition { RoomNumber = 60, Storyline = 200, SpawnPoint = 0 } },        // Tidus sleeping, FMV and chat with Wakka
            { new GameState { RoomNumber = 17, Storyline = 200 }, new Transition { RoomNumber = 69, Storyline = 210, SpawnPoint = 515 } },      // Yuna says goodbye to Besaid
            { new GameState { RoomNumber = 67, Storyline = 210 }, new Transition { RoomNumber = 67, Storyline = 214, SpawnPoint = 0 } },        // Yuna says goodbye to Besaid again
            // END OF BESAID
            // START OF SS LIKI
            { new GameState { RoomNumber = 301, Storyline = 220 }, new Transition { RoomNumber = 301, Storyline = 228, SpawnPoint = 256 } },    // Tidus goofing around
            // END OF SS LIKI
            // START OF KILIKA
            { new GameState { RoomNumber = 43, Storyline = 292 }, new Transition { RoomNumber = 43, Storyline = 294, SpawnPoint = 0 } },        // Undocking in Kilika
            { new GameState { RoomNumber = 152, Storyline = 300 }, new Transition { RoomNumber = 152, Storyline = 302, SpawnPoint = 0 } },      // Tidus wakes up
            { new GameState { RoomNumber = 18, Storyline = 308 }, new Transition { RoomNumber = 18, Storyline = 312, SpawnPoint = 0 } },        // Camera pan in Kilika Woods
            { new GameState { RoomNumber = 65, Storyline = 315 }, new Transition { RoomNumber = 65, Storyline = 322, SpawnPoint = 0 } },        // Race up the stairs
            { new GameState { RoomNumber = 78, Storyline = 328 }, new Transition { RoomNumber = 78, Storyline = 330, SpawnPoint = 1 } },        // Arrival at temple
            { new GameState { RoomNumber = 96, Storyline = 330 }, new Transition { RoomNumber = 96, Storyline = 335, SpawnPoint = 0 } },        // Camera pan in Kilika Temple
            // END OF KILIKA
            // START OF SS WINNO
            { new GameState { RoomNumber = 94, Storyline = 370 }, new Transition { RoomNumber = 167, Storyline = 372, SpawnPoint = 0 } },       // Opening scenes
            // END OF WINNO
            // START OF LUCA
            { new GameState { RoomNumber = 121, Storyline = 508 }, new Transition { RoomNumber = 88, Storyline = 514, SpawnPoint = 0 } },       // Aurochs win the game
            // END OF LUCA
            // START OF MI'IHEN
            { new GameState { RoomNumber = 95, Storyline = 730 }, new Transition { RoomNumber = 95, Storyline = 750, SpawnPoint = 0 } },         // Tidus runs up the stairs
            { new GameState { RoomNumber = 58, Storyline = 750 }, new Transition { RoomNumber = 58, Storyline = 734, SpawnPoint = 0 } },         // Reset it back to avoid a sequence break!
            { new GameState { RoomNumber = 112, Storyline = 755 }, new Transition { RoomNumber = 171, Storyline = 760, SpawnPoint = 0 } },       // Tidus chats with Yuna
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

        public static readonly Dictionary<IGameState, Transition> PostBossBattleTransitions = new Dictionary<IGameState, Transition>()
        {
            { new GameState { HpEnemyA = 12000, Storyline = 1420 }, new Transition { RoomNumber = 221, Storyline = 1480, SpawnPoint = 2} } // Spherimorph
        };
    }
}
