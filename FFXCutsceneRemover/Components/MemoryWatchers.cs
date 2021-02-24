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
        public MemoryWatcher<short> FangirlsOrKidsSkip;
        public MemoryWatcher<sbyte> State;
        public MemoryWatcher<float> XCoordinate;
        public MemoryWatcher<float> YCoordinate;
        public MemoryWatcher<byte> Camera;
        public MemoryWatcher<float> CameraRotation;
        public MemoryWatcher<byte> EncounterStatus;
        public MemoryWatcher<byte> MovementLock;
        public MemoryWatcher<byte> MusicId;
        public MemoryWatcher<byte> CutsceneAlt;
        public MemoryWatcher<byte> AirshipDestinations;
        public MemoryWatcher<short> AuronOverdrives;
        public MemoryWatcher<byte> PartyMembers;
        public MemoryWatcher<byte> Sandragoras;
        //public MemoryWatcher<int> HpEnemyA;
        //public MemoryWatcher<byte> GuadoCount;

        public MemoryWatcher<byte> EnableYuna;
        public MemoryWatcher<byte> EnableAuron;
        public MemoryWatcher<byte> EnableKimahri;
        public MemoryWatcher<byte> EnableWakka;

        public MemoryWatcher<byte> LucaFlag;
        public MemoryWatcher<byte> LucaFlag2;

        public MemoryWatcher<byte> MiihenFlag1;
        public MemoryWatcher<byte> MiihenFlag2;
        public MemoryWatcher<byte> MiihenFlag3;
        public MemoryWatcher<byte> MiihenFlag4;

        public MemoryWatcher<byte> Formation;

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
            FangirlsOrKidsSkip = GetMemoryWatcher<short>(MemoryLocations.FangirlsOrKidsSkip);
            State = GetMemoryWatcher<sbyte>(MemoryLocations.State);
            XCoordinate = GetMemoryWatcher<float>(MemoryLocations.XCoordinate);
            YCoordinate = GetMemoryWatcher<float>(MemoryLocations.YCoordinate);
            Camera = GetMemoryWatcher<byte>(MemoryLocations.Camera);
            CameraRotation = GetMemoryWatcher<float>(MemoryLocations.CameraRotation);
            EncounterStatus = GetMemoryWatcher<byte>(MemoryLocations.EncounterStatus);
            MovementLock = GetMemoryWatcher<byte>(MemoryLocations.MovementLock);
            MusicId = GetMemoryWatcher<byte>(MemoryLocations.MusicId);
            CutsceneAlt = GetMemoryWatcher<byte>(MemoryLocations.CutsceneAlt);
            AirshipDestinations = GetMemoryWatcher<byte>(MemoryLocations.AirshipDestinations);
            AuronOverdrives = GetMemoryWatcher<short>(MemoryLocations.AuronOverdrives);
            PartyMembers = GetMemoryWatcher<byte>(MemoryLocations.PartyMembers);
            Sandragoras = GetMemoryWatcher<byte>(MemoryLocations.Sandragoras);
            //HpEnemyA = GetMemoryWatcher<int>(MemoryLocations.HpEnemyA);
            //GuadoCount = GetMemoryWatcher<byte>(MemoryLocations.GuadoCount);

            EnableYuna = GetMemoryWatcher<byte>(MemoryLocations.EnableYuna);
            EnableAuron = GetMemoryWatcher<byte>(MemoryLocations.EnableAuron);
            EnableKimahri = GetMemoryWatcher<byte>(MemoryLocations.EnableKimahri);
            EnableWakka = GetMemoryWatcher<byte>(MemoryLocations.EnableWakka);

            LucaFlag = GetMemoryWatcher<byte>(MemoryLocations.LucaFlag);
            LucaFlag2 = GetMemoryWatcher<byte>(MemoryLocations.LucaFlag2);

            MiihenFlag1 = GetMemoryWatcher<byte>(MemoryLocations.MiihenFlag1);
            MiihenFlag2 = GetMemoryWatcher<byte>(MemoryLocations.MiihenFlag2);
            MiihenFlag3 = GetMemoryWatcher<byte>(MemoryLocations.MiihenFlag3);
            MiihenFlag4 = GetMemoryWatcher<byte>(MemoryLocations.MiihenFlag4);

            Formation = GetMemoryWatcher<byte>(MemoryLocations.Formation);

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
                    AirshipDestinations,
                    AuronOverdrives,
                    PartyMembers,
                    Sandragoras,
                    //HpEnemyA,
                    //GuadoCount,
                    EnableYuna,
                    EnableAuron,
                    EnableKimahri,
                    EnableWakka,
                    LucaFlag,
                    LucaFlag2,
                    MiihenFlag1,
                    MiihenFlag2,
                    MiihenFlag3,
                    MiihenFlag4
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
