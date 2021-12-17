using FFX_Cutscene_Remover.ComponentUtil;
using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using FFXCutsceneRemover.Logging;

namespace FFXCutsceneRemover
{
    class GeneauxTransition : Transition
    {
        static private byte[] formation = new byte[] { 0x00, 0x01, 0x03, 0x04, 0x05, 0xFF, 0xFF, 0xFF };

        static private List<short> CutsceneAltList = new List<short>(new short[] { 265, 1173, 1174 });
        public override void Execute(string defaultDescription = "")
        {
            Process process = memoryWatchers.Process;

            int baseAddress = base.memoryWatchers.GetBaseAddress();
            if (base.memoryWatchers.GeneauxTransition.Current > 0)
            {
                if (CutsceneAltList.Contains(base.memoryWatchers.CutsceneAlt.Current) && Stage == 0)
                {
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.GeneauxTransition.Current;
                    DiagnosticLog.Information(BaseCutsceneValue.ToString("X2"));
                    Stage = 1;

                }
                else if (base.memoryWatchers.GeneauxTransition.Current == (BaseCutsceneValue + 0x4D8) && Stage == 1)
                {
                    DiagnosticLog.Information("Stage: " + Stage.ToString());
                    WriteValue<int>(base.memoryWatchers.GeneauxTransition, BaseCutsceneValue + 0x6B8);

                    formation = process.ReadBytes(base.memoryWatchers.Formation.Address, 8);

                    Transition actorPositions;
                    //Position Party Member 1
                    actorPositions = new Transition { ForceLoad = false, ConsoleOutput = false, TargetActorIDs = new short[] { (short)(formation[0] + 1)}, Target_x = -6.565776825f, Target_y = -159.9975586f, Target_z = 551.0246582f };
                    actorPositions.Execute();

                    //Position Party Member 2
                    actorPositions = new Transition { ForceLoad = false, ConsoleOutput = false, TargetActorIDs = new short[] { (short)(formation[1] + 1) }, Target_x = 31.14787483f, Target_y = -159.9975586f, Target_z = 514.7622681f };
                    actorPositions.Execute();

                    //Position Party Member 3
                    actorPositions = new Transition { ForceLoad = false, ConsoleOutput = false, TargetActorIDs = new short[] { (short)(formation[2] + 1) }, Target_x = 43.50946045f, Target_y = -159.9975586f, Target_z = 571.7218628f };
                    actorPositions.Execute();

                    Stage += 1;
                }
                else if (base.memoryWatchers.GeneauxTransition.Current == (BaseCutsceneValue + 0x6DC) && base.memoryWatchers.HpEnemyA.Current < 3000 && base.memoryWatchers.HpEnemyA.Old == 3000 && Stage == 2)
                {
                    DiagnosticLog.Information("Stage: " + Stage.ToString());
                    WriteValue<int>(base.memoryWatchers.GeneauxTransition, BaseCutsceneValue + 0x958);
                    Stage += 1;
                }
                else if (base.memoryWatchers.Gil.Current > base.memoryWatchers.Gil.Old && Stage == 3)
                {
                    Stage += 1;
                }
                else if (base.memoryWatchers.Gil.Current == base.memoryWatchers.Gil.Old && Stage == 4)
                {
                    Menu = 0;
                    Description = "Exit Menu";
                    ForceLoad = false;
                    base.Execute();
                    Stage = 8;
                }
            }
        }
    }
}