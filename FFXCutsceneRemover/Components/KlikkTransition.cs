using System.Collections.Generic;
using FFXCutsceneRemover.Logging;

namespace FFXCutsceneRemover
{
    class KlikkTransition : Transition
    {
        static private List<short> CutsceneAltList = new List<short>(new short[] { 1137 });
        public override void Execute(string defaultDescription = "")
        {
            if (CutsceneAltList.Contains(base.memoryWatchers.CutsceneAlt.Current) && Stage == 0)
            {
                base.Execute();

                BaseCutsceneValue = base.memoryWatchers.EventFileStart.Current;
                DiagnosticLog.Information(BaseCutsceneValue.ToString("X2"));
                Stage += 1;

            }
            else if (base.memoryWatchers.KlikkTransition.Current == (BaseCutsceneValue + 0xA523) && Stage == 1)
            {
                DiagnosticLog.Information("Stage: " + Stage.ToString());
                WriteValue<int>(base.memoryWatchers.KlikkTransition, BaseCutsceneValue + 0xA7E3);//972 , 999
                Stage += 1;
            }
            else if (base.memoryWatchers.KlikkTransition.Current > (BaseCutsceneValue + 0xA7E3) && Stage == 2)
            {
                DiagnosticLog.Information("Stage: " + Stage.ToString());
                WriteValue<int>(base.memoryWatchers.KlikkTransition, BaseCutsceneValue + 0xA847);//972 , 999
                Stage += 1;
            }
            else if (base.memoryWatchers.PlayerTurn.Current == 1 && Stage == 3)
            {
                DiagnosticLog.Information("Stage: " + Stage.ToString());
                WriteValue<int>(base.memoryWatchers.KlikkTransition, BaseCutsceneValue + 0xAF27); //104E
                Stage += 1;
            }
        }
    }
}