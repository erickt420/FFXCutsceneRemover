namespace FFXCutsceneRemover;

class GarudaTransition : Transition
{
    public override void Execute(string defaultDescription = "")
    {
        int baseAddress = base.memoryWatchers.GetBaseAddress();
        if (base.memoryWatchers.GarudaTransition.Current > 0)
        {
            if (base.memoryWatchers.BattleState.Current == 10 && Stage == 0)
            {
                base.Execute();

                BaseCutsceneValue = base.memoryWatchers.GarudaTransition.Current;

                Stage = 1;

            }
            else if (base.memoryWatchers.GarudaTransition.Current == (BaseCutsceneValue + 0x21) && base.memoryWatchers.HpEnemyA.Current == 0 && Stage == 1)
            {
                WriteValue<int>(base.memoryWatchers.GarudaTransition, BaseCutsceneValue + 0x2A9);
                Stage = 2;
            }
            else if (base.memoryWatchers.GarudaTransition.Current == (BaseCutsceneValue + 0x566) && base.memoryWatchers.HpEnemyA.Current == 0 && Stage == 2) //0x428 Allows for a faster skip but causes motion blur. Need a way to turn off.
            {
                WriteValue<int>(base.memoryWatchers.GarudaTransition, BaseCutsceneValue + 0x84C);
                Stage = 3;
            }
        }
    }
}