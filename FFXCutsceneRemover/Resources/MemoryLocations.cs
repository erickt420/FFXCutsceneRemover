namespace FFXCutsceneRemover.Resources
{
    /* Create MemoryLocationData objects for all of your new memory addresses. You can add a deep pointer by specifying 1 or
     * more additional offsets. 
     *      new MemoryLocationData(MemoryLocationNames.Example, 0x00F2FD00, 0x124);
     *      
     * To specify more than 1 additional offset, pass the additional offsets as an array:
     *      new MemoryLocationData(MemoryLocationNames.Example, 0x00F2FD00, { 0x124, 0xD24, ... }); */
    static class MemoryLocations
    {
        public static MemoryLocationData RoomNumber = new MemoryLocationData(MemoryLocationNames.RoomNumber, 0xD2CA90);
        public static MemoryLocationData Storyline = new MemoryLocationData(MemoryLocationNames.Storyline, 0xD2D67C);
        public static MemoryLocationData ForceLoad = new MemoryLocationData(MemoryLocationNames.ForceLoad, 0xF3080C);
        public static MemoryLocationData SpawnPoint = new MemoryLocationData(MemoryLocationNames.SpawnPoint, 0xD2CA9C);
        public static MemoryLocationData BattleState = new MemoryLocationData(MemoryLocationNames.BattleState, 0xD2C9F0);
        public static MemoryLocationData Input = new MemoryLocationData(MemoryLocationNames.Input, 0x8CB170);
        public static MemoryLocationData Menu = new MemoryLocationData(MemoryLocationNames.Menu, 0xF407E4);
        public static MemoryLocationData Intro = new MemoryLocationData(MemoryLocationNames.Intro, 0x922D64);
        public static MemoryLocationData FangirlsOrKidsSkip = new MemoryLocationData(MemoryLocationNames.FangirlsOrKidsSkip, 0xD2CE7C);
        public static MemoryLocationData State = new MemoryLocationData(MemoryLocationNames.State, 0xD381AC);
        public static MemoryLocationData XCoordinate = new MemoryLocationData(MemoryLocationNames.XCoordinate, 0xF25D80);
        public static MemoryLocationData YCoordinate = new MemoryLocationData(MemoryLocationNames.YCoordinate, 0xF25D78);
        public static MemoryLocationData Camera = new MemoryLocationData(MemoryLocationNames.Camera, 0xD3818C);
        public static MemoryLocationData CameraRotation = new MemoryLocationData(MemoryLocationNames.CameraRotation, 0x8A858C);
        public static MemoryLocationData EncounterStatus = new MemoryLocationData(MemoryLocationNames.EncounterStatus, 0xF25D70);
        public static MemoryLocationData MovementLock = new MemoryLocationData(MemoryLocationNames.MovementLock, 0xF25B63);
        public static MemoryLocationData MusicId = new MemoryLocationData(MemoryLocationNames.MusicId, 0xF2FF1C);
        public static MemoryLocationData CutsceneAlt = new MemoryLocationData(MemoryLocationNames.CutsceneAlt, 0xD27C88);
        public static MemoryLocationData AirshipDestinations = new MemoryLocationData(MemoryLocationNames.AirshipDestinations, 0xD2D710);
        public static MemoryLocationData AuronOverdrives = new MemoryLocationData(MemoryLocationNames.AuronOverdrives, 0xD307FC);
        public static MemoryLocationData PartyMembers = new MemoryLocationData(MemoryLocationNames.PartyMembers, 0xD307E8);
        public static MemoryLocationData Sandragoras = new MemoryLocationData(MemoryLocationNames.Sandragoras, 0xD2CD4E);
        
        // Deep Pointers
        public static MemoryLocationData HpEnemyA = new MemoryLocationData(MemoryLocationNames.HpEnemyA, 0xD34460, 0x5D0);
        public static MemoryLocationData GuadoCount = new MemoryLocationData(MemoryLocationNames.GuadoCount, 0x00F2FF14, 0x120);
    }

    public struct MemoryLocationData
    {
        public string Name;
        public int BaseAddress;
        // For DeepPointers
        public int[] Offsets;

        public MemoryLocationData(string name, int baseAddress, int offset)
        {
            Name = name;
            BaseAddress = baseAddress;
            Offsets = new int[] { offset };
        }

        public MemoryLocationData(string name, int baseAddress, int[] offsets = null)
        {
            Name = name;
            BaseAddress = baseAddress;
            Offsets = offsets ?? new int[0];
        }
    }
}
