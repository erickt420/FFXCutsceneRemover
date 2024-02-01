using System;
using System.Diagnostics;
using System.Linq;

using FFXCutsceneRemover.ComponentUtil;

namespace FFXCutsceneRemover;

/* Special transition for the 'Yuna says goodbye to Besaid' cutscene. Many things get added, enabled and equipped here.
   Would have been a crazy amount of MemoryWatchers to add, most of which are only used once for this cutscene, so just
   figured it made more sense to have one special transition here that derives from the Transition class */
class BrotherhoodTransition : Transition
{
    public override void Execute(string defaultDescription = "")
    {
        base.Execute(); // Execute the cutscene transition first (AreaID + Cutscene + SpawnPoint + EnableYuna + EnableLulu)
        int baseAddress = MemoryWatchers.GetBaseAddress();

        int equipmentStructRelativeOffset = 0xD30F2C;
        byte equipmentStructSizeBytes = 22;
        byte equipmentEquippedFlagOffset = 0x06;

        int characterDataStructRelativeOffset = 0xD3205C;
        byte characterDataStructSizeBytes = 148;
        byte equippedWeaponIndexOffset = 0x2D;
        byte equippedArmorIndexOffset = 0x2E;

        byte equipmentIndex;
        byte characterIndex;

        equipmentIndex = 0;
        MemoryWatcher<byte> unequipLongsword = new MemoryWatcher<byte>(new IntPtr(baseAddress + equipmentStructRelativeOffset + equipmentStructSizeBytes * equipmentIndex + equipmentEquippedFlagOffset));
        WriteValue<byte>(unequipLongsword, 0xFF);

        equipmentIndex = 2;
        MemoryWatcher<byte> addYunaStaff = new MemoryWatcher<byte>(new IntPtr(baseAddress + equipmentStructRelativeOffset + equipmentStructSizeBytes * equipmentIndex + 0x03));
        WriteValue<byte>(addYunaStaff, 0x00);

        equipmentIndex = 3;
        MemoryWatcher<byte> addYunaRing = new MemoryWatcher<byte>(new IntPtr(baseAddress + equipmentStructRelativeOffset + equipmentStructSizeBytes * equipmentIndex + 0x03));
        WriteValue<byte>(addYunaRing, 0x00);

        equipmentIndex = 8;
        MemoryWatcher<byte> addLuluMoogle = new MemoryWatcher<byte>(new IntPtr(baseAddress + equipmentStructRelativeOffset + equipmentStructSizeBytes * equipmentIndex + 0x03));
        WriteValue<byte>(addLuluMoogle, 0x00);

        equipmentIndex = 9;
        MemoryWatcher<byte> addLuluBangle = new MemoryWatcher<byte>(new IntPtr(baseAddress + equipmentStructRelativeOffset + equipmentStructSizeBytes * equipmentIndex + 0x03));
        WriteValue<byte>(addLuluBangle, 0x00);

        equipmentIndex = 34;
        MemoryWatcher<byte> addBrotherhood = new MemoryWatcher<byte>(new IntPtr(baseAddress + equipmentStructRelativeOffset + equipmentStructSizeBytes * equipmentIndex + 0x03));
        WriteValue<byte>(addBrotherhood, 0x09);

        // By triangle I mean the small triangle that appears in menus to show what item is equipped
        equipmentIndex = 34;
        MemoryWatcher<byte> equipBrotherhoodTriangle = new MemoryWatcher<byte>(new IntPtr(baseAddress + equipmentStructRelativeOffset + equipmentStructSizeBytes * equipmentIndex + equipmentEquippedFlagOffset));
        WriteValue<byte>(equipBrotherhoodTriangle, 0x00);

        characterIndex = 0;
        MemoryWatcher<byte> equipBrotherhood = new MemoryWatcher<byte>(new IntPtr(baseAddress + characterDataStructRelativeOffset + characterDataStructSizeBytes * characterIndex + equippedWeaponIndexOffset));
        WriteValue<byte>(equipBrotherhood, 0x22);

        // Adding the map to the first empty slot in the item menu
        IntPtr ItemMenu = new IntPtr(baseAddress + 0xD3095C); // Address of beginning of Item menu
        IntPtr ItemCount = IntPtr.Add(ItemMenu, 512); // Total number of bytes of Item menu before the count for each item is stored

        bool foundEmptySlot = false;
        var emptySlot = new byte[2] { 0xFF, 0x00 }; // How empty slots are represented in hex
        int count = 0;
        Process process = MemoryWatchers.Process;

        while (!foundEmptySlot)
        {
            // Check the two bytes for each item and compare against empty slot representation
            var item = process.ReadBytes(ItemMenu, 2);

            if (item.SequenceEqual<byte>(emptySlot))
            {
                foundEmptySlot = true;
                IntPtr MapCount = IntPtr.Add(ItemCount, count);

                process.WriteBytes(ItemMenu, new byte[] { 0x64, 0x20 }); // Map location in item menu
                process.WriteValue<byte>(MapCount, 1); // Number of maps to add
                break;
            }
            else
            {
                // Not found an empty slot yet, so advance two bytes to the next item
                ItemMenu = IntPtr.Add(ItemMenu, 2);
                ++count;
            }
        }
    }
}
