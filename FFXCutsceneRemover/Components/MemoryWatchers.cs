using FFX_Cutscene_Remover.ComponentUtil;
using FFXCutsceneRemover.Resources;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace FFXCutsceneRemover
{
    /* This class contains all the memory watchers used in the program. All watchers should be added here. */
    sealed class MemoryWatchers
    {
        private static readonly string MODULE = "FFX.exe";

        private static readonly object padlock = new object();

        private static MemoryWatchers instance = null;

        private int processBaseAddress;
        
        public Process Process;
        public MemoryWatcherList Watchers = new MemoryWatcherList();

        public MemoryWatcher<short> RoomNumber;
        public MemoryWatcher<short> Storyline;
        public MemoryWatcher<byte> ForceLoad;
        public MemoryWatcher<short> SpawnPoint;
        public MemoryWatcher<int> BattleState;
        public MemoryWatcher<short> Input;
        public MemoryWatcher<byte> Menu;
        public MemoryWatcher<short> Intro;
        public MemoryWatcher<sbyte> State;
        public MemoryWatcher<float> XCoordinate;
        public MemoryWatcher<float> YCoordinate;
        public MemoryWatcher<byte> Camera;
        public MemoryWatcher<float> CameraRotation;
        public MemoryWatcher<byte> EncounterStatus;
        public MemoryWatcher<byte> MovementLock;
        public MemoryWatcher<byte> MusicId;
        public MemoryWatcher<byte> RoomNumberAlt;
        public MemoryWatcher<short> CutsceneAlt;
        public MemoryWatcher<short> AirshipDestinations;
        public MemoryWatcher<short> AuronOverdrives;
        
        // Deep Pointers
        public MemoryWatcher<int> HpEnemyA;
        public MemoryWatcher<byte> GuadoCount;

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
        public MemoryWatcher<byte> SSWinnoFlag2;
        public MemoryWatcher<byte> LucaFlag;
        public MemoryWatcher<byte> LucaFlag2;
        public MemoryWatcher<byte> MiihenFlag1;
        public MemoryWatcher<byte> MiihenFlag2;
        public MemoryWatcher<byte> MiihenFlag3;
        public MemoryWatcher<byte> MiihenFlag4;
        public MemoryWatcher<byte> MoonflowFlag;
        public MemoryWatcher<byte> MoonflowFlag2;
        public MemoryWatcher<byte> RikkuOutfit;
        public MemoryWatcher<byte> MacalaniaFlag;
        public MemoryWatcher<byte> Sandragoras;
        public MemoryWatcher<byte> ViaPurificoPlatform;
        public MemoryWatcher<short> CalmLandsFlag;
        public MemoryWatcher<byte> GagazetCaveFlag;

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
            Console.WriteLine("Process base address: " + processBaseAddress);

            RoomNumber = GetMemoryWatcher<short>(MemoryLocations.RoomNumber);
            Storyline = GetMemoryWatcher<short>(MemoryLocations.Storyline);
            ForceLoad = GetMemoryWatcher<byte>(MemoryLocations.ForceLoad);
            SpawnPoint = GetMemoryWatcher<short>(MemoryLocations.SpawnPoint);
            BattleState = GetMemoryWatcher<int>(MemoryLocations.BattleState);
            Input = GetMemoryWatcher<short>(MemoryLocations.Input);
            Menu = GetMemoryWatcher<byte>(MemoryLocations.Menu);
            Intro = GetMemoryWatcher<short>(MemoryLocations.Intro);
            State = GetMemoryWatcher<sbyte>(MemoryLocations.State);
            XCoordinate = GetMemoryWatcher<float>(MemoryLocations.XCoordinate);
            YCoordinate = GetMemoryWatcher<float>(MemoryLocations.YCoordinate);
            Camera = GetMemoryWatcher<byte>(MemoryLocations.Camera);
            CameraRotation = GetMemoryWatcher<float>(MemoryLocations.CameraRotation);
            EncounterStatus = GetMemoryWatcher<byte>(MemoryLocations.EncounterStatus);
            MovementLock = GetMemoryWatcher<byte>(MemoryLocations.MovementLock);
            MusicId = GetMemoryWatcher<byte>(MemoryLocations.MusicId);
            RoomNumberAlt = GetMemoryWatcher<byte>(MemoryLocations.RoomNumberAlt);
            CutsceneAlt = GetMemoryWatcher<short>(MemoryLocations.CutsceneAlt);
            AirshipDestinations = GetMemoryWatcher<short>(MemoryLocations.AirshipDestinations);
            AuronOverdrives = GetMemoryWatcher<short>(MemoryLocations.AuronOverdrives);

            // Deep Pointers
            HpEnemyA = GetMemoryWatcher<int>(MemoryLocations.HpEnemyA);
            GuadoCount = GetMemoryWatcher<byte>(MemoryLocations.GuadoCount);

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
            SSWinnoFlag2 = GetMemoryWatcher<byte>(MemoryLocations.SSWinnoFlag2);
            LucaFlag = GetMemoryWatcher<byte>(MemoryLocations.LucaFlag);
            LucaFlag2 = GetMemoryWatcher<byte>(MemoryLocations.LucaFlag2);
            MiihenFlag1 = GetMemoryWatcher<byte>(MemoryLocations.MiihenFlag1);
            MiihenFlag2 = GetMemoryWatcher<byte>(MemoryLocations.MiihenFlag2);
            MiihenFlag3 = GetMemoryWatcher<byte>(MemoryLocations.MiihenFlag3);
            MiihenFlag4 = GetMemoryWatcher<byte>(MemoryLocations.MiihenFlag4);
            MoonflowFlag = GetMemoryWatcher<byte>(MemoryLocations.MoonflowFlag);
            MoonflowFlag2 = GetMemoryWatcher<byte>(MemoryLocations.MoonflowFlag2);
            RikkuOutfit = GetMemoryWatcher<byte>(MemoryLocations.RikkuOutfit);
            MacalaniaFlag = GetMemoryWatcher<byte>(MemoryLocations.MacalaniaFlag);
            Sandragoras = GetMemoryWatcher<byte>(MemoryLocations.Sandragoras);
            ViaPurificoPlatform = GetMemoryWatcher<byte>(MemoryLocations.ViaPurificoPlatform);
            CalmLandsFlag = GetMemoryWatcher<short>(MemoryLocations.CalmLandsFlag);
            GagazetCaveFlag = GetMemoryWatcher<byte>(MemoryLocations.GagazetCaveFlag);
            
            Watchers.Clear();
            Watchers.AddRange(new List<MemoryWatcher>() { 
                    RoomNumber,
                    Storyline,
                    ForceLoad,
                    SpawnPoint,
                    BattleState,
                    Input,
                    Menu,
                    Intro,
                    FangirlsOrKidsSkip,
                    State,
                    XCoordinate,
                    YCoordinate,
                    Camera,
                    CameraRotation,
                    EncounterStatus,
                    MovementLock,
                    MusicId,
                    CutsceneAlt,
                    RoomNumberAlt,
                    AirshipDestinations,
                    AuronOverdrives,
                    Sandragoras,
                    HpEnemyA,
                    GuadoCount,
                    EnableTidus,
                    EnableYuna,
                    EnableAuron,
                    EnableKimahri,
                    EnableWakka,
                    EnableLulu,
                    EnableRikku,
                    EnableSeymour,
                    EnableValefor,
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
                    SSWinnoFlag2,
                    LucaFlag,
                    LucaFlag2,
                    MiihenFlag1,
                    MiihenFlag2,
                    MiihenFlag3,
                    MiihenFlag4,
                    MoonflowFlag,
                    MoonflowFlag2,
                    RikkuOutfit,
                    MacalaniaFlag,
                    ViaPurificoPlatform,
                    CalmLandsFlag,
                    GagazetCaveFlag
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
    }
}
