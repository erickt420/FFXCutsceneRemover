using System.Collections.Generic;
using FFXCutsceneRemover.Logging;

namespace FFXCutsceneRemover
{
    class OblitzeratorTransition : Transition
    {
        static private List<short> CutsceneAltList = new List<short>(new short[] { 2037 });
        public override void Execute(string defaultDescription = "")
        {
            if (base.memoryWatchers.OblitzeratorTransition.Current > 0)
            {
                if (CutsceneAltList.Contains(base.memoryWatchers.CutsceneAlt.Current) && Stage == 0)
                {
                    FormationSwitch = formations.PreOblitzerator;
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.OblitzeratorTransition.Current;
                    Stage += 1;

                }
                else if (base.memoryWatchers.OblitzeratorTransition.Current >= (BaseCutsceneValue + 0xEC) && Stage == 1) // 21B , EC
                {
                    WriteValue<int>(base.memoryWatchers.OblitzeratorTransition, BaseCutsceneValue + 0x142);// 30A

                    Stage += 1;
                }
                else if (base.memoryWatchers.OblitzeratorTransition.Current == (BaseCutsceneValue + 0x1A0) && Stage == 2) // 21B , EC
                {
                    WriteValue<int>(base.memoryWatchers.OblitzeratorTransition, BaseCutsceneValue + 0x30A);// 30A

                    Stage += 1;
                }
                else if (base.memoryWatchers.BattleState2.Current == 1 && Stage == 3)
                {
                    WriteValue<int>(base.memoryWatchers.OblitzeratorTransition, BaseCutsceneValue + 0x655);// 
                    Stage += 1;
                }
            }
        }
    }
}