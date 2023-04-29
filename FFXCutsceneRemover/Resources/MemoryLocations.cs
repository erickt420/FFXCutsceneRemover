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
        public static MemoryLocationData Language = new MemoryLocationData(MemoryLocationNames.Language, 0x8DED48, 0x04);

        public static MemoryLocationData RoomNumber = new MemoryLocationData(MemoryLocationNames.RoomNumber, 0xD2CA90);
        public static MemoryLocationData Storyline = new MemoryLocationData(MemoryLocationNames.Storyline, 0xD2D67C);
        public static MemoryLocationData ForceLoad = new MemoryLocationData(MemoryLocationNames.ForceLoad, 0xF3080C);
        public static MemoryLocationData SpawnPoint = new MemoryLocationData(MemoryLocationNames.SpawnPoint, 0xD2CA9C);
        public static MemoryLocationData BattleState = new MemoryLocationData(MemoryLocationNames.BattleState, 0xD2C9F0);
        public static MemoryLocationData BattleState2 = new MemoryLocationData(MemoryLocationNames.BattleState2, 0xD2A8E0);
        public static MemoryLocationData Input = new MemoryLocationData(MemoryLocationNames.Input, 0x8CB170);
        public static MemoryLocationData Menu = new MemoryLocationData(MemoryLocationNames.Menu, 0xF407E4);
        public static MemoryLocationData MenuLock = new MemoryLocationData(MemoryLocationNames.MenuLock, 0xF25B61);
        public static MemoryLocationData Intro = new MemoryLocationData(MemoryLocationNames.Intro, 0x922D64);
        public static MemoryLocationData State = new MemoryLocationData(MemoryLocationNames.State, 0xD381AC);
        public static MemoryLocationData XCoordinate = new MemoryLocationData(MemoryLocationNames.XCoordinate, 0xF25D80);
        public static MemoryLocationData YCoordinate = new MemoryLocationData(MemoryLocationNames.YCoordinate, 0xF25D78);
        public static MemoryLocationData Camera = new MemoryLocationData(MemoryLocationNames.Camera, 0xD3818C);
        public static MemoryLocationData Camera_x = new MemoryLocationData(MemoryLocationNames.Camera_x, 0xD37B7C);
        public static MemoryLocationData Camera_y = new MemoryLocationData(MemoryLocationNames.Camera_y, 0xD37B80);
        public static MemoryLocationData Camera_z = new MemoryLocationData(MemoryLocationNames.Camera_z, 0xD37B84);
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
        public static MemoryLocationData TargetFramerate = new MemoryLocationData(MemoryLocationNames.TargetFramerate, 0x830E88);//This is target framerate 0 = Uncapped??? / 1 = 60 / 2 = 30 / 3 = 20 / 4 = 15 / 5 = 12 / 6 = 10. Formula appears to be Target Framerate = 60 / this value
        public static MemoryLocationData PlayerTurn = new MemoryLocationData(MemoryLocationNames.PlayerTurn, 0xF3F77B);
        public static MemoryLocationData FrameCounterFromLoad = new MemoryLocationData(MemoryLocationNames.FrameCounterFromLoad, 0xF25D54);

        // Dialogue
        public static MemoryLocationData Dialogue1 = new MemoryLocationData(MemoryLocationNames.Dialogue1, 0xF25A80);
        public static MemoryLocationData DialogueOption = new MemoryLocationData(MemoryLocationNames.DialogueOption, 0x146780A);
        public static MemoryLocationData DialogueBoxOpen = new MemoryLocationData(MemoryLocationNames.DialogueBoxOpen, 0x1465CC2);
        public static MemoryLocationData DialogueOption_Gui = new MemoryLocationData(MemoryLocationNames.DialogueOption_Gui, 0x1467942);
        public static MemoryLocationData DialogueBoxOpen_Gui = new MemoryLocationData(MemoryLocationNames.DialogueBoxOpen_Gui, 0x1465CDE);

        // Deep Pointers
        public static MemoryLocationData HpEnemyA = new MemoryLocationData(MemoryLocationNames.HpEnemyA, 0xD34460, 0x5D0);
        public static MemoryLocationData GuadoCount = new MemoryLocationData(MemoryLocationNames.GuadoCount, 0xF2FF14, 0x120);
        public static MemoryLocationData NPCLastInteraction = new MemoryLocationData(MemoryLocationNames.NPCLastInteraction, 0xF26AE8, 0x1E8);
        public static MemoryLocationData TidusActionCount = new MemoryLocationData(MemoryLocationNames.TidusActionCount, 0xD334CC, 0x6DF);
        public static MemoryLocationData TidusXCoordinate = new MemoryLocationData(MemoryLocationNames.TidusXCoordinate, 0x1FC44E4, 0x0C);
        public static MemoryLocationData TidusYCoordinate = new MemoryLocationData(MemoryLocationNames.TidusYCoordinate, 0x1FC44E4, 0x10);
        public static MemoryLocationData TidusZCoordinate = new MemoryLocationData(MemoryLocationNames.TidusZCoordinate, 0x1FC44E4, 0x14);
        public static MemoryLocationData TidusRotation = new MemoryLocationData(MemoryLocationNames.TidusRotation, 0x1FC44E4, 0x168);
        public static MemoryLocationData DialogueFile = new MemoryLocationData(MemoryLocationNames.DialogueFile, 0xF270E8, 0x00);
        public static MemoryLocationData CutsceneTiming = new MemoryLocationData(MemoryLocationNames.CutsceneTiming, 0x8E9004, 0x1C);

        // Event File
        public static MemoryLocationData EventFileStart = new MemoryLocationData(MemoryLocationNames.EventFileStart, 0xF270B8);

        //Bespoke Transitions
        public static MemoryLocationData AuronTransition = new MemoryLocationData(MemoryLocationNames.AuronTransition, 0xF25B60 + 0x1C, new int[] { 0xB58 * (0x23 - 0x1 - 0x5 - 0x3) + 0x12C + 0x4C + 0x18 });
        public static MemoryLocationData AmmesTransition = new MemoryLocationData(MemoryLocationNames.AmmesTransition, 0xF25B60 + 0x1C, new int[] { 0xB58 * (0x4F - 0x1 - 0x9 - 0x0) + 0x12C + 0x4C + 0x18 + 0x558 });
        public static MemoryLocationData TankerTransition = new MemoryLocationData(MemoryLocationNames.TankerTransition, 0xF25B60 + 0x1C, new int[] { 0xB58 * (0x38 - 0x0 - 0x0 - 0x0) + 0x12C + 0x4C + 0x18 + 0x558 });
        public static MemoryLocationData InsideSinTransition = new MemoryLocationData(MemoryLocationNames.InsideSinTransition, 0xF25B60 + 0x1C, new int[] { 0xB58 * (0xC - 0x2 - 0x5 - 0x0) + 0x12C + 0x4C + 0x18 + 0x558 });
        public static MemoryLocationData DiveTransition = new MemoryLocationData(MemoryLocationNames.DiveTransition, 0xF25B60 + 0x1C, new int[] { 0xB58 * (0x31 - 0xA - 0x2 - 0xA) + 0x12C + 0x4C + 0x18 });
        public static MemoryLocationData GeosTransition = new MemoryLocationData(MemoryLocationNames.GeosTransition, 0xF25B60 + 0x1C, new int[] { 0xB58 * (0x31 - 0xA - 0x2 - 0xA) + 0x12C + 0x4C + 0x18 + 0x4C });
        public static MemoryLocationData KlikkTransition = new MemoryLocationData(MemoryLocationNames.KlikkTransition, 0xF25B60 + 0x1C, new int[] { 0xB58 * (0x30 - 0x9 - 0x4 - 0x8) + 0x12C + 0x4C + 0x18 });
        public static MemoryLocationData AlBhedBoatTransition = new MemoryLocationData(MemoryLocationNames.AlBhedBoatTransition, 0xF25B60 + 0x1C, new int[] { 0xB58 * (0x23 - 0x0 - 0x3 - 0x3) + 0x12C + 0x4C + 0x18 });
        public static MemoryLocationData UnderwaterRuinsTransition = new MemoryLocationData(MemoryLocationNames.UnderwaterRuinsTransition, 0xF25B60 + 0x1C, new int[] { 0xB58 * (0x13 - 0x0 - 0x0 - 0x0) + 0x12C + 0x4C + 0x18 });
        public static MemoryLocationData UnderwaterRuinsTransition2 = new MemoryLocationData(MemoryLocationNames.UnderwaterRuinsTransition2, 0xF25B60 + 0x1C, new int[] { 0x18148 });
        public static MemoryLocationData BeachTransition = new MemoryLocationData(MemoryLocationNames.BeachTransition, 0xF25B60 + 0x1C, new int[] { 0xB58 * (0x43 - 0x1 - 0xD - 0x22) + 0x12C + 0x4C + 0x18 });
        public static MemoryLocationData LagoonTransition1 = new MemoryLocationData(MemoryLocationNames.LagoonTransition1, 0xF25B60 + 0x1C, new int[] { 0x068D8 });
        public static MemoryLocationData LagoonTransition2 = new MemoryLocationData(MemoryLocationNames.LagoonTransition2, 0xF25B60 + 0x1C, new int[] { 0x07398 });
        public static MemoryLocationData ValeforTransition = new MemoryLocationData(MemoryLocationNames.ValeforTransition, 0xF25B60 + 0x1C, new int[] { 0xB58 * (0x39 - 0x9 - 0x6 - 0x11) + 0x12C + 0x4C + 0x18 + 0x1560 });
        public static MemoryLocationData KimahriTransition = new MemoryLocationData(MemoryLocationNames.KimahriTransition, 0xF25B60 + 0x1C, new int[] { 0xB58 * (0x17 - 0x4 - 0x2 - 0x0) + 0x12C + 0x4C + 0x18 - 0x5A28 });
        public static MemoryLocationData YunaBoatTransition = new MemoryLocationData(MemoryLocationNames.YunaBoatTransition, 0xF25B60 + 0x1C, new int[] { 0xB58 * (0x52 - 0xE - 0xA - 0xA) + 0x12C + 0x4C + 0x18 + 0x558 });
        public static MemoryLocationData SinFinTransition = new MemoryLocationData(MemoryLocationNames.SinFinTransition, 0xF25B60 + 0x1C, new int[] { 0xB58 * (0x29 - 0x2 - 0x4 - 0xA) + 0x12C + 0x4C + 0x18 + 0x558 });
        public static MemoryLocationData EchuillesTransition = new MemoryLocationData(MemoryLocationNames.EchuillesTransition, 0xF25B60 + 0x1C, new int[] { 0xB58 * (0x11 - 0x0 - 0x4 - 0x0) + 0x12C + 0x4C + 0x18 + 0x558});
        public static MemoryLocationData GeneauxTransition = new MemoryLocationData(MemoryLocationNames.GeneauxTransition, 0xF25B60 + 0x1C, new int[] { 0xB58 * (0x18 - 0x2 - 0x4 - 0x3) + 0x12C + 0x4C + 0x18 });
        public static MemoryLocationData KilikaTrialsTransition = new MemoryLocationData(MemoryLocationNames.KilikaTrialsTransition, 0xF25B60 + 0x1C, new int[] { 0xB58 * (0x30 - 0xD - 0xC - 0x7) + 0x12C + 0x18 });
        public static MemoryLocationData KilikaAntechamberTransition = new MemoryLocationData(MemoryLocationNames.KilikaAntechamberTransition, 0xF25B60 + 0x1C, new int[] { 0xD918 });
        public static MemoryLocationData IfritTransition = new MemoryLocationData(MemoryLocationNames.IfritTransition, 0xF25B60 + 0x1C, new int[] { 0xB58 * (0x1B - 0x3 - 0x3 - 0x2) + 0x12C + 0x4C + 0x18 });
        public static MemoryLocationData IfritTransition2 = new MemoryLocationData(MemoryLocationNames.IfritTransition2, 0xF25B60 + 0x1C, new int[] { 0xB58 * (0x1B - 0x3 - 0x3 - 0x2) + 0x12C + 0x4C + 0x18 - 0x23D0 });
        public static MemoryLocationData JechtShotTransition = new MemoryLocationData(MemoryLocationNames.JechtShotTransition, 0xF25B60 + 0x1C, new int[] { 0xB58 * (0x31 - 0x7 - 0xB - 0xB) + 0x12C + 0x4C + 0x18 + 0xAB0 });
        public static MemoryLocationData OblitzeratorTransition = new MemoryLocationData(MemoryLocationNames.OblitzeratorTransition, 0xF25B60 + 0x1C, new int[] { 0xB58 * (0x13 - 0x0 - 0x0 - 0x0) + 0x12C + 0x4C + 0x18 });
        public static MemoryLocationData BlitzballTransition = new MemoryLocationData(MemoryLocationNames.BlitzballTransition, 0xF25B60 + 0x1C, new int[] { 0x144});
        public static MemoryLocationData SahaginTransition = new MemoryLocationData(MemoryLocationNames.SahaginTransition, 0xF25B60 + 0x1C, new int[] { 0xB58 * (0x10 - 0x0 - 0x2 - 0x0) + 0x12C + 0x18 });
        public static MemoryLocationData GarudaTransition = new MemoryLocationData(MemoryLocationNames.GarudaTransition, 0xF25B60 + 0x1C, new int[] { 0xB58 * (0x1E - 0x0 - 0x5 - 0x0) + 0x12C + 0x18 });
        public static MemoryLocationData RinTransition = new MemoryLocationData(MemoryLocationNames.RinTransition, 0xF25B60 + 0x1C, new int[] { 0xB58 * (0x21 - 0x5 - 0x5 - 0x2) + 0x12C + 0x4C + 0x18 });
        public static MemoryLocationData ChocoboEaterTransition = new MemoryLocationData(MemoryLocationNames.ChocoboEaterTransition, 0xF25B60 + 0x1C, new int[] { 0xB58 * (0x35 - 0x3 - 0x8 - 0xA) + 0x12C + 0x4C + 0x18 });
        public static MemoryLocationData GuiTransition = new MemoryLocationData(MemoryLocationNames.GuiTransition, 0xF25B60 + 0x1C, new int[] { 0xB58 * (0x39 - 0x4 - 0x8 - 0xA) + 0x12C + 0x4C + 0x18 });
        public static MemoryLocationData Gui2Transition = new MemoryLocationData(MemoryLocationNames.Gui2Transition, 0xF25B60 + 0x1C, new int[] { 0xB58 * (0x16 - 0x1 - 0x6 - 0x5) + 0x12C + 0x4C + 0x18 });
        public static MemoryLocationData DjoseTransition = new MemoryLocationData(MemoryLocationNames.DjoseTransition, 0xF25B60 + 0x1C, new int[] { 0xB58 * (0x1D - 0x2 - 0x5 - 0x1) + 0x12C + 0x4C + 0x18 });
        public static MemoryLocationData IxionTransition = new MemoryLocationData(MemoryLocationNames.IxionTransition, 0xF25B60 + 0x1C, new int[] { 0xB58 * (0x1E - 0x2 - 0x7 - 0x0) + 0x12C + 0x4C + 0x18 });
        public static MemoryLocationData ExtractorTransition = new MemoryLocationData(MemoryLocationNames.ExtractorTransition, 0xF25B60 + 0x1C, new int[] { 0x675C });
        public static MemoryLocationData SeymoursHouseTransition1 = new MemoryLocationData(MemoryLocationNames.SeymoursHouseTransition1, 0xF25B60 + 0x1C, new int[] { 0xD77C });
        public static MemoryLocationData SeymoursHouseTransition2 = new MemoryLocationData(MemoryLocationNames.SeymoursHouseTransition2, 0xF25B60 + 0x1C, new int[] { 0xD270 });
        public static MemoryLocationData FarplaneTransition1 = new MemoryLocationData(MemoryLocationNames.FarplaneTransition1, 0xF25B60 + 0x1C, new int[] { 0xDD7C });
        public static MemoryLocationData FarplaneTransition2 = new MemoryLocationData(MemoryLocationNames.FarplaneTransition2, 0xF25B60 + 0x1C, new int[] { 0xDDC8 });
        public static MemoryLocationData TromellTransition = new MemoryLocationData(MemoryLocationNames.TromellTransition, 0xF25B60 + 0x1C, new int[] { 0xB58 * (0x23 - 0x7 - 0x4 - 0x0) + 0x12C + 0x4C + 0x18 + 0xAB0 });
        public static MemoryLocationData CrawlerTransition = new MemoryLocationData(MemoryLocationNames.CrawlerTransition, 0xF25B60 + 0x1C, new int[] { 0xB58 * (0x1F - 0x2 - 0x5 - 0x0) + 0x12C + 0x4C + 0x18 + 0xFBC});
        public static MemoryLocationData SeymourTransition = new MemoryLocationData(MemoryLocationNames.SeymourTransition, 0xF25B60 + 0x1C, new int[] { 0xB58 * (0x14 - 0x0 - 0x0 - 0x0) + 0x12C + 0x4C + 0x18 });
        public static MemoryLocationData SeymourTransition2 = new MemoryLocationData(MemoryLocationNames.SeymourTransition2, 0xF25B60 + 0x1C, new int[] { 0xB58 * (0x14 - 0x0 - 0x0 - 0x0) + 0x12C + 0x4C + 0x18 + 0x4C });
        public static MemoryLocationData WendigoTransition = new MemoryLocationData(MemoryLocationNames.WendigoTransition, 0xF25B60 + 0x1C, new int[] { 0xB58 * (0x18 - 0x0 - 0x0 - 0x0) + 0x12C + 0x4C + 0x18 + 0xFBC });
        public static MemoryLocationData SpherimorphTransition = new MemoryLocationData(MemoryLocationNames.SpherimorphTransition, 0xF25B60 + 0x1C, new int[] { 0xB58 * (0x14 - 0x1 - 0x6 - 0x2) + 0x12C + 0x4C + 0x18 });
        public static MemoryLocationData UnderLakeTransition = new MemoryLocationData(MemoryLocationNames.UnderLakeTransition, 0xF25B60 + 0x1C, new int[] { 0xB58 * (0xC - 0x0 - 0x0 - 0x0) + 0x12C + 0x4C + 0x18 });
        public static MemoryLocationData BikanelTransition = new MemoryLocationData(MemoryLocationNames.BikanelTransition, 0xF25B60 + 0x1C, new int[] { 0xB58 * (0x42 - 0x6 - 0xC - 0x18) + 0x12C + 0x4C + 0x18 });
        public static MemoryLocationData HomeTransition = new MemoryLocationData(MemoryLocationNames.HomeTransition, 0xF25B60 + 0x1C, new int[] { 0xB58 * (0x2D - 0x6 - 0x9 - 0xA) + 0x12C + 0x4C + 0x18 });
        public static MemoryLocationData EvraeTransition = new MemoryLocationData(MemoryLocationNames.EvraeTransition, 0xF25B60 + 0x1C, new int[] { 0xB58 * (0x26 - 0x2 - 0x6 - 0x1) + 0x12C + 0x18 });
        public static MemoryLocationData EvraeAirshipTransition = new MemoryLocationData(MemoryLocationNames.EvraeAirshipTransition, 0xF25B60 + 0x1C, new int[] { 0xB58 * (0x20 - 0x3 - 0x5 - 0x5) + 0x12C + 0x18 });
        public static MemoryLocationData GuardsTransition = new MemoryLocationData(MemoryLocationNames.GuardsTransition, 0xF25B60 + 0x1C, new int[] { 0xB58 * (0x3C - 0x6 - 0x2 - 0x5) + 0x12C + 0x4C + 0x18 - 0x11BE4 });
        public static MemoryLocationData BahamutTransition = new MemoryLocationData(MemoryLocationNames.BahamutTransition, 0xF25B60 + 0x1C, new int[] { 0xB58 * (0x27 - 0x1 - 0x2 - 0x0) + 0x12C + 0x4C + 0x18 - 0x9F1C });
        public static MemoryLocationData IsaaruTransition = new MemoryLocationData(MemoryLocationNames.IsaaruTransition, 0xF25B60 + 0x1C, new int[] { 0xB58 * (0x43 - 0xE - 0x5 - 0x17) + 0x12C + 0x4C + 0x18 + 0x1B9C});
        public static MemoryLocationData AltanaTransition = new MemoryLocationData(MemoryLocationNames.AltanaTransition, 0xF25B60 + 0x1C, new int[] { 0xB58 * (0x17 - 0x0 - 0x0 - 0x0) + 0x12C + 0x4C + 0x18 + 0xB94 });
        public static MemoryLocationData NatusTransition = new MemoryLocationData(MemoryLocationNames.NatusTransition, 0xF25B60 + 0x1C, new int[] { 0xB58 * (0x1D - 0x0 - 0x0 - 0x0) + 0x12C + 0x4C + 0x18 - 0x4378 });
        public static MemoryLocationData DefenderXTransition = new MemoryLocationData(MemoryLocationNames.DefenderXTransition, 0xF25B60 + 0x1C, new int[] { 0xB58 * (0x20 - 0x3 - 0x7 - 0x9) + 0x12C + 0x4C + 0x18 + 0x4C });
        public static MemoryLocationData RonsoTransition = new MemoryLocationData(MemoryLocationNames.RonsoTransition, 0xF25B60 + 0x1C, new int[] { 0xB58 * (0x27 - 0x5 - 0x6 - 0x2) + 0x12C + 0x4C + 0x18 });
        public static MemoryLocationData FluxTransition = new MemoryLocationData(MemoryLocationNames.FluxTransition, 0xF25B60 + 0x1C, new int[] { 0xB58 * (0x15 - 0x2 - 0x6 - 0x1) + 0x12C + 0x4C + 0x18});
        public static MemoryLocationData SanctuaryTransition = new MemoryLocationData(MemoryLocationNames.SanctuaryTransition, 0xF25B60 + 0x1C, new int[] { 0xB58 * (0x15 - 0x2 - 0x7 - 0x1) + 0x12C + 0x4C + 0x18 });
        public static MemoryLocationData SpectralKeeperTransition = new MemoryLocationData(MemoryLocationNames.SpectralKeeperTransition, 0xF25B60 + 0x1C, new int[] { 0xB58 * (0x11 - 0x0 - 0x6 - 0x0) + 0x12C + 0x4C + 0x18});
        public static MemoryLocationData SpectralKeeperTransition2 = new MemoryLocationData(MemoryLocationNames.SpectralKeeperTransition2, 0xF25B60 + 0x1C, new int[] { 0xB58 * (0x55 - 0xF - 0x7 - 0x1E) + 0x12C + 0x4C + 0x18});
        public static MemoryLocationData YunalescaTransition = new MemoryLocationData(MemoryLocationNames.YunalescaTransition, 0xF25B60 + 0x1C, new int[] { 0xB58 * (0x1B - 0x1 - 0x7 - 0x2) + 0x12C + 0x4C + 0x18});
        public static MemoryLocationData FinsTransition = new MemoryLocationData(MemoryLocationNames.FinsTransition, 0xF25B60 + 0x1C, new int[] { 0xB58 * (0x12 - 0x0 - 0x2 - 0x0) + 0x12C + 0x18 });
        public static MemoryLocationData FinsAirshipTransition = new MemoryLocationData(MemoryLocationNames.FinsAirshipTransition, 0xF25B60 + 0x1C, new int[] { 0xB58 * (0x1F - 0x3 - 0x5 - 0x5) + 0x12C + 0x18 });
        public static MemoryLocationData SinCoreTransition = new MemoryLocationData(MemoryLocationNames.SinCoreTransition, 0xF25B60 + 0x1C, new int[] { 0xB58 * (0xF - 0x0 - 0x0 - 0x0) + 0x12C + 0x4C + 0x18 - 0x3904 });
        public static MemoryLocationData OverdriveSinTransition = new MemoryLocationData(MemoryLocationNames.OverdriveSinTransition, 0xF25B60 + 0x1C, new int[] { 0xB58 * (0x22 - 0x2 - 0x5 - 0x1) + 0x12C + 0x4C + 0x18 - 0x4C });
        public static MemoryLocationData OmnisTransition = new MemoryLocationData(MemoryLocationNames.OmnisTransition, 0xF25B60 + 0x1C, new int[] { 0xB58 * (0x18 - 0x2 - 0x3 - 0x1) + 0x12C + 0x4C + 0x18 });
        public static MemoryLocationData BFATransition = new MemoryLocationData(MemoryLocationNames.BFATransition, 0xF25B60 + 0x1C, new int[] { 0xB58 * (0x1B - 0x0 - 0x5 - 0x1) + 0x12C + 0x4C + 0x18 });
        public static MemoryLocationData AeonTransition = new MemoryLocationData(MemoryLocationNames.AeonTransition, 0xF25B60 + 0x1C, new int[] { 0xB58 * (0x1D - 0x0 - 0x3 - 0x0) + 0x12C + 0x4C + 0x18 });
        public static MemoryLocationData YuYevonTransition = new MemoryLocationData(MemoryLocationNames.YuYevonTransition, 0xF25B60 + 0x1C, new int[] { 0xB58 * (0x1D - 0x0 - 0x3 - 0x0) + 0x12C + 0x4C + 0x18 + 0x4C });

        public static MemoryLocationData YojimboFaythTransition = new MemoryLocationData(MemoryLocationNames.YojimboFaythTransition, 0xF25B60 + 0x1C, new int[] { 0x9508 });

        public static MemoryLocationData CutsceneProgress_Max = new MemoryLocationData(MemoryLocationNames.CutsceneProgress_Max, 0xF26AE8, 0xC);
        public static MemoryLocationData CutsceneProgress_uVar1 = new MemoryLocationData(MemoryLocationNames.CutsceneProgress_uVar1, 0xF26AE8, 0x14);
        public static MemoryLocationData CutsceneProgress_uVar2 = new MemoryLocationData(MemoryLocationNames.CutsceneProgress_uVar2, 0xF26AE8, 0x16);
        public static MemoryLocationData CutsceneProgress_uVar3 = new MemoryLocationData(MemoryLocationNames.CutsceneProgress_uVar3, 0xF26AE8, 0x18);

        // Encounters
        public static MemoryLocationData EncounterMapID = new MemoryLocationData(MemoryLocationNames.EncounterMapID, 0xD2C256);
        public static MemoryLocationData EncounterFormationID1 = new MemoryLocationData(MemoryLocationNames.EncounterFormationID1, 0xD2C258);
        public static MemoryLocationData EncounterFormationID2 = new MemoryLocationData(MemoryLocationNames.EncounterFormationID2, 0xD2C259);
        public static MemoryLocationData ScriptedBattleFlag1 = new MemoryLocationData(MemoryLocationNames.ScriptedBattleFlag1, 0xD2A9D4); // Setting to 0 triggers a post battle rewards screen
        public static MemoryLocationData ScriptedBattleFlag2 = new MemoryLocationData(MemoryLocationNames.ScriptedBattleFlag2, 0xD2A9D5); // 0 = Screen crack effect, 1 = Boss transition effect
        public static MemoryLocationData ScriptedBattleVar1 = new MemoryLocationData(MemoryLocationNames.ScriptedBattleVar1, 0xF26B08); // Set to the right value to make the game recognise battle as scripted and not random
        public static MemoryLocationData ScriptedBattleVar3 = new MemoryLocationData(MemoryLocationNames.ScriptedBattleVar3, 0xF26B10); // Set at the start of a scripted battle
        public static MemoryLocationData ScriptedBattleVar4 = new MemoryLocationData(MemoryLocationNames.ScriptedBattleVar4, 0xF26B14); // Set at the start of a scripted battle
        public static MemoryLocationData EncounterTrigger = new MemoryLocationData(MemoryLocationNames.EncounterTrigger, 0xD2A8E2); // Set to 2 to trigger boss encounter

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
        public static MemoryLocationData EnableAnima = new MemoryLocationData(MemoryLocationNames.EnableYojimbo, 0xD3280C);
        public static MemoryLocationData EnableYojimbo = new MemoryLocationData(MemoryLocationNames.EnableAnima, 0xD328A0);
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

        // Encounter Rate
        public static MemoryLocationData EncountersActiveFlag = new MemoryLocationData("EncountersActiveFlag", 0xD2A9D7);
        public static MemoryLocationData TotalDistance = new MemoryLocationData("TotalDistance", 0xD2A9DC);
        public static MemoryLocationData CycleDistance = new MemoryLocationData("CycleDistance", 0xD2A9D8);

        // Special Flags
        public static MemoryLocationData FangirlsOrKidsSkip = new MemoryLocationData(MemoryLocationNames.FangirlsOrKidsSkip, 0xD2CE7C);
        public static MemoryLocationData BaajFlag1 = new MemoryLocationData(MemoryLocationNames.BaajFlag1, 0xD2CE0C);
        public static MemoryLocationData BesaidFlag1 = new MemoryLocationData(MemoryLocationNames.BesaidFlag1, 0xF25AB3);
        public static MemoryLocationData SSWinnoFlag1 = new MemoryLocationData(MemoryLocationNames.SSWinnoFlag1, 0xD2CE7D);
        public static MemoryLocationData KilikaMapFlag = new MemoryLocationData(MemoryLocationNames.KilikaMapFlag, 0xD2CE7E);
        public static MemoryLocationData SSWinnoFlag2 = new MemoryLocationData(MemoryLocationNames.SSWinnoFlag2, 0xD2CE7F);
        public static MemoryLocationData LucaFlag = new MemoryLocationData(MemoryLocationNames.LucaFlag, 0xD2CDE5);
        public static MemoryLocationData LucaFlag2 = new MemoryLocationData(MemoryLocationNames.LucaFlag2, 0xD2CDE4);
        public static MemoryLocationData BlitzballFlag = new MemoryLocationData(MemoryLocationNames.BlitzballFlag, 0xD2E10A);
        public static MemoryLocationData MiihenFlag1 = new MemoryLocationData(MemoryLocationNames.MiihenFlag1, 0xD2CCFE);
        public static MemoryLocationData MiihenFlag2 = new MemoryLocationData(MemoryLocationNames.MiihenFlag2, 0xD2CCFF);
        public static MemoryLocationData MiihenFlag3 = new MemoryLocationData(MemoryLocationNames.MiihenFlag3, 0xD2CD00);
        public static MemoryLocationData MiihenFlag4 = new MemoryLocationData(MemoryLocationNames.MiihenFlag4, 0xD2CD04);
        public static MemoryLocationData MRRFlag1 = new MemoryLocationData(MemoryLocationNames.MRRFlag1, 0xD2CD07);
        public static MemoryLocationData MRRFlag2 = new MemoryLocationData(MemoryLocationNames.MRRFlag2, 0xD2CD08);
        public static MemoryLocationData MoonflowFlag = new MemoryLocationData(MemoryLocationNames.MoonflowFlag, 0xD2CC7F);
        public static MemoryLocationData MoonflowFlag2 = new MemoryLocationData(MemoryLocationNames.MoonflowFlag2, 0xD2CC83);
        public static MemoryLocationData RikkuOutfit = new MemoryLocationData(MemoryLocationNames.RikkuOutfit, 0xD2CB61);
        public static MemoryLocationData TidusWeaponDamageBoost = new MemoryLocationData(MemoryLocationNames.TidusWeaponDamageBoost, 0x1F11240);
        public static MemoryLocationData GuadosalamShopFlag = new MemoryLocationData(MemoryLocationNames.GuadosalamShopFlag, 0xD2CD84);
        public static MemoryLocationData ThunderPlainsFlag = new MemoryLocationData(MemoryLocationNames.ThunderPlainsFlag, 0xD2CE81);
        public static MemoryLocationData MacalaniaFlag = new MemoryLocationData(MemoryLocationNames.MacalaniaFlag, 0xD2CD16);
        public static MemoryLocationData BikanelFlag = new MemoryLocationData(MemoryLocationNames.BikanelFlag, 0xD2CD4B);
        public static MemoryLocationData Sandragoras = new MemoryLocationData(MemoryLocationNames.Sandragoras, 0xD2CD4E);
        public static MemoryLocationData ViaPurificoPlatform = new MemoryLocationData(MemoryLocationNames.ViaPurificoPlatform, 0xD2CC89);
        public static MemoryLocationData NatusFlag = new MemoryLocationData(MemoryLocationNames.NatusFlag, 0xD2CC7C);
        public static MemoryLocationData CalmLandsFlag = new MemoryLocationData(MemoryLocationNames.CalmLandsFlag, 0xD2CD09);
        public static MemoryLocationData WantzFlag = new MemoryLocationData(MemoryLocationNames.WantzFlag, 0xD2CF06);
        public static MemoryLocationData GagazetCaveFlag = new MemoryLocationData(MemoryLocationNames.GagazetCaveFlag, 0xD2CD55);
        public static MemoryLocationData OmegaRuinsFlag = new MemoryLocationData(MemoryLocationNames.OmegaRuinsFlag, 0xD2CE4E);
        public static MemoryLocationData WantzMacalaniaFlag = new MemoryLocationData(MemoryLocationNames.WantzMacalaniaFlag, 0xD2D6E1);


        // Blitzball
        public static MemoryLocationData AurochsTeamBytes = new MemoryLocationData(MemoryLocationNames.AurochsTeamBytes, 0xD2D704);
        public static MemoryLocationData BlitzballBytes = new MemoryLocationData(MemoryLocationNames.BlitzballBytes, 0xD2DC7C);
        public static MemoryLocationData AurochsPlayer1 = new MemoryLocationData(MemoryLocationNames.AurochsPlayer1, 0xD2E0BE);

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

        // Items
        public static MemoryLocationData ItemsStart = new MemoryLocationData(MemoryLocationNames.ItemsStart, 0xD3095C);
        public static MemoryLocationData ItemsQtyStart = new MemoryLocationData(MemoryLocationNames.ItemsQtyStart, 0xD30B5C);

        // AP
        public static MemoryLocationData CharacterAPFlags = new MemoryLocationData(MemoryLocationNames.CharacterAPFlags, 0x1F10EC4);

        // Menu Trigger
        public static MemoryLocationData MenuTriggerValue = new MemoryLocationData(MemoryLocationNames.MenuTriggerValue, 0xEFBBF0);

        // Menu Values - These are values which the game sets during the battle rewards menu which don't get cleaned out properly when we skip straight to the rewards screen.
        //               We set the values to 0x00000000 to clean these out after some skips
        public static MemoryLocationData MenuValue1 = new MemoryLocationData(MemoryLocationNames.MenuValue1, 0x14408AC);
        public static MemoryLocationData MenuValue2 = new MemoryLocationData(MemoryLocationNames.MenuValue2, 0xF27F10);

        // Menu Values - These are values which need to be set correctly to avoid menu bug where the menu can't open
        public static MemoryLocationData MenuValue3 = new MemoryLocationData(MemoryLocationNames.MenuValue3, 0x840E18);
        public static MemoryLocationData MenuValue4 = new MemoryLocationData(MemoryLocationNames.MenuValue4, 0xD2A00C);
        public static MemoryLocationData MenuValue5 = new MemoryLocationData(MemoryLocationNames.MenuValue5, 0x8DED2C, 0x6D0);
        public static MemoryLocationData MenuValue6 = new MemoryLocationData(MemoryLocationNames.MenuValue6, 0x8DED2C, 0x704);
        public static MemoryLocationData MenuValue7 = new MemoryLocationData(MemoryLocationNames.MenuValue7, 0x8CB9D8, 0x10D2E);

        // Booster Values
        public static MemoryLocationData SpeedBoostAmount = new MemoryLocationData(MemoryLocationNames.SpeedBoostAmount, 0x8E82A4);
        public static MemoryLocationData SpeedBoostVar1 = new MemoryLocationData(MemoryLocationNames.SpeedBoostVar1, 0x85A068);

        // Actor Model Positions
        public static MemoryLocationData ActorArrayLength = new MemoryLocationData(MemoryLocationNames.ActorArrayLength, 0x1FC44E0);

        // RNGmod
        public static MemoryLocationData RNGArrayOpBytes = new MemoryLocationData(MemoryLocationNames.RNGArrayOpBytes, 0x398903);

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
