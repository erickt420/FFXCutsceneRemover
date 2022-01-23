using FFX_Cutscene_Remover.ComponentUtil;
using FFXCutsceneRemover.Logging;
using FFXCutsceneRemover.Resources;
using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Text.Json;
using System.IO;
using MathNet.Numerics.Distributions;
using MathNet.Numerics.Statistics;

namespace FFXCutsceneRemover
{
    class RandoAbilityBalance : Transition
    {
        int quickHitIndex = 21;
        public override void Execute(string defaultDescription = "")
        {
            base.Execute();

            ConsoleOutput = false;

            editAbility(abilityIndex: quickHitIndex, rank: 1);
        }

        private void editAbility(int abilityIndex, byte? rank = null, byte? MP = null)
        {
            int baseAddress = base.memoryWatchers.GetBaseAddress();
            int rankOffset = 0x14 + abilityIndex * 0x60 + 0x24;
            int MPOffset = 0x14 + abilityIndex * 0x60 + 0x25;

            MemoryWatcher<int> abilityRank = new MemoryWatcher<int>(new DeepPointer(new IntPtr(baseAddress + 0xD2A92C), new int[] { rankOffset }));
            MemoryWatcher<int> abilityMP = new MemoryWatcher<int>(new DeepPointer(new IntPtr(baseAddress + 0xD2A92C), new int[] { MPOffset }));

            if (!(rank is null))
            {
                WriteValue(abilityRank, rank);
            }
            if (!(MP is null))
            {
                WriteValue(abilityMP, MP);
            }
        }

    }
}