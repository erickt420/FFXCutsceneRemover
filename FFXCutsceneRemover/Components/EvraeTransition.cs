using FFX_Cutscene_Remover.ComponentUtil;
using FFXCutsceneRemover.Logging;
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

            if (base.memoryWatchers.FrameCounterFromLoad.Current < 5 && Stage == 0) // Frame counter condition is to make skip work when loading from an autosave
            {
                base.Execute();

                BaseCutsceneValue = base.memoryWatchers.EventFileStart.Current;
                Stage += 1;

            }
            else if (base.memoryWatchers.State.Current == 0 && Stage == 1)
            {
                WriteValue<int>(base.memoryWatchers.EvraeTransition, BaseCutsceneValue + 0x7AEA); // 0x7D6C 0x7C9F

                formation = process.ReadBytes(base.memoryWatchers.Formation.Address, 8);

                Transition actorPositions;
                //Position Party Member 1
                actorPositions = new Transition { ForceLoad = false, ConsoleOutput = false, TargetActorIDs = new short[] { (short)(formation[0] + 1) }, Target_x = -25.0f, Target_y = -35.53496933f, Target_z = 119.9999924f, Target_var1 = 21};
                actorPositions.Execute();

                //Position Party Member 2
                actorPositions = new Transition { ForceLoad = false, ConsoleOutput = false, TargetActorIDs = new short[] { (short)(formation[1] + 1) }, Target_x = -20.0f, Target_y = -35.85807419f, Target_z = 80.0f, Target_var1 = 19 };
                actorPositions.Execute();

                //Position Party Member 3
                actorPositions = new Transition { ForceLoad = false, ConsoleOutput = false, TargetActorIDs = new short[] { (short)(formation[2] + 1) }, Target_x = -15.00001526f, Target_y = -35.72403336f, Target_z = 40.0f, Target_var1 = 17 };
                actorPositions.Execute();
                
                //Position Evrae
                actorPositions = new Transition { ForceLoad = false, ConsoleOutput = false, TargetActorIDs = new short[] { 4215 }, Target_x = -140.0f, Target_y = -35.0f, Target_z = 80.0f };
                actorPositions.Execute();

                Stage += 1;
            }
            else if (base.memoryWatchers.EvraeTransition.Current >= (BaseCutsceneValue + 0x7AEB) && Stage == 2)
            {
                WriteValue<int>(base.memoryWatchers.EvraeTransition, BaseCutsceneValue + 0x7D6C);

                Stage += 1;
            }
            else if (base.memoryWatchers.BattleState.Current == 522 && base.memoryWatchers.CutsceneAlt.Current == 420 && Stage == 3)
            {
                Transition actorPositions;
                //Position Rikku
                actorPositions = new Transition { ForceLoad = false, ConsoleOutput = false, TargetActorIDs = new short[] { 7 }, Target_x = -20.0f, Target_y = -35.85807419f, Target_z = 80.0f, Target_var1 = 19 };
                actorPositions.Execute();

                Stage += 1;
            }
        }
    }
}