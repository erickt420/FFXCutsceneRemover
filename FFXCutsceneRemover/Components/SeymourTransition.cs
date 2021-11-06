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

                WriteValue<int>(base.memoryWatchers.SeymourTransition, base.memoryWatchers.SeymourTransition.Current + 0xBAF);
            }
            else if (base.memoryWatchers.Storyline.Current == 1540)
            {
                base.Execute(); // Execute the cutscene transition first (AreaID + Cutscene etc)
                WriteValue<int>(base.memoryWatchers.SeymourTransition2, base.memoryWatchers.SeymourTransition2.Current + 0x1703);
            }
        }
    }
}
