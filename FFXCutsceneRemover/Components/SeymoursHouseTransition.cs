using FFX_Cutscene_Remover.ComponentUtil;
using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using FFXCutsceneRemover.Logging;

namespace FFXCutsceneRemover
{
    class SeymoursHouseTransition : Transition
    {
        Boolean TalkedToAuron = false;
        Boolean TalkedToWakka = false;
        Boolean TalkedToLulu = false;
        Boolean TalkedToRikku = false;
        public override void Execute(string defaultDescription = "")
        {
            Process process = memoryWatchers.Process;
            
            if (Stage == 0)
            {
                base.Execute();

                BaseCutsceneValue = base.memoryWatchers.EventFileStart.Current;

                Stage += 1;
            }
            else if (base.memoryWatchers.SeymoursHouseTransition1.Current == (BaseCutsceneValue + 0x730E) && Stage == 1)
            {
                WriteValue<int>(base.memoryWatchers.SeymoursHouseTransition1, BaseCutsceneValue + 0x7372);
                TalkedToAuron = true;
                Stage += 1;
            }
            else if (base.memoryWatchers.SeymoursHouseTransition2.Current == (BaseCutsceneValue + 0x7122) && Stage == 2)
            {
                WriteValue<int>(base.memoryWatchers.SeymoursHouseTransition2, BaseCutsceneValue + 0x7263);
                TalkedToAuron = true;
                //Stage += 1;
            }
            else if (base.memoryWatchers.SeymoursHouseTransition2.Current == (BaseCutsceneValue + 0x6EC1) && Stage == 2)
            {
                WriteValue<int>(base.memoryWatchers.SeymoursHouseTransition2, BaseCutsceneValue + 0x70B5);
                TalkedToLulu = true;
                //Stage += 1;
            }
            else if (base.memoryWatchers.NPCLastInteraction.Current == 2 && Stage == 2)
            {
                TalkedToWakka = true;
                //Stage += 1;
            }
            else if (base.memoryWatchers.NPCLastInteraction.Current == 5 && Stage == 2)
            {
                TalkedToRikku = true;
                //Stage += 1;
            }

            if (TalkedToAuron && TalkedToWakka && TalkedToLulu && TalkedToRikku && base.memoryWatchers.NPCLastInteraction.Current == 1)
            {
                new Transition { RoomNumber = 197, Description = "Lady Yuna, this way." }.Execute();
            }
        }
    }
}