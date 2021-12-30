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
                if (Stage == 0)
                {
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.IsaaruTransition.Current;
                    DiagnosticLog.Information(BaseCutsceneValue.ToString("X8"));

                    Stage += 1;

                }
                else if (base.memoryWatchers.State.Current == 1 && Stage == 1)
                {
                    DiagnosticLog.Information("Stage: " + Stage.ToString());
                    BaseCutsceneValue2 = base.memoryWatchers.IsaaruTransition.Current;
                    DiagnosticLog.Information(BaseCutsceneValue2.ToString("X8"));

                    Stage += 1;

                }
                // If we enter a battle before Isaaru reset to stage 0 so we can get the Base Cutscene Value again.
                // This is needed because sometimes after a Maze Larva battle the cutscene value will progress for seemingly no reason.
                else if (base.memoryWatchers.State.Current == 2 && Stage == 2)
                {
                    DiagnosticLog.Information("Stage: " + Stage.ToString());
                    Stage -= 1;
                }
                else if (base.memoryWatchers.IsaaruTransition.Current == (BaseCutsceneValue2 + 0x32) && Stage == 2)
                {
                    DiagnosticLog.Information("Stage: " + Stage.ToString());
                    Formation = new byte[] { 0x01, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
                    ConsoleOutput = false;
                    base.Execute();

                    WriteValue<int>(base.memoryWatchers.IsaaruTransition, BaseCutsceneValue2 + 0x2F8);
                    Stage += 1;
                }
                else if (base.memoryWatchers.IsaaruTransition.Current == (BaseCutsceneValue2 + 0x37A) && Stage == 3)
                {
                    DiagnosticLog.Information("Stage: " + Stage.ToString());
                    WriteValue<int>(base.memoryWatchers.IsaaruTransition, BaseCutsceneValue2 + 0x5C4);
                    Stage += 1;
                }
            }
        }
    }
}