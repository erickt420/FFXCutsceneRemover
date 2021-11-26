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
        public static MemoryLocationData MenuLock = new MemoryLocationData(MemoryLocationNames.MenuLock, 0xF25B61);
        public static MemoryLocationData Intro = new MemoryLocationData(MemoryLocationNames.Intro, 0x922D64);
        public static MemoryLocationData State = new MemoryLocationData(MemoryLocationNames.State, 0xD381AC);
        public static MemoryLocationData XCoordinate = new MemoryLocationData(MemoryLocationNames.XCoordinate, 0xF25D80);
        public static MemoryLocationData YCoordinate = new MemoryLocationData(MemoryLocationNames.YCoordinate, 0xF25D78);
        public static MemoryLocationData Camera = new MemoryLocationData(MemoryLocationNames.Camera, 0xD3818C);
        public static MemoryLocationData CameraRotation = new MemoryLocationData(MemoryLocationNames.CameraRotation, 0x8A858C);
        public static MemoryLocationData EncounterStatus = new MemoryLocationData(MemoryLocationNames.EncounterStatus, 0xF25D70);
        public static MemoryLocationData MovementLock = new MemoryLocationData(MemoryLocationNames.MovementLock, 0xF25B63);
        public static MemoryLocationData ActiveMusicId = new MemoryLocationData(MemoryLocationNames.ActiveMusicId, 0xF270F0);
        public static MemoryLocationData MusicId = new MemoryLocationData(MemoryLocationNames.MusicId, 0xF2FF1C);
        public static MemoryLocationData RoomNumberAlt = new MemoryLocationData(MemoryLocationNames.RoomNumberAlt, 0xD2Ca92);
        public static MemoryLocationData CutsceneAlt = new MemoryLocationData(MemoryLocationNames.CutsceneAlt, 0xD27C88);
        public static MemoryLocationData AirshipDestinations = new MemoryLocationData(MemoryLocationNames.AirshipDestinations, 0xD2D710);
        public static MemoryLocationData AuronOverdrives = new MemoryLocationData(MemoryLocationNames.AuronOverdrives, 0xD307FC);
        public static MemoryLocationData Gil = new MemoryLocationData(MemoryLocationNames.Gil, 0xD307D8);
        public static MemoryLocationData TargetFramerate = new MemoryLocationData(MemoryLocationNames.TargetFramerate, 0x830E88);//I think this is target framerate 0 = Uncapped??? / 1 = 60 / 2 = 30 / 3 = 20 / 4 = 15 / 5 = 12 / 6 = 10. Formula appears to be Target Framerate = 60 / this value

        // Deep Pointers
        public static MemoryLocationData HpEnemyA = new MemoryLocationData(MemoryLocationNames.HpEnemyA, 0xD34460, 0x5D0);
        public static MemoryLocationData GuadoCount = new MemoryLocationData(MemoryLocationNames.GuadoCount, 0xF2FF14, 0x120);
        public static MemoryLocationData TidusActionCount = new MemoryLocationData(MemoryLocationNames.TidusActionCount, 0xD334CC, 0x6DF);

        //Bespoke Transitions
        public static MemoryLocationData BaajIntTransition = new MemoryLocationData(MemoryLocationNames.BaajIntTransition, 0xF26AE8, new int[] { 0x1C, 0xB58 * (0x30 - 0x9 - 0x4 - 0x8) + 0x12C + 0x4C + 0x18 });
        public static MemoryLocationData AlBhedBoatTransition = new MemoryLocationData(MemoryLocationNames.AlBhedBoatTransition, 0xF26AE8, new int[] { 0x1C, 0xB58 * (0x23 - 0x0 - 0x3 - 0x3) + 0x12C + 0x4C + 0x18 });
        public static MemoryLocationData ValeforTransition = new MemoryLocationData(MemoryLocationNames.ValeforTransition, 0xF26AE8, new int[] { 0x1C, 0xB58 * (0x39 - 0x9 - 0x6 - 0x11) + 0x12C + 0x4C + 0x18 + 0x1560 });
        public static MemoryLocationData KimahriTransition = new MemoryLocationData(MemoryLocationNames.KimahriTransition, 0xF26AE8, new int[] { 0x1C, 0xB58 * (0x17 - 0x4 - 0x2 - 0x0) + 0x12C + 0x4C + 0x18 - 0x5A28 });
        public static MemoryLocationData YunaBoatTransition = new MemoryLocationData(MemoryLocationNames.YunaBoatTransition, 0xF26AE8, new int[] { 0x1C, 0xB58 * (0x52 - 0xE - 0xA - 0xA) + 0x12C + 0x4C + 0x18 + 0x558 });
        public static MemoryLocationData SinFinTransition = new MemoryLocationData(MemoryLocationNames.SinFinTransition, 0xF26AE8, new int[] { 0x1C, 0xB58 * (0x29 - 0x2 - 0x4 - 0xA) + 0x12C + 0x4C + 0x18 + 0x558 });
        public static MemoryLocationData EchuillesTransition = new MemoryLocationData(MemoryLocationNames.EchuillesTransition, 0xF26AE8, new int[] { 0x1C, 0xB58 * (0x11 - 0x0 - 0x4 - 0x0) + 0x12C + 0x4C + 0x18 + 0x558});
        public static MemoryLocationData GeneauxTransition = new MemoryLocationData(MemoryLocationNames.GeneauxTransition, 0xF26AE8, new int[] { 0x1C, 0xB58 * (0x18 - 0x2 - 0x4 - 0x3) + 0x12C + 0x4C + 0x18 });
        public static MemoryLocationData IfritTransition = new MemoryLocationData(MemoryLocationNames.IfritTransition, 0xF26AE8, new int[] { 0x1C, 0xB58 * (0x1B - 0x3 - 0x3 - 0x2) + 0x12C + 0x4C + 0x18 });
        public static MemoryLocationData IfritTransition2 = new MemoryLocationData(MemoryLocationNames.IfritTransition2, 0xF26AE8, new int[] { 0x1C, 0xB58 * (0x1B - 0x3 - 0x3 - 0x2) + 0x12C + 0x4C + 0x18 - 0x23D0 });
        public static MemoryLocationData SahaginTransition = new MemoryLocationData(MemoryLocationNames.SahaginTransition, 0xF26AE8, new int[] { 0x1C, 0xB58 * (0x10 - 0x0 - 0x2 - 0x0) + 0x12C + 0x18 });
        public static MemoryLocationData GarudaTransition = new MemoryLocationData(MemoryLocationNames.GarudaTransition, 0xF26AE8, new int[] { 0x1C, 0xB58 * (0x1E - 0x0 - 0x5 - 0x0) + 0x12C + 0x18 });
        public static MemoryLocationData GuiTransition = new MemoryLocationData(MemoryLocationNames.GuiTransition, 0xF26AE8, new int[] { 0x1C, 0xB58 * (0x39 - 0x4 - 0x8 - 0xA) + 0x12C + 0x4C + 0x18 });
        public static MemoryLocationData Gui2Transition = new MemoryLocationData(MemoryLocationNames.Gui2Transition, 0xF26AE8, new int[] { 0x1C, 0xB58 * (0x16 - 0x1 - 0x6 - 0x5) + 0x12C + 0x4C + 0x18 });
        public static MemoryLocationData IxionTransition = new MemoryLocationData(MemoryLocationNames.IxionTransition, 0xF26AE8, new int[] { 0x1C, 0xB58 * (0x1E - 0x2 - 0x7 - 0x0) + 0x12C + 0x4C + 0x18 });
        public static MemoryLocationData TromellTransition = new MemoryLocationData(MemoryLocationNames.TromellTransition, 0xF26AE8, new int[] { 0x1C, 0xB58 * (0x23 - 0x7 - 0x4 - 0x0) + 0x12C + 0x4C + 0x18 + 0xAB0 });
        public static MemoryLocationData CrawlerTransition = new MemoryLocationData(MemoryLocationNames.CrawlerTransition, 0xF26AE8, new int[] { 0x1C, 0xB58 * (0x1F - 0x2 - 0x5 - 0x0) + 0x12C + 0x4C + 0x18 + 0xFBC});
        public static MemoryLocationData SeymourTransition = new MemoryLocationData(MemoryLocationNames.SeymourTransition, 0xD3777C, new int[] { 0x398, 0x4A8, 0x4A8, 0x4A8, 0x248, 0xFDC });
        public static MemoryLocationData SeymourTransition2 = new MemoryLocationData(MemoryLocationNames.SeymourTransition2, 0xD3777C, new int[] { 0x398, 0x4A8, 0x4A8, 0x4A8, 0x248, 0x1028 });
        public static MemoryLocationData HomeTransition = new MemoryLocationData(MemoryLocationNames.HomeTransition, 0xF26AE8, new int[] { 0x1C, 0xB58 * (0x2D - 0x6 - 0x9 - 0xA) + 0x12C + 0x4C + 0x18 });
        public static MemoryLocationData EvraeTransition = new MemoryLocationData(MemoryLocationNames.EvraeTransition, 0xF26AE8, new int[] { 0x1C, 0xB58 * (0x26 - 0x2 - 0x6 - 0x1) + 0x12C + 0x18 });
        public static MemoryLocationData BahamutTransition = new MemoryLocationData(MemoryLocationNames.BahamutTransition, 0xF26AE8, new int[] { 0x1C, 0xB58 * (0x27 - 0x1 - 0x2 - 0x0) + 0x12C + 0x4C + 0x18 - 0x9F1C });
        public static MemoryLocationData IsaaruTransition = new MemoryLocationData(MemoryLocationNames.IsaaruTransition, 0xF26AE8, new int[] { 0x1C, 0xB58 * (0x43 - 0xE - 0x5 - 0x17) + 0x12C + 0x4C + 0x18 + 0x1B9C});
        public static MemoryLocationData DefenderXTransition = new MemoryLocationData(MemoryLocationNames.DefenderXTransition, 0xF26AE8, new int[] { 0x1C, 0xB58 * (0x20 - 0x3 - 0x7 - 0x9) + 0x12C + 0x4C + 0x18 + 0x4C });
        public static MemoryLocationData RonsoTransition = new MemoryLocationData(MemoryLocationNames.RonsoTransition, 0xF26AE8, new int[] { 0x1C, 0xB58 * (0x27 - 0x5 - 0x6 - 0x2) + 0x12C + 0x4C + 0x18 });
        public static MemoryLocationData FluxTransition = new MemoryLocationData(MemoryLocationNames.FluxTransition, 0xF26AE8, new int[] { 0x1C, 0xB58 * (0x15 - 0x2 - 0x6 - 0x1) + 0x12C + 0x4C + 0x18});
        public static MemoryLocationData SanctuaryTransition = new MemoryLocationData(MemoryLocationNames.SanctuaryTransition, 0xF26AE8, new int[] { 0x1C, 0xB58 * (0x15 - 0x2 - 0x7 - 0x1) + 0x12C + 0x4C + 0x18 });
        public static MemoryLocationData SpectralKeeperTransition = new MemoryLocationData(MemoryLocationNames.SpectralKeeperTransition, 0xF26AE8, new int[] { 0x1C, 0xB58 * (0x11 - 0x0 - 0x6 - 0x0) + 0x12C + 0x4C + 0x18});
        public static MemoryLocationData SpectralKeeperTransition2 = new MemoryLocationData(MemoryLocationNames.SpectralKeeperTransition2, 0xF26AE8, new int[] { 0x1C, 0xB58 * (0x55 - 0xF - 0x7 - 0x1E) + 0x12C + 0x4C + 0x18});
        public static MemoryLocationData YunalescaTransition = new MemoryLocationData(MemoryLocationNames.YunalescaTransition, 0xF26AE8, new int[] { 0x1C, 0xB58 * (0x1B - 0x1 - 0x7 - 0x2) + 0x12C + 0x4C + 0x18});
        public static MemoryLocationData FinsTransition = new MemoryLocationData(MemoryLocationNames.FinsTransition, 0xF26AE8, new int[] { 0x1C, 0xB58 * (0x12 - 0x0 - 0x2 - 0x0) + 0x12C + 0x18 });
        public static MemoryLocationData FinsAirshipTransition = new MemoryLocationData(MemoryLocationNames.FinsAirshipTransition, 0xF26AE8, new int[] { 0x1C, 0xB58 * (0x1F - 0x3 - 0x5 - 0x5) + 0x12C + 0x18 });
        public static MemoryLocationData BFATransition = new MemoryLocationData(MemoryLocationNames.BFATransition, 0xF26AE8, new int[] { 0x1C, 0xB58 * (0x1B - 0x0 - 0x5 - 0x1) + 0x12C + 0x4C + 0x18 });
        public static MemoryLocationData AeonTransition = new MemoryLocationData(MemoryLocationNames.AeonTransition, 0xF26AE8, new int[] { 0x1C, 0xB58 * (0x1D - 0x0 - 0x3 - 0x0) + 0x12C + 0x4C + 0x18 });
        public static MemoryLocationData CutsceneProgress_Max = new MemoryLocationData(MemoryLocationNames.HpEnemyA, 0xF26AE8, 0xC);
        public static MemoryLocationData CutsceneProgress_uVar1 = new MemoryLocationData(MemoryLocationNames.HpEnemyA, 0xF26AE8, 0x14);
        public static MemoryLocationData CutsceneProgress_uVar2 = new MemoryLocationData(MemoryLocationNames.HpEnemyA, 0xF26AE8, 0x16);
        public static MemoryLocationData CutsceneProgress_uVar3 = new MemoryLocationData(MemoryLocationNames.HpEnemyA, 0xF26AE8, 0x18);

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
        public static MemoryLocationData EnableIfrit = new MemoryLocationData(MemoryLocationNames.EnableIfrit, 0xD325BC);
        public static MemoryLocationData EnableIxion = new MemoryLocationData(MemoryLocationNames.EnableIxion, 0xD32650);
        public static MemoryLocationData EnableShiva = new MemoryLocationData(MemoryLocationNames.EnableShiva, 0xD326E4);
        public static MemoryLocationData EnableBahamut = new MemoryLocationData(MemoryLocationNames.EnableBahamut, 0xD32778);
        public static MemoryLocationData EnableYojimbo = new MemoryLocationData(MemoryLocationNames.EnableYojimbo, 0xD3280C);
        public static MemoryLocationData EnableAnima = new MemoryLocationData(MemoryLocationNames.EnableAnima, 0xD328A0);
        public static MemoryLocationData EnableMagus = new MemoryLocationData(MemoryLocationNames.EnableMagus, 0xD32934);

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
        public static MemoryLocationData BikanelFlag = new MemoryLocationData(MemoryLocationNames.BikanelFlag, 0xD2CD4B);
        public static MemoryLocationData Sandragoras = new MemoryLocationData(MemoryLocationNames.Sandragoras, 0xD2CD4E);
        public static MemoryLocationData ViaPurificoPlatform = new MemoryLocationData(MemoryLocationNames.ViaPurificoPlatform, 0xD2CC89);
        public static MemoryLocationData CalmLandsFlag = new MemoryLocationData(MemoryLocationNames.CalmLandsFlag, 0xD2CD09);
        public static MemoryLocationData GagazetCaveFlag = new MemoryLocationData(MemoryLocationNames.GagazetCaveFlag, 0xD2CD55);

        // Battle Rewards
        public static MemoryLocationData GilBattleRewards = new MemoryLocationData(MemoryLocationNames.GilBattleRewards, 0x1F10F6C);
        public static MemoryLocationData BattleRewardItemCount = new MemoryLocationData(MemoryLocationNames.BattleRewardItemCount, 0x1F10F70);
        public static MemoryLocationData BattleRewardItem1 = new MemoryLocationData(MemoryLocationNames.BattleRewardItem1, 0x1F10F74);
        public static MemoryLocationData BattleRewardItem2 = new MemoryLocationData(MemoryLocationNames.BattleRewardItem2, 0x1F10F76);
        public static MemoryLocationData BattleRewardItem3 = new MemoryLocationData(MemoryLocationNames.BattleRewardItem3, 0x1F10F78);
        public static MemoryLocationData BattleRewardItem4 = new MemoryLocationData(MemoryLocationNames.BattleRewardItem4, 0x1F10F7A);
        public static MemoryLocationData BattleRewardItem5 = new MemoryLocationData(MemoryLocationNames.BattleRewardItem5, 0x1F10F7C);
        public static MemoryLocationData BattleRewardItem6 = new MemoryLocationData(MemoryLocationNames.BattleRewardItem6, 0x1F10F7E);
        public static MemoryLocationData BattleRewardItem7 = new MemoryLocationData(MemoryLocationNames.BattleRewardItem7, 0x1F10F80);
        public static MemoryLocationData BattleRewardItem8 = new MemoryLocationData(MemoryLocationNames.BattleRewardItem8, 0x1F10F82);
        public static MemoryLocationData BattleRewardItemQty1 = new MemoryLocationData(MemoryLocationNames.BattleRewardItemQty1, 0x1F10F84);
        public static MemoryLocationData BattleRewardItemQty2 = new MemoryLocationData(MemoryLocationNames.BattleRewardItemQty2, 0x1F10F85);
        public static MemoryLocationData BattleRewardItemQty3 = new MemoryLocationData(MemoryLocationNames.BattleRewardItemQty3, 0x1F10F86);
        public static MemoryLocationData BattleRewardItemQty4 = new MemoryLocationData(MemoryLocationNames.BattleRewardItemQty4, 0x1F10F87);
        public static MemoryLocationData BattleRewardItemQty5 = new MemoryLocationData(MemoryLocationNames.BattleRewardItemQty5, 0x1F10F88);
        public static MemoryLocationData BattleRewardItemQty6 = new MemoryLocationData(MemoryLocationNames.BattleRewardItemQty6, 0x1F10F89);
        public static MemoryLocationData BattleRewardItemQty7 = new MemoryLocationData(MemoryLocationNames.BattleRewardItemQty7, 0x1F10F8A);
        public static MemoryLocationData BattleRewardItemQty8 = new MemoryLocationData(MemoryLocationNames.BattleRewardItemQty8, 0x1F10F8B);
        public static MemoryLocationData BattleRewardEquipCount = new MemoryLocationData(MemoryLocationNames.BattleRewardItemCount, 0x1F10F72);
        public static MemoryLocationData BattleRewardEquip1 = new MemoryLocationData(MemoryLocationNames.BattleRewardEquip1, 0x1F10F9E);
        public static MemoryLocationData BattleRewardEquip2 = new MemoryLocationData(MemoryLocationNames.BattleRewardEquip2, 0x1F10FC0);
        public static MemoryLocationData BattleRewardEquip3 = new MemoryLocationData(MemoryLocationNames.BattleRewardEquip3, 0x1F10FE2);
        public static MemoryLocationData BattleRewardEquip4 = new MemoryLocationData(MemoryLocationNames.BattleRewardEquip4, 0x1F11004);
        public static MemoryLocationData BattleRewardEquip5 = new MemoryLocationData(MemoryLocationNames.BattleRewardEquip5, 0x1F11026);
        public static MemoryLocationData BattleRewardEquip6 = new MemoryLocationData(MemoryLocationNames.BattleRewardEquip6, 0x1F11048);
        public static MemoryLocationData BattleRewardEquip7 = new MemoryLocationData(MemoryLocationNames.BattleRewardEquip7, 0x1F1106A);
        public static MemoryLocationData BattleRewardEquip8 = new MemoryLocationData(MemoryLocationNames.BattleRewardEquip8, 0x1F1108C);

        // Menu Values - These are values which the game sets during the battle rewards menu which don't get cleaned out properly when we skip straight to the rewards screen.
        //               We set the values to 0x00000000 to clean these out after some skips
        public static MemoryLocationData MenuValue1 = new MemoryLocationData(MemoryLocationNames.MenuValue1, 0x14408AC);
        public static MemoryLocationData MenuValue2 = new MemoryLocationData(MemoryLocationNames.MenuValue2, 0xF27F10);

        // Actor Model Positions
        public static MemoryLocationData ActorArrayLength = new MemoryLocationData(MemoryLocationNames.ActorArrayLength, 0x1FC44E0);

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
