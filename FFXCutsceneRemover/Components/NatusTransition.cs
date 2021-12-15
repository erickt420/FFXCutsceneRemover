using System;
using System.Diagnostics;
using System.Collections.Generic;
using FFX_Cutscene_Remover.ComponentUtil;
using FFXCutsceneRemover.Logging;


namespace FFXCutsceneRemover
{
    class NatusTransition : Transition
    {
        static private byte[] formation = new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0xFF };

        static private List<short> CutsceneAltList = new List<short>(new short[] { 3751 });
        public override void Execute(string defaultDescription = "")
        {
            Process process = memoryWatchers.Process;

            int baseAddress = base.memoryWatchers.GetBaseAddress();
            MemoryWatcher<byte> KimahriWeapon = new MemoryWatcher<byte>(new IntPtr(baseAddress + 0xD32245));
            MemoryWatcher<byte> KimahriArmor = new MemoryWatcher<byte>(new IntPtr(baseAddress + 0xD32246));
            KimahriWeapon.Update(process);
            KimahriArmor.Update(process);

            byte CurrentWeapon = 0xFF;
            byte CurrentArmor = 0xFF;

            if (base.memoryWatchers.NatusTransition.Current > 0)
            {
                if (CutsceneAltList.Contains(base.memoryWatchers.CutsceneAlt.Current) && Stage == 0)
                {
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.NatusTransition.Current;
                    DiagnosticLog.Information(BaseCutsceneValue.ToString("X2"));
                    Stage += 1;

                }
                else if (base.memoryWatchers.NatusTransition.Current == (BaseCutsceneValue + 0x1893) && Stage == 1) // 1893
                {
                    DiagnosticLog.Information("Stage: " + Stage.ToString());

                    CurrentWeapon = KimahriWeapon.Current;
                    CurrentArmor = KimahriArmor.Current;

                    WriteValue<int>(base.memoryWatchers.EnableKimahri, 17);

                    formation = process.ReadBytes(base.memoryWatchers.Formation.Address, 7);
                    formation[6] = 0x03;

                    byte secondPositionIndex = formation[1];

                    formation = SwapCharacterWithPosition(formation, 0x03, 1);
                    formation = SwapCharacterWithPosition(formation, secondPositionIndex, 2);

                    Formation = formation;
                    ConsoleOutput = false;
                    base.Execute();

                    WriteValue<byte>(KimahriWeapon, CurrentWeapon);
                    WriteValue<byte>(KimahriArmor, CurrentArmor);

                    WriteValue<int>(base.memoryWatchers.NatusTransition, BaseCutsceneValue + 0x1A85);//

                    Transition actorPositions;
                    //Position Party Member 1
                    actorPositions = new Transition { ForceLoad = false, ConsoleOutput = false, TargetActorID = (int)formation[0] + 1, Target_x = -31.0f, Target_y = 0.0f, Target_z = -25.0f };
                    actorPositions.Execute();

                    //Position Party Member 2
                    actorPositions = new Transition { ForceLoad = false, ConsoleOutput = false, TargetActorID = (int)formation[1] + 1, Target_x = 0.0f, Target_y = 0.0f, Target_z = -13.0f };
                    actorPositions.Execute();

                    //Position Party Member 3
                    actorPositions = new Transition { ForceLoad = false, ConsoleOutput = false, TargetActorID = (int)formation[2] + 1, Target_x = 31.0f, Target_y = 0.0f, Target_z = -25.0f };
                    actorPositions.Execute();

                    //Position Natus
                    actorPositions = new Transition { ForceLoad = false, ConsoleOutput = false, TargetActorID = 4222, Target_x = 0.0f, Target_y = -29.0f, Target_z = -100.0f };
                    actorPositions.Execute();

                    Stage += 1;
                }
                else if (base.memoryWatchers.NatusTransition.Current == (BaseCutsceneValue + 0x1AA0) && base.memoryWatchers.HpEnemyA.Current < 36000 && base.memoryWatchers.HpEnemyA.Old == 36000 && Stage == 2)
                {
                    DiagnosticLog.Information("Stage: " + Stage.ToString());
                    WriteValue<int>(base.memoryWatchers.NatusTransition, BaseCutsceneValue + 0x1B38);
                    Stage += 1;
                }
            }
        }
    }
}