using FFX_Cutscene_Remover.ComponentUtil;
using System;
using System.Diagnostics;

namespace FFXCutsceneRemover
{
    /* Represents a change in current state of the game's memory. Create one of these objects
     * with the values you care about, and Execute() will set the game's state to match this object. */
    class Transition 
    {
        private readonly MemoryWatchers memoryWatchers = MemoryWatchers.Instance;

        private Process process;
        public bool ForceLoad = true;
        public string Description = null;

        /* Only add members here for memory addresses that we want to write the value to.
         * If we only ever read the value then there is no need to add it here. */
        public short? RoomNumber = null;
        public short? Storyline = null;
        public short? SpawnPoint = null;
        public int? BattleState = null;
        public byte? Menu = null;
        public short? Intro = null;
        public short? FangirlsOrKidsSkip = null;
        public sbyte? State = null;
        public float? XCoordinate = null;
        public float? YCoordinate = null;
        public byte? Camera = null;
        public float? CameraRotation = null;
        public byte? EncounterStatus = null;
        public byte? MovementLock = null;
        public byte? MusicId = null;
        public short? CutsceneAlt = null;
        public byte? AirshipDestinations = null;
        public short? AuronOverdrives = null;
        public byte? PartyMembers = null;
        public byte? Sandragoras = null;
        public int? HpEnemyA = null;
        public byte? GuadoCount = null;

        public byte? EnableTidus = null;
        public byte? EnableYuna = null;
        public byte? EnableAuron = null;
        public byte? EnableKimahri = null;
        public byte? EnableWakka = null;
        public byte? EnableLulu = null;
        public byte? EnableRikku = null;
        public byte? EnableValefor = null;

        public byte? BaajFlag1 = null;

        public byte? SSWinnoFlag1 = null;
        public byte? SSWinnoFlag2 = null;

        public byte? LucaFlag = null;
        public byte? LucaFlag2 = null;

        public byte? MiihenFlag1 = null;
        public byte? MiihenFlag2 = null;
        public byte? MiihenFlag3 = null;
        public byte? MiihenFlag4 = null;

        public byte? MoonflowFlag = null;
        public byte? MoonflowFlag2 = null;
        public byte? RikkuOutfit = null;

        public byte? MacalaniaFlag = null;

        public byte[] Formation = null;
        
        public byte? ViaPurifico = null;

        public void Execute()
        {
            // Always update to get the latest process
            process = memoryWatchers.Process;

            WriteValue(memoryWatchers.RoomNumber, RoomNumber);
            WriteValue(memoryWatchers.Storyline, Storyline);
            WriteValue(memoryWatchers.SpawnPoint, SpawnPoint);
            WriteValue(memoryWatchers.BattleState, BattleState);
            WriteValue(memoryWatchers.Menu, Menu);
            WriteValue(memoryWatchers.Intro, Intro);
            WriteValue(memoryWatchers.FangirlsOrKidsSkip, FangirlsOrKidsSkip);
            WriteValue(memoryWatchers.State, State);
            WriteValue(memoryWatchers.XCoordinate, XCoordinate);
            WriteValue(memoryWatchers.YCoordinate, YCoordinate);
            WriteValue(memoryWatchers.Camera, Camera);
            WriteValue(memoryWatchers.CameraRotation, CameraRotation);
            WriteValue(memoryWatchers.EncounterStatus, EncounterStatus);
            WriteValue(memoryWatchers.MovementLock, MovementLock);
            WriteValue(memoryWatchers.MusicId, MusicId);
            WriteValue(memoryWatchers.CutsceneAlt, CutsceneAlt);
            WriteValue(memoryWatchers.AirshipDestinations, AirshipDestinations);
            WriteValue(memoryWatchers.AuronOverdrives, AuronOverdrives);
            WriteValue(memoryWatchers.PartyMembers, PartyMembers);
            WriteValue(memoryWatchers.Sandragoras, Sandragoras);
            WriteValue(memoryWatchers.HpEnemyA, HpEnemyA);
            WriteValue(memoryWatchers.GuadoCount, GuadoCount);
            WriteValue(memoryWatchers.EnableTidus, EnableTidus);
            WriteValue(memoryWatchers.EnableYuna, EnableYuna);
            WriteValue(memoryWatchers.EnableAuron, EnableAuron);
            WriteValue(memoryWatchers.EnableKimahri, EnableKimahri);
            WriteValue(memoryWatchers.EnableWakka, EnableWakka);
            WriteValue(memoryWatchers.EnableLulu, EnableLulu);
            WriteValue(memoryWatchers.EnableRikku, EnableRikku);
            WriteValue(memoryWatchers.EnableValefor, EnableValefor);

            WriteValue(memoryWatchers.BaajFlag1, BaajFlag1);
            WriteValue(memoryWatchers.SSWinnoFlag1, SSWinnoFlag1);
            WriteValue(memoryWatchers.SSWinnoFlag2, SSWinnoFlag2);

            WriteValue(memoryWatchers.LucaFlag, LucaFlag);
            WriteValue(memoryWatchers.LucaFlag2, LucaFlag2);
            WriteValue(memoryWatchers.MiihenFlag1, MiihenFlag1);
            WriteValue(memoryWatchers.MiihenFlag2, MiihenFlag2);
            WriteValue(memoryWatchers.MiihenFlag3, MiihenFlag3);
            WriteValue(memoryWatchers.MiihenFlag4, MiihenFlag4);
            WriteValue(memoryWatchers.MoonflowFlag, MoonflowFlag);
            WriteValue(memoryWatchers.MoonflowFlag2, MoonflowFlag2);
            WriteValue(memoryWatchers.RikkuOutfit, RikkuOutfit);
            WriteValue(memoryWatchers.MacalaniaFlag, MacalaniaFlag);
            WriteBytes(memoryWatchers.Formation, Formation);
            WriteValue(memoryWatchers.ViaPurifico, ViaPurifico);

            if (ForceLoad)
            {
                ForceGameLoad();
            }
        }

        private void WriteValue<T>(MemoryWatcher watcher, T? value) where T : struct
        {
            if (value.HasValue)
            {
                if (watcher.AddrType == MemoryWatcher.AddressType.Absolute)
                {
                    process.WriteValue(watcher.Address, value.Value);
                }
                else
                {
                    // To write to a deep pointer we need to dereference its pointer path.
                    // Then we write to the final pointer.
                    IntPtr finalPointer;
                    if (!watcher.DeepPtr.DerefOffsets(process, out finalPointer))
                    {
                        Console.WriteLine("Couldn't read the pointer path for: " + watcher.Name);
                    }
                    process.WriteValue(finalPointer, value.Value);
                }
            }
        }

        private void WriteBytes(MemoryWatcher watcher, byte[] bytes)
        {
            if (bytes != null)
            {
                process.WriteBytes(watcher.Address, bytes);
            }
        }

        /* Set the force load bit. Will immediately cause a fade and load. */
        private void ForceGameLoad()
        {
            WriteValue<byte>(memoryWatchers.ForceLoad, 1);
        }
    }
}
