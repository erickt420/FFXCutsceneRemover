using FFX_Cutscene_Remover.ComponentUtil;
using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

namespace FFXCutsceneRemover
{
    class CrawlerTransition : Transition
    {
        static private List<short> CutsceneAltList = new List<short>(new short[] { 190, 665, 111});
        public override void Execute(string defaultDescription = "")
        {
            int baseAddress = base.memoryWatchers.GetBaseAddress();
            if (base.memoryWatchers.CrawlerTransition.Current > 0)
            {
                if (CutsceneAltList.Contains(base.memoryWatchers.CutsceneAlt.Current) && Stage == 0)
                {
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.CrawlerTransition.Current;
                    Console.WriteLine(BaseCutsceneValue.ToString("X2"));

                    Stage = 1;

                }
                //First 4 stages are an attempt to emulate the logic from the PS2 Pnach. Values don't line up perfectly but it works.
                else if (base.memoryWatchers.CrawlerTransition.Current >= (BaseCutsceneValue + 0x11) && Stage == 1)
                {
                    Console.WriteLine("Test " + Stage.ToString());
                    WriteValue<int>(base.memoryWatchers.CrawlerTransition, BaseCutsceneValue + 0x466);
                    Stage = 2;
                }
                else if (base.memoryWatchers.CrawlerTransition.Current >= (BaseCutsceneValue + 0x47C) && Stage == 2)
                {
                    Console.WriteLine("Test " + Stage.ToString());
                    WriteValue<int>(base.memoryWatchers.CrawlerTransition, BaseCutsceneValue + 0x542);
                    Stage = 3;
                }
                else if (base.memoryWatchers.CrawlerTransition.Current >= (BaseCutsceneValue + 0x54B) && Stage == 3)
                {
                    Console.WriteLine("Test " + Stage.ToString());
                    WriteValue<int>(base.memoryWatchers.CrawlerTransition, BaseCutsceneValue + 0x562);
                    Stage = 4;
                }
                else if (base.memoryWatchers.CrawlerTransition.Current >= (BaseCutsceneValue + 0x562) && Stage == 4)
                {
                    Console.WriteLine("Test " + Stage.ToString());
                    WriteValue<int>(base.memoryWatchers.CrawlerTransition, BaseCutsceneValue + 0x5ED);
                    Stage = 5;
                }
                else if (base.memoryWatchers.CrawlerTransition.Current >= (BaseCutsceneValue + 0x635) && Stage == 5)
                {
                    Console.WriteLine("Test " + Stage.ToString());
                    WriteValue<int>(base.memoryWatchers.CrawlerTransition, BaseCutsceneValue + 0x886);
                    Stage = 6;
                }

                //A value of +0x886 launches the end of the fight straight into results screen which seems to be the only way to not crash the game post battle.
                //This causes a menu glitch if game is allowed to progress past the item rewards screen so the next stage removes the menu flag once gil has finished
                //ticking and the game will process Crawler post boss logic

                else if (base.memoryWatchers.Gil.Current > base.memoryWatchers.Gil.Old && Stage == 6)
                {
                    Console.WriteLine("Test " + Stage.ToString());
                    Stage = 7;
                }
                else if (base.memoryWatchers.Gil.Current == base.memoryWatchers.Gil.Old && Stage == 7)
                {
                    Console.WriteLine("Test " + Stage.ToString());
                    Menu = 0;
                    Description = "Exit Menu";
                    ForceLoad = false;
                    base.Execute();
                    Stage = 8;
                }
            }
        }
    }
}