using FFXCutsceneRemover.Logging;

namespace FFXCutsceneRemover
{
    /* Represents the current state of the game's memory. Create one of these objects
     * with the values you care about, and CheckState() will evaluate to true when
     * the game state matches this object. */
    class GameState : IGameState
    {
        private readonly MemoryWatchers memoryWatchers = MemoryWatchers.Instance;

        /* Only add members here for memory addresses that we want to read the value of.
         * If we only ever write the value then there is no need to add it here. */
        public short? RoomNumber = null;
        public short? Storyline = null;
        public short? SpawnPoint = null;
        public short? BattleState = null;
        public short? BattleState2 = null;
        public short? Input = null;
        public byte? Menu = null;
        public byte? MenuLock = null;
        public byte? FangirlsOrKidsSkip = null;
        public short? Intro = null;
        public sbyte? State = null;
        public float? XCoordinate = null;
        public float? YCoordinate = null;
        public byte? Camera = null;
        public float? Camera_x = null;
        public float? Camera_y = null;
        public float? Camera_z = null;
        public float? CameraRotation = null;
        public byte? EncounterStatus = null;
        public byte? MovementLock = null;
        public byte? ActiveMusicId = null;
        public byte? MusicId = null;
        public short? RoomNumberAlt = null;
        public short? CutsceneAlt = null;
        public short? AirshipDestinations = null;
        public short? AuronOverdrives = null;
        public int? Gil = null;
        public int? TargetFramerate = null;
        public int? Dialogue1 = null;
        public byte? DialogueOption = null;
        public byte? DialogueBoxOpen = null;
        public byte? DialogueOption_Gui = null;
        public byte? DialogueBoxOpen_Gui = null;
        public byte? PlayerTurn = null;
        public byte? PartyMembers = null;
        public byte? Sandragoras = null;
        public short? EncounterMapID = null;
        public byte? EncounterFormationID1 = null;
        public byte? EncounterFormationID2 = null;
        public int? HpEnemyA = null;
        public byte? GuadoCount = null;
        public short? NPCLastInteraction = null;
        public byte? TidusActionCount = null;
        public float? TidusXCoordinate = null;
        public float? TidusYCoordinate = null;
        public float? TidusZCoordinate = null;
        public float? TidusRotation = null;
        public int? SeymourTransition = null;
        public int? SeymourTransition2 = null;
        public byte? EnableAuron = null;
        public byte? EnableWakka = null;
        public byte? EnableRikku = null;

        public byte? BesaidFlag1 = null;

        public byte? SSWinnoFlag1 = null;
        public byte? KilikaMapFlag = null;
        public byte? SSWinnoFlag2 = null;

        public byte? LucaFlag = null;
        public byte? LucaFlag2 = null;

        public byte? MiihenFlag1 = null;
        public byte? MiihenFlag2 = null;
        public byte? MiihenFlag3 = null;
        public byte? MiihenFlag4 = null;

        public byte? MRRFlag1 = null;
        public byte? MRRFlag2 = null;

        public byte? MoonflowFlag = null;
        public byte? MoonflowFlag2 = null;

        public byte? ThunderPlainsFlag = null;

        public byte? GagazetCaveFlag = null;
        public byte? OmegaRuinsFlag = null;

        public int? MenuValue1 = null;
        public int? MenuValue2 = null;

