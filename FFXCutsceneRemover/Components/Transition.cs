using FFX_Cutscene_Remover.ComponentUtil;
using System;
using System.Diagnostics;
using System.Reflection;
using FFXCutsceneRemover.Logging;

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
        public bool AddItems = false;
        public bool PositionPartyOffScreen = false;
        public bool PositionTidusAfterLoad = false;
        public string Description = null;
        public int BaseCutsceneValue = 0;
        public int BaseCutsceneValue2 = 0;
        public bool Repeatable = false;
        public bool Suspendable = true;
        public int Stage = 0;

        public int? ActorArrayLength = null;
        public short[] TargetActorIDs = null;
        public float? Target_x = null;
        public float? Target_y = null;
        public float? Target_z = null;
        public float? Target_rot = null;
        public bool Target_swimming = false;
        public float? PartyTarget_x = null;
        public float? PartyTarget_y = null;
        public float? PartyTarget_z = null;

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
        public short? AuronOverdrives = null;
        public int? TargetFramerate = null;
        public byte? PartyMembers = null;
        public byte? Sandragoras = null;
        public int? HpEnemyA = null;
        public byte? GuadoCount = null;
        public float? TidusXCoordinate = null;
        public float? TidusYCoordinate = null;
        public float? TidusZCoordinate = null;
        public float? TidusRotation = null;
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
        public int? LagoonTransition = null;
        public int? ValeforTransition = null;
        public int? KimahriTransition = null;
        public int? YunaBoatTransition = null;
        public int? SinFinTransition = null;
        public int? EchuillesTransition = null;
        public int? GeneauxTransition = null;
        public int? KilikaTrialsTransition = null;
        public int? IfritTransition = null;
        public int? IfritTransition2 = null;
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
        public int? OmnisTransition = null;
        public int? BFATransition = null;
        public int? AeonTransition = null;

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
        public byte? EnableYojimbo = null;
        public byte? EnableAnima = null;
        public byte? EnableMagus = null;

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

        public byte? MacalaniaFlag = null;
        public byte? BikanelFlag = null;

        public byte[] Formation = null;
        public byte[] RikkuName = null;

        public byte? ViaPurificoPlatform = null;
        public byte? NatusFlag = null;
        public short? CalmLandsFlag = null;
        public short? GagazetCaveFlag = null;

        public byte[] BlitzballAbilities = null;

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

        public int? MenuValue1 = null;
        public int? MenuValue2 = null;

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
            WriteValue(memoryWatchers.HpEnemyA, HpEnemyA);
            WriteValue(memoryWatchers.GuadoCount, GuadoCount);
            WriteValue(memoryWatchers.TidusXCoordinate, TidusXCoordinate);
            WriteValue(memoryWatchers.TidusYCoordinate, TidusYCoordinate);
            WriteValue(memoryWatchers.TidusZCoordinate, TidusZCoordinate);
            WriteValue(memoryWatchers.TidusRotation, TidusRotation);
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
            WriteValue(memoryWatchers.LagoonTransition, LagoonTransition);
            WriteValue(memoryWatchers.ValeforTransition, ValeforTransition);
            WriteValue(memoryWatchers.KimahriTransition, KimahriTransition);
            WriteValue(memoryWatchers.YunaBoatTransition, YunaBoatTransition);
            WriteValue(memoryWatchers.SinFinTransition, SinFinTransition);
            WriteValue(memoryWatchers.EchuillesTransition, EchuillesTransition);
            WriteValue(memoryWatchers.GeneauxTransition, GeneauxTransition);
            WriteValue(memoryWatchers.KilikaTrialsTransition, KilikaTrialsTransition);
            WriteValue(memoryWatchers.IfritTransition, IfritTransition);
            WriteValue(memoryWatchers.IfritTransition2, IfritTransition2);
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
            WriteValue(memoryWatchers.OmnisTransition, OmnisTransition);
            WriteValue(memoryWatchers.BFATransition, BFATransition);
            WriteValue(memoryWatchers.AeonTransition, AeonTransition);
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
            WriteValue(memoryWatchers.EnableYojimbo, EnableYojimbo);
            WriteValue(memoryWatchers.EnableAnima, EnableAnima);
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
            WriteValue(memoryWatchers.MacalaniaFlag, MacalaniaFlag);
            WriteValue(memoryWatchers.BikanelFlag, BikanelFlag);
            WriteBytes(memoryWatchers.Formation, Formation);
            WriteBytes(memoryWatchers.RikkuName, RikkuName);
            WriteValue(memoryWatchers.ViaPurificoPlatform, ViaPurificoPlatform);
            WriteValue(memoryWatchers.NatusFlag, NatusFlag);
            WriteValue(memoryWatchers.CalmLandsFlag, CalmLandsFlag);
            WriteValue(memoryWatchers.GagazetCaveFlag, GagazetCaveFlag);

            WriteBytes(memoryWatchers.BlitzballAbilities, BlitzballAbilities);

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

            WriteValue(memoryWatchers.ActorArrayLength, ActorArrayLength);

            if (ForceLoad)
            {
                ForceGameLoad();
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

            if (PositionPartyOffScreen)
            {
                PartyOffScreen();
            }
            //*/
            if (PositionTidusAfterLoad)
            {
                process.Resume();
                while(memoryWatchers.ForceLoad.Current == 1 || memoryWatchers.State.Current == -1) // Wait for loading to start and black screen to end
                {
                    memoryWatchers.ForceLoad.Update(process);
                    memoryWatchers.State.Update(process);
                }
                /*/ This breaks existing skips. If we are to use it we need to add a bool to only use this when needed.
                bool TidusFound = false;
                while (!TidusFound) // Keep trying to move Tidus until his character model is in memory
                {
                    TidusFound = SetActorPosition(1, Target_x, Target_y, Target_z, Target_rot);
                    //DiagnosticLog.Information("Waiting...");
                }
                //*/
                process.Suspend();
                SetActorPosition(1, Target_x, Target_y, Target_z, Target_rot);
            }
            else
            {
                if (TargetActorIDs != null)
                {
                    foreach (short TargetActorID in TargetActorIDs)
                    {
                        SetActorPosition(TargetActorID, Target_x, Target_y, Target_z, Target_rot);
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
                DiagnosticLog.Information(watcher.Name + ": Writing " + value.Value.ToString());
                writeHelper(watcher, () => process.WriteValue(watcher.Address, value.Value),
                   (pointer) => process.WriteValue(pointer, value.Value));
                DiagnosticLog.Information(watcher.Name + ": Written " + value.Value.ToString());
            }
        }

        protected void WriteBytes(MemoryWatcher watcher, byte[] bytes)
        {
            if (bytes != null)
            {
                DiagnosticLog.Information(watcher.Name + ": Writing " + BitConverter.ToString(bytes));
                writeHelper(watcher, () => process.WriteBytes(watcher.Address, bytes),
                    (pointer) => process.WriteBytes(pointer, bytes));
                DiagnosticLog.Information(watcher.Name + ": Written " + BitConverter.ToString(bytes));
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

        public byte[] SwapCharacterWithPosition(byte[] formation, byte characterIndex, int newPosition)
        {
            int oldposition = Array.IndexOf(formation, characterIndex);
            
            byte temp = formation[oldposition];
            formation[oldposition] = formation[newPosition];
            formation[newPosition] = temp;

            return formation;
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

        private void CleanMenuValues()
        {
            WriteValue<int>(memoryWatchers.MenuValue1, 0);
            WriteValue<int>(memoryWatchers.MenuValue2, 0);
        }

        private void ClearAllBattleRewards()
        {
            // Clear Gil
            WriteValue<int>(memoryWatchers.GilBattleRewards, 0);

            if (AddItems)
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

                            DiagnosticLog.Information("Existing Item: " + items[2 * j] + " / Position: " + j + " / Qty: " + itemsQty[j]);

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

                                DiagnosticLog.Information("New Item: " + items[2 * j] + " / Position: " + j + " / Qty: " + itemsQty[j]);

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

        private bool SetActorPosition(short? TargetActorID = null, float? Target_x = null, float? Target_y = null, float? Target_z = null, float? Target_rot = null, bool Target_swimming = false)
        {
            Process process = memoryWatchers.Process;

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

                        if (!(Target_x is null))
                        {
                            WriteValue<float>(characterPos_x, Target_x);
                        }
                        if (!(Target_y is null))
                        {
                            if (!Target_swimming)
                            {
                                WriteValue<float>(characterPos_floor, Target_y); // Always set floor to be the target y value when not swimming
                            }
                            
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
                    }
                }
            }
            return actorFound;
        }
    }
}
