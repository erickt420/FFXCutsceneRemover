using FFX_Cutscene_Remover.ComponentUtil;
using System;
using System.Diagnostics;
using FFXCutsceneRemover.Resources;

namespace FFXCutsceneRemover
{
    class AddKimahriAbilitiesTransition : Transition
    {
        public override void Execute(string defaultDescription = "")
        {
            base.Execute();

            Process process = memoryWatchers.Process;
            int baseAddress = base.memoryWatchers.GetBaseAddress();

            MemoryWatcher<byte> abilities1 = new MemoryWatcher<byte>(new IntPtr(baseAddress + 0xD3205C + 0x94 * 0x03 + 0x3E));
            byte[] abilitiesBytes1 = process.ReadBytes(abilities1.Address, 12);

            MemoryWatcher<byte> abilities2 = new MemoryWatcher<byte>(new IntPtr(baseAddress + 0xD35E08 + 0x1C * 0x03));
            byte[] abilitiesBytes2 = process.ReadBytes(abilities2.Address, 12);

            if (Transitions.RandoSetupTransition.KimahriLancet == false)
            {
                byte nodeID = 0x44;

                int byteNum = Transitions.RandoSetupTransition.abilityMemoryLocations[nodeID][0];
                int bitNum = Transitions.RandoSetupTransition.abilityMemoryLocations[nodeID][1];

                abilitiesBytes1[byteNum] += (byte)Math.Pow(2, bitNum);
                abilitiesBytes2[byteNum] += (byte)Math.Pow(2, bitNum);
            }

            WriteBytes(abilities1, abilitiesBytes1);
            WriteBytes(abilities2, abilitiesBytes2);
        }
    }
}