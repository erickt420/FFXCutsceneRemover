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
        public int? BattleState = null;
        public short? Input = null;
        public byte? Menu = null;
        public short? MenuLock = null;
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
        public byte? AirshipDestinations = null;
        public short? AuronOverdrives = null;
        public byte? PartyMembers = null;
        public byte? Sandragoras = null;
        public int? HpEnemyA = null;
        public byte? GuadoCount = null;
        public int? SeymourTransition = null;
        public int? SeymourTransition2 = null;
        public bool CheckState()
        {
            return TestValue(RoomNumber, memoryWatchers.RoomNumber.Old) &&
                TestValue(Storyline, memoryWatchers.Storyline.Old) &&
                TestValue(SpawnPoint, memoryWatchers.SpawnPoint.Old) &&
                TestValue(BattleState, memoryWatchers.BattleState.Old) &&
                TestValue(Input, memoryWatchers.Input.Old) &&
                TestValue(Menu, memoryWatchers.Menu.Old) &&
                TestValue(MenuLock, memoryWatchers.MenuLock.Old) &&
                TestValue(Intro, memoryWatchers.Intro.Old) &&
                TestValue(State, memoryWatchers.State.Old) &&
                TestValue(XCoordinate, memoryWatchers.XCoordinate.Old) &&
                TestValue(YCoordinate, memoryWatchers.YCoordinate.Old) &&
                TestValue(Camera, memoryWatchers.Camera.Old) &&
                TestValue(CameraRotation, memoryWatchers.CameraRotation.Old) &&
                TestValue(EncounterStatus, memoryWatchers.EncounterStatus.Old) &&
                TestValue(MovementLock, memoryWatchers.MovementLock.Old) &&
                TestValue(MusicId, memoryWatchers.MusicId.Old) &&
                TestValue(CutsceneAlt, memoryWatchers.CutsceneAlt.Old) &&
                TestValue(AirshipDestinations, memoryWatchers.AirshipDestinations.Old) &&
                TestValue(AuronOverdrives, memoryWatchers.AuronOverdrives.Old) &&
                TestValue(Sandragoras, memoryWatchers.Sandragoras.Old) &&
                TestValue(HpEnemyA, memoryWatchers.HpEnemyA.Old) &&
                TestValue(GuadoCount, memoryWatchers.GuadoCount.Old) &&
                TestValue(SeymourTransition, memoryWatchers.SeymourTransition.Old);
                TestValue(SeymourTransition2, memoryWatchers.SeymourTransition2.Old);
        }

        private bool TestValue<T>(T? expected, T actual) where T : struct
        {
            // We only test to see if the memory values match if the value is provied
            // in intitialization.
            return !expected.HasValue || expected.Equals(actual);
        }
    }
}
