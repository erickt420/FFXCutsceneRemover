using FFXCutsceneRemover.Logging;

namespace FFXCutsceneRemover
{
    class UnderwaterRuinsTransition2 : Transition
    {
        public override void Execute(string defaultDescription = "")
        {
            if (base.memoryWatchers.UnderwaterRuinsTransition2.Current > 0)
            {
                if (Stage == 0)
                {
                    base.Execute();

                    BaseCutsceneValue = base.memoryWatchers.EventFileStart.Current;
                    Stage += 1;

                }
                //*/
                else if (base.memoryWatchers.UnderwaterRuinsTransition2.Current == (BaseCutsceneValue + 0x356E) && Stage == 1)
                {
                    WriteValue<int>(base.memoryWatchers.UnderwaterRuinsTransition2, BaseCutsceneValue + 0x35F6);
                    Stage += 1;
                }
                //*/
            }
        }
    }
}