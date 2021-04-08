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

        // Deep Pointers
        public static MemoryLocationData HpEnemyA = new MemoryLocationData(MemoryLocationNames.HpEnemyA, 0xD34460, 0x5D0);
        public static MemoryLocationData GuadoCount = new MemoryLocationData(MemoryLocationNames.GuadoCount, 0x00F2FF14, 0x120);

        // Party Configuration
        public static MemoryLocationData Formation = new MemoryLocationData(MemoryLocationNames.Formation, 0xD307E8);
        public static MemoryLocationData RikkuName = new MemoryLocationData(MemoryLocationNames.RikkuName, 0xD32E54);
        public static MemoryLocationData EnableTidus = new MemoryLocationData(MemoryLocationNames.EnableTidus, 0xD32088);
        public static MemoryLocationData EnableYuna = new MemoryLocationData(MemoryLocationNames.EnableYuna, 0xD3211C);
        public static MemoryLocationData EnableAuron = new MemoryLocationData(MemoryLocationNames.EnableAuron, 0xD321B0);
        public static MemoryLocationData EnableKimahri = new MemoryLocationData(MemoryLocationNames.EnableKimahri, 0xD32244);
        public static MemoryLocationData EnableWakka = new MemoryLocationData(MemoryLocationNames.EnableWakka, 0xD322D8);
        public static MemoryLocationData EnableLulu = new MemoryLocationData(MemoryLocationNames.EnableLulu, 0xD3236C);
        public static MemoryLocationData EnableRikku = new MemoryLocationData(MemoryLocationNames.EnableRikku, 0xD32400);
        public static MemoryLocationData EnableSeymour = new MemoryLocationData(MemoryLocationNames.EnableSeymour, 0xD32494);
        public static MemoryLocationData EnableValefor = new MemoryLocationData(MemoryLocationNames.EnableValefor, 0xD32528);
        
        // HP/MP TODO: Find a better method for full party restore to clean this up
        public static MemoryLocationData TidusHP = new MemoryLocationData("TidusHP", 0xD32078);
        public static MemoryLocationData TidusMaxHP = new MemoryLocationData("TidusMaxHP", 0xD32080);
        public static MemoryLocationData TidusMP = new MemoryLocationData("TidusMP", 0xD3207C);
        public static MemoryLocationData TidusMaxMP = new MemoryLocationData("TidusMaxMP", 0xD32084);
        
        public static MemoryLocationData YunaHP = new MemoryLocationData("YunaHP", 0xD3210C);
        public static MemoryLocationData YunaMaxHP = new MemoryLocationData("YunaMaxHP", 0xD32114);
        public static MemoryLocationData YunaMP = new MemoryLocationData("YunaMP", 0xD32110);
        public static MemoryLocationData YunaMaxMP = new MemoryLocationData("YunaMaxMP", 0xD32118);
        
        public static MemoryLocationData AuronHP = new MemoryLocationData("AuronHP", 0xD321A0);
        public static MemoryLocationData AuronMaxHP = new MemoryLocationData("AuronMaxHP", 0xD321A8);
        public static MemoryLocationData AuronMP = new MemoryLocationData("AuronMP", 0xD321A4);
        public static MemoryLocationData AuronMaxMP = new MemoryLocationData("AuronMaxMP", 0xD321AC);
        
        public static MemoryLocationData KimahriHP = new MemoryLocationData("KimahriHP", 0xD32234);
        public static MemoryLocationData KimahriMaxHP = new MemoryLocationData("KimahriMaxHP", 0xD3223C);
        public static MemoryLocationData KimahriMP = new MemoryLocationData("KimahriMP", 0xD32238);
        public static MemoryLocationData KimahriMaxMP = new MemoryLocationData("KimahriMaxMP", 0xD32240);
        
        public static MemoryLocationData WakkaHP = new MemoryLocationData("WakkaHP", 0xD322C8);
        public static MemoryLocationData WakkaMaxHP = new MemoryLocationData("WakkaMaxHP", 0xD322D0);
        public static MemoryLocationData WakkaMP = new MemoryLocationData("WakkaMP", 0xD322CC);
        public static MemoryLocationData WakkaMaxMP = new MemoryLocationData("WakkaMaxMP", 0xD322D4);
        
        public static MemoryLocationData LuluHP = new MemoryLocationData("LuluHP", 0xD3235C);
        public static MemoryLocationData LuluMaxHP = new MemoryLocationData("LuluMaxHP", 0xD32364);
        public static MemoryLocationData LuluMP = new MemoryLocationData("LuluMP", 0xD32360);
        public static MemoryLocationData LuluMaxMP = new MemoryLocationData("LuluMaxMP", 0xD32368);
        
        public static MemoryLocationData RikkuHP = new MemoryLocationData("RikkuHP", 0xD323F0);
        public static MemoryLocationData RikkuMaxHP = new MemoryLocationData("RikkuMaxHP", 0xD323F8);
        public static MemoryLocationData RikkuMP = new MemoryLocationData("RikkuMP", 0xD323F4);
        public static MemoryLocationData RikkuMaxMP = new MemoryLocationData("RikkuMaxMP", 0xD323FC);
        
        // Aeons
        // Only adding Valefor (for now?), as this is currently the only aeon that could affect speedruns
        public static MemoryLocationData ValeforHP = new MemoryLocationData("ValeforHP", 0xD32518);
        public static MemoryLocationData ValeforMaxHP = new MemoryLocationData("ValeforMaxHP", 0xD32520);
        public static MemoryLocationData ValeforMP = new MemoryLocationData("ValeforMP", 0xD3251C);
        public static MemoryLocationData ValeforMaxMP = new MemoryLocationData("ValeforMaxMP", 0xD32524);

        // Special Flags
        public static MemoryLocationData FangirlsOrKidsSkip = new MemoryLocationData(MemoryLocationNames.FangirlsOrKidsSkip, 0xD2CE7C);
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
        public static MemoryLocationData TidusWeaponDamageBoost = new MemoryLocationData(MemoryLocationNames.TidusWeaponDamageBoost, 0x1F11240);
        public static MemoryLocationData MacalaniaFlag = new MemoryLocationData(MemoryLocationNames.MacalaniaFlag, 0xD2CD16);
        public static MemoryLocationData Sandragoras = new MemoryLocationData(MemoryLocationNames.Sandragoras, 0xD2CD4E);
        public static MemoryLocationData ViaPurificoPlatform = new MemoryLocationData(MemoryLocationNames.ViaPurificoPlatform, 0xD2CC89);
        public static MemoryLocationData CalmLandsFlag = new MemoryLocationData(MemoryLocationNames.CalmLandsFlag, 0xD2CD09);
        public static MemoryLocationData GagazetCaveFlag = new MemoryLocationData(MemoryLocationNames.GagazetCaveFlag, 0xD2CD55);
        
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
