﻿using FFX_Cutscene_Remover.ComponentUtil;
using System;
using System.Diagnostics;
using System.Reflection;
using FFXCutsceneRemover.Logging;
using System.ComponentModel;
using System.Linq;

namespace FFXCutsceneRemover
{
    /* Represents a change in current state of the game's memory. Create one of these objects
     * with the values you care about, and Execute() will set the game's state to match this object. */
    public class Transition
    {
        private static string DEFAULT_DESCRIPTION = "Executing Transition - No Description";
        private static FieldInfo[] publicFields = typeof(Transition).GetFields(BindingFlags.Public | BindingFlags.Instance);
        protected readonly MemoryWatchers memoryWatchers = MemoryWatchers.Instance;

        private Process process;

        public bool ConsoleOutput = true;
        public bool ForceLoad = true;
        public bool FullHeal = false;
        public bool MenuCleanup = false;
        public bool AddRewardItems = false;
        public bool AddSinLocation = false;
        public bool RemoveSinLocation = false;
        public bool PositionPartyOffScreen = false;
        public bool PositionTidusAfterLoad = false;
        public string Description = null;
        public int BaseCutsceneValue = 0;
        public int BaseCutsceneValue2 = 0;
        public bool Repeatable = false;
        public bool Suspendable = true;
        public int Stage = 0;
        public (byte itemref, byte itemqty)[] AddItemsToInventory = null;

        public int? ActorArrayLength = null;
        public short[] TargetActorIDs = null;
        public float? Target_x = null;
        public float? Target_y = null;
        public float? Target_z = null;
        public float? Target_rot = null;
        public short? Target_var1 = null;
        public byte? MoveFrame = 8; // Default to 8 Frames as this seems to work for most transitions
        public float? PartyTarget_x = null;
        public float? PartyTarget_y = null;
        public float? PartyTarget_z = null;

        public formations? FormationSwitch = null;

        /* Only add members here for memory addresses that we want to write the value to.
         * If we only ever read the value then there is no need to add it here. */
        public short? RoomNumber = null;
        public short? Storyline = null;
        public byte? SpawnPoint = null;
        public short? BattleState = null;
        public short? BattleState2 = null;
        public byte? Menu = null;
        public byte? MenuLock = null;
        public short? Intro = null;
        public short? FangirlsOrKidsSkip = null;
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
        public short? AirshipDestinationChange = null;
        public short? AuronOverdrives = null;
        public int? TargetFramerate = null;
        public byte? PartyMembers = null;
        public byte? Sandragoras = null;
        public short? EncounterMapID = null;
        public byte? EncounterFormationID1 = null;
        public byte? EncounterFormationID2 = null;
        public byte? ScriptedBattleFlag1 = null;
        public byte? ScriptedBattleFlag2 = null;
        public int? ScriptedBattleVar1 = null;
        public int? ScriptedBattleVar3 = null;
        public int? ScriptedBattleVar4 = null;
        public byte? EncounterTrigger = null;
        public int? HpEnemyA = null;
        public byte? GuadoCount = null;
        public float? TidusXCoordinate = null;
        public float? TidusYCoordinate = null;
        public float? TidusZCoordinate = null;
        public float? TidusRotation = null;
        public byte[] DialogueFile = null;
        public byte? CutsceneTiming = null;

        // Bespoke Transitions
        public int? AuronTransition = null;
        public int? AmmesTransition = null;
        public int? TankerTransition = null;
        public int? InsideSinTransition = null;
        public int? DiveTransition = null;
        public int? GeosTransition = null;
        public int? KlikkTransition = null;
        public int? AlBhedBoatTransition = null;
        public int? UnderwaterRuinsTransition = null;
        public int? UnderwaterRuinsTransition2 = null;
        public int? BeachTransition = null;
        public int? LagoonTransition1 = null;
        public int? LagoonTransition2 = null;
        public int? ValeforTransition = null;
        public int? KimahriTransition = null;
        public int? YunaBoatTransition = null;
        public int? SinFinTransition = null;
        public int? EchuillesTransition = null;
        public int? GeneauxTransition = null;
        public int? KilikaTrialsTransition = null;
        public int? KilikaAntechamberTransition = null;
        public int? IfritTransition = null;
        public int? IfritTransition2 = null;
        public int? JechtShotTransition = null;
        public int? OblitzeratorTransition = null;
        public int? BlitzballTransition = null;
        public int? SahaginTransition = null;
        public int? GarudaTransition = null;
        public int? RinTransition = null;
        public int? ChocoboEaterTransition = null;
        public int? GuiTransition = null;
        public int? Gui2Transition = null;
        public int? DjoseTransition = null;
        public int? IxionTransition = null;
        public int? ExtractorTransition = null;
        public int? SeymoursHouseTransition1 = null;
        public int? SeymoursHouseTransition2 = null;
        public int? FarplaneTransition1 = null;
        public int? FarplaneTransition2 = null;
        public int? TromellTransition = null;
        public int? CrawlerTransition = null;
        public int? SeymourTransition = null;
        public int? SeymourTransition2 = null;
        public int? WendigoTransition = null;
        public int? SpherimorphTransition = null;
        public int? UnderLakeTransition = null;
        public int? BikanelTransition = null;
        public int? HomeTransition = null;
        public int? EvraeTransition = null;
        public int? EvraeAirshipTransition = null;
        public int? GuardsTransition = null;
        public int? BahamutTransition = null;
        public int? IsaaruTransition = null;
        public int? AltanaTransition = null;
        public int? NatusTransition = null;
        public int? DefenderXTransition = null;
        public int? RonsoTransition = null;
        public int? FluxTransition = null;
        public int? SanctuaryTransition = null;
        public int? SpectralKeeperTransition = null;
        public int? SpectralKeeperTransition2 = null;
        public int? YunalescaTransition = null;
        public int? FinsTransition = null;
        public int? FinsAirshipTransition = null;
        public int? SinCoreTransition = null;
        public int? OverdriveSinTransition = null;
        public int? OmnisTransition = null;
        public int? BFATransition = null;
        public int? AeonTransition = null;
        public int? YuYevonTransition = null;
        public int? YojimboFaythTransition = null;

        public byte? EnableTidus = null;
        public byte? EnableYuna = null;
        public byte? EnableAuron = null;
        public byte? EnableKimahri = null;
        public byte? EnableWakka = null;
        public byte? EnableLulu = null;
        public byte? EnableRikku = null;
        public byte? EnableSeymour = null;
        public byte? EnableValefor = null;
        public byte? EnableIfrit = null;
        public byte? EnableIxion = null;
        public byte? EnableShiva = null;
        public byte? EnableBahamut = null;
        public byte? EnableAnima = null;
        public byte? EnableYojimbo = null;
        public byte? EnableMagus = null;

        public byte? EncountersActiveFlag = null;
        public float? TotalDistance = null;
        public float? CycleDistance = null;

        public byte? BaajFlag1 = null;

        public byte? SSWinnoFlag1 = null;
        public byte? KilikaMapFlag = null;
        public byte? SSWinnoFlag2 = null;

