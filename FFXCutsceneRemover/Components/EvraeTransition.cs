using FFX_Cutscene_Remover.ComponentUtil;
using System;
using System.Diagnostics;
using System.Linq;

namespace FFXCutsceneRemover
{
    class EvraeTransition : Transition
    {
        static private byte[] formation = new byte[] { 0x00, 0x02, 0x03, 0x04, 0x05, 0x06, 0xFF, 0xFF };
        public override void Execute(string defaultDescription = "")
        {
            Process process = memoryWatchers.Process;

            if (Stage == 0)
            {
                base.Execute();

                BaseCutsceneValue = base.memoryWatchers.EventFileStart.Current;

                Stage += 1;

            }
            else if (base.memoryWatchers.State.Current == 0 && Stage == 1)
            {
                WriteValue<int>(base.memoryWatchers.EvraeTransition, BaseCutsceneValue + 0x7D6C);

                formation = process.ReadBytes(base.memoryWatchers.Formation.Address, 8);

                Transition actorPositions;
                //Position backup party members in narnia so they don't appear during transition
                short partyMember4 = (short)(formation[3] + 1);
                short partyMember5 = (short)(formation[4] + 1);
                short partyMember6 = (short)(formation[5] + 1);
                short partyMember7 = (short)(formation[6] + 1);
                actorPositions = new Transition { ForceLoad = false, ConsoleOutput = false, TargetActorIDs = new short[] { partyMember4, partyMember5, partyMember6, partyMember7 }, Target_x = 1000.0f, Target_z = 1000.0f };
                actorPositions.Execute();

                //Position Evrae
                actorPositions = new Transition { ForceLoad = false, ConsoleOutput = false, TargetActorIDs = new short[] { 4215 }, Target_x = -140.0f, Target_y = -35.0f, Target_z = 80.0f };
                actorPositions.Execute();

                Stage += 1;
            }
            else if (base.memoryWatchers.EvraeTransition.Current >= (BaseCutsceneValue + 0x7DD5) && Stage == 2)
            {
                WriteValue<int>(base.memoryWatchers.EvraeTransition, BaseCutsceneValue + 0x7E0A);

                Stage += 1;
            }
            else if (base.memoryWatchers.BattleState.Current == 522 && base.memoryWatchers.CutsceneAlt.Current == 420 && Stage == 3)
            {
                RoomNumber = 194;
                Storyline = 2050;
                ConsoleOutput = false;
                ForceLoad = true;
                base.Execute();
                Stage += 1;
            }
        }
    }
}