        public bool CheckState()
        {
            return TestValue(RoomNumber, memoryWatchers.RoomNumber.Current) &&
                TestValue(Storyline, memoryWatchers.Storyline.Current) &&
                TestValue(SpawnPoint, memoryWatchers.SpawnPoint.Current) &&
                TestValue(BattleState, memoryWatchers.BattleState.Current) &&
                TestValue(BattleState2, memoryWatchers.BattleState2.Current) &&
                TestValue(Input, memoryWatchers.Input.Current) &&
                TestValue(Menu, memoryWatchers.Menu.Current) &&
                TestValue(MenuLock, memoryWatchers.MenuLock.Current) &&
                TestValue(FangirlsOrKidsSkip, memoryWatchers.FangirlsOrKidsSkip.Current) &&
                TestValue(Intro, memoryWatchers.Intro.Current) &&
                TestValue(State, memoryWatchers.State.Current) &&
                TestValue(XCoordinate, memoryWatchers.XCoordinate.Current) &&
                TestValue(YCoordinate, memoryWatchers.YCoordinate.Current) &&
                TestValue(Camera, memoryWatchers.Camera.Current) &&
                TestValue(Camera_x, memoryWatchers.Camera_x.Current) &&
                TestValue(Camera_y, memoryWatchers.Camera_y.Current) &&
                TestValue(Camera_z, memoryWatchers.Camera_z.Current) &&
                TestValue(CameraRotation, memoryWatchers.CameraRotation.Current) &&
                TestValue(EncounterStatus, memoryWatchers.EncounterStatus.Current) &&
                TestValue(MovementLock, memoryWatchers.MovementLock.Current) &&
                TestValue(ActiveMusicId, memoryWatchers.ActiveMusicId.Current) &&
                TestValue(MusicId, memoryWatchers.MusicId.Current) &&
                TestValue(RoomNumberAlt, memoryWatchers.RoomNumberAlt.Current) &&
                TestValue(CutsceneAlt, memoryWatchers.CutsceneAlt.Current) &&
                TestValue(AirshipDestinations, memoryWatchers.AirshipDestinations.Current) &&
                TestValue(AuronOverdrives, memoryWatchers.AuronOverdrives.Current) &&
                TestValue(Gil, memoryWatchers.Gil.Current) &&
                TestValue(TargetFramerate, memoryWatchers.TargetFramerate.Current) &&
                TestValue(Dialogue1, memoryWatchers.Dialogue1.Current) &&
                TestValue(DialogueOption, memoryWatchers.DialogueOption.Current) &&
                TestValue(DialogueBoxOpen, memoryWatchers.DialogueBoxOpen.Current) &&
                TestValue(DialogueOption_Gui, memoryWatchers.DialogueOption_Gui.Current) &&
                TestValue(DialogueBoxOpen_Gui, memoryWatchers.DialogueBoxOpen_Gui.Current) &&
                TestValue(PlayerTurn, memoryWatchers.PlayerTurn.Current) &&
                TestValue(EnableAuron, memoryWatchers.EnableAuron.Current) &&
                TestValue(EnableWakka, memoryWatchers.EnableWakka.Current) &&
                TestValue(EnableRikku, memoryWatchers.EnableRikku.Current) &&
                TestValue(Sandragoras, memoryWatchers.Sandragoras.Current) &&
                TestValue(EncounterMapID, memoryWatchers.EncounterMapID.Current) &&
                TestValue(EncounterFormationID1, memoryWatchers.EncounterFormationID1.Current) &&
                TestValue(EncounterFormationID2, memoryWatchers.EncounterFormationID2.Current) &&
                TestValue(BesaidFlag1, memoryWatchers.BesaidFlag1.Current) &&
                TestValue(SSWinnoFlag1, memoryWatchers.SSWinnoFlag1.Current) &&
                TestValue(KilikaMapFlag, memoryWatchers.KilikaMapFlag.Current) &&
                TestValue(SSWinnoFlag2, memoryWatchers.SSWinnoFlag2.Current) &&
                TestValue(LucaFlag, memoryWatchers.LucaFlag.Current) &&
                TestValue(LucaFlag2, memoryWatchers.LucaFlag2.Current) &&
                TestValue(MiihenFlag1, memoryWatchers.MiihenFlag1.Current) &&
                TestValue(MiihenFlag2, memoryWatchers.MiihenFlag2.Current) &&
                TestValue(MiihenFlag3, memoryWatchers.MiihenFlag3.Current) &&
                TestValue(MiihenFlag4, memoryWatchers.MiihenFlag4.Current) &&
                TestValue(MRRFlag1, memoryWatchers.MRRFlag1.Current) &&
                TestValue(MRRFlag2, memoryWatchers.MRRFlag2.Current) &&
                TestValue(MoonflowFlag, memoryWatchers.MoonflowFlag.Current) &&
                TestValue(MoonflowFlag2, memoryWatchers.MoonflowFlag2.Current) &&
                TestValue(ThunderPlainsFlag, memoryWatchers.ThunderPlainsFlag.Current) &&
                TestValue(GagazetCaveFlag, memoryWatchers.GagazetCaveFlag.Current) &&
                TestValue(OmegaRuinsFlag, memoryWatchers.OmegaRuinsFlag.Current) &&
                TestValue(HpEnemyA, memoryWatchers.HpEnemyA.Current) &&
                TestValue(GuadoCount, memoryWatchers.GuadoCount.Current) &&
                TestValue(NPCLastInteraction, memoryWatchers.NPCLastInteraction.Current) &&
                TestValue(TidusActionCount, memoryWatchers.TidusActionCount.Current) &&
                TestValue(TidusXCoordinate, memoryWatchers.TidusXCoordinate.Current) &&
                TestValue(SeymourTransition, memoryWatchers.SeymourTransition.Current) &&
                TestValue(SeymourTransition2, memoryWatchers.SeymourTransition2.Current) &&
                TestValue(MenuValue1, memoryWatchers.MenuValue1.Current) &&
                TestValue(MenuValue2, memoryWatchers.MenuValue2.Current);
        }

        private bool TestValue<T>(T? expected, T actual) where T : struct
        {
            // We only test to see if the memory values match if the value is provied
            // in intitialization.
            return !expected.HasValue || expected.Equals(actual);
        }
    }
}
