using System.Collections.Generic;
using FFXCutsceneRemover.Logging;

namespace FFXCutsceneRemover
{
    class LagoonTransition : Transition
    {
        public override void Execute(string defaultDescription = "")
        {
            if (base.memoryWatchers.LagoonTransition.Current > 0)
            {
                if (Stage == 0)
                {
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.LagoonTransition.Current;
                    Stage += 1;

                }
                else if (base.memoryWatchers.LagoonTransition.Current == (BaseCutsceneValue + 0x70) && Stage == 1)
                {
                    WriteValue<int>(base.memoryWatchers.LagoonTransition, BaseCutsceneValue + 0x13E);

                    Stage += 1;
                }
            }
        }
    }
}