        public byte? LucaFlag = null;
        public byte? LucaFlag2 = null;
        public byte? BlitzballFlag = null;

        public byte? MiihenFlag1 = null;
        public byte? MiihenFlag2 = null;
        public byte? MiihenFlag3 = null;
        public byte? MiihenFlag4 = null;

        public byte? MRRFlag1 = null;
        public byte? MRRFlag2 = null;

        public byte? MoonflowFlag = null;
        public byte? MoonflowFlag2 = null;
        public byte? RikkuOutfit = null;
        public byte? TidusWeaponDamageBoost = null;
        public byte? GuadosalamShopFlag = null;
        public byte? ThunderPlainsFlag = null;
        public byte? MacalaniaFlag = null;
        public byte? BikanelFlag = null;

        public byte[] Formation = null;
        public byte[] RikkuName = null;

        public byte? ViaPurificoPlatform = null;
        public byte? NatusFlag = null;
        public ushort? CalmLandsFlag = null;
        public short? GagazetCaveFlag = null;
        public byte? WantzFlag = null;
        public byte? OmegaRuinsFlag = null;
        public byte? WantzMacalaniaFlag = null;

        public byte[] AurochsTeamBytes = null;
        public byte[] BlitzballBytes = null;
        public byte? AurochsPlayer1 = null;

        public int? GilBattleRewards = null;
        public byte? BattleRewardItemCount = null;
        public short? BattleRewardItem1 = null;
        public short? BattleRewardItem2 = null;
        public short? BattleRewardItem3 = null;
        public short? BattleRewardItem4 = null;
        public short? BattleRewardItem5 = null;
        public short? BattleRewardItem6 = null;
        public short? BattleRewardItem7 = null;
        public short? BattleRewardItem8 = null;
        public byte? BattleRewardItemQty1 = null;
        public byte? BattleRewardItemQty2 = null;
        public byte? BattleRewardItemQty3 = null;
        public byte? BattleRewardItemQty4 = null;
        public byte? BattleRewardItemQty5 = null;
        public byte? BattleRewardItemQty6 = null;
        public byte? BattleRewardItemQty7 = null;
        public byte? BattleRewardItemQty8 = null;
        public byte? BattleRewardEquipCount = null;
        public byte[] BattleRewardEquip1 = null;
        public byte[] BattleRewardEquip2 = null;
        public byte[] BattleRewardEquip3 = null;
        public byte[] BattleRewardEquip4 = null;
        public byte[] BattleRewardEquip5 = null;
        public byte[] BattleRewardEquip6 = null;
        public byte[] BattleRewardEquip7 = null;
        public byte[] BattleRewardEquip8 = null;

        public byte[] ItemsStart = null;
        public byte[] ItemsQtyStart = null;

        public byte[] CharacterAPFlags = null;

        public int? MenuValue1 = null;
        public int? MenuValue2 = null;
        public int? MenuTriggerValue = null;

        public byte[] RNGArrayOpBytes = null;

        // Bitmask Addition
        public int? AddCalmLandsBitmask = null;

