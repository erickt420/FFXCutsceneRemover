using FFX_Cutscene_Remover.ComponentUtil;
using System;
using System.Diagnostics;
using System.Linq;

namespace FFXCutsceneRemover
{
    class CrawlerTransition : Transition
    {
        public override void Execute(string defaultDescription = "")
        {
            int baseAddress = base.memoryWatchers.GetBaseAddress();
            if (base.memoryWatchers.CrawlerTransition.Current > 0)
            {
                if (Stage == 0)
                {
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.CrawlerTransition.Current;
                    Console.WriteLine(BaseCutsceneValue.ToString("X2"));

                    Stage = 1;

                }
                else if (base.memoryWatchers.CrawlerTransition.Current >= (BaseCutsceneValue + 0x00) && Stage == 1)
                {
                    Console.WriteLine("Test");
                    WriteValue<int>(base.memoryWatchers.CrawlerTransition, BaseCutsceneValue + 0x6A5);
                    Stage = 2;
                }
            }
        }
    }
}