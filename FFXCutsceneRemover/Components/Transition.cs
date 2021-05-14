using FFX_Cutscene_Remover.ComponentUtil;
using System;
using System.Diagnostics;
using System.Reflection;

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

        public bool ForceLoad = true;
        public bool FullHeal = false;
        public string Description = null;

        /* Only add members here for memory addresses that we want to write the value to.
         * If we only ever read the value then there is no need to add it here. */
        public short? RoomNumber = null;
        public short? Storyline = null;
        public short? SpawnPoint = null;
        public int? BattleState = null;
        public byte? Menu = null;
        public byte? MenuLock = null;
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
        public short? RoomNumberAlt = null;
        public short? CutsceneAlt = null;
        public short? AirshipDestinations = null;
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
        public byte? EnableSeymour = null;
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
        public byte? TidusWeaponDamageBoost = null;

        public byte? MacalaniaFlag = null;
        public byte? BikanelFlag = null;

        public byte[] Formation = null;
        public byte[] RikkuName = null;

        public byte? ViaPurificoPlatform = null;
        public short? CalmLandsFlag = null;
        public short? GagazetCaveFlag = null;

        public virtual void Execute(string defaultDescription = "")
        {
            Console.WriteLine(
                !string.IsNullOrEmpty(Description) ? Description : 
                !string.IsNullOrEmpty(defaultDescription) ? defaultDescription : 
                DEFAULT_DESCRIPTION);
            
            // Always update to get the latest process
            process = memoryWatchers.Process;

            WriteValue(memoryWatchers.RoomNumber, RoomNumber);
            WriteValue(memoryWatchers.Storyline, Storyline);
            WriteValue(memoryWatchers.SpawnPoint, SpawnPoint);
            WriteValue(memoryWatchers.BattleState, BattleState);
            WriteValue(memoryWatchers.Menu, Menu);
            WriteValue(memoryWatchers.MenuLock, MenuLock);
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
            WriteValue(memoryWatchers.RoomNumberAlt, RoomNumberAlt);
            WriteValue(memoryWatchers.CutsceneAlt, CutsceneAlt);
            WriteValue(memoryWatchers.AirshipDestinations, AirshipDestinations);
            WriteValue(memoryWatchers.AuronOverdrives, AuronOverdrives);
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
            WriteValue(memoryWatchers.EnableSeymour, EnableSeymour);
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
            WriteValue(memoryWatchers.TidusWeaponDamageBoost, TidusWeaponDamageBoost);
            WriteValue(memoryWatchers.MacalaniaFlag, MacalaniaFlag);
            WriteValue(memoryWatchers.BikanelFlag, BikanelFlag);
            WriteBytes(memoryWatchers.Formation, Formation);
            WriteBytes(memoryWatchers.RikkuName, RikkuName);
            WriteValue(memoryWatchers.ViaPurificoPlatform, ViaPurificoPlatform);
            WriteValue(memoryWatchers.CalmLandsFlag, CalmLandsFlag);
            WriteValue(memoryWatchers.GagazetCaveFlag, GagazetCaveFlag);

            if (ForceLoad)
            {
                ForceGameLoad();
            }

            if (FullHeal)
            {
                FullPartyHeal();
            }
        }

        /* Set the force load bit. Will immediately cause a fade and load. */
        private void ForceGameLoad()
        {
            WriteValue<byte>(memoryWatchers.ForceLoad, 1);
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
                    Console.WriteLine("Couldn't read the pointer path for: " + watcher.Name);
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
            WriteValue<int>(memoryWatchers.TidusHP, memoryWatchers.TidusMaxHP.Current);
            WriteValue<int>(memoryWatchers.YunaHP, memoryWatchers.YunaMaxHP.Current);
            WriteValue<int>(memoryWatchers.AuronHP, memoryWatchers.AuronMaxHP.Current);
            WriteValue<int>(memoryWatchers.KimahriHP, memoryWatchers.KimahriMaxHP.Current);
            WriteValue<int>(memoryWatchers.WakkaHP, memoryWatchers.WakkaMaxHP.Current);
            WriteValue<int>(memoryWatchers.LuluHP, memoryWatchers.LuluMaxHP.Current);
            WriteValue<int>(memoryWatchers.RikkuHP, memoryWatchers.RikkuMaxHP.Current);
            WriteValue<int>(memoryWatchers.ValeforHP, memoryWatchers.ValeforMaxHP.Current);
            
            WriteValue<short>(memoryWatchers.TidusMP, memoryWatchers.TidusMaxMP.Current);
            WriteValue<short>(memoryWatchers.YunaMP, memoryWatchers.YunaMaxMP.Current);
            WriteValue<short>(memoryWatchers.AuronMP, memoryWatchers.AuronMaxMP.Current);
            WriteValue<short>(memoryWatchers.WakkaMP, memoryWatchers.WakkaMaxMP.Current);
            WriteValue<short>(memoryWatchers.KimahriMP, memoryWatchers.KimahriMaxMP.Current);
            WriteValue<short>(memoryWatchers.LuluMP, memoryWatchers.LuluMaxMP.Current);
            WriteValue<short>(memoryWatchers.RikkuMP, memoryWatchers.RikkuMaxMP.Current);
            WriteValue<short>(memoryWatchers.ValeforMP, memoryWatchers.ValeforMaxMP.Current);
        }
    }
}
