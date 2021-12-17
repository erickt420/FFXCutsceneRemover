using System.Diagnostics;
using System.Collections.Generic;
using FFX_Cutscene_Remover.ComponentUtil;
using FFXCutsceneRemover.Logging;

namespace FFXCutsceneRemover
{
    class AltanaTransition : Transition
    {
        static private byte[] formation = new byte[] { 0x00, 0x04, 0x06 };

        static private List<short> CutsceneAltList = new List<short>(new short[] { 1137 });
        public override void Execute(string defaultDescription = "")
        {
            Process process = memoryWatchers.Process;

            if (base.memoryWatchers.AltanaTransition.Current > 0)
            {
                if (Stage == 0)
                {
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.AltanaTransition.Current;
                    DiagnosticLog.Information(BaseCutsceneValue.ToString("X2"));
                    Stage += 1;

                }
                else if (base.memoryWatchers.AltanaTransition.Current == (BaseCutsceneValue + 0x69) && Stage == 1) // CC
                {
                    DiagnosticLog.Information("Stage: " + Stage.ToString());
                    WriteValue<int>(base.memoryWatchers.AltanaTransition, BaseCutsceneValue + 0x307);//

                    formation = process.ReadBytes(base.memoryWatchers.Formation.Address, 3);

                    Transition actorPositions;
                    //Position Party Member 1
                    actorPositions = new Transition { ForceLoad = false, ConsoleOutput = false, TargetActorIDs = new short[] { (short)(formation[0] + 1) }, Target_x = 998.0f, Target_y = -30.0f, Target_z = -1474.0f };
                    actorPositions.Execute();

                    //Position Party Member 2
                    actorPositions = new Transition { ForceLoad = false, ConsoleOutput = false, TargetActorIDs = new short[] { (short)(formation[1] + 1) }, Target_x = 998.0f, Target_y = -30.0f, Target_z = -1444.0f };
                    actorPositions.Execute();

                    //Position Party Member 3
                    actorPositions = new Transition { ForceLoad = false, ConsoleOutput = false, TargetActorIDs = new short[] { (short)(formation[2] + 1) }, Target_x = 998.0f, Target_y = -30.0f, Target_z = -1414.0f };
                    actorPositions.Execute();

                    Stage += 1;
                }
                else if (base.memoryWatchers.AltanaTransition.Current == (BaseCutsceneValue + 0x32C) && Stage == 2) // This is a filler stage which only serves to facilitate fight end logic
                {
                    DiagnosticLog.Information("Stage: " + Stage.ToString());

                    Stage += 1;
                }
                else if (base.memoryWatchers.AltanaTransition.Current == (BaseCutsceneValue + 0x50E) && Stage == 3)
                {
                    DiagnosticLog.Information("Stage: " + Stage.ToString());
                    WriteValue<int>(base.memoryWatchers.AltanaTransition, BaseCutsceneValue + 0x709);

                    Stage += 1;
                }
                else if (base.memoryWatchers.AltanaTransition.Current == (BaseCutsceneValue + 0x72B) && Stage == 4)
                {
                    DiagnosticLog.Information("Stage: " + Stage.ToString());

                    Transition actorPositions;
                    //Position Party Member 1
                    actorPositions = new Transition { ForceLoad = false, ConsoleOutput = false, TargetActorIDs = new short[] { (short)(formation[0] + 1) }, Target_x = 529.0f, Target_y = -30.0f, Target_z = -828.0f };
                    actorPositions.Execute();

                    //Position Party Member 2
                    actorPositions = new Transition { ForceLoad = false, ConsoleOutput = false, TargetActorIDs = new short[] { (short)(formation[1] + 1) }, Target_x = 569.0f, Target_y = -30.0f, Target_z = -828.0f };
                    actorPositions.Execute();

                    //Position Party Member 3
                    actorPositions = new Transition { ForceLoad = false, ConsoleOutput = false, TargetActorIDs = new short[] { (short)(formation[2] + 1) }, Target_x = 609.0f, Target_y = -30.0f, Target_z = -828.0f };
                    actorPositions.Execute();

                    //Position Evrae Altana
                    actorPositions = new Transition { ForceLoad = false, ConsoleOutput = false, TargetActorIDs = new short[] { 4216 }, Target_x = 569.0f, Target_y = -30.0f, Target_z = -988.0f };
                    actorPositions.Execute();

                    //Position Lock Pin Left
                    actorPositions = new Transition { ForceLoad = false, ConsoleOutput = false, TargetActorIDs = new short[] { 4267 }, Target_x = 528.7f, Target_y = -10.0f, Target_z = -790.7f };
                    actorPositions.Execute();

                    //Position Lock Pin Right
                    actorPositions = new Transition { ForceLoad = false, ConsoleOutput = false, TargetActorIDs = new short[] { 162 }, Target_x = 611.3f, Target_y = -10.0f, Target_z = -790.7f };
                    actorPositions.Execute();

                    Stage += 1;
                }
                else if (base.memoryWatchers.AltanaTransition.Current == (BaseCutsceneValue + 0x8EE) && Stage == 5) // 50E
                {
                    DiagnosticLog.Information("Stage: " + Stage.ToString());
                    WriteValue<int>(base.memoryWatchers.AltanaTransition, BaseCutsceneValue + 0x94A);// 96B

                    WriteValue<int>(base.memoryWatchers.Camera, 0);
                    Stage += 1;
                }
                else if (base.memoryWatchers.AltanaTransition.Current == (BaseCutsceneValue + 0xA16) && Stage == 6)
                {
                    DiagnosticLog.Information("Stage: " + Stage.ToString());

                    Transition actorPositions;
                    //Position Party Member 1
                    actorPositions = new Transition { ForceLoad = false, ConsoleOutput = false, TargetActorIDs = new short[] { (short)(formation[0] + 1) }, Target_x = 378.582f, Target_y = -43.0f, Target_z = -234.134f };
                    actorPositions.Execute();

                    //Position Party Member 2
                    actorPositions = new Transition { ForceLoad = false, ConsoleOutput = false, TargetActorIDs = new short[] { (short)(formation[1] + 1) }, Target_x = 368.730f, Target_y = -70.0f, Target_z = -260.191f };
                    actorPositions.Execute();

                    //Position Party Member 3
                    actorPositions = new Transition { ForceLoad = false, ConsoleOutput = false, TargetActorIDs = new short[] { (short)(formation[2] + 1) }, Target_x = 338.239f, Target_y = -37.0f, Target_z = -328.214f };
                    actorPositions.Execute();

                    //Position Evrae Altana
                    actorPositions = new Transition { ForceLoad = false, ConsoleOutput = false, TargetActorIDs = new short[] { 4216 }, Target_x = 613.0f, Target_y = -35.0f, Target_z = -281.0f };
                    actorPositions.Execute();

                    Stage += 1;
                }
                else if (base.memoryWatchers.BattleState.Current == 522 && Stage == 7)
                {
                    DiagnosticLog.Information("Stage: End Fight");
                    WriteValue<int>(base.memoryWatchers.AltanaTransition, BaseCutsceneValue + 0xA7D);// 
                    Stage = 99;
                }
                else if (base.memoryWatchers.BattleState.Current == 522 && Stage == 5)
                {
                    DiagnosticLog.Information("Stage: End Fight");
                    WriteValue<int>(base.memoryWatchers.AltanaTransition, BaseCutsceneValue + 0x7A2);// Camera is jank if ending fight in second room. Need to work out how to move camera.
                    Stage = 98;
                }
                else if (base.memoryWatchers.BattleState.Current == 522 && Stage == 3)
                {
                    DiagnosticLog.Information("Stage: End Fight");
                    WriteValue<int>(base.memoryWatchers.AltanaTransition, BaseCutsceneValue + 0x3A9);// 
                    Stage = 99;
                }
                else if (base.memoryWatchers.Menu.Current == 0 && base.memoryWatchers.Menu.Old == 1 && Stage == 98)
                {
                    DiagnosticLog.Information("Stage: Reposition Tidus");

                    Transition actorPositions;
                    //Position Tidus
                    actorPositions = new Transition { ForceLoad = false, ConsoleOutput = false, TargetActorIDs = new short[] { 1 }, Target_x = 529.320f, Target_y = -30.0f, Target_z = -830.060f };
                    actorPositions.Execute();

                    Stage = 99;
                }
            }
        }
    }
}