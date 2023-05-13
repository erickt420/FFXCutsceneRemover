﻿using FFX_Cutscene_Remover.ComponentUtil;
using FFXCutsceneRemover.Resources;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using FFXCutsceneRemover.Logging;

namespace FFXCutsceneRemover
{
    /* This class contains all the memory watchers used in the program. All watchers should be added here. */
    sealed public class MemoryWatchers
    {
        private static readonly string MODULE = "FFX.exe";

        private static readonly object padlock = new object();

        private static MemoryWatchers instance = null;

        private int processBaseAddress;
        
        public Process Process;
        public MemoryWatcherList Watchers = new MemoryWatcherList();

        public MemoryWatcher<byte> Language;

        public MemoryWatcher<short> RoomNumber;
        public MemoryWatcher<short> Storyline;
        public MemoryWatcher<byte> ForceLoad;
        public MemoryWatcher<byte> SpawnPoint;
        public MemoryWatcher<short> BattleState;
        public MemoryWatcher<short> BattleState2;
        public MemoryWatcher<short> Input;
        public MemoryWatcher<byte> Menu;
        public MemoryWatcher<byte> MenuLock;
        public MemoryWatcher<short> Intro;
        public MemoryWatcher<sbyte> State;
        public MemoryWatcher<float> XCoordinate;
        public MemoryWatcher<float> YCoordinate;
        public MemoryWatcher<byte> Camera;
        public MemoryWatcher<float> Camera_x;
        public MemoryWatcher<float> Camera_y;
        public MemoryWatcher<float> Camera_z;
        public MemoryWatcher<float> CameraRotation;
        public MemoryWatcher<byte> EncounterStatus;
        public MemoryWatcher<byte> MovementLock;
        public MemoryWatcher<byte> ActiveMusicId;
        public MemoryWatcher<byte> MusicId;
        public MemoryWatcher<byte> RoomNumberAlt;
        public MemoryWatcher<short> CutsceneAlt;
        public MemoryWatcher<short> AirshipDestinations;
        public MemoryWatcher<short> AuronOverdrives;
        public MemoryWatcher<int> Gil;
        public MemoryWatcher<int> TargetFramerate;
        public MemoryWatcher<int> Dialogue1;
        public MemoryWatcher<byte> DialogueOption;
        public MemoryWatcher<byte> DialogueBoxOpen;
        public MemoryWatcher<byte> DialogueOption_Gui;
        public MemoryWatcher<byte> DialogueBoxOpen_Gui;
        public MemoryWatcher<byte> PlayerTurn;
        public MemoryWatcher<int> FrameCounterFromLoad;

        // Event File
        public MemoryWatcher<int> EventFileStart;

        // Deep Pointers
        public MemoryWatcher<int> HpEnemyA;
        public MemoryWatcher<byte> GuadoCount;
        public MemoryWatcher<short> NPCLastInteraction;
        public MemoryWatcher<byte> TidusActionCount;
        public MemoryWatcher<float> TidusXCoordinate;
        public MemoryWatcher<float> TidusYCoordinate;
        public MemoryWatcher<float> TidusZCoordinate;
        public MemoryWatcher<float> TidusRotation;
        public MemoryWatcher<byte> DialogueFile;
        public MemoryWatcher<byte> CutsceneTiming;
        public MemoryWatcher<int> AuronTransition;
        public MemoryWatcher<int> AmmesTransition;
        public MemoryWatcher<int> TankerTransition;
        public MemoryWatcher<int> InsideSinTransition;
        public MemoryWatcher<int> DiveTransition;
        public MemoryWatcher<int> GeosTransition;
        public MemoryWatcher<int> KlikkTransition;
        public MemoryWatcher<int> AlBhedBoatTransition;
        public MemoryWatcher<int> UnderwaterRuinsTransition;
        public MemoryWatcher<int> UnderwaterRuinsTransition2;
        public MemoryWatcher<int> BeachTransition;
        public MemoryWatcher<int> LagoonTransition1;
        public MemoryWatcher<int> LagoonTransition2;
        public MemoryWatcher<int> ValeforTransition;
        public MemoryWatcher<int> KimahriTransition;
        public MemoryWatcher<int> YunaBoatTransition;
        public MemoryWatcher<int> SinFinTransition;
        public MemoryWatcher<int> EchuillesTransition;
        public MemoryWatcher<int> GeneauxTransition;
        public MemoryWatcher<int> KilikaTrialsTransition;
        public MemoryWatcher<int> KilikaAntechamberTransition;
        public MemoryWatcher<int> IfritTransition;
        public MemoryWatcher<int> IfritTransition2;
        public MemoryWatcher<int> JechtShotTransition;
        public MemoryWatcher<int> OblitzeratorTransition;
        public MemoryWatcher<int> BlitzballTransition;
        public MemoryWatcher<int> SahaginTransition;
        public MemoryWatcher<int> GarudaTransition;
        public MemoryWatcher<int> RinTransition;
        public MemoryWatcher<int> ChocoboEaterTransition;
        public MemoryWatcher<int> GuiTransition;
        public MemoryWatcher<int> Gui2Transition;
        public MemoryWatcher<int> DjoseTransition;
        public MemoryWatcher<int> IxionTransition;
        public MemoryWatcher<int> ExtractorTransition;
        public MemoryWatcher<int> SeymoursHouseTransition1;
        public MemoryWatcher<int> SeymoursHouseTransition2;
        public MemoryWatcher<int> FarplaneTransition1;
        public MemoryWatcher<int> FarplaneTransition2;
        public MemoryWatcher<int> TromellTransition;
        public MemoryWatcher<int> CrawlerTransition;
        public MemoryWatcher<int> SeymourTransition;
        public MemoryWatcher<int> SeymourTransition2;
        public MemoryWatcher<int> WendigoTransition;
        public MemoryWatcher<int> SpherimorphTransition;
        public MemoryWatcher<int> UnderLakeTransition;
        public MemoryWatcher<int> BikanelTransition;
        public MemoryWatcher<int> HomeTransition;
        public MemoryWatcher<int> EvraeTransition;
        public MemoryWatcher<int> EvraeAirshipTransition;
        public MemoryWatcher<int> GuardsTransition;
        public MemoryWatcher<int> BahamutTransition;
        public MemoryWatcher<int> IsaaruTransition;
        public MemoryWatcher<int> AltanaTransition;
        public MemoryWatcher<int> NatusTransition;
        public MemoryWatcher<int> DefenderXTransition;
        public MemoryWatcher<int> RonsoTransition;
        public MemoryWatcher<int> FluxTransition;
        public MemoryWatcher<int> SanctuaryTransition;
        public MemoryWatcher<int> SpectralKeeperTransition;
        public MemoryWatcher<int> SpectralKeeperTransition2;
        public MemoryWatcher<int> YunalescaTransition;
        public MemoryWatcher<int> FinsTransition;
        public MemoryWatcher<int> FinsAirshipTransition;
        public MemoryWatcher<int> SinCoreTransition;
        public MemoryWatcher<int> OverdriveSinTransition;
        public MemoryWatcher<int> OmnisTransition;
        public MemoryWatcher<int> BFATransition;
        public MemoryWatcher<int> AeonTransition;
        public MemoryWatcher<int> YuYevonTransition;
        public MemoryWatcher<int> YojimboFaythTransition;
        public MemoryWatcher<int> CutsceneProgress_Max;
        public MemoryWatcher<int> CutsceneProgress_uVar1;
        public MemoryWatcher<int> CutsceneProgress_uVar2;
        public MemoryWatcher<int> CutsceneProgress_uVar3;

