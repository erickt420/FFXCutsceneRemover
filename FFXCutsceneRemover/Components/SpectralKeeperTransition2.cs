using FFXCutsceneRemover.Logging;

namespace FFXCutsceneRemover
{
    class SpectralKeeperTransition2 : Transition
    {
        public override void Execute(string defaultDescription = "")
        {
            int baseAddress = base.memoryWatchers.GetBaseAddress();

            if (base.memoryWatchers.SpectralKeeperTransition2.Current > 0)
            {
                
                if (Stage == 0)
                {
                    base.Execute();
                    
                    BaseCutsceneValue = base.memoryWatchers.EventFileStart.Current;
                    DiagnosticLog.Information(BaseCutsceneValue.ToString("X2"));
                    Stage += 1;

                }//*/
                else if (base.memoryWatchers.SpectralKeeperTransition2.Current == (BaseCutsceneValue + 0x672A) && Stage == 1)
                {
                    WriteValue<int>(base.memoryWatchers.SpectralKeeperTransition2, BaseCutsceneValue + 0x6882);
                    DiagnosticLog.Information("Stage: " + Stage.ToString());
                    Stage += 1;
                }
                else if (base.memoryWatchers.SpectralKeeperTransition2.Current == (BaseCutsceneValue + 0x6888) && Stage == 2)
                {
                    WriteValue<int>(base.memoryWatchers.SpectralKeeperTransition2, BaseCutsceneValue + 0x6A33);// 0x492
                    DiagnosticLog.Information("Stage: " + Stage.ToString());
                    Stage += 1;
                }
                /*/
                if (base.memoryWatchers.CutsceneAlt.Current != base.memoryWatchers.CutsceneAlt.Old || base.memoryWatchers.SpectralKeeperTransition2.Current != base.memoryWatchers.SpectralKeeperTransition2.Old)
                {
                    DiagnosticLog.Information(base.memoryWatchers.CutsceneAlt.Current.ToString() + " / " + base.memoryWatchers.SpectralKeeperTransition2.Current.ToString("X2"));
                }
                //*/
            }
        }
    }
}