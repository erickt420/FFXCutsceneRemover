using FFX_Cutscene_Remover.ComponentUtil;
using System.Diagnostics;

namespace FFXCutsceneRemover
{
    /* Special transition for the Sinspawn Gui fight. Formation is stored in memory after the Gui 1 fight
     * and reapplied after the Gui 2 fight, so reproduced here by storing the formation statically */
    class SinspawnGuiTransition : Transition
    {
        static private byte[] GuiFormation = { 0x0, 0x1, 0x2, 0x3, 0x4, 0x5, 0xFF };
        public override void Execute(string defaultDescription = "")
        {
            base.Execute(); // Execute the cutscene transition first (AreaID + Cutscene etc)

            if (Storyline == 865)
            {
                // Finished Sinspawn Gui 1, so remember the formation
                Process process = memoryWatchers.Process;
                GuiFormation = process.ReadBytes(memoryWatchers.Formation.Address, 7);
            }
            else if (Storyline == 882)
            {
                // Finished Sinspawn Gui 2, so reapply the formation
                WriteBytes(base.memoryWatchers.Formation, GuiFormation);
            }
        }
    }
}
