using FFX_Cutscene_Remover.ComponentUtil;
using System;
using System.Diagnostics;
using FFXCutsceneRemover.Resources;
using FFXCutsceneRemover.Logging;

namespace FFXCutsceneRemover
{
    class RemoveLuluAbilitiesTransition : Transition
    {
        bool LuluBlizzard = false;
        bool LuluFire = false;
        bool LuluThunder = false;
        bool LuluWater = false;
        bool LuluThundara = false;
        bool LuluThundaga = false;

        public override void Execute(string defaultDescription = "")
        {
            base.Execute();

            Process process = memoryWatchers.Process;
            int baseAddress = base.memoryWatchers.GetBaseAddress();

            MemoryWatcher<byte> abilities1 = new MemoryWatcher<byte>(new IntPtr(baseAddress + 0xD3205C + 0x94 * 0x05 + 0x3E));
            byte[] abilitiesBytes1 = process.ReadBytes(abilities1.Address, 12);

            MemoryWatcher<byte> abilities2 = new MemoryWatcher<byte>(new IntPtr(baseAddress + 0xD35E08 + 0x1C * 0x05));
            byte[] abilitiesBytes2 = process.ReadBytes(abilities2.Address, 12);

            int memorySizeBytes = 1714;
            byte[] SphereGridBytes = process.ReadBytes(memoryWatchers.SphereGrid.Address, memorySizeBytes);

            for (int i = 0; i < memorySizeBytes / 2; i++)
            {
                if (SphereGridBytes[2 * i] == 0x64 & (SphereGridBytes[2 * i + 1] & 0x20) == 0x20)
                {
                    LuluBlizzard = true;
                }
                else if (SphereGridBytes[2 * i] == 0x65 & (SphereGridBytes[2 * i + 1] & 0x20) == 0x20)
                {
                    LuluFire = true;
                }
                else if (SphereGridBytes[2 * i] == 0x66 & (SphereGridBytes[2 * i + 1] & 0x20) == 0x20)
                {
                    LuluThunder = true;
                }
                else if (SphereGridBytes[2 * i] == 0x67 & (SphereGridBytes[2 * i + 1] & 0x20) == 0x20)
                {
                    LuluWater = true;
                }
                else if (SphereGridBytes[2 * i] == 0x6A & (SphereGridBytes[2 * i + 1] & 0x20) == 0x20)
                {
                    LuluThundara = true;
                }
                else if (SphereGridBytes[2 * i] == 0x6E & (SphereGridBytes[2 * i + 1] & 0x20) == 0x20)
                {
                    LuluThundaga = true;
                }
            }

            if (LuluBlizzard == false)
            {
                byte nodeID = 0x64;

                int byteNum = Transitions.RandoSetupTransition.abilityMemoryLocations[nodeID][0];
                int bitNum = Transitions.RandoSetupTransition.abilityMemoryLocations[nodeID][1];

                byte bitValue = (byte)Math.Pow(2, bitNum);

                if ((abilitiesBytes1[byteNum] & bitValue) == bitValue) { abilitiesBytes1[byteNum] -= bitValue; }
                if ((abilitiesBytes2[byteNum] & bitValue) == bitValue) { abilitiesBytes2[byteNum] -= bitValue; }
            }
            if (LuluFire == false)
            {
                byte nodeID = 0x65;

                int byteNum = Transitions.RandoSetupTransition.abilityMemoryLocations[nodeID][0];
                int bitNum = Transitions.RandoSetupTransition.abilityMemoryLocations[nodeID][1];

                byte bitValue = (byte)Math.Pow(2, bitNum);

                if ((abilitiesBytes1[byteNum] & bitValue) == bitValue) { abilitiesBytes1[byteNum] -= bitValue; }
                if ((abilitiesBytes2[byteNum] & bitValue) == bitValue) { abilitiesBytes2[byteNum] -= bitValue; }
            }
            if (LuluThunder == false)
            {
                byte nodeID = 0x66;

                int byteNum = Transitions.RandoSetupTransition.abilityMemoryLocations[nodeID][0];
                int bitNum = Transitions.RandoSetupTransition.abilityMemoryLocations[nodeID][1];

                byte bitValue = (byte)Math.Pow(2, bitNum);

                if ((abilitiesBytes1[byteNum] & bitValue) == bitValue) { abilitiesBytes1[byteNum] -= bitValue; }
                if ((abilitiesBytes2[byteNum] & bitValue) == bitValue) { abilitiesBytes2[byteNum] -= bitValue; }
            }
            if (LuluWater == false)
            {
                byte nodeID = 0x67;

                int byteNum = Transitions.RandoSetupTransition.abilityMemoryLocations[nodeID][0];
                int bitNum = Transitions.RandoSetupTransition.abilityMemoryLocations[nodeID][1];

                byte bitValue = (byte)Math.Pow(2, bitNum);

                if ((abilitiesBytes1[byteNum] & bitValue) == bitValue) { abilitiesBytes1[byteNum] -= bitValue; }
                if ((abilitiesBytes2[byteNum] & bitValue) == bitValue) { abilitiesBytes2[byteNum] -= bitValue; }
            }
            if (LuluThundara == false)
            {
                byte nodeID = 0x6A;

                int byteNum = Transitions.RandoSetupTransition.abilityMemoryLocations[nodeID][0];
                int bitNum = Transitions.RandoSetupTransition.abilityMemoryLocations[nodeID][1];

                byte bitValue = (byte)Math.Pow(2, bitNum);

                if ((abilitiesBytes1[byteNum] & bitValue) == bitValue) { abilitiesBytes1[byteNum] -= bitValue; }
                if ((abilitiesBytes2[byteNum] & bitValue) == bitValue) { abilitiesBytes2[byteNum] -= bitValue; }
            }
            if (LuluThundaga == false)
            {
                byte nodeID = 0x6E;

                int byteNum = Transitions.RandoSetupTransition.abilityMemoryLocations[nodeID][0];
                int bitNum = Transitions.RandoSetupTransition.abilityMemoryLocations[nodeID][1];

                byte bitValue = (byte)Math.Pow(2, bitNum);

                if ((abilitiesBytes1[byteNum] & bitValue) == bitValue) { abilitiesBytes1[byteNum] -= bitValue; }
                if ((abilitiesBytes2[byteNum] & bitValue) == bitValue) { abilitiesBytes2[byteNum] -= bitValue; }
            }

            WriteBytes(abilities1, abilitiesBytes1);
            WriteBytes(abilities2, abilitiesBytes2);
        }
    }
}