        // Encounters
        public MemoryWatcher<byte> EncounterMapID;
        public MemoryWatcher<byte> EncounterFormationID1;
        public MemoryWatcher<byte> EncounterFormationID2;
        public MemoryWatcher<byte> ScriptedBattleFlag1;
        public MemoryWatcher<byte> ScriptedBattleFlag2;
        public MemoryWatcher<int> ScriptedBattleVar1;
        public MemoryWatcher<int> ScriptedBattleVar3;
        public MemoryWatcher<int> ScriptedBattleVar4;
        public MemoryWatcher<byte> EncounterTrigger;

        // Party Configuration
        public MemoryWatcher<byte> Formation;
        public MemoryWatcher<byte> RikkuName;
        public MemoryWatcher<byte> EnableTidus;
        public MemoryWatcher<byte> EnableYuna;
        public MemoryWatcher<byte> EnableAuron;
        public MemoryWatcher<byte> EnableKimahri;
        public MemoryWatcher<byte> EnableWakka;
        public MemoryWatcher<byte> EnableLulu;
        public MemoryWatcher<byte> EnableRikku;
        public MemoryWatcher<byte> EnableSeymour;
        public MemoryWatcher<byte> EnableValefor;
        public MemoryWatcher<byte> EnableIfrit;
        public MemoryWatcher<byte> EnableIxion;
        public MemoryWatcher<byte> EnableShiva;
        public MemoryWatcher<byte> EnableBahamut;
        public MemoryWatcher<byte> EnableAnima;
        public MemoryWatcher<byte> EnableYojimbo;
        public MemoryWatcher<byte> EnableMagus;

        // Encounter Rate
        public MemoryWatcher<byte> EncountersActiveFlag;
        public MemoryWatcher<float> TotalDistance;
        public MemoryWatcher<float> CycleDistance;

        // HP/MP
        public MemoryWatcher<int> TidusHP;
        public MemoryWatcher<short> TidusMP;
        public MemoryWatcher<int> TidusMaxHP;
        public MemoryWatcher<short> TidusMaxMP;
        public MemoryWatcher<int> YunaHP;
        public MemoryWatcher<short> YunaMP;
        public MemoryWatcher<int> YunaMaxHP;
        public MemoryWatcher<short> YunaMaxMP;
        public MemoryWatcher<int> AuronHP;
        public MemoryWatcher<short> AuronMP;
        public MemoryWatcher<int> AuronMaxHP;
        public MemoryWatcher<short> AuronMaxMP;
        public MemoryWatcher<int> WakkaHP;
        public MemoryWatcher<short> WakkaMP;
        public MemoryWatcher<int> WakkaMaxHP;
        public MemoryWatcher<short> WakkaMaxMP;
        public MemoryWatcher<int> KimahriHP;
        public MemoryWatcher<short> KimahriMP;
        public MemoryWatcher<int> KimahriMaxHP;
        public MemoryWatcher<short> KimahriMaxMP;
        public MemoryWatcher<int> LuluHP;
        public MemoryWatcher<short> LuluMP;
        public MemoryWatcher<int> LuluMaxHP;
        public MemoryWatcher<short> LuluMaxMP;
        public MemoryWatcher<int> RikkuHP;
        public MemoryWatcher<short> RikkuMP;
        public MemoryWatcher<int> RikkuMaxHP;
        public MemoryWatcher<short> RikkuMaxMP;
        public MemoryWatcher<int> ValeforHP;
        public MemoryWatcher<short> ValeforMP;
        public MemoryWatcher<int> ValeforMaxHP;
        public MemoryWatcher<short> ValeforMaxMP;
        
        // HP/MP Aeons


        // Special Flags
        public MemoryWatcher<short> FangirlsOrKidsSkip;
        public MemoryWatcher<byte> BaajFlag1;
        public MemoryWatcher<byte> BesaidFlag1;
        public MemoryWatcher<byte> SSWinnoFlag1;
        public MemoryWatcher<byte> KilikaMapFlag;
        public MemoryWatcher<byte> SSWinnoFlag2;
        public MemoryWatcher<byte> LucaFlag;
        public MemoryWatcher<byte> LucaFlag2;
        public MemoryWatcher<byte> BlitzballFlag;
        public MemoryWatcher<byte> MiihenFlag1;
        public MemoryWatcher<byte> MiihenFlag2;
        public MemoryWatcher<byte> MiihenFlag3;
        public MemoryWatcher<byte> MiihenFlag4;
        public MemoryWatcher<byte> MRRFlag1;
        public MemoryWatcher<byte> MRRFlag2;
        public MemoryWatcher<byte> MoonflowFlag;
        public MemoryWatcher<byte> MoonflowFlag2;
        public MemoryWatcher<byte> RikkuOutfit;
        public MemoryWatcher<byte> TidusWeaponDamageBoost;
        public MemoryWatcher<byte> GuadosalamShopFlag;
        public MemoryWatcher<byte> ThunderPlainsFlag;
        public MemoryWatcher<byte> MacalaniaFlag;
        public MemoryWatcher<byte> BikanelFlag;
        public MemoryWatcher<byte> Sandragoras;
        public MemoryWatcher<byte> ViaPurificoPlatform;
        public MemoryWatcher<byte> NatusFlag;
        public MemoryWatcher<ushort> CalmLandsFlag;
        public MemoryWatcher<byte> WantzFlag;
        public MemoryWatcher<short> GagazetCaveFlag;
        public MemoryWatcher<byte> OmegaRuinsFlag;
        public MemoryWatcher<byte> WantzMacalaniaFlag;

