using FFX_Cutscene_Remover.ComponentUtil;
using System;

namespace FFXCutsceneRemover
{
    /* Special transition for the 'Yuna says goodbye to Besaid' cutscene. Many things get added, enabled and equipped here.
       Would have been a crazy amount of MemoryWatchers to add, most of which are only used once for this cutscene, so just
       figured it made more sense to have one special transition here that derives from the Transition class */
    class BrotherhoodTransition : Transition
    {
        public override void Execute()
        {
            base.Execute(); // Execute the cutscene transition first (AreaID + Cutscene + SpawnPoint + EnableYuna + EnableLulu)
            int baseAddress = base.memoryWatchers.GetBaseAddress();

            MemoryWatcher<byte> unequipLongsword = new MemoryWatcher<byte>(new IntPtr(baseAddress + 0xD30F32));
            WriteValue<byte>(unequipLongsword, 0xFF);

            MemoryWatcher<byte> addYunaStaff = new MemoryWatcher<byte>(new IntPtr(baseAddress + 0xD30F5B));
            WriteValue<byte>(addYunaStaff, 0x0);

            MemoryWatcher<byte> addYunaRing = new MemoryWatcher<byte>(new IntPtr(baseAddress + 0xD30F71));
            WriteValue<byte>(addYunaRing, 0x0);

            MemoryWatcher<byte> addLuluMoogle = new MemoryWatcher<byte>(new IntPtr(baseAddress + 0xD30FDF));
            WriteValue<byte>(addLuluMoogle, 0x0);

            MemoryWatcher<byte> addLuluBangle = new MemoryWatcher<byte>(new IntPtr(baseAddress + 0xD30FF5));
            WriteValue<byte>(addLuluBangle, 0x0);

            MemoryWatcher<byte> addBrotherhood = new MemoryWatcher<byte>(new IntPtr(baseAddress + 0xD3121B));
            WriteValue<byte>(addBrotherhood, 0x9);

            // By triangle I mean the small triangle that appears in menus to show what item is equipped
            MemoryWatcher<byte> equipBrotherhoodTriangle = new MemoryWatcher<byte>(new IntPtr(baseAddress + 0xD3121E));
            WriteValue<byte>(equipBrotherhoodTriangle, 0x0);

            MemoryWatcher<byte> equipBrotherhood = new MemoryWatcher<byte>(new IntPtr(baseAddress + 0xD32089));
            WriteValue<byte>(equipBrotherhood, 0x22);
        }
    }
}
