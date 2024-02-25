using System.Collections.Generic;
using System.Diagnostics;

using FFXCutsceneRemover.ComponentUtil;
using FFXCutsceneRemover.Logging;

namespace FFXCutsceneRemover;

class CrawlerTransition : Transition
{
    public override void Execute(string defaultDescription = "")
    {
        Process process = MemoryWatchers.Process;

        if (Stage == 0)
        {
            base.Execute();

            //BaseCutsceneValue = MemoryWatchers.CrawlerTransition.Current;
            BaseCutsceneValue = MemoryWatchers.EventFileStart.Current;
            Stage += 1;

        }
        //First 4 stages are an attempt to emulate the logic from the PS2 Pnach. Values don't line up perfectly but it works.
        else if (MemoryWatchers.CrawlerTransition.Current == (BaseCutsceneValue + 0xEBC2) && Stage == 1)
        {
            WriteValue<int>(MemoryWatchers.CrawlerTransition, BaseCutsceneValue + 0xF017);
            Stage += 1;
        }
        else if (MemoryWatchers.CrawlerTransition.Current >= (BaseCutsceneValue + 0xF02D) && Stage == 2)
        {
            WriteValue<int>(MemoryWatchers.CrawlerTransition, BaseCutsceneValue + 0xF0F3);
            Stage += 1;
        }
        else if (MemoryWatchers.CrawlerTransition.Current >= (BaseCutsceneValue + 0xF0FC) && Stage == 3)
        {
            WriteValue<int>(MemoryWatchers.CrawlerTransition, BaseCutsceneValue + 0xF113);
            Stage += 1;
        }
        else if (MemoryWatchers.CrawlerTransition.Current >= (BaseCutsceneValue + 0xF113) && Stage == 4)
        {
            WriteValue<int>(MemoryWatchers.CrawlerTransition, BaseCutsceneValue + 0xF19E);
            Stage += 1;
        }
        else if (Stage == 5)
        {
            byte[] formation = process.ReadBytes(MemoryWatchers.Formation.Address, 3);

            Transition actorPositions;
            //Position Party Member 1
            actorPositions = new Transition { ForceLoad = false, ConsoleOutput = false, TargetActorIDs = new short[] { (short)(formation[0] + 1) }, Target_x = 97.75f, Target_y = 0.0f, Target_z = -451.00f };
            actorPositions.Execute();

            //Position Party Member 2
            actorPositions = new Transition { ForceLoad = false, ConsoleOutput = false, TargetActorIDs = new short[] { (short)(formation[1] + 1) }, Target_x = 112.25f, Target_y = 0.0f, Target_z = -425.75f };
            actorPositions.Execute();

            //Position Party Member 3
            actorPositions = new Transition { ForceLoad = false, ConsoleOutput = false, TargetActorIDs = new short[] { (short)(formation[2] + 1) }, Target_x = 135.25f, Target_y = 0.0f, Target_z = -405.50f };
            actorPositions.Execute();
            Stage += 1;
        }
        else if (MemoryWatchers.CrawlerTransition.Current == (BaseCutsceneValue + 0xF1E6) && MemoryWatchers.BattleState2.Current == 22 && Stage == 6)
        {
            WriteValue<int>(MemoryWatchers.CrawlerTransition, BaseCutsceneValue + 0xF437);
            Stage += 1;
        }

        //A value of +0x886 launches the end of the fight straight into results screen which seems to be the only way to not crash the game post battle.
        //This causes a menu glitch if game is allowed to progress past the item rewards screen so the next stage removes the menu flag once gil has finished
        //ticking and the game will process Crawler post boss logic

        else if (MemoryWatchers.GilRewardCounter.Current > 0 && Stage == 7)
        {
            Stage += 1;
        }
        else if (MemoryWatchers.GilRewardCounter.Current == 0 && Stage == 8)
        {
            process.Suspend();

            new Transition { MenuCleanup = true, AddRewardItems = true, Description = "Exit Menu", ForceLoad = false }.Execute();

            Stage += 1;

            process.Resume();
        }
    }
}