        // Blitzball Abilities
        public MemoryWatcher<byte> AurochsTeamBytes;
        public MemoryWatcher<byte> BlitzballBytes;
        public MemoryWatcher<byte> AurochsPlayer1;

        // Battle Rewards
        public MemoryWatcher<int> GilBattleRewards;
        public MemoryWatcher<byte> BattleRewardItemCount;
        public MemoryWatcher<short> BattleRewardItem1;
        public MemoryWatcher<short> BattleRewardItem2;
        public MemoryWatcher<short> BattleRewardItem3;
        public MemoryWatcher<short> BattleRewardItem4;
        public MemoryWatcher<short> BattleRewardItem5;
        public MemoryWatcher<short> BattleRewardItem6;
        public MemoryWatcher<short> BattleRewardItem7;
        public MemoryWatcher<short> BattleRewardItem8;
        public MemoryWatcher<byte> BattleRewardItemQty1;
        public MemoryWatcher<byte> BattleRewardItemQty2;
        public MemoryWatcher<byte> BattleRewardItemQty3;
        public MemoryWatcher<byte> BattleRewardItemQty4;
        public MemoryWatcher<byte> BattleRewardItemQty5;
        public MemoryWatcher<byte> BattleRewardItemQty6;
        public MemoryWatcher<byte> BattleRewardItemQty7;
        public MemoryWatcher<byte> BattleRewardItemQty8;
        public MemoryWatcher<byte> BattleRewardEquipCount;
        public MemoryWatcher<byte> BattleRewardEquip1;
        public MemoryWatcher<byte> BattleRewardEquip2;
        public MemoryWatcher<byte> BattleRewardEquip3;
        public MemoryWatcher<byte> BattleRewardEquip4;
        public MemoryWatcher<byte> BattleRewardEquip5;
        public MemoryWatcher<byte> BattleRewardEquip6;
        public MemoryWatcher<byte> BattleRewardEquip7;
        public MemoryWatcher<byte> BattleRewardEquip8;

        // Items
        public MemoryWatcher<byte> ItemsStart;
        public MemoryWatcher<byte> ItemsQtyStart;

        // AP
        public MemoryWatcher<byte> CharacterAPFlags;

        // Menu Values
        public MemoryWatcher<int> MenuTriggerValue;

        public MemoryWatcher<int> MenuValue1;
        public MemoryWatcher<int> MenuValue2;

        public MemoryWatcher<int> MenuValue3;
        public MemoryWatcher<int> MenuValue4;
        public MemoryWatcher<byte> MenuValue5;
        public MemoryWatcher<int> MenuValue6;
        public MemoryWatcher<byte> MenuValue7;

        public MemoryWatcher<int> SpeedBoostAmount;
        public MemoryWatcher<int> SpeedBoostVar1;

        public MemoryWatcher<int> ActorArrayLength;

        public MemoryWatcher<byte> RNGArrayOpBytes;

        MemoryWatchers() { }

        public static MemoryWatchers Instance
        {
            get
            {
                lock(padlock)
                {
                    if(instance == null)
                    {
                        instance = new MemoryWatchers();
                    }
                    return instance;
                }
            }
        }

