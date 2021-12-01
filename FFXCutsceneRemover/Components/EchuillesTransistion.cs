using FFX_Cutscene_Remover.ComponentUtil;
using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using FFXCutsceneRemover.Logging;

namespace FFXCutsceneRemover
{
    class EchuillesTransition : Transition
    {
        static private List<short> CutsceneAltList = new List<short>(new short[] { 180, 213, 5079 });
        public override void Execute(string defaultDescription = "")
        {
            int baseAddress = base.memoryWatchers.GetBaseAddress();
            if (base.memoryWatchers.EchuillesTransition.Current > 0)
            {
                if (CutsceneAltList.Contains(base.memoryWatchers.CutsceneAlt.Current) && Stage == 0)
                {
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.EchuillesTransition.Current;
                    DiagnosticLog.Information(BaseCutsceneValue.ToString("X2"));
                    Stage += 1;

                }
                else if (base.memoryWatchers.EchuillesTransition.Current >= (BaseCutsceneValue + 0x59) && Stage == 1)
                {
                    WriteValue<int>(base.memoryWatchers.EchuillesTransition, BaseCutsceneValue + 0x419);

                    Transition actorPositions;

                    //Position Echuilles
                    actorPositions = new Transition { ForceLoad = false, ConsoleOutput = false, TargetActorID = 4210, Target_x = 0.0f, Target_y = -124.0f, Target_z = -40.0f };
                    actorPositions.Execute();

                    Stage += 1;
                }
                else if (base.memoryWatchers.EchuillesTransition.Current == (BaseCutsceneValue + 0x4C6) && base.memoryWatchers.HpEnemyA.Current < 2000 && base.memoryWatchers.HpEnemyA.Old == 2000 && Stage == 2)
                {
                    WriteValue<int>(base.memoryWatchers.EchuillesTransition, BaseCutsceneValue + 0x593);
                    Stage += 1;
                }
                else if (base.memoryWatchers.Gil.Current > base.memoryWatchers.Gil.Old && Stage == 3)
                {
                    Stage += 1;
                }
                else if (base.memoryWatchers.Gil.Current == base.memoryWatchers.Gil.Old && Stage == 4)
                {
                    Menu = 0;
                    Description = "Exit Menu";
                    ForceLoad = false;
                    base.Execute();
                    Stage = 6;
                }
            }
        }
    }
}