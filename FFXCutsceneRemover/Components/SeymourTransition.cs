using FFX_Cutscene_Remover.ComponentUtil;
using System;
using System.Diagnostics;
using System.Linq;

namespace FFXCutsceneRemover
{
    class SeymourTransition : Transition
    {
        public override void Execute(string defaultDescription = "")
        {
            int baseAddress = base.memoryWatchers.GetBaseAddress();

            if (base.memoryWatchers.Storyline.Current == 1530)
            {
                base.Execute(); // Execute the cutscene transition first (AreaID + Cutscene etc)
                MemoryWatcher<byte> shivaEnabled1 = new MemoryWatcher<byte>(new IntPtr(baseAddress + 0xD3211C));
                WriteValue<byte>(shivaEnabled1, 0x11);

                MemoryWatcher<byte> shivaEnabled2 = new MemoryWatcher<byte>(new IntPtr(baseAddress + 0xD326E4));
                WriteValue<byte>(shivaEnabled2, 0x11);

                BaseCutsceneValue = base.memoryWatchers.SeymourTransition.Current;
                BaseCutsceneValue2 = base.memoryWatchers.SeymourTransition2.Current;

                WriteValue<int>(base.memoryWatchers.SeymourTransition, BaseCutsceneValue + 0xBAF);
            }
            else if (base.memoryWatchers.Storyline.Current == 1540 & base.memoryWatchers.SeymourTransition2.Current > BaseCutsceneValue2)
            {
                Storyline = 1545;
                ForceLoad = false;
                Description = "Post-Seymour";
                Formation = null;
                base.Execute(); // Execute the cutscene transition first (AreaID + Cutscene etc)
                WriteValue<int>(base.memoryWatchers.SeymourTransition2, BaseCutsceneValue2 + 0x1703);
            }
        }
    }
}
