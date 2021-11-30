using FFX_Cutscene_Remover.ComponentUtil;
using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

namespace FFXCutsceneRemover
{
    class IxionTransition : Transition
    {
        static private List<short> CutsceneAltList = new List<short>(new short[] { 1641, 16, 96 });
        public override void Execute(string defaultDescription = "")
        {
            int baseAddress = base.memoryWatchers.GetBaseAddress();
            if (base.memoryWatchers.IxionTransition.Current > 0)
            {
                if (CutsceneAltList.Contains(base.memoryWatchers.CutsceneAlt.Current) && Stage == 0)
                {
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.IxionTransition.Current;

                    Stage += 1;

                }
                else if (base.memoryWatchers.IxionTransition.Current == (BaseCutsceneValue + 0xFC) && Stage == 1)
                {
                    WriteValue<int>(base.memoryWatchers.IxionTransition, BaseCutsceneValue + 0x3DC);
                    Stage += 1;
                }
            }
        }
    }
}