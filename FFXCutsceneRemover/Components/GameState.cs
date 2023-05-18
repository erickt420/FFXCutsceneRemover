namespace FFXCutsceneRemover;

/* Represents the current state of the game's memory. Create one of these objects
 * with the values you care about, and CheckState() will evaluate to true when
 * the game state matches this object. */
class GameState : IGameState
{
    /* Only add members here for memory addresses that we want to read the value of.
     * If we only ever write the value then there is no need to add it here. */
    public short? RoomNumber = null;
    public short? Storyline = null;
    public byte? SpawnPoint = null;
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
    public byte? AuronOverdrives = null;
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
        return TestValue(RoomNumber, MemoryWatchers.RoomNumber.Current) &&
            TestValue(Storyline, MemoryWatchers.Storyline.Current) &&
            TestValue(SpawnPoint, MemoryWatchers.SpawnPoint.Current) &&
            TestValue(BattleState, MemoryWatchers.BattleState.Current) &&
            TestValue(BattleState2, MemoryWatchers.BattleState2.Current) &&
            TestValue(Input, MemoryWatchers.Input.Current) &&
            TestValue(Menu, MemoryWatchers.Menu.Current) &&
            TestValue(MenuLock, MemoryWatchers.MenuLock.Current) &&
            TestValue(FangirlsOrKidsSkip, MemoryWatchers.FangirlsOrKidsSkip.Current) &&
            TestValue(Intro, MemoryWatchers.Intro.Current) &&
            TestValue(State, MemoryWatchers.State.Current) &&
            TestValue(XCoordinate, MemoryWatchers.XCoordinate.Current) &&
            TestValue(YCoordinate, MemoryWatchers.YCoordinate.Current) &&
            TestValue(Camera, MemoryWatchers.Camera.Current) &&
            TestValue(Camera_x, MemoryWatchers.Camera_x.Current) &&
            TestValue(Camera_y, MemoryWatchers.Camera_y.Current) &&
            TestValue(Camera_z, MemoryWatchers.Camera_z.Current) &&
            TestValue(CameraRotation, MemoryWatchers.CameraRotation.Current) &&
            TestValue(EncounterStatus, MemoryWatchers.EncounterStatus.Current) &&
            TestValue(MovementLock, MemoryWatchers.MovementLock.Current) &&
            TestValue(ActiveMusicId, MemoryWatchers.ActiveMusicId.Current) &&
            TestValue(MusicId, MemoryWatchers.MusicId.Current) &&
            TestValue(RoomNumberAlt, MemoryWatchers.RoomNumberAlt.Current) &&
            TestValue(CutsceneAlt, MemoryWatchers.CutsceneAlt.Current) &&
            TestValue(AirshipDestinations, MemoryWatchers.AirshipDestinations.Current) &&
            TestValue(AuronOverdrives, MemoryWatchers.AuronOverdrives.Current) &&
            TestValue(Gil, MemoryWatchers.Gil.Current) &&
            TestValue(TargetFramerate, MemoryWatchers.TargetFramerate.Current) &&
            TestValue(Dialogue1, MemoryWatchers.Dialogue1.Current) &&
            TestValue(DialogueOption, MemoryWatchers.DialogueOption.Current) &&
            TestValue(DialogueBoxOpen, MemoryWatchers.DialogueBoxOpen.Current) &&
            TestValue(DialogueOption_Gui, MemoryWatchers.DialogueOption_Gui.Current) &&
            TestValue(DialogueBoxOpen_Gui, MemoryWatchers.DialogueBoxOpen_Gui.Current) &&
            TestValue(PlayerTurn, MemoryWatchers.PlayerTurn.Current) &&
            TestValue(EnableAuron, MemoryWatchers.EnableAuron.Current) &&
            TestValue(EnableWakka, MemoryWatchers.EnableWakka.Current) &&
            TestValue(EnableRikku, MemoryWatchers.EnableRikku.Current) &&
            TestValue(Sandragoras, MemoryWatchers.Sandragoras.Current) &&
            TestValue(EncounterMapID, MemoryWatchers.EncounterMapID.Current) &&
            TestValue(EncounterFormationID1, MemoryWatchers.EncounterFormationID1.Current) &&
            TestValue(EncounterFormationID2, MemoryWatchers.EncounterFormationID2.Current) &&
            TestValue(BesaidFlag1, MemoryWatchers.BesaidFlag1.Current) &&
            TestValue(SSWinnoFlag1, MemoryWatchers.SSWinnoFlag1.Current) &&
            TestValue(KilikaMapFlag, MemoryWatchers.KilikaMapFlag.Current) &&
            TestValue(SSWinnoFlag2, MemoryWatchers.SSWinnoFlag2.Current) &&
            TestValue(LucaFlag, MemoryWatchers.LucaFlag.Current) &&
            TestValue(LucaFlag2, MemoryWatchers.LucaFlag2.Current) &&
            TestValue(MiihenFlag1, MemoryWatchers.MiihenFlag1.Current) &&
            TestValue(MiihenFlag2, MemoryWatchers.MiihenFlag2.Current) &&
            TestValue(MiihenFlag3, MemoryWatchers.MiihenFlag3.Current) &&
            TestValue(MiihenFlag4, MemoryWatchers.MiihenFlag4.Current) &&
            TestValue(MRRFlag1, MemoryWatchers.MRRFlag1.Current) &&
            TestValue(MRRFlag2, MemoryWatchers.MRRFlag2.Current) &&
            TestValue(MoonflowFlag, MemoryWatchers.MoonflowFlag.Current) &&
            TestValue(MoonflowFlag2, MemoryWatchers.MoonflowFlag2.Current) &&
            TestValue(ThunderPlainsFlag, MemoryWatchers.ThunderPlainsFlag.Current) &&
            TestValue(GagazetCaveFlag, MemoryWatchers.GagazetCaveFlag.Current) &&
            TestValue(OmegaRuinsFlag, MemoryWatchers.OmegaRuinsFlag.Current) &&
            TestValue(HpEnemyA, MemoryWatchers.HpEnemyA.Current) &&
            TestValue(GuadoCount, MemoryWatchers.GuadoCount.Current) &&
            TestValue(NPCLastInteraction, MemoryWatchers.NPCLastInteraction.Current) &&
            TestValue(TidusActionCount, MemoryWatchers.TidusActionCount.Current) &&
            TestValue(TidusXCoordinate, MemoryWatchers.TidusXCoordinate.Current) &&
            TestValue(SeymourTransition, MemoryWatchers.SeymourTransition.Current) &&
            TestValue(SeymourTransition2, MemoryWatchers.SeymourTransition2.Current) &&
            TestValue(MenuValue1, MemoryWatchers.MenuValue1.Current) &&
            TestValue(MenuValue2, MemoryWatchers.MenuValue2.Current);
    }

    private bool TestValue<T>(T? expected, T actual) where T : struct
    {
        // We only test to see if the memory values match if the value is provied
        // in intitialization.
        return !expected.HasValue || expected.Equals(actual);
    }
}
