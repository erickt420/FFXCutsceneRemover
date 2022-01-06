using FFX_Cutscene_Remover.ComponentUtil;
using System.Diagnostics;
using System.Collections.Generic;
using FFXCutsceneRemover.Logging;

namespace FFXCutsceneRemover
{
    class CrawlerTransition : Transition
    {
        static private List<short> CutsceneAltList = new List<short>(new short[] { 1839 });
        public override void Execute(string defaultDescription = "")
        {
            Process process = memoryWatchers.Process;

            if (base.memoryWatchers.CrawlerTransition.Current > 0)
            {
                if (CutsceneAltList.Contains(base.memoryWatchers.CutsceneAlt.Current) && Stage == 0)
                {
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.CrawlerTransition.Current;

                    Stage += 1;

                }
                //First 4 stages are an attempt to emulate the logic from the PS2 Pnach. Values don't line up perfectly but it works.
                else if (base.memoryWatchers.CrawlerTransition.Current == (BaseCutsceneValue + 0x11) && Stage == 1)
                {
                    WriteValue<int>(base.memoryWatchers.CrawlerTransition, BaseCutsceneValue + 0x466);
                    Stage += 1;
                }
                else if (base.memoryWatchers.CrawlerTransition.Current >= (BaseCutsceneValue + 0x47C) && Stage == 2)
                {
                    WriteValue<int>(base.memoryWatchers.CrawlerTransition, BaseCutsceneValue + 0x542);
                    Stage += 1;
                }
                else if (base.memoryWatchers.CrawlerTransition.Current >= (BaseCutsceneValue + 0x54B) && Stage == 3)
                {
                    WriteValue<int>(base.memoryWatchers.CrawlerTransition, BaseCutsceneValue + 0x562);
                    Stage += 1;
                }
                else if (base.memoryWatchers.CrawlerTransition.Current >= (BaseCutsceneValue + 0x562) && Stage == 4)
                {
                    WriteValue<int>(base.memoryWatchers.CrawlerTransition, BaseCutsceneValue + 0x5ED);
                    Stage += 1;
                }
                else if (base.memoryWatchers.CrawlerTransition.Current == (BaseCutsceneValue + 0x635) && base.memoryWatchers.HpEnemyA.Current < 16000 && base.memoryWatchers.HpEnemyA.Old == 16000 && Stage == 5)
                {
                    DiagnosticLog.Information("HP Check");
                    WriteValue<int>(base.memoryWatchers.CrawlerTransition, BaseCutsceneValue + 0x886);
                    Stage += 1;
                }

                //A value of +0x886 launches the end of the fight straight into results screen which seems to be the only way to not crash the game post battle.
                //This causes a menu glitch if game is allowed to progress past the item rewards screen so the next stage removes the menu flag once gil has finished
                //ticking and the game will process Crawler post boss logic

                else if (base.memoryWatchers.Gil.Current > base.memoryWatchers.Gil.Old && Stage == 6)
                {
                    Stage += 1;
                }
                else if (base.memoryWatchers.Gil.Current == base.memoryWatchers.Gil.Old && Stage == 7)
                {
                    process.Suspend();

                    Transition FormationSwitch = new Transition { ForceLoad = false, ConsoleOutput = false, FormationSwitch = Transition.formations.PostCrawler, Description = "Fix party after Crawler" };
                    FormationSwitch.Execute();

                    Transition ExitMenu = new Transition { Menu = 0, Description = "Exit Menu", ForceLoad = false };
                    ExitMenu.Execute();

                    Stage += 1;

                    process.Resume();
                }
            }
        }
    }
}