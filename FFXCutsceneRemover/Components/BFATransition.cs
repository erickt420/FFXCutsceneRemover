using FFX_Cutscene_Remover.ComponentUtil;
using System;
using System.Diagnostics;
using System.Linq;

namespace FFXCutsceneRemover
{
    class BFATransition : Transition
    {
        IntPtr PointerAddress = default;
        public override void Execute(string defaultDescription = "")
        {
            int baseAddress = base.memoryWatchers.GetBaseAddress();
            Process process = base.memoryWatchers.Process;

            if (base.memoryWatchers.BFATransition.Current > 0)
            {

                if (base.Stage == 0)
                {
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.BFATransition.Current;
                    PointerAddress = new IntPtr(base.memoryWatchers.BFATransitionAddress.Current + 0xFDC);

                    base.Stage = 1;

                }
                else if (base.Stage == 1)
                {
                    int val;
                    process.ReadValue(PointerAddress, out val);
                    if (val >= (BaseCutsceneValue + 0x0))
                    {
                        process.WriteValue<int>(PointerAddress, BaseCutsceneValue + 0x907);
                        base.Stage = 2;
                    }
                    process.ReadValue(PointerAddress, out val);
                }
                else if (base.Stage == 2)
                {
                    int val;
                    process.ReadValue(PointerAddress, out val);
                    if (val >= (BaseCutsceneValue + 0x908)) {
                        process.WriteValue<int>(PointerAddress, BaseCutsceneValue + 0xC42);
                        base.Stage = 3;
                    }
                    process.ReadValue(PointerAddress, out val);
                }
                else if (base.Stage == 3)
                {
                    int val;
                    process.ReadValue(PointerAddress, out val);
                    if (val >= (BaseCutsceneValue + 0xCBD))
                    {
                        process.WriteValue<int>(PointerAddress, BaseCutsceneValue + 0xFCA);
                        base.Stage = 4;
                    }
                    process.ReadValue(PointerAddress, out val);
                }
                else
                {
                    //Do Nothing
                }            
            }
        }
    }
}