        public virtual void Execute(string defaultDescription = "")
        {
            if (ConsoleOutput)
            {
                DiagnosticLog.Information(
                    !string.IsNullOrEmpty(Description) ? Description :
                    !string.IsNullOrEmpty(defaultDescription) ? defaultDescription :
                    DEFAULT_DESCRIPTION);
            }
            // Always update to get the latest process
            process = memoryWatchers.Process;

            WriteValue(memoryWatchers.RoomNumber, RoomNumber);
            WriteValue(memoryWatchers.Storyline, Storyline);
            WriteValue(memoryWatchers.SpawnPoint, SpawnPoint);
            WriteValue(memoryWatchers.BattleState, BattleState);
            WriteValue(memoryWatchers.BattleState2, BattleState2);
            WriteValue(memoryWatchers.Menu, Menu);
            WriteValue(memoryWatchers.MenuLock, MenuLock);
            WriteValue(memoryWatchers.Intro, Intro);
            WriteValue(memoryWatchers.FangirlsOrKidsSkip, FangirlsOrKidsSkip);
            WriteValue(memoryWatchers.State, State);
            WriteValue(memoryWatchers.XCoordinate, XCoordinate);
            WriteValue(memoryWatchers.YCoordinate, YCoordinate);
            WriteValue(memoryWatchers.Camera, Camera);
            WriteValue(memoryWatchers.Camera_x, Camera_x);
            WriteValue(memoryWatchers.Camera_y, Camera_y);
            WriteValue(memoryWatchers.Camera_z, Camera_z);
            WriteValue(memoryWatchers.CameraRotation, CameraRotation);
            WriteValue(memoryWatchers.EncounterStatus, EncounterStatus);
            WriteValue(memoryWatchers.MovementLock, MovementLock);
            WriteValue(memoryWatchers.ActiveMusicId, ActiveMusicId);
            WriteValue(memoryWatchers.MusicId, MusicId);
            WriteValue(memoryWatchers.RoomNumberAlt, RoomNumberAlt);
            WriteValue(memoryWatchers.CutsceneAlt, CutsceneAlt);
            WriteValue(memoryWatchers.AirshipDestinations, AirshipDestinations);
            WriteValue(memoryWatchers.AuronOverdrives, AuronOverdrives);
            WriteValue(memoryWatchers.TargetFramerate, TargetFramerate);
            WriteValue(memoryWatchers.Sandragoras, Sandragoras);
            WriteValue(memoryWatchers.EncounterMapID, EncounterMapID);
            WriteValue(memoryWatchers.EncounterFormationID1, EncounterFormationID1);
            WriteValue(memoryWatchers.EncounterFormationID2, EncounterFormationID2);
            WriteValue(memoryWatchers.ScriptedBattleFlag1, ScriptedBattleFlag1);
            WriteValue(memoryWatchers.ScriptedBattleFlag2, ScriptedBattleFlag2);
            WriteValue(memoryWatchers.ScriptedBattleVar1, ScriptedBattleVar1);
            WriteValue(memoryWatchers.ScriptedBattleVar3, ScriptedBattleVar3);
            WriteValue(memoryWatchers.ScriptedBattleVar4, ScriptedBattleVar4);
            WriteValue(memoryWatchers.EncounterTrigger, EncounterTrigger);
            WriteValue(memoryWatchers.HpEnemyA, HpEnemyA);
            WriteValue(memoryWatchers.GuadoCount, GuadoCount);
            WriteValue(memoryWatchers.TidusXCoordinate, TidusXCoordinate);
            WriteValue(memoryWatchers.TidusYCoordinate, TidusYCoordinate);
            WriteValue(memoryWatchers.TidusZCoordinate, TidusZCoordinate);
            WriteValue(memoryWatchers.TidusRotation, TidusRotation);
            WriteBytes(memoryWatchers.DialogueFile, DialogueFile);
            WriteValue(memoryWatchers.CutsceneTiming, CutsceneTiming);
            WriteValue(memoryWatchers.AuronTransition, AuronTransition);
            WriteValue(memoryWatchers.AmmesTransition, AmmesTransition);
            WriteValue(memoryWatchers.TankerTransition, TankerTransition);
            WriteValue(memoryWatchers.InsideSinTransition, InsideSinTransition);
            WriteValue(memoryWatchers.DiveTransition, DiveTransition);
            WriteValue(memoryWatchers.GeosTransition, GeosTransition);
            WriteValue(memoryWatchers.KlikkTransition, KlikkTransition);
            WriteValue(memoryWatchers.AlBhedBoatTransition, AlBhedBoatTransition);
            WriteValue(memoryWatchers.UnderwaterRuinsTransition, UnderwaterRuinsTransition);
            WriteValue(memoryWatchers.UnderwaterRuinsTransition2, UnderwaterRuinsTransition2);
            WriteValue(memoryWatchers.BeachTransition, BeachTransition);
            WriteValue(memoryWatchers.LagoonTransition1, LagoonTransition1);
            WriteValue(memoryWatchers.LagoonTransition2, LagoonTransition2);
            WriteValue(memoryWatchers.ValeforTransition, ValeforTransition);
            WriteValue(memoryWatchers.KimahriTransition, KimahriTransition);
            WriteValue(memoryWatchers.YunaBoatTransition, YunaBoatTransition);
            WriteValue(memoryWatchers.SinFinTransition, SinFinTransition);
            WriteValue(memoryWatchers.EchuillesTransition, EchuillesTransition);
            WriteValue(memoryWatchers.GeneauxTransition, GeneauxTransition);
            WriteValue(memoryWatchers.KilikaTrialsTransition, KilikaTrialsTransition);
            WriteValue(memoryWatchers.KilikaAntechamberTransition, KilikaAntechamberTransition);
            WriteValue(memoryWatchers.IfritTransition, IfritTransition);
            WriteValue(memoryWatchers.IfritTransition2, IfritTransition2);
            WriteValue(memoryWatchers.JechtShotTransition, JechtShotTransition);
            WriteValue(memoryWatchers.OblitzeratorTransition, OblitzeratorTransition);
            WriteValue(memoryWatchers.BlitzballTransition, BlitzballTransition);
            WriteValue(memoryWatchers.SahaginTransition, SahaginTransition);
            WriteValue(memoryWatchers.GarudaTransition, GarudaTransition);
            WriteValue(memoryWatchers.RinTransition, RinTransition);
            WriteValue(memoryWatchers.ChocoboEaterTransition, ChocoboEaterTransition);
            WriteValue(memoryWatchers.GuiTransition, GuiTransition);
            WriteValue(memoryWatchers.Gui2Transition, Gui2Transition);
            WriteValue(memoryWatchers.DjoseTransition, DjoseTransition);
            WriteValue(memoryWatchers.IxionTransition, IxionTransition);
            WriteValue(memoryWatchers.ExtractorTransition, ExtractorTransition);
            WriteValue(memoryWatchers.SeymoursHouseTransition1, SeymoursHouseTransition1);
            WriteValue(memoryWatchers.SeymoursHouseTransition2, SeymoursHouseTransition2);
            WriteValue(memoryWatchers.FarplaneTransition1, FarplaneTransition1);
            WriteValue(memoryWatchers.FarplaneTransition2, FarplaneTransition2);
            WriteValue(memoryWatchers.TromellTransition, TromellTransition);
            WriteValue(memoryWatchers.CrawlerTransition, CrawlerTransition);
            WriteValue(memoryWatchers.SeymourTransition, SeymourTransition);
            WriteValue(memoryWatchers.SeymourTransition2, SeymourTransition2);
            WriteValue(memoryWatchers.WendigoTransition, WendigoTransition);
            WriteValue(memoryWatchers.SpherimorphTransition, SpherimorphTransition);
            WriteValue(memoryWatchers.UnderLakeTransition, UnderLakeTransition);
            WriteValue(memoryWatchers.BikanelTransition, BikanelTransition);
            WriteValue(memoryWatchers.HomeTransition, HomeTransition);
            WriteValue(memoryWatchers.EvraeTransition, EvraeTransition);
            WriteValue(memoryWatchers.EvraeAirshipTransition, EvraeAirshipTransition);
            WriteValue(memoryWatchers.GuardsTransition, GuardsTransition);
            WriteValue(memoryWatchers.BahamutTransition, BahamutTransition);
            WriteValue(memoryWatchers.IsaaruTransition, IsaaruTransition);
            WriteValue(memoryWatchers.AltanaTransition, AltanaTransition);
            WriteValue(memoryWatchers.NatusTransition, NatusTransition);
            WriteValue(memoryWatchers.DefenderXTransition, DefenderXTransition);
            WriteValue(memoryWatchers.RonsoTransition, RonsoTransition);
            WriteValue(memoryWatchers.FluxTransition, FluxTransition);
            WriteValue(memoryWatchers.SanctuaryTransition, SanctuaryTransition);
            WriteValue(memoryWatchers.SpectralKeeperTransition, SpectralKeeperTransition);
            WriteValue(memoryWatchers.SpectralKeeperTransition2, SpectralKeeperTransition2);
            WriteValue(memoryWatchers.YunalescaTransition, YunalescaTransition);
            WriteValue(memoryWatchers.FinsTransition, FinsTransition);
            WriteValue(memoryWatchers.FinsAirshipTransition, FinsAirshipTransition);
            WriteValue(memoryWatchers.SinCoreTransition, SinCoreTransition);
            WriteValue(memoryWatchers.OverdriveSinTransition, OverdriveSinTransition);
            WriteValue(memoryWatchers.OmnisTransition, OmnisTransition);
            WriteValue(memoryWatchers.BFATransition, BFATransition);
            WriteValue(memoryWatchers.AeonTransition, AeonTransition);
            WriteValue(memoryWatchers.YuYevonTransition, YuYevonTransition);
            WriteValue(memoryWatchers.YojimboFaythTransition, YojimboFaythTransition);
            WriteValue(memoryWatchers.EnableTidus, EnableTidus);
            WriteValue(memoryWatchers.EnableYuna, EnableYuna);
            WriteValue(memoryWatchers.EnableAuron, EnableAuron);
            WriteValue(memoryWatchers.EnableKimahri, EnableKimahri);
            WriteValue(memoryWatchers.EnableWakka, EnableWakka);
            WriteValue(memoryWatchers.EnableLulu, EnableLulu);
            WriteValue(memoryWatchers.EnableRikku, EnableRikku);
            WriteValue(memoryWatchers.EnableSeymour, EnableSeymour);
            WriteValue(memoryWatchers.EnableValefor, EnableValefor);
            WriteValue(memoryWatchers.EnableIfrit, EnableIfrit);
            WriteValue(memoryWatchers.EnableIxion, EnableIxion);
            WriteValue(memoryWatchers.EnableShiva, EnableShiva);
            WriteValue(memoryWatchers.EnableBahamut, EnableBahamut);
            WriteValue(memoryWatchers.EnableAnima, EnableAnima);
            WriteValue(memoryWatchers.EnableYojimbo, EnableYojimbo);
            WriteValue(memoryWatchers.EnableMagus, EnableMagus);

            WriteValue(memoryWatchers.BaajFlag1, BaajFlag1);
            WriteValue(memoryWatchers.SSWinnoFlag1, SSWinnoFlag1);
            WriteValue(memoryWatchers.KilikaMapFlag, KilikaMapFlag);
            WriteValue(memoryWatchers.SSWinnoFlag2, SSWinnoFlag2);

            WriteValue(memoryWatchers.LucaFlag, LucaFlag);
            WriteValue(memoryWatchers.LucaFlag2, LucaFlag2);
            WriteValue(memoryWatchers.BlitzballFlag, BlitzballFlag);
            WriteValue(memoryWatchers.MiihenFlag1, MiihenFlag1);
            WriteValue(memoryWatchers.MiihenFlag2, MiihenFlag2);
            WriteValue(memoryWatchers.MiihenFlag3, MiihenFlag3);
            WriteValue(memoryWatchers.MiihenFlag4, MiihenFlag4);
            WriteValue(memoryWatchers.MRRFlag1, MRRFlag1);
            WriteValue(memoryWatchers.MRRFlag2, MRRFlag2);
            WriteValue(memoryWatchers.MoonflowFlag, MoonflowFlag);
            WriteValue(memoryWatchers.MoonflowFlag2, MoonflowFlag2);
            WriteValue(memoryWatchers.RikkuOutfit, RikkuOutfit);
            WriteValue(memoryWatchers.TidusWeaponDamageBoost, TidusWeaponDamageBoost);
            WriteValue(memoryWatchers.GuadosalamShopFlag, GuadosalamShopFlag);
            WriteValue(memoryWatchers.ThunderPlainsFlag, ThunderPlainsFlag);
            WriteValue(memoryWatchers.MacalaniaFlag, MacalaniaFlag);
            WriteValue(memoryWatchers.BikanelFlag, BikanelFlag);
            WriteBytes(memoryWatchers.RikkuName, RikkuName);
            WriteValue(memoryWatchers.ViaPurificoPlatform, ViaPurificoPlatform);
            WriteValue(memoryWatchers.NatusFlag, NatusFlag);
            WriteValue(memoryWatchers.CalmLandsFlag, CalmLandsFlag);
            WriteValue(memoryWatchers.WantzFlag, WantzFlag);
            WriteValue(memoryWatchers.GagazetCaveFlag, GagazetCaveFlag);
            WriteValue(memoryWatchers.OmegaRuinsFlag, OmegaRuinsFlag);
            WriteValue(memoryWatchers.WantzMacalaniaFlag, WantzMacalaniaFlag);

            WriteBytes(memoryWatchers.AurochsTeamBytes, AurochsTeamBytes);
            WriteBytes(memoryWatchers.BlitzballBytes, BlitzballBytes);
            WriteValue(memoryWatchers.AurochsPlayer1, AurochsPlayer1);

            WriteValue(memoryWatchers.GilBattleRewards, GilBattleRewards);
            WriteValue(memoryWatchers.BattleRewardItemCount, BattleRewardItemCount);
            WriteValue(memoryWatchers.BattleRewardItem1, BattleRewardItem1);
            WriteValue(memoryWatchers.BattleRewardItem2, BattleRewardItem2);
            WriteValue(memoryWatchers.BattleRewardItem3, BattleRewardItem3);
            WriteValue(memoryWatchers.BattleRewardItem4, BattleRewardItem4);
            WriteValue(memoryWatchers.BattleRewardItem5, BattleRewardItem5);
            WriteValue(memoryWatchers.BattleRewardItem6, BattleRewardItem6);
            WriteValue(memoryWatchers.BattleRewardItem7, BattleRewardItem7);
            WriteValue(memoryWatchers.BattleRewardItem8, BattleRewardItem8);
            WriteValue(memoryWatchers.BattleRewardItemQty1, BattleRewardItemQty1);
            WriteValue(memoryWatchers.BattleRewardItemQty2, BattleRewardItemQty2);
            WriteValue(memoryWatchers.BattleRewardItemQty3, BattleRewardItemQty3);
            WriteValue(memoryWatchers.BattleRewardItemQty4, BattleRewardItemQty4);
            WriteValue(memoryWatchers.BattleRewardItemQty5, BattleRewardItemQty5);
            WriteValue(memoryWatchers.BattleRewardItemQty6, BattleRewardItemQty6);
            WriteValue(memoryWatchers.BattleRewardItemQty7, BattleRewardItemQty7);
            WriteValue(memoryWatchers.BattleRewardItemQty8, BattleRewardItemQty8);
            WriteValue(memoryWatchers.BattleRewardEquipCount, BattleRewardEquipCount);
            WriteBytes(memoryWatchers.BattleRewardEquip1, BattleRewardEquip1);
            WriteBytes(memoryWatchers.BattleRewardEquip2, BattleRewardEquip2);
            WriteBytes(memoryWatchers.BattleRewardEquip3, BattleRewardEquip3);
            WriteBytes(memoryWatchers.BattleRewardEquip4, BattleRewardEquip4);
            WriteBytes(memoryWatchers.BattleRewardEquip5, BattleRewardEquip5);
            WriteBytes(memoryWatchers.BattleRewardEquip6, BattleRewardEquip6);
            WriteBytes(memoryWatchers.BattleRewardEquip7, BattleRewardEquip7);
            WriteBytes(memoryWatchers.BattleRewardEquip8, BattleRewardEquip8);

            WriteValue(memoryWatchers.MenuValue1, MenuValue1);
            WriteValue(memoryWatchers.MenuValue2, MenuValue2);
            WriteValue(memoryWatchers.MenuTriggerValue, MenuTriggerValue);

            WriteBytes(memoryWatchers.RNGArrayOpBytes, RNGArrayOpBytes);

            // Update Bitmasks
            WriteValue(memoryWatchers.CalmLandsFlag, memoryWatchers.CalmLandsFlag.Current | AddCalmLandsBitmask);

            if (ForceLoad)
            {
                ForceGameLoad();
                FixMenuBug();
                FixSpeedBoosterBug();
            }

            if (FullHeal)
            {
                FullPartyHeal();
            }

            if (MenuCleanup)
            {
                CleanMenuValues();
                ClearAllBattleRewards();
            }

            if (AddSinLocation)
            {
                AddSin();
            }

            if (RemoveSinLocation)
            {
                RemoveSin();
            }

            if (PositionPartyOffScreen)
            {
                PartyOffScreen();
            }

            if (!(AddItemsToInventory is null))
            {
                AddItems(AddItemsToInventory);
            }    

            UpdateFormation(Formation);

            if (PositionTidusAfterLoad)
            {
                process.Resume();
                memoryWatchers.ForceLoad.Update(process);
                memoryWatchers.State.Update(process);
                while (memoryWatchers.ForceLoad.Current == 1 || memoryWatchers.State.Current == -1) // Wait for loading to finish and black screen to end
                {
                    memoryWatchers.ForceLoad.Update(process);
                    memoryWatchers.State.Update(process);
                }
                memoryWatchers.FrameCounterFromLoad.Update(process);
                while (memoryWatchers.FrameCounterFromLoad.Current < MoveFrame)
                {
                    memoryWatchers.FrameCounterFromLoad.Update(process);
                }
                process.Suspend();
                SetActorPosition(1, Target_x, Target_y, Target_z, Target_rot, Target_var1);
                SetActorPosition(101, Target_x, Target_y, Target_z, Target_rot, Target_var1); // In Besaid Temple Tidus is ID 101 for some reason, also some other locations.
                process.Resume();
                while (memoryWatchers.FrameCounterFromLoad.Current < MoveFrame + 3)
                {
                    memoryWatchers.FrameCounterFromLoad.Update(process);
                }
                process.Suspend();
                WriteValue<float>(memoryWatchers.TotalDistance, 0.0f);
                WriteValue<float>(memoryWatchers.CycleDistance, 0.0f);
                process.Resume();
            }
            else
            {
                if (TargetActorIDs != null)
                {
                    foreach (short TargetActorID in TargetActorIDs)
                    {
                        SetActorPosition(TargetActorID, Target_x, Target_y, Target_z, Target_rot, Target_var1);
                    }
                }
            }
        }

