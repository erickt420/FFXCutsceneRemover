using System.Collections.Generic;

namespace FFXCutsceneRemover;

class GuardsTransition : Transition
{
    static private List<short> CutsceneAltList = new List<short>(new short[] { 70, 71, 75, 76 });
    public override void Execute(string defaultDescription = "")
    {
        if (MemoryWatchers.Storyline.Current == 2075)
        {
            if (Stage == 0)
            {
                new Transition { Storyline = 2080, SpawnPoint = 0, SupressAutosaveOnForceLoad = 1, SupressAutosaveCounter = 0, Description = "The Guardians Arrive" }.Execute();
            }
        }
        else if (MemoryWatchers.Storyline.Current == 2080)
        {
            if (MemoryWatchers.State.Current == 1 && Stage == 0)
            {
                base.Execute();
                BaseCutsceneValue = MemoryWatchers.EventFileStart.Current;
                Stage += 1;
            }
            else if (MemoryWatchers.GuardsTransition.Current > (BaseCutsceneValue + 0x86CA) && Stage == 1)
            {
                WriteValue<int>(MemoryWatchers.GuardsTransition, BaseCutsceneValue + 0x90DB);
                Stage += 1;
            }
            else if (MemoryWatchers.GuardsTransition.Current == (BaseCutsceneValue + 0x90F0) && Stage == 2)
            {
                new Transition { ForceLoad = false, SupressAutosaveOnForceLoad = 0, SupressAutosaveCounter = 0, Description = "Clean Up ForceLoad Values", ConsoleOutput = false }.Execute();
                Stage += 1;
            }
        }
    }
}