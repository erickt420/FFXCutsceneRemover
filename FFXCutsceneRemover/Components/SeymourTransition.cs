using System;
using System.Diagnostics;
using System.Collections.Generic;
using FFXCutsceneRemover.Logging;
using FFX_Cutscene_Remover.ComponentUtil;

namespace FFXCutsceneRemover
{
    class SeymourTransition : Transition
    {
        static private byte[] formation = new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0xFF };
        public override void Execute(string defaultDescription = "")
        {
            Process process = memoryWatchers.Process;

            int baseAddress = base.memoryWatchers.GetBaseAddress();

            if (base.memoryWatchers.SeymourTransition.Current > 0)
            {
                if (base.memoryWatchers.MovementLock.Current == 0 && Stage == 0)
                {
                    Formation = new byte[] { 0x0, 0x1, 0x3, 0x4, 0x2, 0x6, 0x5, 0xFF };
                    base.Execute(); // Execute the cutscene transition first (AreaID + Cutscene etc)

                    MemoryWatcher<byte> shivaEnabled1 = new MemoryWatcher<byte>(new IntPtr(baseAddress + 0xD3211C));
                    WriteValue<byte>(shivaEnabled1, 0x11);

                    MemoryWatcher<byte> shivaEnabled2 = new MemoryWatcher<byte>(new IntPtr(baseAddress + 0xD326E4));
                    WriteValue<byte>(shivaEnabled2, 0x11);

                    BaseCutsceneValue = base.memoryWatchers.SeymourTransition.Current;
                    DiagnosticLog.Information(BaseCutsceneValue.ToString("X2"));

                    Stage += 1;

                }
                else if (base.memoryWatchers.MovementLock.Current == 0x10 && Stage == 1)
                {
                    DiagnosticLog.Information("Stage: " + Stage.ToString());
                    WriteValue<int>(base.memoryWatchers.SeymourTransition, BaseCutsceneValue + 0xBAF);// C0C

                    formation = process.ReadBytes(base.memoryWatchers.Formation.Address, 7);

                    Transition actorPositions;
                    //Position Party Member 1
                    actorPositions = new Transition { ForceLoad = false, ConsoleOutput = false, TargetActorIDs = new short[] { (short)(formation[0] + 1) }, Target_x = 35.668f, Target_y = 0.0f, Target_z = -42.0f };
                    actorPositions.Execute();

                    //Position Party Member 2
                    actorPositions = new Transition { ForceLoad = false, ConsoleOutput = false, TargetActorIDs = new short[] { (short)(formation[1] + 1) }, Target_x = 3.668f, Target_y = 0.0f, Target_z = -55.0f };
                    actorPositions.Execute();

                    //Position Party Member 3
                    actorPositions = new Transition { ForceLoad = false, ConsoleOutput = false, TargetActorIDs = new short[] { (short)(formation[2] + 1) }, Target_x = -28.332f, Target_y = 0.0f, Target_z = -42.0f };
                    actorPositions.Execute();

                    Stage += 1;
                }
                else if (base.memoryWatchers.SeymourTransition2.Current == (BaseCutsceneValue + 0xDA6) && Stage == 2)
                {
                    DiagnosticLog.Information("Stage: " + Stage.ToString());
                    WriteValue<int>(base.memoryWatchers.SeymourTransition2, BaseCutsceneValue + 0x1555);

                    Stage += 1;
                }
                else if (base.memoryWatchers.Menu.Current == 1 && base.memoryWatchers.CutsceneAlt.Current == 0 && Stage == 3)
                {
                    DiagnosticLog.Information("Stage: " + Stage.ToString());

                    Storyline = 1545;
                    ForceLoad = true;
                    Formation = null;
                    ConsoleOutput = false;
                    base.Execute();

                    Stage += 1;
                }
            }
        }
    }
}