        /* Set the force load bit. Will immediately cause a fade and load. */
        private void ForceGameLoad()
        {
            WriteValue<byte>(memoryWatchers.ForceLoad, 1);
            memoryWatchers.ForceLoad.Update(process);
        }

        protected void WriteValue<T>(MemoryWatcher watcher, T? value) where T : struct
        {
            if (value.HasValue)
            {
                writeHelper(watcher, () => process.WriteValue(watcher.Address, value.Value),
                   (pointer) => process.WriteValue(pointer, value.Value));
            }
        }

        protected void WriteBytes(MemoryWatcher watcher, byte[] bytes)
        {
            if (bytes != null)
            {
                writeHelper(watcher, () => process.WriteBytes(watcher.Address, bytes),
                    (pointer) => process.WriteBytes(pointer, bytes));
            }
        }

        private void writeHelper(MemoryWatcher watcher, Func<object> basicWriteAction, Func<IntPtr, object> deepPointerWriteAction)
        {
            if (watcher.AddrType == MemoryWatcher.AddressType.Absolute)
            {
                basicWriteAction.Invoke();
            }
            else
            {
                // To write to a deep pointer we need to dereference its pointer path.
                // Then we write to the final pointer.
                IntPtr finalPointer;
                if (!watcher.DeepPtr.DerefOffsets(process, out finalPointer))
                {
                    DiagnosticLog.Information("Couldn't read the pointer path for: " + watcher.Name);
                }
                deepPointerWriteAction.Invoke(finalPointer);
            }
        }

