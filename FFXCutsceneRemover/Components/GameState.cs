using System.Diagnostics;

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
        public int? BattleState = null;
        public short? Input = null;
        public byte? Menu = null;
        public byte? FangirlsOrKidsSkip = null;
        public short? Intro = null;
        public sbyte? State = null;
        public float? XCoordinate = null;
        public float? YCoordinate = null;
        public byte? Camera = null;
        public float? CameraRotation = null;
        public byte? EncounterStatus = null;
        public byte? MovementLock = null;
        public byte? MusicId = null;
        public short? CutsceneAlt = null;
        public short? AirshipDestinations = null;
        public short? AuronOverdrives = null;
        public byte? PartyMembers = null;
        public byte? Sandragoras = null;
        public int? HpEnemyA = null;
        public byte? GuadoCount = null;
        public byte? EnableWakka = null;
        public byte? EnableRikku = null;

        public byte? BesaidFlag1 = null;

        public byte? SSWinnoFlag1 = null;
        public byte? SSWinnoFlag2 = null;

        public byte? LucaFlag = null;
        public byte? LucaFlag2 = null;

        public byte? MiihenFlag1 = null;
        public byte? MiihenFlag2 = null;
        public byte? MiihenFlag3 = null;
        public byte? MiihenFlag4 = null;

        public byte? MoonflowFlag = null;
        public byte? MoonflowFlag2 = null;

        public bool CheckState()
        {
            return TestValue(RoomNumber, memoryWatchers.RoomNumber.Current) &&
                TestValue(Storyline, memoryWatchers.Storyline.Current) &&
                TestValue(SpawnPoint, memoryWatchers.SpawnPoint.Current) &&
                TestValue(BattleState, memoryWatchers.BattleState.Current) &&
                TestValue(Input, memoryWatchers.Input.Current) &&
                TestValue(Menu, memoryWatchers.Menu.Current) &&
                TestValue(FangirlsOrKidsSkip, memoryWatchers.FangirlsOrKidsSkip.Current) &&
                TestValue(Intro, memoryWatchers.Intro.Current) &&
                TestValue(State, memoryWatchers.State.Current) &&
                TestValue(XCoordinate, memoryWatchers.XCoordinate.Current) &&
                TestValue(YCoordinate, memoryWatchers.YCoordinate.Current) &&
                TestValue(Camera, memoryWatchers.Camera.Current) &&
                TestValue(CameraRotation, memoryWatchers.CameraRotation.Current) &&
                TestValue(EncounterStatus, memoryWatchers.EncounterStatus.Current) &&
                TestValue(MovementLock, memoryWatchers.MovementLock.Current) &&
                TestValue(MusicId, memoryWatchers.MusicId.Current) &&
                TestValue(CutsceneAlt, memoryWatchers.CutsceneAlt.Current) &&
                TestValue(AirshipDestinations, memoryWatchers.AirshipDestinations.Current) &&
                TestValue(AuronOverdrives, memoryWatchers.AuronOverdrives.Current) &&
                TestValue(PartyMembers, memoryWatchers.PartyMembers.Current) &&
                TestValue(EnableWakka, memoryWatchers.EnableWakka.Current) &&
                TestValue(EnableRikku, memoryWatchers.EnableRikku.Current) &&
                TestValue(Sandragoras, memoryWatchers.Sandragoras.Current) &&
                TestValue(BesaidFlag1, memoryWatchers.BesaidFlag1.Current) &&
                TestValue(SSWinnoFlag1, memoryWatchers.SSWinnoFlag1.Current) &&
                TestValue(SSWinnoFlag2, memoryWatchers.SSWinnoFlag2.Current) &&
                TestValue(LucaFlag, memoryWatchers.LucaFlag.Current) &&
                TestValue(LucaFlag2, memoryWatchers.LucaFlag2.Current) &&
                TestValue(MiihenFlag1, memoryWatchers.MiihenFlag1.Current) &&
                TestValue(MiihenFlag2, memoryWatchers.MiihenFlag2.Current) &&
                TestValue(MiihenFlag3, memoryWatchers.MiihenFlag3.Current) &&
                TestValue(MiihenFlag4, memoryWatchers.MiihenFlag4.Current) &&
                TestValue(MoonflowFlag, memoryWatchers.MoonflowFlag.Current) &&
                TestValue(MoonflowFlag2, memoryWatchers.MoonflowFlag2.Current) &&
                TestValue(HpEnemyA, memoryWatchers.HpEnemyA.Current) &&
                TestValue(GuadoCount, memoryWatchers.GuadoCount.Current);

        }

        private bool TestValue<T>(T? expected, T actual) where T : struct
        {
            // We only test to see if the memory values match if the value is provied
            // in intitialization.
            return !expected.HasValue || expected.Equals(actual);
        }
    }
}
