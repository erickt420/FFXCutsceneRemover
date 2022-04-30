using FFXCutsceneRemover.Logging;
using FFX_Cutscene_Remover.ComponentUtil;
using System.Diagnostics;
using System.Collections.Generic;

namespace FFXCutsceneRemover
{
    class BahamutFaythTransition2 : Transition
    {
        static private List<short> CutsceneAltList2 = new List<short>(new short[] { 4449, 4450 });

        public override void Execute(string defaultDescription = "")
        {
            Process process = memoryWatchers.Process;

            if (base.memoryWatchers.Dialogue1.Current == 30 && Stage == 0)
            {
                process.Suspend();

                short? NewAirshipDestinations = (short?)(base.memoryWatchers.AirshipDestinations.Current + 512);

                new Transition { RoomNumber = 255, Storyline = 2970, SpawnPoint = 0, AirshipDestinations = NewAirshipDestinations, PositionTidusAfterLoad = true, Target_x = -242.8587952f, Target_y = 12.12630653f, Target_z = 160.4484863f, Target_rot = 1.556545019f, Target_var1 = 1390, Description = "Return from Highbridge" }.Execute();

                Stage += 1;

                process.Resume();
            }
        }
    }
}
