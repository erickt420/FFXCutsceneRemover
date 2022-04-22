using System.Diagnostics;

namespace FFXCutsceneRemover
{
    /* Represents the previous state of the game's memory. Create one of these objects
     * with the values you care about, and CheckState() will evaluate to true when
     * the game state matches this object. */
    class PreviousGameState : IGameState
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
        public byte? EncounterFormationID = null;
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

        public int? MenuValue1 = null;
        public int? MenuValue2 = null;

        public bool CheckState()
        {
            return TestValue(RoomNumber, memoryWatchers.RoomNumber.Old) &&
                TestValue(Storyline, memoryWatchers.Storyline.Old) &&
                TestValue(SpawnPoint, memoryWatchers.SpawnPoint.Old) &&
                TestValue(BattleState, memoryWatchers.BattleState.Old) &&
                TestValue(BattleState2, memoryWatchers.BattleState2.Old) &&
                TestValue(Input, memoryWatchers.Input.Old) &&
                TestValue(Menu, memoryWatchers.Menu.Old) &&
                TestValue(MenuLock, memoryWatchers.MenuLock.Old) &&
                TestValue(FangirlsOrKidsSkip, memoryWatchers.FangirlsOrKidsSkip.Old) &&
                TestValue(Intro, memoryWatchers.Intro.Old) &&
                TestValue(State, memoryWatchers.State.Old) &&
                TestValue(XCoordinate, memoryWatchers.XCoordinate.Old) &&
                TestValue(YCoordinate, memoryWatchers.YCoordinate.Old) &&
                TestValue(Camera, memoryWatchers.Camera.Old) &&
                TestValue(Camera_x, memoryWatchers.Camera_x.Old) &&
                TestValue(Camera_y, memoryWatchers.Camera_y.Old) &&
                TestValue(Camera_z, memoryWatchers.Camera_z.Old) &&
                TestValue(CameraRotation, memoryWatchers.CameraRotation.Old) &&
                TestValue(EncounterStatus, memoryWatchers.EncounterStatus.Old) &&
                TestValue(MovementLock, memoryWatchers.MovementLock.Old) &&
                TestValue(ActiveMusicId, memoryWatchers.ActiveMusicId.Old) &&
                TestValue(MusicId, memoryWatchers.MusicId.Old) &&
                TestValue(RoomNumberAlt, memoryWatchers.RoomNumberAlt.Old) &&
                TestValue(CutsceneAlt, memoryWatchers.CutsceneAlt.Old) &&
                TestValue(AirshipDestinations, memoryWatchers.AirshipDestinations.Old) &&
                TestValue(AuronOverdrives, memoryWatchers.AuronOverdrives.Old) &&
                TestValue(Gil, memoryWatchers.Gil.Old) &&
                TestValue(TargetFramerate, memoryWatchers.TargetFramerate.Old) &&
                TestValue(Dialogue1, memoryWatchers.Dialogue1.Old) &&
                TestValue(DialogueOption, memoryWatchers.DialogueOption.Old) &&
                TestValue(DialogueBoxOpen, memoryWatchers.DialogueBoxOpen.Old) &&
                TestValue(DialogueOption_Gui, memoryWatchers.DialogueOption_Gui.Old) &&
                TestValue(DialogueBoxOpen_Gui, memoryWatchers.DialogueBoxOpen_Gui.Old) &&
                TestValue(PlayerTurn, memoryWatchers.PlayerTurn.Old) &&
                TestValue(EnableAuron, memoryWatchers.EnableAuron.Old) &&
                TestValue(EnableWakka, memoryWatchers.EnableWakka.Old) &&
                TestValue(EnableRikku, memoryWatchers.EnableRikku.Old) &&
                TestValue(Sandragoras, memoryWatchers.Sandragoras.Old) &&
                TestValue(EncounterMapID, memoryWatchers.EncounterMapID.Old) &&
                TestValue(EncounterFormationID, memoryWatchers.EncounterFormationID.Old) &&
                TestValue(BesaidFlag1, memoryWatchers.BesaidFlag1.Old) &&
                TestValue(SSWinnoFlag1, memoryWatchers.SSWinnoFlag1.Old) &&
                TestValue(KilikaMapFlag, memoryWatchers.KilikaMapFlag.Old) &&
                TestValue(SSWinnoFlag2, memoryWatchers.SSWinnoFlag2.Old) &&
                TestValue(LucaFlag, memoryWatchers.LucaFlag.Old) &&
                TestValue(LucaFlag2, memoryWatchers.LucaFlag2.Old) &&
                TestValue(MiihenFlag1, memoryWatchers.MiihenFlag1.Old) &&
                TestValue(MiihenFlag2, memoryWatchers.MiihenFlag2.Old) &&
                TestValue(MiihenFlag3, memoryWatchers.MiihenFlag3.Old) &&
                TestValue(MiihenFlag4, memoryWatchers.MiihenFlag4.Old) &&
                TestValue(MRRFlag1, memoryWatchers.MRRFlag1.Old) &&
                TestValue(MRRFlag2, memoryWatchers.MRRFlag2.Old) &&
                TestValue(MoonflowFlag, memoryWatchers.MoonflowFlag.Old) &&
                TestValue(MoonflowFlag2, memoryWatchers.MoonflowFlag2.Old) &&
                TestValue(ThunderPlainsFlag, memoryWatchers.ThunderPlainsFlag.Old) &&
                TestValue(GagazetCaveFlag, memoryWatchers.GagazetCaveFlag.Current) &&
                TestValue(HpEnemyA, memoryWatchers.HpEnemyA.Old) &&
                TestValue(GuadoCount, memoryWatchers.GuadoCount.Old) &&
                TestValue(NPCLastInteraction, memoryWatchers.NPCLastInteraction.Old) &&
                TestValue(TidusActionCount, memoryWatchers.TidusActionCount.Old) &&
                TestValue(TidusXCoordinate, memoryWatchers.TidusXCoordinate.Old) &&
                TestValue(SeymourTransition, memoryWatchers.SeymourTransition.Old) &&
                TestValue(SeymourTransition2, memoryWatchers.SeymourTransition2.Old) &&
                TestValue(MenuValue1, memoryWatchers.MenuValue1.Old) &&
                TestValue(MenuValue2, memoryWatchers.MenuValue2.Old);
            ;
        }

        private bool TestValue<T>(T? expected, T actual) where T : struct
        {
            // We only test to see if the memory values match if the value is provied
            // in intitialization.
            return !expected.HasValue || expected.Equals(actual);
        }
    }
}
