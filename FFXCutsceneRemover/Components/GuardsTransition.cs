using FFXCutsceneRemover.Logging;
using System.Collections.Generic;

namespace FFXCutsceneRemover
{
    class GuardsTransition : Transition
    {
        static private List<short> CutsceneAltList = new List<short>(new short[] { 70, 71, 75, 76 });
        public override void Execute(string defaultDescription = "")
        {
            if (base.memoryWatchers.State.Current == 1 && Stage == 0)
            {
                base.Execute();

                BaseCutsceneValue = base.memoryWatchers.EventFileStart.Current;
                DiagnosticLog.Information(BaseCutsceneValue.ToString("X2"));
                Stage += 1;

            }//*/
            else if (base.memoryWatchers.GuardsTransition.Current > (BaseCutsceneValue + 0x86CA) && Stage == 1)
            {
                DiagnosticLog.Information("Stage: " + Stage.ToString());
                WriteValue<int>(base.memoryWatchers.GuardsTransition, BaseCutsceneValue + 0x90DB);

                Stage += 1;
            }
        }
    }
}