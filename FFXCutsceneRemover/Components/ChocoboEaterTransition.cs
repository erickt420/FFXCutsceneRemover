using FFXCutsceneRemover.ComponentUtil;
using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using FFXCutsceneRemover.Logging;

namespace FFXCutsceneRemover
{
    class ChocoboEaterTransition : Transition
    {
        public override void Execute(string defaultDescription = "")
        {
            Process process = base.memoryWatchers.Process;

            if (base.memoryWatchers.ChocoboEaterTransition.Current > 0)
            {
                if (base.memoryWatchers.MovementLock.Current == 0x20 && Stage == 0)
                {
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.ChocoboEaterTransition.Current;
                    Stage += 1;

                }
                else if (base.memoryWatchers.ChocoboEaterTransition.Current >= (BaseCutsceneValue + 0x7A5) && Stage == 1) // 21B , EC
                {
                    WriteValue<int>(base.memoryWatchers.ChocoboEaterTransition, BaseCutsceneValue + 0xC96);// 30A

                    byte[] ActiveParty = process.ReadBytes(base.memoryWatchers.Formation.Address, 3);

                    for (int i = 0; i < 3; i++)
                    {
                        if (ActiveParty[i] == 0x00)
                        {
                            Transition actorPositions;
                            //Position Tidus if he is in the party
                            actorPositions = new Transition { ForceLoad = false, ConsoleOutput = false, TargetActorIDs = new short[] { 1 }, Target_x = 100.0f, Target_y = 0.0f, Target_z = 30.0f };
                            actorPositions.Execute();
                        }
                    }

                    Stage += 1;
                }
            }
        }
    }
}