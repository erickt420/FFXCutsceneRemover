using FFX_Cutscene_Remover.ComponentUtil;
using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

namespace FFXCutsceneRemover
{
    class SinFinTransition : Transition
    {
        static private List<short> CutsceneAltList = new List<short>(new short[] { 205, 195, 16 });
        public override void Execute(string defaultDescription = "")
        {
            int baseAddress = base.memoryWatchers.GetBaseAddress();
            if (base.memoryWatchers.SinFinTransition.Current > 0)
            {
                if (CutsceneAltList.Contains(base.memoryWatchers.CutsceneAlt.Current) && Stage == 0)
                {
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.SinFinTransition.Current;

                    Stage = 1;

                }
                else if (base.memoryWatchers.SinFinTransition.Current == (BaseCutsceneValue + 0x76F) && Stage == 1)
                {
                    WriteValue<int>(base.memoryWatchers.SinFinTransition, BaseCutsceneValue + 0xBF0);

                    Transition actorPositions;

                    //Position Tidus
                    actorPositions = new Transition { ForceLoad = false, ConsoleOutput = false, TargetActorID = 1, Target_x = -29.0f, Target_y = -50.0f, Target_z = 131.5f };
                    actorPositions.Execute();

                    //Position Sin Fin
                    actorPositions = new Transition { ForceLoad = false, ConsoleOutput = false, TargetActorID = 4209, Target_x = 1.0f, Target_z = 945.0f};
                    actorPositions.Execute();

                    Stage += 1;
                }
                else if (base.memoryWatchers.SinFinTransition.Current == (BaseCutsceneValue + 0xCFD) && base.memoryWatchers.TidusActionCount.Current == 1 && Stage == 2) //200 = Sinscale HP
                {
                    Storyline = 272;
                    ForceLoad = false;
                    Description = "Post Sin Fin";
                    base.Execute();
                    WriteValue<int>(base.memoryWatchers.SinFinTransition, BaseCutsceneValue + 0x114A);
                    Stage += 1;
                }
            }
        }
    }
}