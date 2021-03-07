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
        public static MemoryLocationData RoomNumberAlt = new MemoryLocationData(MemoryLocationNames.RoomNumberAlt, 0xD2Ca92);
        public static MemoryLocationData CutsceneAlt = new MemoryLocationData(MemoryLocationNames.CutsceneAlt, 0xD27C88);
        public static MemoryLocationData AirshipDestinations = new MemoryLocationData(MemoryLocationNames.AirshipDestinations, 0xD2D710);
        public static MemoryLocationData AuronOverdrives = new MemoryLocationData(MemoryLocationNames.AuronOverdrives, 0xD307FC);
        public static MemoryLocationData PartyMembers = new MemoryLocationData(MemoryLocationNames.PartyMembers, 0xD307E8);
        public static MemoryLocationData Sandragoras = new MemoryLocationData(MemoryLocationNames.Sandragoras, 0xD2CD4E);
        
        // Deep Pointers
        public static MemoryLocationData HpEnemyA = new MemoryLocationData(MemoryLocationNames.HpEnemyA, 0xD34460, 0x5D0);
        public static MemoryLocationData GuadoCount = new MemoryLocationData(MemoryLocationNames.GuadoCount, 0x00F2FF14, 0x120);

        public static MemoryLocationData EnableTidus = new MemoryLocationData(MemoryLocationNames.EnableTidus, 0xD32088);
        public static MemoryLocationData EnableYuna = new MemoryLocationData(MemoryLocationNames.EnableYuna, 0xD3211C);
        public static MemoryLocationData EnableAuron = new MemoryLocationData(MemoryLocationNames.EnableAuron, 0xD321B0);
        public static MemoryLocationData EnableKimahri = new MemoryLocationData(MemoryLocationNames.EnableKimahri, 0xD32244);
        public static MemoryLocationData EnableWakka = new MemoryLocationData(MemoryLocationNames.EnableWakka, 0xD322D8);
        public static MemoryLocationData EnableLulu = new MemoryLocationData(MemoryLocationNames.EnableLulu, 0xD3236C);
        public static MemoryLocationData EnableRikku = new MemoryLocationData(MemoryLocationNames.EnableRikku, 0xD32400);
        public static MemoryLocationData EnableSeymour = new MemoryLocationData(MemoryLocationNames.EnableSeymour, 0xD32494);
        public static MemoryLocationData EnableValefor = new MemoryLocationData(MemoryLocationNames.EnableValefor, 0xD32528);

        public static MemoryLocationData BaajFlag1 = new MemoryLocationData(MemoryLocationNames.BaajFlag1, 0xD2CE0C);

        public static MemoryLocationData BesaidFlag1 = new MemoryLocationData(MemoryLocationNames.BesaidFlag1, 0xF25AB3);

        public static MemoryLocationData SSWinnoFlag1 = new MemoryLocationData(MemoryLocationNames.SSWinnoFlag1, 0xD2CE7D);
        public static MemoryLocationData SSWinnoFlag2 = new MemoryLocationData(MemoryLocationNames.SSWinnoFlag2, 0xD2CE7F);

        public static MemoryLocationData LucaFlag = new MemoryLocationData(MemoryLocationNames.LucaFlag, 0xD2CDE5);
        public static MemoryLocationData LucaFlag2 = new MemoryLocationData(MemoryLocationNames.LucaFlag2, 0xD2CDE4);

        public static MemoryLocationData MiihenFlag1 = new MemoryLocationData(MemoryLocationNames.MiihenFlag1, 0xD2CCFE);
        public static MemoryLocationData MiihenFlag2 = new MemoryLocationData(MemoryLocationNames.MiihenFlag2, 0xD2CCFF);
        public static MemoryLocationData MiihenFlag3 = new MemoryLocationData(MemoryLocationNames.MiihenFlag3, 0xD2CD00);
        public static MemoryLocationData MiihenFlag4 = new MemoryLocationData(MemoryLocationNames.MiihenFlag4, 0xD2CD04);

        public static MemoryLocationData MoonflowFlag = new MemoryLocationData(MemoryLocationNames.MoonflowFlag, 0xD2CC7F);
        public static MemoryLocationData MoonflowFlag2 = new MemoryLocationData(MemoryLocationNames.MoonflowFlag2, 0xD2CC83);
        public static MemoryLocationData RikkuOutfit = new MemoryLocationData(MemoryLocationNames.RikkuOutfit, 0xD2CB61);

        public static MemoryLocationData MacalaniaFlag = new MemoryLocationData(MemoryLocationNames.MacalaniaFlag, 0xD2CD16);

        public static MemoryLocationData Formation = new MemoryLocationData(MemoryLocationNames.Formation, 0xD307E8);
        public static MemoryLocationData RikkuName = new MemoryLocationData(MemoryLocationNames.RikkuName, 0xD32E54);

        public static MemoryLocationData ViaPurificoPlatform = new MemoryLocationData(MemoryLocationNames.ViaPurificoPlatform, 0xD2CC89);
        public static MemoryLocationData CalmLandsFlag = new MemoryLocationData(MemoryLocationNames.CalmLandsFlag, 0xD2CD09);
        public static MemoryLocationData GagazetCaveFlag = new MemoryLocationData(MemoryLocationNames.GagazetCaveFlag, 0xD2CD56);
        
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
