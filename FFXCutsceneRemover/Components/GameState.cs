using System.Diagnostics;

namespace FFXCutsceneRemover
{
    class GameState
    {
        private readonly MemoryWatchers memoryWatchers = MemoryWatchers.Instance;
        private readonly Process process;

        /* Only add members here for memory addresses that we want to read the value of.
         * If we only ever write the value then there is no need to add it here. */
        public short? RoomNumber = null;
        public short? Storyline = null;
        public short? SpawnPoint = null;
        public int? BattleState = null;
        public short? Input = null;
        public byte? Menu = null;
        public short? Intro = null;
        public sbyte? State = null;
        public float? XCoordinate = null;
        public float? YCoordinate = null;
        public byte? Camera = null;
        public float? CameraRotation = null;
        public byte? EncounterStatus = null;
        public byte? MovementLock = null;
        public byte? MusicId = null;
        public byte? CutsceneAlt = null;
        public byte? AirshipDestinations = null;
        public short? AuronOverdrives = null;
        public byte? PartyMembers = null;
        public byte? Sandragoras = null;
        public int? HpEnemyA = null;
        public byte? GuadoCount = null;

        public GameState()
        {
            process = memoryWatchers.Process;
        }

        public bool CheckState()
        {
            memoryWatchers.Watchers.UpdateAll(process);

            return TestValue(RoomNumber, memoryWatchers.RoomNumber.Current) &&
                TestValue(Storyline, memoryWatchers.Storyline.Current) &&
                TestValue(SpawnPoint, memoryWatchers.SpawnPoint.Current) &&
                TestValue(BattleState, memoryWatchers.BattleState.Current) &&
                TestValue(Input, memoryWatchers.Input.Current) &&
                TestValue(Menu, memoryWatchers.Menu.Current) &&
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
                TestValue(Sandragoras, memoryWatchers.Sandragoras.Current) &&
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
