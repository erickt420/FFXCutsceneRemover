using FFX_Cutscene_Remover.ComponentUtil;
using System;
using System.Diagnostics;
using FFXCutsceneRemover.Resources;

namespace FFXCutsceneRemover
{
    class AddRikkuAbilitiesTransition : Transition
    {
        bool RikkuSteal = false;
        bool RikkuUse = false;
        public override void Execute(string defaultDescription = "")
        {
            base.Execute();

            Process process = memoryWatchers.Process;
            int baseAddress = base.memoryWatchers.GetBaseAddress();

            MemoryWatcher<byte> abilities1 = new MemoryWatcher<byte>(new IntPtr(baseAddress + 0xD3205C + 0x94 * 0x06 + 0x3E));
            byte[] abilitiesBytes1 = process.ReadBytes(abilities1.Address, 12);

            MemoryWatcher<byte> abilities2 = new MemoryWatcher<byte>(new IntPtr(baseAddress + 0xD35E08 + 0x1C * 0x06));
            byte[] abilitiesBytes2 = process.ReadBytes(abilities2.Address, 12);

            int memorySizeBytes = 1714;
            byte[] SphereGridBytes = process.ReadBytes(memoryWatchers.SphereGrid.Address, memorySizeBytes);

            for (int i = 0; i < memorySizeBytes / 2; i++)
            {
                if (SphereGridBytes[2 * i] == 0x3A & (SphereGridBytes[2 * i + 1] & 0x40) == 0x40)
                {
                    RikkuSteal = true;
                }
                else if (SphereGridBytes[2 * i] == 0x3B & (SphereGridBytes[2 * i + 1] & 0x40) == 0x40)
                {
                    RikkuUse = true;
                }
            }

            if (RikkuSteal == false)
            {
                byte nodeID = 0x3A;

                int byteNum = Transitions.RandoSetupTransition.abilityMemoryLocations[nodeID][0];
                int bitNum = Transitions.RandoSetupTransition.abilityMemoryLocations[nodeID][1];

                byte bitValue = (byte)Math.Pow(2, bitNum);

                if ((abilitiesBytes1[byteNum] & bitValue) == 0x00) { abilitiesBytes1[byteNum] += bitValue; }
                if ((abilitiesBytes2[byteNum] & bitValue) == 0x00) { abilitiesBytes2[byteNum] += bitValue; }
            }
            if (RikkuUse == false)
            {
                byte nodeID = 0x3B;

                int byteNum = Transitions.RandoSetupTransition.abilityMemoryLocations[nodeID][0];
                int bitNum = Transitions.RandoSetupTransition.abilityMemoryLocations[nodeID][1];

                byte bitValue = (byte)Math.Pow(2, bitNum);

                if ((abilitiesBytes1[byteNum] & bitValue) == 0x00) { abilitiesBytes1[byteNum] += bitValue; }
                if ((abilitiesBytes2[byteNum] & bitValue) == 0x00) { abilitiesBytes2[byteNum] += bitValue; }
            }

            WriteBytes(abilities1, abilitiesBytes1);
            WriteBytes(abilities2, abilitiesBytes2);
        }
    }
}