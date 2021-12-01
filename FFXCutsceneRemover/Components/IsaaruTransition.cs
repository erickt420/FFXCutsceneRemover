using FFX_Cutscene_Remover.ComponentUtil;
using System;
using System.Diagnostics;
using System.Linq;
using FFXCutsceneRemover.Logging;

namespace FFXCutsceneRemover
{
    class IsaaruTransition : Transition
    {
        public override void Execute(string defaultDescription = "")
        {
            int baseAddress = base.memoryWatchers.GetBaseAddress();

            if (base.memoryWatchers.IsaaruTransition.Current > 0)
            {
                if (base.memoryWatchers.State.Current == 1 && Stage == 0)
                {
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.IsaaruTransition.Current;
                    DiagnosticLog.Information(BaseCutsceneValue.ToString("X2"));

                    Stage += 1;

                }
                // If we enter a battle before Isaaru reset to stage 0 so we can get the Base Cutscene Value again.
                // This is needed because sometimes after a Maze Larva battle the cutscene value will progress for seemingly no reason.
                else if (base.memoryWatchers.State.Current == 2 && Stage == 1)
                {
                    ConsoleOutput = false;
                    Stage = 0;
                }
                else if (base.memoryWatchers.IsaaruTransition.Current >= (BaseCutsceneValue + 0x104) && Stage == 1)
                {
                    DiagnosticLog.Information("Stage: " + Stage.ToString());
                    Formation = new byte[] { 0x01, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
                    base.Execute();

                    WriteValue<int>(base.memoryWatchers.IsaaruTransition, BaseCutsceneValue + 0x2F1);
                    Stage += 1;
                }
                else if (base.memoryWatchers.IsaaruTransition.Current >= (BaseCutsceneValue + 0x3BC) && Stage == 2)
                {
                    WriteValue<int>(base.memoryWatchers.IsaaruTransition, BaseCutsceneValue + 0x5C4);
                    Stage += 1;
                }
            }
        }
    }
}