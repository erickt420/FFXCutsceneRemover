using FFX_Cutscene_Remover.ComponentUtil;
using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace FFXCutsceneRemover
{
    class GuiTransition : Transition
    {
        static private byte[] GuiFormation = { 0x0, 0x1, 0x2, 0x3, 0x4, 0x5, 0xFF };

        static private List<short> CutsceneAltList2 = new List<short>(new short[] { 4449, 4450 });

        public override void Execute(string defaultDescription = "")
        {
            if (base.memoryWatchers.MovementLock.Current == 0x20 && Stage == 0)
            {
                base.Execute();

                BaseCutsceneValue = base.memoryWatchers.GuiTransition.Current;

                Stage += 1;

            }
            else if (base.memoryWatchers.GuiTransition.Current == (BaseCutsceneValue + 0xBC1) && Stage == 1)
            {

                Storyline = 857;
                ConsoleOutput = false;
                base.Execute();
                ConsoleOutput = true;

                WriteValue<int>(base.memoryWatchers.GuiTransition, BaseCutsceneValue + 0x14BA);

                // Reposition Party Members just off screen to run into battle
                Transition actorPositions = new Transition { ForceLoad = false, ConsoleOutput = false, PartyTarget_x = 427.0f, PartyTarget_z = 3350.0f, PositionPartyOffScreen = true };
                actorPositions.Execute();

                Stage += 1;
            }
            else if (base.memoryWatchers.Storyline.Current == 860 && Stage == 2)
            {
                RoomNumber = 247;
                Storyline = 865;
                Description = "Auron Look out + FMV ";
                ForceLoad = true;
                base.Execute();
                ForceLoad = false;

                Stage += 1;
            }
            else if (CutsceneAltList2.Contains(base.memoryWatchers.CutsceneAlt.Current) && Stage == 3)
            {
                BaseCutsceneValue2 = base.memoryWatchers.Gui2Transition.Current;

                Stage += 1;
            }
            else if (base.memoryWatchers.Gui2Transition.Current >= (BaseCutsceneValue2 + 0x15B) && Stage == 4)
            {
                Process process = memoryWatchers.Process;
                GuiFormation = process.ReadBytes(memoryWatchers.Formation.Address, 7);

                Transition actorPositions;
                //Position Yuna
                actorPositions = new Transition { ForceLoad = false, ConsoleOutput = false, TargetActorID = 2, Target_x = 225.0f, Target_z = 3140.0f};
                actorPositions.Execute();

                //Position Auron
                actorPositions = new Transition { ForceLoad = false, ConsoleOutput = false, TargetActorID = 3, Target_x = 155.0f, Target_z = 3140.0f};
                actorPositions.Execute();

                //Position Seymour
                actorPositions = new Transition { ForceLoad = false, ConsoleOutput = false, TargetActorID = 8, Target_x = 190.0f, Target_z = 3150.0f};
                actorPositions.Execute();

                //Position Gui
                actorPositions = new Transition { ForceLoad = false, ConsoleOutput = false, TargetActorID = 4213, Target_x = 190.0f, Target_z = 3294.0f};
                actorPositions.Execute();

                WriteValue<int>(base.memoryWatchers.Gui2Transition, BaseCutsceneValue2 + 0x497);

                Stage += 1;
            }
            else if (base.memoryWatchers.Gui2Transition.Current == (BaseCutsceneValue2 + 0x614) && Stage == 5)
            {

                WriteBytes(base.memoryWatchers.Formation, GuiFormation);

                Stage += 1;
            }
            /*/ Skipping Gui 2 death animation seems to reliably make the game crash
            else if (base.memoryWatchers.Gui2Transition.Current == (BaseCutsceneValue2 + 0x538) && base.memoryWatchers.HpEnemyA.Current == 6000 && Stage == 5)
            {
                DiagnosticLog.Information("Test " + Stage.ToString());

                WriteValue<int>(base.memoryWatchers.Gui2Transition, BaseCutsceneValue2 + 0x5E2);

                Stage += 1;
            }
            else if (base.memoryWatchers.Gil.Current > base.memoryWatchers.Gil.Old && Stage == 5)
            {
                DiagnosticLog.Information("Test " + Stage.ToString());
                Stage += 1;
            }
            else if (base.memoryWatchers.Gil.Current == base.memoryWatchers.Gil.Old && Stage == 6)
            {
                DiagnosticLog.Information("Test " + Stage.ToString());

                Menu = 0;
                Description = "Exit Menu";
                ForceLoad = false;
                base.Execute();
                Stage += 1;
            }//*/
        }
    }
}