        public void Initialize(Process process)
        {
            Process = process;
            processBaseAddress = process.Modules[0].BaseAddress.ToInt32();
            DiagnosticLog.Information("Process base address: " + processBaseAddress);

            Language = GetMemoryWatcher<byte>(MemoryLocations.Language);

            RoomNumber = GetMemoryWatcher<short>(MemoryLocations.RoomNumber);
            Storyline = GetMemoryWatcher<short>(MemoryLocations.Storyline);
            ForceLoad = GetMemoryWatcher<byte>(MemoryLocations.ForceLoad);
            SpawnPoint = GetMemoryWatcher<byte>(MemoryLocations.SpawnPoint);
            BattleState = GetMemoryWatcher<short>(MemoryLocations.BattleState);
            BattleState2 = GetMemoryWatcher<short>(MemoryLocations.BattleState2);
            Input = GetMemoryWatcher<short>(MemoryLocations.Input);
            Menu = GetMemoryWatcher<byte>(MemoryLocations.Menu);
            MenuLock = GetMemoryWatcher<byte>(MemoryLocations.MenuLock);
            Intro = GetMemoryWatcher<short>(MemoryLocations.Intro);
            State = GetMemoryWatcher<sbyte>(MemoryLocations.State);
            XCoordinate = GetMemoryWatcher<float>(MemoryLocations.XCoordinate);
            YCoordinate = GetMemoryWatcher<float>(MemoryLocations.YCoordinate);
            Camera = GetMemoryWatcher<byte>(MemoryLocations.Camera);
            Camera_x = GetMemoryWatcher<float>(MemoryLocations.Camera_x);
            Camera_y = GetMemoryWatcher<float>(MemoryLocations.Camera_y);
            Camera_z = GetMemoryWatcher<float>(MemoryLocations.Camera_z);
            CameraRotation = GetMemoryWatcher<float>(MemoryLocations.CameraRotation);
            EncounterStatus = GetMemoryWatcher<byte>(MemoryLocations.EncounterStatus);
            MovementLock = GetMemoryWatcher<byte>(MemoryLocations.MovementLock);
            ActiveMusicId = GetMemoryWatcher<byte>(MemoryLocations.ActiveMusicId);
            MusicId = GetMemoryWatcher<byte>(MemoryLocations.MusicId);
            RoomNumberAlt = GetMemoryWatcher<byte>(MemoryLocations.RoomNumberAlt);
            CutsceneAlt = GetMemoryWatcher<short>(MemoryLocations.CutsceneAlt);
            AirshipDestinations = GetMemoryWatcher<short>(MemoryLocations.AirshipDestinations);
            AuronOverdrives = GetMemoryWatcher<short>(MemoryLocations.AuronOverdrives);
            Gil = GetMemoryWatcher<int>(MemoryLocations.Gil);
            TargetFramerate = GetMemoryWatcher<int>(MemoryLocations.TargetFramerate);
            Dialogue1 = GetMemoryWatcher<int>(MemoryLocations.Dialogue1);
            DialogueOption = GetMemoryWatcher<byte>(MemoryLocations.DialogueOption);
            DialogueBoxOpen = GetMemoryWatcher<byte>(MemoryLocations.DialogueBoxOpen);
            DialogueOption_Gui = GetMemoryWatcher<byte>(MemoryLocations.DialogueOption_Gui);
            DialogueBoxOpen_Gui = GetMemoryWatcher<byte>(MemoryLocations.DialogueBoxOpen_Gui);
            PlayerTurn = GetMemoryWatcher<byte>(MemoryLocations.PlayerTurn);
            FrameCounterFromLoad = GetMemoryWatcher<int>(MemoryLocations.FrameCounterFromLoad);

            // Event File
            EventFileStart = GetMemoryWatcher<int>(MemoryLocations.EventFileStart);

            // Deep Pointers
            HpEnemyA = GetMemoryWatcher<int>(MemoryLocations.HpEnemyA);
            GuadoCount = GetMemoryWatcher<byte>(MemoryLocations.GuadoCount);
            NPCLastInteraction = GetMemoryWatcher<short>(MemoryLocations.NPCLastInteraction);
            TidusActionCount = GetMemoryWatcher<byte>(MemoryLocations.TidusActionCount);
            TidusXCoordinate = GetMemoryWatcher<float>(MemoryLocations.TidusXCoordinate);
            TidusYCoordinate = GetMemoryWatcher<float>(MemoryLocations.TidusYCoordinate);
            TidusZCoordinate = GetMemoryWatcher<float>(MemoryLocations.TidusZCoordinate);
            TidusRotation = GetMemoryWatcher<float>(MemoryLocations.TidusRotation);
            DialogueFile = GetMemoryWatcher<byte>(MemoryLocations.DialogueFile);
            CutsceneTiming = GetMemoryWatcher<byte>(MemoryLocations.CutsceneTiming);
            AuronTransition = GetMemoryWatcher<int>(MemoryLocations.AuronTransition);
            AmmesTransition = GetMemoryWatcher<int>(MemoryLocations.AmmesTransition);
            TankerTransition = GetMemoryWatcher<int>(MemoryLocations.TankerTransition);
            InsideSinTransition = GetMemoryWatcher<int>(MemoryLocations.InsideSinTransition);
            DiveTransition = GetMemoryWatcher<int>(MemoryLocations.DiveTransition);
            GeosTransition = GetMemoryWatcher<int>(MemoryLocations.GeosTransition);
            KlikkTransition = GetMemoryWatcher<int>(MemoryLocations.KlikkTransition);
            AlBhedBoatTransition = GetMemoryWatcher<int>(MemoryLocations.AlBhedBoatTransition);
            UnderwaterRuinsTransition = GetMemoryWatcher<int>(MemoryLocations.UnderwaterRuinsTransition);
            UnderwaterRuinsTransition2 = GetMemoryWatcher<int>(MemoryLocations.UnderwaterRuinsTransition2);
            BeachTransition = GetMemoryWatcher<int>(MemoryLocations.BeachTransition);
            LagoonTransition1 = GetMemoryWatcher<int>(MemoryLocations.LagoonTransition1);
            LagoonTransition2 = GetMemoryWatcher<int>(MemoryLocations.LagoonTransition2);
            ValeforTransition = GetMemoryWatcher<int>(MemoryLocations.ValeforTransition);
            KimahriTransition = GetMemoryWatcher<int>(MemoryLocations.KimahriTransition);
            YunaBoatTransition = GetMemoryWatcher<int>(MemoryLocations.YunaBoatTransition);
            SinFinTransition = GetMemoryWatcher<int>(MemoryLocations.SinFinTransition);
            EchuillesTransition = GetMemoryWatcher<int>(MemoryLocations.EchuillesTransition);
            GeneauxTransition = GetMemoryWatcher<int>(MemoryLocations.GeneauxTransition);
            KilikaTrialsTransition = GetMemoryWatcher<int>(MemoryLocations.KilikaTrialsTransition);
            KilikaAntechamberTransition = GetMemoryWatcher<int>(MemoryLocations.KilikaAntechamberTransition);
            IfritTransition = GetMemoryWatcher<int>(MemoryLocations.IfritTransition);
            IfritTransition2 = GetMemoryWatcher<int>(MemoryLocations.IfritTransition2);
            JechtShotTransition = GetMemoryWatcher<int>(MemoryLocations.JechtShotTransition);
            OblitzeratorTransition = GetMemoryWatcher<int>(MemoryLocations.OblitzeratorTransition);
            BlitzballTransition = GetMemoryWatcher<int>(MemoryLocations.BlitzballTransition);
            SahaginTransition = GetMemoryWatcher<int>(MemoryLocations.SahaginTransition);
            GarudaTransition = GetMemoryWatcher<int>(MemoryLocations.GarudaTransition);
            RinTransition = GetMemoryWatcher<int>(MemoryLocations.RinTransition);
            ChocoboEaterTransition = GetMemoryWatcher<int>(MemoryLocations.ChocoboEaterTransition);
            GuiTransition = GetMemoryWatcher<int>(MemoryLocations.GuiTransition);
            Gui2Transition = GetMemoryWatcher<int>(MemoryLocations.Gui2Transition);
            DjoseTransition = GetMemoryWatcher<int>(MemoryLocations.DjoseTransition);
            IxionTransition = GetMemoryWatcher<int>(MemoryLocations.IxionTransition);
            ExtractorTransition = GetMemoryWatcher<int>(MemoryLocations.ExtractorTransition);
            SeymoursHouseTransition1 = GetMemoryWatcher<int>(MemoryLocations.SeymoursHouseTransition1);
            SeymoursHouseTransition2 = GetMemoryWatcher<int>(MemoryLocations.SeymoursHouseTransition2);
            FarplaneTransition1 = GetMemoryWatcher<int>(MemoryLocations.FarplaneTransition1);
            FarplaneTransition2 = GetMemoryWatcher<int>(MemoryLocations.FarplaneTransition2);
            TromellTransition = GetMemoryWatcher<int>(MemoryLocations.TromellTransition);
            CrawlerTransition = GetMemoryWatcher<int>(MemoryLocations.CrawlerTransition);
            SeymourTransition = GetMemoryWatcher<int>(MemoryLocations.SeymourTransition);
            SeymourTransition2 = GetMemoryWatcher<int>(MemoryLocations.SeymourTransition2);
            WendigoTransition = GetMemoryWatcher<int>(MemoryLocations.WendigoTransition);
            SpherimorphTransition = GetMemoryWatcher<int>(MemoryLocations.SpherimorphTransition);
            UnderLakeTransition = GetMemoryWatcher<int>(MemoryLocations.UnderLakeTransition);
            BikanelTransition = GetMemoryWatcher<int>(MemoryLocations.BikanelTransition);
            HomeTransition = GetMemoryWatcher<int>(MemoryLocations.HomeTransition);
            EvraeTransition = GetMemoryWatcher<int>(MemoryLocations.EvraeTransition);
            EvraeAirshipTransition = GetMemoryWatcher<int>(MemoryLocations.EvraeAirshipTransition);
            GuardsTransition = GetMemoryWatcher<int>(MemoryLocations.GuardsTransition);
            BahamutTransition = GetMemoryWatcher<int>(MemoryLocations.BahamutTransition);
            IsaaruTransition = GetMemoryWatcher<int>(MemoryLocations.IsaaruTransition);
            AltanaTransition = GetMemoryWatcher<int>(MemoryLocations.AltanaTransition);
            NatusTransition = GetMemoryWatcher<int>(MemoryLocations.NatusTransition);
            DefenderXTransition = GetMemoryWatcher<int>(MemoryLocations.DefenderXTransition);
            RonsoTransition = GetMemoryWatcher<int>(MemoryLocations.RonsoTransition);
            FluxTransition = GetMemoryWatcher<int>(MemoryLocations.FluxTransition);
            SanctuaryTransition = GetMemoryWatcher<int>(MemoryLocations.SanctuaryTransition);
            SpectralKeeperTransition = GetMemoryWatcher<int>(MemoryLocations.SpectralKeeperTransition);
            SpectralKeeperTransition2 = GetMemoryWatcher<int>(MemoryLocations.SpectralKeeperTransition2);
            YunalescaTransition = GetMemoryWatcher<int>(MemoryLocations.YunalescaTransition);
            FinsTransition = GetMemoryWatcher<int>(MemoryLocations.FinsTransition);
            FinsAirshipTransition = GetMemoryWatcher<int>(MemoryLocations.FinsAirshipTransition);
            SinCoreTransition = GetMemoryWatcher<int>(MemoryLocations.SinCoreTransition);
            OverdriveSinTransition = GetMemoryWatcher<int>(MemoryLocations.OverdriveSinTransition);
            OmnisTransition = GetMemoryWatcher<int>(MemoryLocations.OmnisTransition);
            BFATransition = GetMemoryWatcher<int>(MemoryLocations.BFATransition);
            AeonTransition = GetMemoryWatcher<int>(MemoryLocations.AeonTransition);
            YuYevonTransition = GetMemoryWatcher<int>(MemoryLocations.YuYevonTransition);
            YojimboFaythTransition = GetMemoryWatcher<int>(MemoryLocations.YojimboFaythTransition);
            CutsceneProgress_Max = GetMemoryWatcher<int>(MemoryLocations.CutsceneProgress_Max);
            CutsceneProgress_uVar1 = GetMemoryWatcher<int>(MemoryLocations.CutsceneProgress_uVar1);
            CutsceneProgress_uVar2 = GetMemoryWatcher<int>(MemoryLocations.CutsceneProgress_uVar2);
            CutsceneProgress_uVar3 = GetMemoryWatcher<int>(MemoryLocations.CutsceneProgress_uVar3);


            //Encounters
            EncounterMapID = GetMemoryWatcher<byte>(MemoryLocations.EncounterMapID);
            EncounterFormationID1 = GetMemoryWatcher<byte>(MemoryLocations.EncounterFormationID1);
            EncounterFormationID2 = GetMemoryWatcher<byte>(MemoryLocations.EncounterFormationID2);
            ScriptedBattleFlag1 = GetMemoryWatcher<byte>(MemoryLocations.ScriptedBattleFlag1);
            ScriptedBattleFlag2 = GetMemoryWatcher<byte>(MemoryLocations.ScriptedBattleFlag2);
            ScriptedBattleVar1 = GetMemoryWatcher<int>(MemoryLocations.ScriptedBattleVar1);
            ScriptedBattleVar3 = GetMemoryWatcher<int>(MemoryLocations.ScriptedBattleVar3);
            ScriptedBattleVar4 = GetMemoryWatcher<int>(MemoryLocations.ScriptedBattleVar4);
            EncounterTrigger = GetMemoryWatcher<byte>(MemoryLocations.EncounterTrigger);

            // Party Configuration
            Formation = GetMemoryWatcher<byte>(MemoryLocations.Formation);
            RikkuName = GetMemoryWatcher<byte>(MemoryLocations.RikkuName);
            EnableTidus = GetMemoryWatcher<byte>(MemoryLocations.EnableTidus);
            EnableYuna = GetMemoryWatcher<byte>(MemoryLocations.EnableYuna);
            EnableAuron = GetMemoryWatcher<byte>(MemoryLocations.EnableAuron);
            EnableKimahri = GetMemoryWatcher<byte>(MemoryLocations.EnableKimahri);
            EnableWakka = GetMemoryWatcher<byte>(MemoryLocations.EnableWakka);
            EnableLulu = GetMemoryWatcher<byte>(MemoryLocations.EnableLulu);
            EnableRikku = GetMemoryWatcher<byte>(MemoryLocations.EnableRikku);
            EnableSeymour = GetMemoryWatcher<byte>(MemoryLocations.EnableSeymour);
            EnableValefor = GetMemoryWatcher<byte>(MemoryLocations.EnableValefor);
            EnableIfrit = GetMemoryWatcher<byte>(MemoryLocations.EnableIfrit);
            EnableIxion = GetMemoryWatcher<byte>(MemoryLocations.EnableIxion);
            EnableShiva = GetMemoryWatcher<byte>(MemoryLocations.EnableShiva);
            EnableBahamut = GetMemoryWatcher<byte>(MemoryLocations.EnableBahamut);
            EnableAnima = GetMemoryWatcher<byte>(MemoryLocations.EnableAnima);
            EnableYojimbo = GetMemoryWatcher<byte>(MemoryLocations.EnableYojimbo);
            EnableMagus = GetMemoryWatcher<byte>(MemoryLocations.EnableMagus);

            // Encounter Rate
            EncountersActiveFlag = GetMemoryWatcher<byte>(MemoryLocations.EncountersActiveFlag);
            TotalDistance = GetMemoryWatcher<float>(MemoryLocations.TotalDistance);
            CycleDistance = GetMemoryWatcher<float>(MemoryLocations.CycleDistance);

            // HP/MP
            TidusHP = GetMemoryWatcher<int>(MemoryLocations.TidusHP);
            TidusMP = GetMemoryWatcher<short>(MemoryLocations.TidusMP);
            TidusMaxHP = GetMemoryWatcher<int>(MemoryLocations.TidusMaxHP);
            TidusMaxMP = GetMemoryWatcher<short>(MemoryLocations.TidusMaxMP);
            YunaHP = GetMemoryWatcher<int>(MemoryLocations.YunaHP);
            YunaMP = GetMemoryWatcher<short>(MemoryLocations.YunaMP);
            YunaMaxHP = GetMemoryWatcher<int>(MemoryLocations.YunaMaxHP);
            YunaMaxMP = GetMemoryWatcher<short>(MemoryLocations.YunaMaxMP);
            AuronHP = GetMemoryWatcher<int>(MemoryLocations.AuronHP);
            AuronMP = GetMemoryWatcher<short>(MemoryLocations.AuronMP);
            AuronMaxHP = GetMemoryWatcher<int>(MemoryLocations.AuronMaxHP);
            AuronMaxMP = GetMemoryWatcher<short>(MemoryLocations.AuronMaxMP);
            WakkaHP = GetMemoryWatcher<int>(MemoryLocations.WakkaHP);
            WakkaMP = GetMemoryWatcher<short>(MemoryLocations.WakkaMP);
            WakkaMaxHP = GetMemoryWatcher<int>(MemoryLocations.WakkaMaxHP);
            WakkaMaxMP = GetMemoryWatcher<short>(MemoryLocations.WakkaMaxMP);
            KimahriHP = GetMemoryWatcher<int>(MemoryLocations.KimahriHP);
            KimahriMP = GetMemoryWatcher<short>(MemoryLocations.KimahriMP);
            KimahriMaxHP = GetMemoryWatcher<int>(MemoryLocations.KimahriMaxHP);
            KimahriMaxMP = GetMemoryWatcher<short>(MemoryLocations.KimahriMaxMP);
            LuluHP = GetMemoryWatcher<int>(MemoryLocations.LuluHP);
            LuluMP = GetMemoryWatcher<short>(MemoryLocations.LuluMP);
            LuluMaxHP = GetMemoryWatcher<int>(MemoryLocations.LuluMaxHP);
            LuluMaxMP = GetMemoryWatcher<short>(MemoryLocations.LuluMaxMP);
            RikkuHP = GetMemoryWatcher<int>(MemoryLocations.RikkuHP);
            RikkuMP = GetMemoryWatcher<short>(MemoryLocations.RikkuMP);
            RikkuMaxHP = GetMemoryWatcher<int>(MemoryLocations.RikkuMaxHP);
            RikkuMaxMP = GetMemoryWatcher<short>(MemoryLocations.RikkuMaxMP);
            ValeforHP = GetMemoryWatcher<int>(MemoryLocations.ValeforHP);
            ValeforMP = GetMemoryWatcher<short>(MemoryLocations.ValeforMP);
            ValeforMaxHP = GetMemoryWatcher<int>(MemoryLocations.ValeforMaxHP);
            ValeforMaxMP = GetMemoryWatcher<short>(MemoryLocations.ValeforMaxMP);

            // Special Flags
            FangirlsOrKidsSkip = GetMemoryWatcher<short>(MemoryLocations.FangirlsOrKidsSkip);
            BaajFlag1 = GetMemoryWatcher<byte>(MemoryLocations.BaajFlag1);
            BesaidFlag1 = GetMemoryWatcher<byte>(MemoryLocations.BesaidFlag1);
            SSWinnoFlag1 = GetMemoryWatcher<byte>(MemoryLocations.SSWinnoFlag1);
            KilikaMapFlag = GetMemoryWatcher<byte>(MemoryLocations.KilikaMapFlag);
            SSWinnoFlag2 = GetMemoryWatcher<byte>(MemoryLocations.SSWinnoFlag2);
            LucaFlag = GetMemoryWatcher<byte>(MemoryLocations.LucaFlag);
            LucaFlag2 = GetMemoryWatcher<byte>(MemoryLocations.LucaFlag2);
            BlitzballFlag = GetMemoryWatcher<byte>(MemoryLocations.BlitzballFlag);
            MiihenFlag1 = GetMemoryWatcher<byte>(MemoryLocations.MiihenFlag1);
            MiihenFlag2 = GetMemoryWatcher<byte>(MemoryLocations.MiihenFlag2);
            MiihenFlag3 = GetMemoryWatcher<byte>(MemoryLocations.MiihenFlag3);
            MiihenFlag4 = GetMemoryWatcher<byte>(MemoryLocations.MiihenFlag4);
            MRRFlag1 = GetMemoryWatcher<byte>(MemoryLocations.MRRFlag1);
            MRRFlag2 = GetMemoryWatcher<byte>(MemoryLocations.MRRFlag2);
            MoonflowFlag = GetMemoryWatcher<byte>(MemoryLocations.MoonflowFlag);
            MoonflowFlag2 = GetMemoryWatcher<byte>(MemoryLocations.MoonflowFlag2);
            RikkuOutfit = GetMemoryWatcher<byte>(MemoryLocations.RikkuOutfit);
            TidusWeaponDamageBoost = GetMemoryWatcher<byte>(MemoryLocations.TidusWeaponDamageBoost);
            GuadosalamShopFlag = GetMemoryWatcher<byte>(MemoryLocations.GuadosalamShopFlag);
            ThunderPlainsFlag = GetMemoryWatcher<byte>(MemoryLocations.ThunderPlainsFlag);
            MacalaniaFlag = GetMemoryWatcher<byte>(MemoryLocations.MacalaniaFlag);
            BikanelFlag = GetMemoryWatcher<byte>(MemoryLocations.BikanelFlag);
            Sandragoras = GetMemoryWatcher<byte>(MemoryLocations.Sandragoras);
            ViaPurificoPlatform = GetMemoryWatcher<byte>(MemoryLocations.ViaPurificoPlatform);
            NatusFlag = GetMemoryWatcher<byte>(MemoryLocations.NatusFlag);
            CalmLandsFlag = GetMemoryWatcher<ushort>(MemoryLocations.CalmLandsFlag);
            WantzFlag = GetMemoryWatcher<byte>(MemoryLocations.WantzFlag);
            GagazetCaveFlag = GetMemoryWatcher<short>(MemoryLocations.GagazetCaveFlag);
            OmegaRuinsFlag = GetMemoryWatcher<byte>(MemoryLocations.OmegaRuinsFlag);
            WantzMacalaniaFlag = GetMemoryWatcher<byte>(MemoryLocations.WantzMacalaniaFlag);

            // Blitzball Abilities
            AurochsTeamBytes = GetMemoryWatcher<byte>(MemoryLocations.AurochsTeamBytes);
            BlitzballBytes = GetMemoryWatcher<byte>(MemoryLocations.BlitzballBytes);
            AurochsPlayer1 = GetMemoryWatcher<byte>(MemoryLocations.AurochsPlayer1);

            // Battle Rewards
            GilBattleRewards = GetMemoryWatcher<int>(MemoryLocations.GilBattleRewards);
            BattleRewardItemCount = GetMemoryWatcher<byte>(MemoryLocations.BattleRewardItemCount);
            BattleRewardItem1 = GetMemoryWatcher<short>(MemoryLocations.BattleRewardItem1);
            BattleRewardItem2 = GetMemoryWatcher<short>(MemoryLocations.BattleRewardItem2);
            BattleRewardItem3 = GetMemoryWatcher<short>(MemoryLocations.BattleRewardItem3);
            BattleRewardItem4 = GetMemoryWatcher<short>(MemoryLocations.BattleRewardItem4);
            BattleRewardItem5 = GetMemoryWatcher<short>(MemoryLocations.BattleRewardItem5);
            BattleRewardItem6 = GetMemoryWatcher<short>(MemoryLocations.BattleRewardItem6);
            BattleRewardItem7 = GetMemoryWatcher<short>(MemoryLocations.BattleRewardItem7);
            BattleRewardItem8 = GetMemoryWatcher<short>(MemoryLocations.BattleRewardItem8);
            BattleRewardItemQty1 = GetMemoryWatcher<byte>(MemoryLocations.BattleRewardItemQty1);
            BattleRewardItemQty2 = GetMemoryWatcher<byte>(MemoryLocations.BattleRewardItemQty2);
            BattleRewardItemQty3 = GetMemoryWatcher<byte>(MemoryLocations.BattleRewardItemQty3);
            BattleRewardItemQty4 = GetMemoryWatcher<byte>(MemoryLocations.BattleRewardItemQty4);
            BattleRewardItemQty5 = GetMemoryWatcher<byte>(MemoryLocations.BattleRewardItemQty5);
            BattleRewardItemQty6 = GetMemoryWatcher<byte>(MemoryLocations.BattleRewardItemQty6);
            BattleRewardItemQty7 = GetMemoryWatcher<byte>(MemoryLocations.BattleRewardItemQty7);
            BattleRewardItemQty8 = GetMemoryWatcher<byte>(MemoryLocations.BattleRewardItemQty8);
            BattleRewardEquipCount = GetMemoryWatcher<byte>(MemoryLocations.BattleRewardEquipCount);
            BattleRewardEquip1 = GetMemoryWatcher<byte>(MemoryLocations.BattleRewardEquip1);
            BattleRewardEquip2 = GetMemoryWatcher<byte>(MemoryLocations.BattleRewardEquip2);
            BattleRewardEquip3 = GetMemoryWatcher<byte>(MemoryLocations.BattleRewardEquip3);
            BattleRewardEquip4 = GetMemoryWatcher<byte>(MemoryLocations.BattleRewardEquip4);
            BattleRewardEquip5 = GetMemoryWatcher<byte>(MemoryLocations.BattleRewardEquip5);
            BattleRewardEquip6 = GetMemoryWatcher<byte>(MemoryLocations.BattleRewardEquip6);
            BattleRewardEquip7 = GetMemoryWatcher<byte>(MemoryLocations.BattleRewardEquip7);
            BattleRewardEquip8 = GetMemoryWatcher<byte>(MemoryLocations.BattleRewardEquip8);

            //Items
            ItemsStart = GetMemoryWatcher<byte>(MemoryLocations.ItemsStart);
            ItemsQtyStart = GetMemoryWatcher<byte>(MemoryLocations.ItemsQtyStart);

            // AP
            CharacterAPFlags = GetMemoryWatcher<byte>(MemoryLocations.CharacterAPFlags);

            // Menu Values
            MenuTriggerValue = GetMemoryWatcher<int>(MemoryLocations.MenuTriggerValue);

            MenuValue1 = GetMemoryWatcher<int>(MemoryLocations.MenuValue1);
            MenuValue2 = GetMemoryWatcher<int>(MemoryLocations.MenuValue2);

            MenuValue3 = GetMemoryWatcher<int>(MemoryLocations.MenuValue3);
            MenuValue4 = GetMemoryWatcher<int>(MemoryLocations.MenuValue4);
            MenuValue5 = GetMemoryWatcher<byte>(MemoryLocations.MenuValue5);
            MenuValue6 = GetMemoryWatcher<int>(MemoryLocations.MenuValue6);
            MenuValue7 = GetMemoryWatcher<byte>(MemoryLocations.MenuValue7);

            SpeedBoostAmount = GetMemoryWatcher<int>(MemoryLocations.SpeedBoostAmount);
            SpeedBoostVar1 = GetMemoryWatcher<int>(MemoryLocations.SpeedBoostVar1);

            ActorArrayLength = GetMemoryWatcher<int>(MemoryLocations.ActorArrayLength);

            // RNGMod
            RNGArrayOpBytes = GetMemoryWatcher<byte>(MemoryLocations.RNGArrayOpBytes);

            HpEnemyA.FailAction = MemoryWatcher.ReadFailAction.SetZeroOrNull;

            Watchers.Clear();
            Watchers.AddRange(new List<MemoryWatcher>() {
                    Language,
                    RoomNumber,
                    Storyline,
                    ForceLoad,
                    SpawnPoint,
                    BattleState,
                    BattleState2,
                    Input,
                    Menu,
                    MenuLock,
                    Intro,
                    FangirlsOrKidsSkip,
                    State,
                    XCoordinate,
                    YCoordinate,
                    Camera,
                    Camera_x,
                    Camera_y,
                    Camera_z,
                    CameraRotation,
                    EncounterStatus,
                    MovementLock,
                    ActiveMusicId,
                    MusicId,
                    CutsceneAlt,
                    RoomNumberAlt,
                    AirshipDestinations,
                    AuronOverdrives,
                    Gil,
                    TargetFramerate,
                    Dialogue1,
                    DialogueOption,
                    DialogueBoxOpen,
                    DialogueOption_Gui,
                    DialogueBoxOpen_Gui,
                    PlayerTurn,
                    FrameCounterFromLoad,
                    EncounterMapID,
                    EncounterFormationID1,
                    EncounterFormationID2,
                    ScriptedBattleFlag1,
                    ScriptedBattleFlag2,
                    ScriptedBattleVar1,
                    ScriptedBattleVar3,
                    ScriptedBattleVar4,
                    EncounterTrigger,
                    Sandragoras,
                    HpEnemyA,
                    GuadoCount,
                    NPCLastInteraction,
                    TidusActionCount,
                    TidusXCoordinate,
                    TidusYCoordinate,
                    TidusZCoordinate,
                    TidusRotation,
                    DialogueFile,
                    CutsceneTiming,
                    EventFileStart,
                    AuronTransition,
                    AmmesTransition,
                    TankerTransition,
                    InsideSinTransition,
                    DiveTransition,
                    GeosTransition,
                    KlikkTransition,
                    AlBhedBoatTransition,
                    UnderwaterRuinsTransition,
                    UnderwaterRuinsTransition2,
                    BeachTransition,
                    LagoonTransition1,
                    LagoonTransition2,
                    ValeforTransition,
                    KimahriTransition,
                    YunaBoatTransition,
                    SinFinTransition,
                    EchuillesTransition,
                    GeneauxTransition,
                    KilikaTrialsTransition,
                    KilikaAntechamberTransition,
                    IfritTransition,
                    IfritTransition2,
                    JechtShotTransition,
                    OblitzeratorTransition,
                    BlitzballTransition,
                    SahaginTransition,
                    GarudaTransition,
                    RinTransition,
                    ChocoboEaterTransition,
                    GuiTransition,
                    Gui2Transition,
                    DjoseTransition,
                    IxionTransition,
                    ExtractorTransition,
                    SeymoursHouseTransition1,
                    SeymoursHouseTransition2,
                    FarplaneTransition1,
                    FarplaneTransition2,
                    TromellTransition,
                    CrawlerTransition,
                    SeymourTransition,
                    SeymourTransition2,
                    WendigoTransition,
                    SpherimorphTransition,
                    UnderLakeTransition,
                    BikanelTransition,
                    HomeTransition,
                    EvraeTransition,
                    EvraeAirshipTransition,
                    GuardsTransition,
                    BahamutTransition,
                    IsaaruTransition,
                    AltanaTransition,
                    NatusTransition,
                    DefenderXTransition,
                    RonsoTransition,
                    FluxTransition,
                    SanctuaryTransition,
                    SpectralKeeperTransition,
                    SpectralKeeperTransition2,
                    YunalescaTransition,
                    FinsTransition,
                    FinsAirshipTransition,
                    SinCoreTransition,
                    OverdriveSinTransition,
                    OmnisTransition,
                    BFATransition,
                    AeonTransition,
                    YuYevonTransition,
                    YojimboFaythTransition,
                    CutsceneProgress_Max,
                    CutsceneProgress_uVar1,
                    CutsceneProgress_uVar2,
                    CutsceneProgress_uVar3,
                    EnableTidus,
                    EnableYuna,
                    EnableAuron,
                    EnableKimahri,
                    EnableWakka,
                    EnableLulu,
                    EnableRikku,
                    EnableSeymour,
                    EnableValefor,
                    EnableIfrit,
                    EnableIxion,
                    EnableShiva,
                    EnableBahamut,
                    EnableAnima,
                    EnableYojimbo,
                    EnableMagus,
                    EncountersActiveFlag,
                    TotalDistance,
                    CycleDistance,
                    TidusHP, TidusMP, TidusMaxHP, TidusMaxMP,
                    YunaHP, YunaMP, YunaMaxHP, YunaMaxMP,
                    AuronHP, AuronMP, AuronMaxHP, AuronMaxMP,
                    WakkaHP, WakkaMP, WakkaMaxHP, WakkaMaxMP,
                    KimahriHP, KimahriMP, KimahriMaxHP, KimahriMaxMP,
                    LuluHP, LuluMP, LuluMaxHP, LuluMaxMP,
                    RikkuHP, RikkuMP, RikkuMaxHP, RikkuMaxMP,
                    ValeforHP, ValeforMP, ValeforMaxHP, ValeforMaxMP,
                    BaajFlag1,
                    BesaidFlag1,
                    SSWinnoFlag1,
                    KilikaMapFlag,
                    SSWinnoFlag2,
                    LucaFlag,
                    LucaFlag2,
                    BlitzballFlag,
                    MiihenFlag1,
                    MiihenFlag2,
                    MiihenFlag3,
                    MiihenFlag4,
                    MRRFlag1,
                    MRRFlag2,
                    MoonflowFlag,
                    MoonflowFlag2,
                    RikkuOutfit,
                    TidusWeaponDamageBoost,
                    GuadosalamShopFlag,
                    ThunderPlainsFlag,
                    MacalaniaFlag,
                    BikanelFlag,
                    ViaPurificoPlatform,
                    NatusFlag,
                    CalmLandsFlag,
                    WantzFlag,
                    GagazetCaveFlag,
                    OmegaRuinsFlag,
                    WantzMacalaniaFlag,
                    AurochsTeamBytes,
                    BlitzballBytes,
                    AurochsPlayer1,
                    GilBattleRewards,
                    BattleRewardItemCount,
                    BattleRewardItem1,
                    BattleRewardItem2,
                    BattleRewardItem3,
                    BattleRewardItem4,
                    BattleRewardItem5,
                    BattleRewardItem6,
                    BattleRewardItem7,
                    BattleRewardItem8,
                    BattleRewardItemQty1,
                    BattleRewardItemQty2,
                    BattleRewardItemQty3,
                    BattleRewardItemQty4,
                    BattleRewardItemQty5,
                    BattleRewardItemQty6,
                    BattleRewardItemQty7,
                    BattleRewardItemQty8,
                    BattleRewardEquipCount,
                    BattleRewardEquip1,
                    BattleRewardEquip2,
                    BattleRewardEquip3,
                    BattleRewardEquip4,
                    BattleRewardEquip5,
                    BattleRewardEquip6,
                    BattleRewardEquip7,
                    BattleRewardEquip8,
                    ItemsStart,
                    ItemsQtyStart,
                    CharacterAPFlags,
                    MenuTriggerValue,
                    MenuValue1,
                    MenuValue2,
                    MenuValue3,
                    MenuValue4,
                    MenuValue5,
                    MenuValue6,
                    MenuValue7,
                    SpeedBoostAmount,
                    SpeedBoostVar1,
                    ActorArrayLength,
                    RNGArrayOpBytes
            });
        }

        private MemoryWatcher<T> GetMemoryWatcher<T>(MemoryLocationData data) where T : struct
        {
            MemoryWatcher<T> watcher;

            if (data.Offsets.Length == 0)
            {
                watcher = new MemoryWatcher<T>(GetPointerAddress(data.BaseAddress));
            }
            else
            {
                watcher = new MemoryWatcher<T>(GetDeepPointer(data.BaseAddress, data.Offsets));
            }
            watcher.Name = data.Name;

            return watcher;
        }

        private IntPtr GetPointerAddress(int offset)
        {
            return new IntPtr(processBaseAddress + offset);
        }

        private DeepPointer GetDeepPointer(int baseAddress, int[] offsets)
        {
            return new DeepPointer(MODULE, baseAddress, offsets);
        }

        public int GetBaseAddress()
        {
            return processBaseAddress;
        }
    }
}
