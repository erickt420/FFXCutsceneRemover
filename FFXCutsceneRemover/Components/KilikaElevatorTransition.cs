using FFXCutsceneRemover.Logging;
using System.Collections.Generic;

namespace FFXCutsceneRemover;

class KilikaElevatorTransition : Transition
{
    public override void Execute(string defaultDescription = "")
    {
        if (Stage == 0)
        {
            base.Execute();

            BaseCutsceneValue = MemoryWatchers.EventFileStart.Current;
            Stage += 1;

        }
        else if (MemoryWatchers.KilikaElevatorTransition.Current > (BaseCutsceneValue + 0x3582) && Stage == 1)
        {
            WriteValue<int>(MemoryWatchers.KilikaElevatorTransition, BaseCutsceneValue + 0x385C);
            new Transition { ForceLoad = false, ConsoleOutput = false, TargetActorIDs = new short[] { 1 }, Target_x = 0.0f, Target_y = -163.75f, Target_z = -25.0f, Target_var1 = 229 }.Execute();
            DiagnosticLog.Information("Test 1");
            Stage += 1;
        }
        //else if (MemoryWatchers.KilikaElevatorTransition.Current == (BaseCutsceneValue + 0x391A) && Stage == 2)
        //{
        //    WriteValue<int>(MemoryWatchers.KilikaElevatorTransition, BaseCutsceneValue + 0x3D46);
        //    DiagnosticLog.Information("Test 2");
        //    Stage += 1;
        //}
    }
}