namespace FFXCutsceneRemover;

/* Represents the previous state of the game's memory. Create one of these objects
 * with the values you care about, and CheckState() will evaluate to true when
 * the game state matches this object. */
class PreviousGameState : IGameState
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
        return TestValue(RoomNumber, MemoryWatchers.RoomNumber.Old) &&
            TestValue(Storyline, MemoryWatchers.Storyline.Old) &&
            TestValue(SpawnPoint, MemoryWatchers.SpawnPoint.Old) &&
            TestValue(BattleState, MemoryWatchers.BattleState.Old) &&
            TestValue(BattleState2, MemoryWatchers.BattleState2.Old) &&
            TestValue(Input, MemoryWatchers.Input.Old) &&
            TestValue(Menu, MemoryWatchers.Menu.Old) &&
            TestValue(MenuLock, MemoryWatchers.MenuLock.Old) &&
            TestValue(FangirlsOrKidsSkip, MemoryWatchers.FangirlsOrKidsSkip.Old) &&
            TestValue(Intro, MemoryWatchers.Intro.Old) &&
            TestValue(State, MemoryWatchers.State.Old) &&
            TestValue(XCoordinate, MemoryWatchers.XCoordinate.Old) &&
            TestValue(YCoordinate, MemoryWatchers.YCoordinate.Old) &&
            TestValue(Camera, MemoryWatchers.Camera.Old) &&
            TestValue(Camera_x, MemoryWatchers.Camera_x.Old) &&
            TestValue(Camera_y, MemoryWatchers.Camera_y.Old) &&
            TestValue(Camera_z, MemoryWatchers.Camera_z.Old) &&
            TestValue(CameraRotation, MemoryWatchers.CameraRotation.Old) &&
            TestValue(EncounterStatus, MemoryWatchers.EncounterStatus.Old) &&
            TestValue(MovementLock, MemoryWatchers.MovementLock.Old) &&
            TestValue(ActiveMusicId, MemoryWatchers.ActiveMusicId.Old) &&
            TestValue(MusicId, MemoryWatchers.MusicId.Old) &&
            TestValue(RoomNumberAlt, MemoryWatchers.RoomNumberAlt.Old) &&
            TestValue(CutsceneAlt, MemoryWatchers.CutsceneAlt.Old) &&
            TestValue(AirshipDestinations, MemoryWatchers.AirshipDestinations.Old) &&
            TestValue(AuronOverdrives, MemoryWatchers.AuronOverdrives.Old) &&
            TestValue(Gil, MemoryWatchers.Gil.Old) &&
            TestValue(TargetFramerate, MemoryWatchers.TargetFramerate.Old) &&
            TestValue(Dialogue1, MemoryWatchers.Dialogue1.Old) &&
            TestValue(DialogueOption, MemoryWatchers.DialogueOption.Old) &&
            TestValue(DialogueBoxOpen, MemoryWatchers.DialogueBoxOpen.Old) &&
            TestValue(DialogueOption_Gui, MemoryWatchers.DialogueOption_Gui.Old) &&
            TestValue(DialogueBoxOpen_Gui, MemoryWatchers.DialogueBoxOpen_Gui.Old) &&
            TestValue(PlayerTurn, MemoryWatchers.PlayerTurn.Old) &&
            TestValue(EnableAuron, MemoryWatchers.EnableAuron.Old) &&
            TestValue(EnableWakka, MemoryWatchers.EnableWakka.Old) &&
            TestValue(EnableRikku, MemoryWatchers.EnableRikku.Old) &&
            TestValue(Sandragoras, MemoryWatchers.Sandragoras.Old) &&
            TestValue(EncounterMapID, MemoryWatchers.EncounterMapID.Old) &&
            TestValue(EncounterFormationID1, MemoryWatchers.EncounterFormationID1.Old) &&
            TestValue(EncounterFormationID2, MemoryWatchers.EncounterFormationID2.Old) &&
            TestValue(BesaidFlag1, MemoryWatchers.BesaidFlag1.Old) &&
            TestValue(SSWinnoFlag1, MemoryWatchers.SSWinnoFlag1.Old) &&
            TestValue(KilikaMapFlag, MemoryWatchers.KilikaMapFlag.Old) &&
            TestValue(SSWinnoFlag2, MemoryWatchers.SSWinnoFlag2.Old) &&
            TestValue(LucaFlag, MemoryWatchers.LucaFlag.Old) &&
            TestValue(LucaFlag2, MemoryWatchers.LucaFlag2.Old) &&
            TestValue(MiihenFlag1, MemoryWatchers.MiihenFlag1.Old) &&
            TestValue(MiihenFlag2, MemoryWatchers.MiihenFlag2.Old) &&
            TestValue(MiihenFlag3, MemoryWatchers.MiihenFlag3.Old) &&
            TestValue(MiihenFlag4, MemoryWatchers.MiihenFlag4.Old) &&
            TestValue(MRRFlag1, MemoryWatchers.MRRFlag1.Old) &&
            TestValue(MRRFlag2, MemoryWatchers.MRRFlag2.Old) &&
            TestValue(MoonflowFlag, MemoryWatchers.MoonflowFlag.Old) &&
            TestValue(MoonflowFlag2, MemoryWatchers.MoonflowFlag2.Old) &&
            TestValue(ThunderPlainsFlag, MemoryWatchers.ThunderPlainsFlag.Old) &&
            TestValue(GagazetCaveFlag, MemoryWatchers.GagazetCaveFlag.Current) &&
            TestValue(OmegaRuinsFlag, MemoryWatchers.OmegaRuinsFlag.Current) &&
            TestValue(HpEnemyA, MemoryWatchers.HpEnemyA.Old) &&
            TestValue(GuadoCount, MemoryWatchers.GuadoCount.Old) &&
            TestValue(NPCLastInteraction, MemoryWatchers.NPCLastInteraction.Old) &&
            TestValue(TidusActionCount, MemoryWatchers.TidusActionCount.Old) &&
            TestValue(TidusXCoordinate, MemoryWatchers.TidusXCoordinate.Old) &&
            TestValue(SeymourTransition, MemoryWatchers.SeymourTransition.Old) &&
            TestValue(SeymourTransition2, MemoryWatchers.SeymourTransition2.Old) &&
            TestValue(MenuValue1, MemoryWatchers.MenuValue1.Old) &&
            TestValue(MenuValue2, MemoryWatchers.MenuValue2.Old);
        ;
    }

    private bool TestValue<T>(T? expected, T actual) where T : struct
    {
        // We only test to see if the memory values match if the value is provied
        // in intitialization.
        return !expected.HasValue || expected.Equals(actual);
    }
}