        public override bool Equals(object obj)
        {
            // If they're the exact same object then we're good.
            if (Equals(this, obj))
            {
                return true;
            }

            // Otherwise check all of the public fields to verify if they are the same transition
            return this == (Transition)obj;
        }

        public static bool operator ==(Transition first, Transition second)
        {
            foreach (var property in publicFields)
            {
                var thisValue = first is null ? null : property.GetValue(first);
                var otherValue = second is null ? null : property.GetValue(second);
                if (!Equals(thisValue, otherValue))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool operator !=(Transition first, Transition second)
        {
            return !(first == second);
        }

        public override int GetHashCode()
        {
            int hashCode = 3;
            foreach (var property in publicFields)
            {
                // This line *should* be getting the hashcode of the actual property value
                // NOT the property type.
                hashCode *= property.GetValue(this).GetHashCode();
            }
            return hashCode;
        }

        private void FullPartyHeal()
        {
            Process process = memoryWatchers.Process;

            int baseAddress = memoryWatchers.GetBaseAddress();

            for (int i = 0; i < 18; i++)
            {
                MemoryWatcher<int> CharacterHP_Current = new MemoryWatcher<int>(new IntPtr(baseAddress + 0xD32078 + 0x94 * i));
                MemoryWatcher<int> CharacterHP_Max = new MemoryWatcher<int>(new IntPtr(baseAddress + 0xD32080 + 0x94 * i));
                MemoryWatcher<int> CharacterMP_Current = new MemoryWatcher<int>(new IntPtr(baseAddress + 0xD3207C + 0x94 * i));
                MemoryWatcher<int> CharacterMP_Max = new MemoryWatcher<int>(new IntPtr(baseAddress + 0xD32084 + 0x94 * i));
                MemoryWatcher<byte> BattlesUntilReady = new MemoryWatcher<byte>(new IntPtr(baseAddress + 0xD32099 + 0x94 * i)); // Reset battles until ready counter for aeons

                CharacterHP_Current.Update(process);
                CharacterHP_Max.Update(process);
                CharacterMP_Current.Update(process);
                CharacterMP_Max.Update(process);
                BattlesUntilReady.Update(process);

                WriteValue<int>(CharacterHP_Current, CharacterHP_Max.Current);
                WriteValue<int>(CharacterMP_Current, CharacterMP_Max.Current);
                WriteValue<byte>(BattlesUntilReady, 0);
            }
        }

        private void CleanMenuValues()
        {
            WriteValue<int>(memoryWatchers.MenuValue1, 0);
            WriteValue<int>(memoryWatchers.MenuValue2, 0);
        }

        private void FixMenuBug()
        {
            WriteValue<int>(memoryWatchers.MenuValue3, unchecked((int)0xFFFFFFFF));
            WriteValue<int>(memoryWatchers.MenuValue4, 0x00000000);
            WriteValue<byte>(memoryWatchers.MenuValue5, 0x00);
            WriteValue<int>(memoryWatchers.MenuValue6, 0x00000001);
            WriteValue<byte>(memoryWatchers.MenuValue7, 0x00);
        }

        private void FixSpeedBoosterBug()
        {
            WriteValue<int>(memoryWatchers.SpeedBoostVar1, 1);
        }

        private void ClearAllBattleRewards()
        {
            // Clear Gil
            WriteValue<int>(memoryWatchers.GilBattleRewards, 0);

            if (AddRewardItems)
            {
                byte[] items = process.ReadBytes(memoryWatchers.ItemsStart.Address, 224);
                byte[] itemsQty = process.ReadBytes(memoryWatchers.ItemsQtyStart.Address, 112);
                byte[] itemRewards = process.ReadBytes(memoryWatchers.BattleRewardItem1.Address, 16);
                byte[] itemRewardsQty = process.ReadBytes(memoryWatchers.BattleRewardItemQty1.Address, 8);

                int rewardCount = memoryWatchers.BattleRewardItemCount.Current;

                bool alreadyExists;

                for (int i = 0; i < rewardCount; i++)
                {
                    alreadyExists = false;

                    for (int j = 0; j < 112; j++)
                    {
                        if (items[2 * j] == itemRewards[2 * i] && itemsQty[j] > 0)
                        {
                            alreadyExists = true;
                            itemsQty[j] += itemRewardsQty[i];

                            break;
                        }
                    }

                    if (alreadyExists == false)
                    {
                        for (int j = 0; j < 112; j++)
                        {
                            if (items[2 * j] == 0xFF && itemsQty[j] == 0)
                            {
                                alreadyExists = true;
                                items[2 * j] = itemRewards[2 * i];
                                items[2 * j + 1] = itemRewards[2 * i + 1];
                                itemsQty[j] = itemRewardsQty[i];

                                break;
                            }
                        }
                    }
                }

                WriteBytes(memoryWatchers.ItemsStart, items);
                WriteBytes(memoryWatchers.ItemsQtyStart, itemsQty);
            }

            // Clear Items
            WriteValue<byte>(memoryWatchers.BattleRewardItemCount, 0);
            WriteValue<short>(memoryWatchers.BattleRewardItem1, 0);
            WriteValue<short>(memoryWatchers.BattleRewardItem2, 0);
            WriteValue<short>(memoryWatchers.BattleRewardItem3, 0);
            WriteValue<short>(memoryWatchers.BattleRewardItem4, 0);
            WriteValue<short>(memoryWatchers.BattleRewardItem5, 0);
            WriteValue<short>(memoryWatchers.BattleRewardItem6, 0);
            WriteValue<short>(memoryWatchers.BattleRewardItem7, 0);
            WriteValue<short>(memoryWatchers.BattleRewardItem8, 0);
            WriteValue<byte>(memoryWatchers.BattleRewardItemQty1, 0);
            WriteValue<byte>(memoryWatchers.BattleRewardItemQty2, 0);
            WriteValue<byte>(memoryWatchers.BattleRewardItemQty3, 0);
            WriteValue<byte>(memoryWatchers.BattleRewardItemQty4, 0);
            WriteValue<byte>(memoryWatchers.BattleRewardItemQty5, 0);
            WriteValue<byte>(memoryWatchers.BattleRewardItemQty6, 0);
            WriteValue<byte>(memoryWatchers.BattleRewardItemQty7, 0);
            WriteValue<byte>(memoryWatchers.BattleRewardItemQty8, 0);

            //Clear Equipment -- Equipment Arrays are 22 bytes long
            WriteValue<byte>(memoryWatchers.BattleRewardEquipCount, 0);
            WriteBytes(memoryWatchers.BattleRewardEquip1, new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });
            WriteBytes(memoryWatchers.BattleRewardEquip2, new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });
            WriteBytes(memoryWatchers.BattleRewardEquip3, new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });
            WriteBytes(memoryWatchers.BattleRewardEquip4, new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });
            WriteBytes(memoryWatchers.BattleRewardEquip5, new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });
            WriteBytes(memoryWatchers.BattleRewardEquip6, new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });
            WriteBytes(memoryWatchers.BattleRewardEquip7, new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });
            WriteBytes(memoryWatchers.BattleRewardEquip8, new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });

            // Clear AP Flags
            WriteBytes(memoryWatchers.CharacterAPFlags, new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });
        }

        private void AddItems((byte itemref, byte itemqty)[] AddItemsToInventory)
        {
            byte[] items = process.ReadBytes(memoryWatchers.ItemsStart.Address, 224);
            byte[] itemsQty = process.ReadBytes(memoryWatchers.ItemsQtyStart.Address, 112);

            bool alreadyExists;

            for (int i = 0; i < AddItemsToInventory.Length; i++)
            {
                alreadyExists = false;

                for (int j = 0; j < 112; j++)
                {
                    if (items[2 * j] == AddItemsToInventory[i].itemref)
                    {
                        alreadyExists = true;
                        itemsQty[j] += AddItemsToInventory[i].itemqty;

                        break;
                    }
                }

                if (alreadyExists == false)
                {
                    for (int j = 0; j < 112; j++)
                    {
                        if (items[2 * j] == 0xFF && itemsQty[j] == 0)
                        {
                            DiagnosticLog.Information($"Adding Item: {AddItemsToInventory[i].itemref}");
                            items[2 * j] = AddItemsToInventory[i].itemref;
                            items[2 * j + 1] = 0x20;
                            itemsQty[j] = AddItemsToInventory[i].itemqty;

                            break;
                        }
                    }
                }
            }

            WriteBytes(memoryWatchers.ItemsStart, items);
            WriteBytes(memoryWatchers.ItemsQtyStart, itemsQty);
        }

        private void AddSin()
        {
            WriteValue<short>(memoryWatchers.AirshipDestinations, (short)(memoryWatchers.AirshipDestinations.Current + 512));
        }

        private void RemoveSin()
        {
            WriteValue<short>(memoryWatchers.AirshipDestinations, (short)(memoryWatchers.AirshipDestinations.Current - 512));
        }

        private void PartyOffScreen()
        {
            if (memoryWatchers.EnableTidus.Current == 17)
            {
                SetActorPosition(1, PartyTarget_x, PartyTarget_y, PartyTarget_z);
            }
            if (memoryWatchers.EnableYuna.Current == 17)
            {
                SetActorPosition(2, PartyTarget_x, PartyTarget_y, PartyTarget_z);
            }
            if (memoryWatchers.EnableAuron.Current == 17)
            {
                SetActorPosition(3, PartyTarget_x, PartyTarget_y, PartyTarget_z);
            }
            if (memoryWatchers.EnableKimahri.Current == 17)
            {
                SetActorPosition(4, PartyTarget_x, PartyTarget_y, PartyTarget_z);
            }
            if (memoryWatchers.EnableWakka.Current == 17)
            {
                SetActorPosition(5, PartyTarget_x, PartyTarget_y, PartyTarget_z);
            }
            if (memoryWatchers.EnableLulu.Current == 17)
            {
                SetActorPosition(6, PartyTarget_x, PartyTarget_y, PartyTarget_z);
            }
            if (memoryWatchers.EnableRikku.Current == 17)
            {
                SetActorPosition(7, PartyTarget_x, PartyTarget_y, PartyTarget_z);
            }
            if (memoryWatchers.EnableSeymour.Current == 17)
            {
                SetActorPosition(8, PartyTarget_x, PartyTarget_y, PartyTarget_z);
            }
        }

        private bool SetActorPosition(short? TargetActorID = null, float? Target_x = null, float? Target_y = null, float? Target_z = null, float? Target_rot = null, short? Target_var1 = null)
        {
            Process process = memoryWatchers.Process;

            memoryWatchers.ActorArrayLength.Update(process);
            int ActorCount = memoryWatchers.ActorArrayLength.Current;
            int baseAddress = memoryWatchers.GetBaseAddress();
            bool actorFound = false;

            if (!(TargetActorID is null))
            {

                for (int i = 0; i < ActorCount; i++)
                {
                    MemoryWatcher<short> characterIndex = new MemoryWatcher<short>(new DeepPointer(new IntPtr(baseAddress + 0x1FC44E4), new int[] { 0x00 + 0x880 * i }));
                    characterIndex.Update(process);

                    short ActorID = characterIndex.Current;

                    if (ActorID == TargetActorID)
                    {
                        actorFound = true;

                        MemoryWatcher<float> characterPos_x = new MemoryWatcher<float>(new DeepPointer(new IntPtr(baseAddress + 0x1FC44E4), new int[] { 0x0C + 0x880 * i }));
                        MemoryWatcher<float> characterPos_y = new MemoryWatcher<float>(new DeepPointer(new IntPtr(baseAddress + 0x1FC44E4), new int[] { 0x10 + 0x880 * i }));
                        MemoryWatcher<float> characterPos_z = new MemoryWatcher<float>(new DeepPointer(new IntPtr(baseAddress + 0x1FC44E4), new int[] { 0x14 + 0x880 * i }));
                        MemoryWatcher<float> characterPos_floor = new MemoryWatcher<float>(new DeepPointer(new IntPtr(baseAddress + 0x1FC44E4), new int[] { 0x16C + 0x880 * i }));
                        MemoryWatcher<float> characterPos_rot = new MemoryWatcher<float>(new DeepPointer(new IntPtr(baseAddress + 0x1FC44E4), new int[] { 0x168 + 0x880 * i }));
                        MemoryWatcher<short> characterPos_var1 = new MemoryWatcher<short>(new DeepPointer(new IntPtr(baseAddress + 0x1FC44E4), new int[] { 0x824 + 0x880 * i }));

                        if (!(Target_x is null))
                        {
                            WriteValue<float>(characterPos_x, Target_x);
                        }
                        if (!(Target_y is null))
                        {
                            WriteValue<float>(characterPos_floor, Target_y);
                            WriteValue<float>(characterPos_y, Target_y);
                        }
                        if (!(Target_z is null))
                        {
                            WriteValue<float>(characterPos_z, Target_z);
                        }
                        if (!(Target_rot is null))
                        {
                            WriteValue<float>(characterPos_rot, Target_rot);
                        }
                        if (!(Target_var1 is null))
                        {
                            WriteValue<short>(characterPos_var1, Target_var1);
                        }
                    }
                }
            }
            return actorFound;
        }

        // Formation Functions

        public enum formations
        {
            Klikk2,
            PreKimahri,
            PostKimahri,
            BoardingSSLiki,
            PostEchuilles,
            MachinaFights,
            PreOblitzerator,
            PostOblitzerator,
            PreSahagins,
            AuronJoinsTheParty,
            PreGui2,
            PostGui,
            MeetRikku,
            PostCrawler,
            PreSeymour,
            BikanelStart,
            PostZu,
            BikanelRikku,
            ViaPurificoStart,
            HighbridgeStart,
            PreNatus,
            PostBiranYenke
        }

        private void UpdateFormation(byte[] initialFormation = null)
        {
            byte[] formation = process.ReadBytes(memoryWatchers.Formation.Address, 10);
            byte initialPosition1 = 0xFF;
            byte initialPosition2 = 0xFF;
            byte initialPosition3 = 0xFF;

            if (!(initialFormation is null))
            {
                initialPosition1 = initialFormation[0];
                initialPosition2 = initialFormation[1];
                initialPosition3 = initialFormation[2];
            }

            if (FormationSwitch.HasValue)
            {
                switch (FormationSwitch)
                {
                    case formations.Klikk2:
                        formation = new byte[] { 0x00, 0x06, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
                        break;
                    case formations.PreKimahri:
                        formation = new byte[] { 0x00, 0xFF, 0xFF, 0x01, 0x04, 0x05, 0xFF, 0xFF, 0xFF, 0xFF };
                        break;
                    case formations.PostKimahri:
                        formation = new byte[] { 0x00, 0x01, 0x04, 0xFF, 0xFF, 0x05, 0xFF, 0xFF, 0xFF, 0xFF };
                        break;
                    case formations.BoardingSSLiki:
                        formation = AddCharacter(formation, 0x03);
                        break;
                    case formations.PostEchuilles:
                        formation = new byte[] { 0x05, 0x04, 0x00, 0x01, 0x03, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
                        WriteValue<byte>(memoryWatchers.EnableYuna, 17);
                        WriteValue<byte>(memoryWatchers.EnableKimahri, 17);
                        WriteValue<byte>(memoryWatchers.EnableLulu, 17);
                        break;
                    case formations.MachinaFights:
                        formation = new byte[] { 0x05, 0x00, 0x03, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
                        WriteValue<byte>(memoryWatchers.EnableYuna, 16);
                        WriteValue<byte>(memoryWatchers.EnableWakka, 16);
                        break;
                    case formations.PreOblitzerator:
                        formation = new byte[] { 0x00, 0x05, 0x03, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
                        break;
                    case formations.PostOblitzerator:
                        formation = new byte[] { 0x05, 0x00, 0x03, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
                        break;
                    case formations.PreSahagins:
                        WriteValue<byte>(memoryWatchers.EnableKimahri, 16);
                        WriteValue<byte>(memoryWatchers.EnableLulu, 16);
                        WriteValue<byte>(memoryWatchers.EnableWakka, 17);
                        formation = new byte[] { 0x04, 0x00, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
                        break;
                    case formations.AuronJoinsTheParty:
                        WriteValue<byte>(memoryWatchers.EnableTidus, 17);
                        WriteValue<byte>(memoryWatchers.EnableYuna, 17);
                        WriteValue<byte>(memoryWatchers.EnableAuron, 17);
                        WriteValue<byte>(memoryWatchers.EnableKimahri, 17);
                        WriteValue<byte>(memoryWatchers.EnableWakka, 17);
                        WriteValue<byte>(memoryWatchers.EnableLulu, 17);
                        formation = new byte[] { 0x00, 0x04, 0x01, 0x02, 0xFF, 0xFF, 0x05, 0x03, 0xFF, 0xFF };
                        break;
                    case formations.PreGui2:
                        formation = SwapPositionWithFirstEmptyReservePosition(formation, 0);
                        formation = SwapPositionWithFirstEmptyReservePosition(formation, 1);
                        formation = SwapPositionWithFirstEmptyReservePosition(formation, 2);
                        formation = RemoveCharacter(formation, 0);
                        formation = RemoveCharacter(formation, 1);
                        formation = RemoveCharacter(formation, 4);
                        formation = RemoveCharacter(formation, 3);
                        formation = RemoveCharacter(formation, 5);
                        formation = RemoveCharacter(formation, 2);
                        formation = AddCharacter(formation, 7);
                        formation = AddCharacter(formation, 1);
                        formation = AddCharacter(formation, 2);
                        formation = SwapCharacterWithPosition(formation, 1, 0);
                        formation = SwapCharacterWithPosition(formation, 7, 1);
                        formation = SwapCharacterWithPosition(formation, 2, 2);
                        break;
                    case formations.PostGui:
                        WriteValue<byte>(memoryWatchers.EnableTidus, 17);
                        WriteValue<byte>(memoryWatchers.EnableKimahri, 17);
                        WriteValue<byte>(memoryWatchers.EnableWakka, 17);
                        WriteValue<byte>(memoryWatchers.EnableLulu, 17);
                        WriteValue<byte>(memoryWatchers.EnableSeymour, 16);
                        byte[] newformation = new byte[] { 0x01, 0xFF, 0x02, 0x00, 0x03, 0x04, 0x05, 0xFF, 0xFF, 0xFF };
                        newformation = SwapCharacterWithPosition(newformation, initialPosition1, 0);
                        newformation = SwapCharacterWithPosition(newformation, initialPosition2, 1);
                        newformation = SwapCharacterWithPosition(newformation, initialPosition3, 2);
                        formation = newformation;
                        break;
                    case formations.MeetRikku:
                        WriteValue<byte>(memoryWatchers.EnableRikku, 17);
                        formation = AddCharacter(formation, 0x06);
                        formation = SwapCharacterWithPosition(formation, 0x06, 3);
                        break;
                    case formations.PostCrawler:
                        formation = RemoveCharacter(formation, 0x01);
                        WriteValue<byte>(memoryWatchers.EnableYuna, 0);
                        formation = FillMainPartySlotIfEmpty(formation, 0x00);
                        break;
                    case formations.PreSeymour:
                        WriteValue<byte>(memoryWatchers.EnableYuna, 17);
                        formation = AddCharacter(formation, 0x01);
                        formation = SwapCharacterWithPosition(formation, 0x00, 0);
                        formation = SwapCharacterWithPosition(formation, 0x01, 1);
                        formation = SwapCharacterWithPosition(formation, 0x03, 2);
                        break;
                    case formations.BikanelStart:
                        formation = RemoveAll(formation);
                        WriteValue<byte>(memoryWatchers.EnableTidus, 17);
                        formation = AddCharacter(formation, 0x00);
                        formation = SwapCharacterWithPosition(formation, 0x00, 0);
                        break;
                    case formations.PostZu:
                        WriteValue<byte>(memoryWatchers.EnableWakka, 17);
                        formation = AddCharacter(formation, 0x04);
                        break;
                    case formations.BikanelRikku:
                        WriteValue<byte>(memoryWatchers.EnableRikku, 17);
                        formation = AddCharacter(formation, 0x06);
                        break;
                    case formations.ViaPurificoStart:
                        formation = RemoveAll(formation);
                        WriteValue<byte>(memoryWatchers.EnableYuna, 17);
                        formation = AddCharacter(formation, 0x01);
                        formation = SwapCharacterWithPosition(formation, 0x01, 0);
                        break;
                    case formations.HighbridgeStart:
                        WriteValue<byte>(memoryWatchers.EnableYuna, 17);
                        WriteValue<byte>(memoryWatchers.EnableAuron, 17);
                        WriteValue<byte>(memoryWatchers.EnableLulu, 17);
                        formation = AddCharacter(formation, 0x01);
                        formation = AddCharacter(formation, 0x02);
                        formation = AddCharacter(formation, 0x05);
                        formation = SwapCharacterWithPosition(formation, 0x00, 0);
                        formation = SwapCharacterWithPosition(formation, 0x01, 1);
                        formation = SwapCharacterWithPosition(formation, 0x04, 2);
                        break;
                    case formations.PreNatus:
                        WriteValue<byte>(memoryWatchers.EnableKimahri, 17);
                        formation = AddCharacter(formation, 0x03);
                        formation = SwapCharacterWithPosition(formation, 0x00, 0);
                        formation = SwapCharacterWithPosition(formation, 0x01, 2);
                        formation = SwapCharacterWithPosition(formation, 0x03, 1);
                        break;
                    case formations.PostBiranYenke:
                        WriteValue<byte>(memoryWatchers.EnableTidus, 17);
                        WriteValue<byte>(memoryWatchers.EnableYuna, 17);
                        WriteValue<byte>(memoryWatchers.EnableAuron, 17);
                        WriteValue<byte>(memoryWatchers.EnableWakka, 17);
                        WriteValue<byte>(memoryWatchers.EnableLulu, 17);
                        WriteValue<byte>(memoryWatchers.EnableRikku, 17);
                        formation = AddCharacter(formation, 0x00);
                        formation = AddCharacter(formation, 0x01);
                        formation = AddCharacter(formation, 0x02);
                        formation = AddCharacter(formation, 0x04);
                        formation = AddCharacter(formation, 0x05);
                        formation = AddCharacter(formation, 0x06);
                        formation = SwapCharacterWithPosition(formation, initialPosition1, 0);
                        formation = SwapCharacterWithPosition(formation, initialPosition2, 1);
                        formation = SwapCharacterWithPosition(formation, initialPosition3, 2);
                        break;
                }
                WriteBytes(memoryWatchers.Formation, formation);
            }
        }

        public int GetFirstEmptyReservePosition(byte[] formation)
        {
            int formationSize = formation.Length;

            for (int i = 3; i < formationSize; i++)
            {
                if (formation[i] == 0xFF)
                {
                    return i;
                }
            }
            return 0;
        }

        public byte[] RemoveCharacter(byte[] formation, byte Character)
        {
            int formationSize = formation.Length;

            for (int i = 0; i < formationSize; i++)
            {
                if (formation[i] == Character)
                {
                    formation[i] = 0xFF;
                }
            }
            return formation;
        }

        public byte[] RemoveAll(byte[] formation)
        {
            int formationSize = formation.Length;

            for (int i = 0; i < formationSize; i++)
            {
                formation[i] = 0xFF;
            }

            WriteValue<byte>(memoryWatchers.EnableTidus, 0);
            WriteValue<byte>(memoryWatchers.EnableYuna, 0);
            WriteValue<byte>(memoryWatchers.EnableAuron, 0);
            WriteValue<byte>(memoryWatchers.EnableKimahri, 0);
            WriteValue<byte>(memoryWatchers.EnableWakka, 0);
            WriteValue<byte>(memoryWatchers.EnableLulu, 0);
            WriteValue<byte>(memoryWatchers.EnableRikku, 0);

            return formation;
        }

        public byte[] AddCharacter(byte[] formation, byte Character)
        {
            if (Array.IndexOf(formation,0x01) == -1)
            {
                int Position = GetFirstEmptyReservePosition(formation);

                formation[Position] = Character;
            }
            return formation;
        }

        public byte[] SwapCharacterWithPosition(byte[] formation, byte Character, int newPosition)
        {
            int oldposition = Array.IndexOf(formation, Character);

            byte temp = formation[oldposition];
            formation[oldposition] = formation[newPosition];
            formation[newPosition] = temp;

            return formation;
        }

        public byte[] SwapPositionWithFirstEmptyReservePosition(byte[] formation, int Position)
        {
            int newPosition = GetFirstEmptyReservePosition(formation);

            formation[newPosition] = formation[Position];
            formation[Position] = 0xFF;

            return formation;
        }

        public byte[] FillMainPartySlotIfEmpty(byte[] formation, byte Character)
        {
            for (int i = 0; i < 3; i++)
            {
                if (formation[i] == 0xFF)
                {
                    formation = SwapCharacterWithPosition(formation, Character, i);
                    return formation;
                }
            }
            return formation;
        }

    }
}
