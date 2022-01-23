using FFX_Cutscene_Remover.ComponentUtil;
using FFXCutsceneRemover.Logging;
using FFXCutsceneRemover.Resources;
using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Text.Json;
using System.IO;
using MathNet.Numerics.Distributions;
using MathNet.Numerics.Statistics;

namespace FFXCutsceneRemover
{
    class RandoShopTransition : Transition
    {
        RandoOptions options = JsonSerializer.Deserialize<RandoOptions>(File.ReadAllText(@".\RandomiserOptions.json"));

        public int shopID = 0;
        public int shopTier = 0;
        public int shopSize = 14;

        private bool shopRandomised = false;

        byte[] baseEquipmentBytes = new byte[] { 0x00, 0x50, 0x00, 0x00, 0x00, 0x00, 0xFF, 0x00, 0x01, 0x10, 0x03, 0x00, 0x00, 0x00, 0xFF, 0x00, 0xFF, 0x00, 0xFF, 0x00, 0xFF, 0x00 };
        byte[] shopEquipmentBytes = new byte[] { };

        byte[][] slotChanceTiered = new byte[][]
        {
            new byte[] { 100, 100, 100, 100 }, // Tier 0 - Besaid to Mi'ihen
            new byte[] { 050, 100, 100, 100 }, // Tier 1 - MRR to Djose
            new byte[] { 000, 100, 100, 100 }, // Tier 2 - Guadosalam to Rin (Escaping Home)
            new byte[] { 000, 010, 075, 100 }, // Tier 3 - Calm Lands to Wantz
            new byte[] { 000, 000, 000, 100 }, // Tier 4 - Post-Airship
        };

        byte[][] abilityChanceBySlots = new byte[][]
        {
            new byte[] { 100, 100, 100, 100 }, // 1 slot
            new byte[] { 090, 100, 100, 100 }, // 2 slot
            new byte[] { 070, 090, 100, 100 }, // 3 slot
            new byte[] { 040, 070, 090, 100 }, // 4 slot
        };

        byte[][] weaponAbilitiesTiered = new byte[][]
        {
            new byte[] // Besaid to Mi'ihen
            {
                0x0B, // Piercing
                0x7C, // Distill Power
                0x7D, // Distill Mana
                0x7E, // Distill Speed
                0x7F, // Distill Ability
                0x62, // Strength +3%
                0x66, // Magic +3%
                0x00, // Sensor
                0x63, // Strength +5%
                0x67, // Magic +5%
                0x1E, // Firestrike
                0x22, // Icestrike
                0x26, // Lightningstrike
                0x2A, // Waterstrike
                0x3F, // Sleeptouch
                0x3B, // Poisontouch
                0x47, // Darktouch
                0x43, // Silencetouch
                0x4B // Slowtouch
            },
            new byte[] // MRR to Djose
            {
                0x0B, // Piercing
                0x7C, // Distill Power
                0x7D, // Distill Mana
                0x7E, // Distill Speed
                0x7F, // Distill Ability
                0x62, // Strength +3%
                0x66, // Magic +3%
                0x00, // Sensor
                0x63, // Strength +5%
                0x67, // Magic +5%
                0x1E, // Firestrike
                0x22, // Icestrike
                0x26, // Lightningstrike
                0x2A, // Waterstrike
                0x3F, // Sleeptouch
                0x3B, // Poisontouch
                0x47, // Darktouch
                0x43, // Silencetouch
                0x4B, // Slowtouch
                0x03, // Counterattack
                0x46, // Darkstrike
                0x37, // Stonetouch
                0x64, // Strength +10%
                0x68, // Magic +10%
                //0x01, // First Strike - Omitted at this tier as it is too early to get first strike
                0x02, // Initiative
                0x07, // Alchemy
                0x2F, // Deathtouch
                0x33, // Zombietouch
                0x3E, // Sleepstrike
                0x42, // Silencestrike
                0x4A // Slowstrike
            },
            new byte[] // Guadosalam to Rin (Escaping Home) - Remove lower value touch abilities, STR+% / MAG+% and Distill Abilities
            {
                0x0B, // Piercing
                //0x7C, // Distill Power
                //0x7D, // Distill Mana
                //0x7E, // Distill Speed
                //0x7F, // Distill Ability
                //0x62, // Strength +3%
                //0x66, // Magic +3%
                0x63, // Strength +5%
                0x67, // Magic +5%
                0x1E, // Firestrike
                0x22, // Icestrike
                0x26, // Lightningstrike
                0x2A, // Waterstrike
                //0x3F, // Sleeptouch
                //0x3B, // Poisontouch
                //0x47, // Darktouch
                //0x43, // Silencetouch
                //0x4B, // Slowtouch
                0x03, // Counterattack
                0x46, // Darkstrike
                0x37, // Stonetouch
                0x64, // Strength +10%
                0x68, // Magic +10%
                0x01, // First Strike
                0x02, // Initiative
                0x07, // Alchemy
                0x2F, // Deathtouch
                0x33, // Zombietouch
                0x3E, // Sleepstrike
                0x42, // Silencestrike
                0x4A, // Slowstrike
                0x3A, // Poisonstrike
                0x65, // Strength +20%
                0x69, // Magic +20%
                0x32, // Zombiestrike
                0x36, // Stonestrike
                0x06 // Magic Booster
            },
            new byte[] // Calm Lands to Wantz - Remove Elemental Strikes
            {
                0x0B, // Piercing
                //0x7C, // Distill Power
                //0x7D, // Distill Mana
                //0x7E, // Distill Speed
                //0x7F, // Distill Ability
                //0x62, // Strength +3%
                //0x66, // Magic +3%
                0x63, // Strength +5%
                0x67, // Magic +5%
                //0x1E, // Firestrike
                //0x22, // Icestrike
                //0x26, // Lightningstrike
                //0x2A, // Waterstrike
                //0x3F, // Sleeptouch
                //0x3B, // Poisontouch
                //0x47, // Darktouch
                //0x43, // Silencetouch
                //0x4B, // Slowtouch
                0x03, // Counterattack
                0x46, // Darkstrike
                0x37, // Stonetouch
                0x64, // Strength +10%
                0x68, // Magic +10%
                0x01, // First Strike
                0x02, // Initiative
                0x07, // Alchemy
                0x2F, // Deathtouch
                0x33, // Zombietouch
                0x3E, // Sleepstrike
                0x42, // Silencestrike
                0x4A, // Slowstrike
                0x3A, // Poisonstrike
                0x65, // Strength +20%
                0x69, // Magic +20%
                0x32, // Zombiestrike
                0x36, // Stonestrike
                0x06, // Magic Booster
                0x0C, // Half MP Cost
                0x10, // SOS Overdrive
                0x2E, // Deathstrike
                0x04, // Evade & Counter
                0x05, // Magic Counter
                0x11, // Overdrive -> AP
                0x0D, // One MP Cost
                0x0E, // Double Overdrive
                0x0F, // Triple Overdrive
                0x12, // Double AP
                0x13 // Triple AP
            },
            new byte[] // Post-Airship
            {
                0x0B, // Piercing
                //0x7C, // Distill Power
                //0x7D, // Distill Mana
                //0x7E, // Distill Speed
                //0x7F, // Distill Ability
                //0x62, // Strength +3%
                //0x66, // Magic +3%
                0x63, // Strength +5%
                0x67, // Magic +5%
                //0x1E, // Firestrike
                //0x22, // Icestrike
                //0x26, // Lightningstrike
                //0x2A, // Waterstrike
                //0x3F, // Sleeptouch
                //0x3B, // Poisontouch
                //0x47, // Darktouch
                //0x43, // Silencetouch
                //0x4B, // Slowtouch
                0x03, // Counterattack
                0x46, // Darkstrike
                0x37, // Stonetouch
                0x64, // Strength +10%
                0x68, // Magic +10%
                0x01, // First Strike
                0x02, // Initiative
                0x07, // Alchemy
                0x2F, // Deathtouch
                0x33, // Zombietouch
                0x3E, // Sleepstrike
                0x42, // Silencestrike
                0x4A, // Slowstrike
                0x3A, // Poisonstrike
                0x65, // Strength +20%
                0x69, // Magic +20%
                0x32, // Zombiestrike
                0x36, // Stonestrike
                0x06, // Magic Booster
                0x0C, // Half MP Cost
                0x10, // SOS Overdrive
                0x2E, // Deathstrike
                0x04, // Evade & Counter
                0x05, // Magic Counter
                0x11, // Overdrive -> AP
                0x0D, // One MP Cost
                0x0E, // Double Overdrive
                0x0F, // Triple Overdrive
                0x12, // Double AP
                0x13 // Triple AP
            }
        };

        byte[][] armorAbilitiesTiered = new byte[][]
        {
            new byte[] // Besaid to Mi'ihen
            {
                0x72, // HP +5%
                0x41, // Sleep Ward
                0x6A, // Defense +3%
                0x6E, // Magic Def +3%
                0x3D, // Poison Ward
                0x45, // Silence Ward
                0x49, // Dark Ward
                0x5E, // SOS NulTide
                0x5F, // SOS NulFrost
                0x60, // SOS NulShock
                0x61, // SOS NulBlaze
                0x6B, // Defense +5%
                0x6F, // Magic Def +5%
                0x40, // Sleepproof
                0x4D, // Slow Ward
                0x4F, // Confuse Ward
                0x51, // Berserk Ward
                0x73, // HP +10%
                0x39, // Stone Ward
                0x76, // MP +5%
                0x1F, // Fire Ward
                0x23, // Ice Ward
                0x27, // Lightning Ward
                0x2B, // Water Ward
                0x3C, // Poisonproof
                0x31, // Death Ward
                0x35, // Zombie Ward
                0x44, // Silenceproof
                0x48, // Darkproof
                0x38, // Stoneproof
                0x20, // Fireproof
                0x24, // Iceproof
                0x28, // Lightningproof
                0x2c, // Waterproof
                0x4c, // Slowproof
                0x5d // SOS Reflect
            },
            new byte[] // MRR to Djose
            {
                0x72, // HP +5%
                0x41, // Sleep Ward
                0x6A, // Defense +3%
                0x6E, // Magic Def +3%
                0x3D, // Poison Ward
                0x45, // Silence Ward
                0x49, // Dark Ward
                0x5E, // SOS NulTide
                0x5F, // SOS NulFrost
                0x60, // SOS NulShock
                0x61, // SOS NulBlaze
                0x6B, // Defense +5%
                0x6F, // Magic Def +5%
                0x40, // Sleepproof
                0x4D, // Slow Ward
                0x4F, // Confuse Ward
                0x51, // Berserk Ward
                0x73, // HP +10%
                0x39, // Stone Ward
                0x76, // MP +5%
                0x1F, // Fire Ward
                0x23, // Ice Ward
                0x27, // Lightning Ward
                0x2B, // Water Ward
                0x3C, // Poisonproof
                0x31, // Death Ward
                0x35, // Zombie Ward
                0x44, // Silenceproof
                0x48, // Darkproof
                0x38, // Stoneproof
                0x20, // Fireproof
                0x24, // Iceproof
                0x28, // Lightningproof
                0x2c, // Waterproof
                0x4c, // Slowproof
                0x5d, // SOS Reflect
                0x30, // Deathproof
                0x34, // Zombieproof
                0x4E, // Confuseproof
                0x50, // Berserkproof
                0x59, // SOS Shell
                0x5A, // SOS Protect
                0x6C, // Defense +10%
                0x70, // Magic Def +10%
                0x1B, // HP Stroll
                0x1C, // MP Stroll
                0x74, // HP +20%
                0x77, // MP +10%
                //0x1D, // No Encounters - No Encounters removed as it feels too cheap for what it does
                0x52, // Curseproof
                0x78 // MP +20%
            },
            new byte[] // Guadosalam to Rin (Escaping Home) - Remove lower value ward / SOS abilities and DEF+% / MDEF+%
            {
                0x72, // HP +5%
                //0x41, // Sleep Ward
                //0x6A, // Defense +3%
                //0x6E, // Magic Def +3%
                //0x3D, // Poison Ward
                //0x45, // Silence Ward
                //0x49, // Dark Ward
                //0x5E, // SOS NulTide
                //0x5F, // SOS NulFrost
                //0x60, // SOS NulShock
                //0x61, // SOS NulBlaze
                0x6B, // Defense +5%
                0x6F, // Magic Def +5%
                0x40, // Sleepproof
                //0x4D, // Slow Ward
                //0x4F, // Confuse Ward
                //0x51, // Berserk Ward
                0x73, // HP +10%
                0x39, // Stone Ward
                0x76, // MP +5%
                0x1F, // Fire Ward
                0x23, // Ice Ward
                0x27, // Lightning Ward
                0x2B, // Water Ward
                0x3C, // Poisonproof
                0x31, // Death Ward
                0x35, // Zombie Ward
                0x44, // Silenceproof
                0x48, // Darkproof
                0x38, // Stoneproof
                0x20, // Fireproof
                0x24, // Iceproof
                0x28, // Lightningproof
                0x2c, // Waterproof
                0x4c, // Slowproof
                0x5d, // SOS Reflect
                0x30, // Deathproof
                0x34, // Zombieproof
                0x4E, // Confuseproof
                0x50, // Berserkproof
                0x59, // SOS Shell
                0x5A, // SOS Protect
                0x6C, // Defense +10%
                0x70, // Magic Def +10%
                0x1B, // HP Stroll
                0x1C, // MP Stroll
                0x74, // HP +20%
                0x77, // MP +10%
                //0x1D, // No Encounters - No Encounters removed as it feels too cheap for what it does
                0x52, // Curseproof
                0x78, // MP +20%
                0x09, // Auto-Med
                0x21, // Fire Eater
                0x25, // Ice Eater
                0x29, // Lightning Eater
                0x2D, // Water Eater
                0x6D, // Defense +20%
                0x71, // Magic Def +20%
                0x08, // Auto-Potion
                0x58, // Auto-Reflect
                0x75, // HP +30%
                0x79 // MP +30%
            },
            new byte[] // Calm Lands to Wantz - Remove Elemental Wards
            {
                0x72, // HP +5%
                //0x41, // Sleep Ward
                //0x6A, // Defense +3%
                //0x6E, // Magic Def +3%
                //0x3D, // Poison Ward
                //0x45, // Silence Ward
                //0x49, // Dark Ward
                //0x5E, // SOS NulTide
                //0x5F, // SOS NulFrost
                //0x60, // SOS NulShock
                //0x61, // SOS NulBlaze
                0x6B, // Defense +5%
                0x6F, // Magic Def +5%
                0x40, // Sleepproof
                //0x4D, // Slow Ward
                //0x4F, // Confuse Ward
                //0x51, // Berserk Ward
                0x73, // HP +10%
                0x39, // Stone Ward
                0x76, // MP +5%
                //0x1F, // Fire Ward
                //0x23, // Ice Ward
                //0x27, // Lightning Ward
                //0x2B, // Water Ward
                0x3C, // Poisonproof
                0x31, // Death Ward
                0x35, // Zombie Ward
                0x44, // Silenceproof
                0x48, // Darkproof
                0x38, // Stoneproof
                0x20, // Fireproof
                0x24, // Iceproof
                0x28, // Lightningproof
                0x2c, // Waterproof
                0x4c, // Slowproof
                0x5d, // SOS Reflect
                0x30, // Deathproof
                0x34, // Zombieproof
                0x4E, // Confuseproof
                0x50, // Berserkproof
                0x59, // SOS Shell
                0x5A, // SOS Protect
                0x6C, // Defense +10%
                0x70, // Magic Def +10%
                0x1B, // HP Stroll
                0x1C, // MP Stroll
                0x74, // HP +20%
                0x77, // MP +10%
                //0x1D, // No Encounters - No Encounters removed as it feels too cheap for what it does
                0x52, // Curseproof
                0x78, // MP +20%
                0x09, // Auto-Med
                0x21, // Fire Eater
                0x25, // Ice Eater
                0x29, // Lightning Eater
                0x2D, // Water Eater
                0x6D, // Defense +20%
                0x71, // Magic Def +20%
                0x08, // Auto-Potion
                0x58, // Auto-Reflect
                0x75, // HP +30%
                0x79, // MP +30%
                0x0A, // Auto-Phoenix
                0x5B, // SOS Haste
                0x5C, // SOS Regen
                0x54, // Auto-Shell
                0x55, // Auto-Protect
                0x15, // Pickpocket
                0x56, // Auto-Haste
                0x16, // Master Thief
                0x57, // Auto-Regen
                0x80 // Ribbon
            },
            new byte[] // Post-Airship
            {
                0x72, // HP +5%
                //0x41, // Sleep Ward
                //0x6A, // Defense +3%
                //0x6E, // Magic Def +3%
                //0x3D, // Poison Ward
                //0x45, // Silence Ward
                //0x49, // Dark Ward
                //0x5E, // SOS NulTide
                //0x5F, // SOS NulFrost
                //0x60, // SOS NulShock
                //0x61, // SOS NulBlaze
                0x6B, // Defense +5%
                0x6F, // Magic Def +5%
                0x40, // Sleepproof
                //0x4D, // Slow Ward
                //0x4F, // Confuse Ward
                //0x51, // Berserk Ward
                0x73, // HP +10%
                0x39, // Stone Ward
                0x76, // MP +5%
                //0x1F, // Fire Ward
                //0x23, // Ice Ward
                //0x27, // Lightning Ward
                //0x2B, // Water Ward
                0x3C, // Poisonproof
                0x31, // Death Ward
                0x35, // Zombie Ward
                0x44, // Silenceproof
                0x48, // Darkproof
                0x38, // Stoneproof
                0x20, // Fireproof
                0x24, // Iceproof
                0x28, // Lightningproof
                0x2c, // Waterproof
                0x4c, // Slowproof
                0x5d, // SOS Reflect
                0x30, // Deathproof
                0x34, // Zombieproof
                0x4E, // Confuseproof
                0x50, // Berserkproof
                0x59, // SOS Shell
                0x5A, // SOS Protect
                0x6C, // Defense +10%
                0x70, // Magic Def +10%
                0x1B, // HP Stroll
                0x1C, // MP Stroll
                0x74, // HP +20%
                0x77, // MP +10%
                //0x1D, // No Encounters - No Encounters removed as it feels too cheap for what it does
                0x52, // Curseproof
                0x78, // MP +20%
                0x09, // Auto-Med
                0x21, // Fire Eater
                0x25, // Ice Eater
                0x29, // Lightning Eater
                0x2D, // Water Eater
                0x6D, // Defense +20%
                0x71, // Magic Def +20%
                0x08, // Auto-Potion
                0x58, // Auto-Reflect
                0x75, // HP +30%
                0x79, // MP +30%
                0x0A, // Auto-Phoenix
                0x5B, // SOS Haste
                0x5C, // SOS Regen
                0x54, // Auto-Shell
                0x55, // Auto-Protect
                0x15, // Pickpocket
                0x56, // Auto-Haste
                0x16, // Master Thief
                0x57, // Auto-Regen
                0x80 // Ribbon
            }
        };

        int[] shopOffsets = new int[]
        {
            0x124111A, // Besaid (Pre-Airship)
            0x12411CA, // Kilika (Pre-Airship)
            0x12412A6, // Luca (Pre-Airship)
            0x12413AE, // O'aka Luca (Pre-Airship)
            0x1241432, // Mi'ihen Agency (Pre-Airship)
            0x124153A, // O'aka MRR Entrance (Pre-Airship)
            0x12415D4, // O'aka MRR Command (Pre-Airship)
            0x124169A, // Djose Inn (Pre-Airship)
            0x12417A2, // Moonflow - Thin Man (Pre-Airship)
            0x1241810, // Moonflow - Woman in White (Pre-Airship)
            0x124187E, // Moonflow - Woman in Green (Pre-Airship)
            0x1241902, // Moonflow - Fat Man (Pre-Airship)
            0x1241986, // Moonflow - O'aka (Pre-Airship)
            0x1241A0A, // O'aka Guadosalam (Pre-Airship)
            0x1241B28, // Guadosalam Shop (Pre-Airship)
            0x1241C5C, // Thunder Plains Agency (Pre-Airship)
            0x1241D90, // O'aka Macalania Woods (Pre-Airship)
            0x1241E2A, // Lake Macalania Agency (Pre-Airship)
            0x1241F74, // O'aka Lake Macalania (Pre-Airship)
            0x1242024, // Rin Airship (Escaping Home)
            0x1242158, // Rin's Mobile Agency (Hovercraft)
            0x12421F2, // Calm Lands Agency (Pre-Airship)
            0x1242326, // Gagazet Mountain Gate (Pre-Airship)
            0x124245A, // Wantz Gagazet
            0x124258E, // Wantz Macalania
            0x12426C2, // Besaid (Post-Airship)
            0x12427F6, // Kilika (Post-Airship)
            0x124292A, // Luca Square (Post-Airship)
            0x1242A5E, // Luca Reception (Post-Airship)
            0x1242B92, // Mi'ihen Agency (Post-Airship)
            0x1242CC6, // Djose Inn (Post-Airship)
            0x1242DFA, // Guadosalam Shop (Post-Airship)
            0x1242F2E, // Thunder Plains Agency (Post-Airship)
            0x1243062, // Lake Macalania Agency (Post-Airship)
            0x1243196, // Rin Airship
            0x12432CA, // Calm Lands Agency (Post-Airship)
            0x12433FE, // Gagazet Mountain Gate (Post-Airship)
            0x1243532, // Monster Arena
        };

        byte[][] activeCharactersArray = new byte[][]
        {
            new byte[] { 0x00, 0x01, 0x04, 0x05 },                      // Besaid (Pre-Airship)
            new byte[] { 0x00, 0x01, 0x03, 0x04, 0x05 },                // Kilika (Pre-Airship)
            new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05 },          // Luca (Pre-Airship)
            new byte[] { 0x00, 0x03, 0x05 },                            // O'aka Luca (Pre-Airship)
            new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05 },          // Mi'ihen Agency (Pre-Airship)
            new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05 },          // O'aka MRR Entrance (Pre-Airship)
            new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05 },          // O'aka MRR Command (Pre-Airship)
            new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05 },          // Djose Inn (Pre-Airship)
            new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05 },          // Moonflow - Thin Man (Pre-Airship)
            new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05 },          // Moonflow - Woman in White (Pre-Airship)
            new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05 },          // Moonflow - Woman in Green (Pre-Airship)
            new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05 },          // Moonflow - Fat Man (Pre-Airship)
            new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05 },          // Moonflow - O'aka (Pre-Airship)
            new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06 },    // O'aka Guadosalam (Pre-Airship)
            new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06 },    // Guadosalam Shop (Pre-Airship)
            new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06 },    // Thunder Plains Agency (Pre-Airship)
            new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06 },    // O'aka Macalania Woods (Pre-Airship)
            new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06 },    // Lake Macalania Agency (Pre-Airship)
            new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06 },    // O'aka Lake Macalania (Pre-Airship)
            new byte[] { 0x00, 0x02, 0x03, 0x04, 0x05, 0x06 },          // Rin Airship (Escaping Home)
            new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06 },    // Rin's Mobile Agency (Hovercraft)
            new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06 },    // Calm Lands Agency (Pre-Airship)
            new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06 },    // Gagazet Mountain Gate (Pre-Airship)
            new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06 },    // Wantz Gagazet
            new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06 },    // Wantz Macalania
            new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06 },    // Besaid (Post-Airship)
            new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06 },    // Kilika (Post-Airship)
            new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06 },    // Luca Square (Post-Airship)
            new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06 },    // Luca Reception (Post-Airship)
            new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06 },    // Mi'ihen Agency (Post-Airship)
            new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06 },    // Djose Inn (Post-Airship)
            new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06 },    // Guadosalam Shop (Post-Airship)
            new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06 },    // Thunder Plains Agency (Post-Airship)
            new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06 },    // Lake Macalania Agency (Post-Airship)
            new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06 },    // Rin Airship
            new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06 },    // Calm Lands Agency (Post-Airship)
            new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06 },    // Gagazet Mountain Gate (Post-Airship)
            new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06 },    // Monster Arena
        };

        public override void Execute(string defaultDescription = "")
        {
            base.Execute();

            if (options.RandomiseShops == 1)
            {
                RandomiseShop();
            }
            
        }
        
        private void RandomiseShop()
        {
            int baseAddress = base.memoryWatchers.GetBaseAddress();

            if (!shopRandomised)
            {
                int weaponCount = shopSize / 2;
                int armorCount = shopSize - weaponCount;

                byte[] weaponBaseModel = new byte[] { 0x02, 0x0B, 0x15, 0x1F, 0x29, 0x33, 0x3D };
                byte[] armorBaseModel = new byte[] { 0x42, 0x47, 0x4C, 0x51, 0x56, 0x5B, 0x60 };

                byte[] activeCharacters = activeCharactersArray[shopID];
                List<byte> weaponCharacters = new List<byte>();
                List<byte> armorCharacters = new List<byte>();
                double[] weaponRoll = new double[] { };
                double[] armorRoll = new double[] { };

                for (int i = 0; i < activeCharacters.Length; i++)
                {
                    weaponCharacters.Add(activeCharacters[i]);
                    weaponRoll = weaponRoll.Append(ThreadSafeRandom.ThisThreadsRandom.NextDouble()).ToArray();
                }

                double[] weaponRanks = Statistics.Ranks(weaponRoll, RankDefinition.First);

                for (int i = 0; i < activeCharacters.Length; i++)
                {
                    if ((int)weaponRanks[i] > weaponCount)
                    {
                        weaponCharacters.Remove((byte)i);
                    }
                }

                for (int i = 0; i < activeCharacters.Length; i++)
                {
                    armorCharacters.Add(activeCharacters[i]);
                    armorRoll = armorRoll.Append(ThreadSafeRandom.ThisThreadsRandom.NextDouble()).ToArray();
                }

                double[] armorRanks = Statistics.Ranks(armorRoll, RankDefinition.First);

                for (int i = 0; i < activeCharacters.Length; i++)
                {
                    if ((int)armorRanks[i] > armorCount)
                    {
                        armorCharacters.Remove((byte)i);
                    }
                }

                foreach (double roll in weaponRoll)
                {
                    DiagnosticLog.Information("Weapon Roll: " + roll.ToString());
                }

                foreach (double rank in weaponRanks)
                {
                    DiagnosticLog.Information("Weapon Rank: " + rank.ToString());
                }

                DiagnosticLog.Information("Weapon Count: " + weaponCount.ToString());
                DiagnosticLog.Information("Armor Count: " + armorCount.ToString());

                DiagnosticLog.Information("Weapon Characters: " + weaponCharacters.Count.ToString());
                DiagnosticLog.Information("Armor Characters: " + armorCharacters.Count.ToString());

                for (int i = 0; i < shopSize; i++)
                {
                    byte equipmentOwner;
                    byte equipmentType;

                    if (i < weaponCount)
                    {
                        equipmentType = 0x00;
                        equipmentOwner = weaponCharacters[i];
                    }
                    else
                    {
                        equipmentType = 0x01;
                        equipmentOwner = armorCharacters[i - weaponCount];
                    }

                    int equipmentSlots = 0;
                    byte[] equipmentSlotChance = slotChanceTiered[shopTier];
                    int equipmentSlotRoll = ThreadSafeRandom.ThisThreadsRandom.Next(0, 100);

                    for (int j = 0; j < 4; j++)
                    {
                        if (equipmentSlotRoll < equipmentSlotChance[j])
                        {
                            equipmentSlots = j + 1;
                            break;
                        }
                    }

                    int abilityCount = 0;
                    byte[] abilityRollChance = abilityChanceBySlots[equipmentSlots - 1];
                    int abilityCountRoll = ThreadSafeRandom.ThisThreadsRandom.Next(0, 100);

                    for (int j = 0; j < 4; j++)
                    {
                        if (abilityCountRoll < abilityRollChance[j])
                        {
                            abilityCount = j + 1;
                            break;
                        }
                    }

                    byte[] validAbilities;
                    List<byte> equipmentAbilities = new List<byte>();

                    if (equipmentType == 0x00)
                    {
                        validAbilities = weaponAbilitiesTiered[shopTier];
                    }
                    else
                    {
                        validAbilities = armorAbilitiesTiered[shopTier];
                    }

                    for (int j = 0; j < abilityCount; j++)
                    {
                        int abilityRoll = ThreadSafeRandom.ThisThreadsRandom.Next(0, validAbilities.Length);
                        byte ability = validAbilities[abilityRoll];

                        while (equipmentAbilities.Contains(ability))
                        {
                            abilityRoll = ThreadSafeRandom.ThisThreadsRandom.Next(0, validAbilities.Length);
                            ability = validAbilities[abilityRoll];
                        }

                        equipmentAbilities = equipmentAbilities.Append(ability).ToList();
                    }

                    foreach (byte ability in equipmentAbilities)
                    {
                        DiagnosticLog.Information("Ability: " + ability.ToString());
                    }

                    byte equipmentName;

                    if (equipmentType == 0x00)
                    {
                        equipmentName = weaponName(equipmentAbilities, equipmentSlots);
                    }
                    else
                    {
                        equipmentName = armorName(equipmentAbilities, equipmentSlots);
                    }

                    shopEquipmentBytes = shopEquipmentBytes.Concat(baseEquipmentBytes).ToArray();

                    shopEquipmentBytes[22 * i + 0] = equipmentName;
                    shopEquipmentBytes[22 * i + 4] = equipmentOwner;
                    shopEquipmentBytes[22 * i + 5] = equipmentType;
                    shopEquipmentBytes[22 * i + 11] = (byte)equipmentSlots;

                    if(equipmentType == 0x00)
                    {
                        shopEquipmentBytes[22 * i + 12] = weaponBaseModel[equipmentOwner];
                        shopEquipmentBytes[22 * i + 13] = 0x40;
                    }
                    else
                    {
                        shopEquipmentBytes[22 * i + 12] = armorBaseModel[equipmentOwner];
                        shopEquipmentBytes[22 * i + 13] = 0x40;
                    }

                    for (int j = 0; j < equipmentAbilities.Count; j++)
                    {
                        shopEquipmentBytes[22 * i + 14 + 2 * j] = equipmentAbilities[j];
                        shopEquipmentBytes[22 * i + 15 + 2 * j] = 0x80;
                    }
                }
            }

            shopRandomised = true;

            MemoryWatcher<byte> shop = new MemoryWatcher<byte>(new IntPtr(baseAddress + shopOffsets[shopID]));

            WriteBytes(shop, shopEquipmentBytes);
        }

        private byte weaponName(List<byte> equipmentAbilities, int equipmentSlots)
        {
            byte[] elementalStrikes = new byte[] { 0x1E, 0x22, 0x26, 0x2A };
            byte[] statusStrikes = new byte[] { 0x2E, 0x32, 0x36, 0x3A, 0x3E, 0x42, 0x46, 0x4A };
            byte[] statusTouches = new byte[] { 0x2F, 0x33, 0x37, 0x3B, 0x3F, 0x43, 0x47, 0x4B };
            byte[] strengthBonuses = new byte[] { 0x62, 0x63, 0x64, 0x65 };
            byte[] magicBonuses = new byte[] { 0x66, 0x67, 0x68, 0x69 };

            int elementalStrikeCount = 0;
            int statusStrikeCount = 0;
            int statusTouchCount = 0;
            int strengthBonusCount = 0;
            int magicBonusCount = 0;

            foreach (byte ability in equipmentAbilities)
            {
                if (elementalStrikes.Contains(ability))
                {
                    elementalStrikeCount += 1;
                }
                else if (statusStrikes.Contains(ability))
                {
                    statusStrikeCount += 1;
                }
                else if (statusTouches.Contains(ability))
                {
                    statusTouchCount += 1;
                }
                else if (strengthBonuses.Contains(ability))
                {
                    strengthBonusCount += 1;
                }
                else if (magicBonuses.Contains(ability))
                {
                    magicBonusCount += 1;
                }
            }

            if (equipmentAbilities.Contains(0x7A))
            {
                // Capture
                return 0x02;
            }
            else if (elementalStrikeCount == 4)
            {
                // All four elemental -strikes
                return 0x03;
            }
            else if (equipmentAbilities.Contains(0x19))
            {
                // Break Damage Limit
                return 0x04;
            }
            else if (equipmentAbilities.Contains(0x0F) && equipmentAbilities.Contains(0x11) && equipmentAbilities.Contains(0x13))
            {
                // Triple Overdrive, Triple AP and Overdrive → AP
                return 0x05;
            }
            else if (equipmentAbilities.Contains(0x0F) && equipmentAbilities.Contains(0x11))
            {
                // Triple Overdrive and Overdrive → AP
                return 0x06;
            }
            else if (equipmentAbilities.Contains(0x0E) && equipmentAbilities.Contains(0x12))
            {
                // Double Overdrive and Double AP
                return 0x07;
            }
            else if (equipmentAbilities.Contains(0x0F))
            {
                // Triple Overdrive
                return 0x08;
            }
            else if (equipmentAbilities.Contains(0x0E))
            {
                // Double Overdrive
                return 0x09;
            }
            else if (equipmentAbilities.Contains(0x13))
            {
                // Triple AP
                return 0x0A;
            }
            else if (equipmentAbilities.Contains(0x12))
            {
                // Double AP
                return 0x0B;
            }
            else if (equipmentAbilities.Contains(0x11))
            {
                // Overdrive → AP
                return 0x0C;
            }
            else if (equipmentAbilities.Contains(0x10))
            {
                // SOS Overdrive
                return 0x0D;
            }
            else if (equipmentAbilities.Contains(0x0D))
            {
                // One MP Cost
                return 0x0F;
            }
            else if (statusStrikeCount == 4)
            {
                // Any four status -strike
                return 0x10;
            }
            else if (strengthBonusCount == 4)
            {
                // All four Strength +X%
                return 0x13;
            }
            else if (magicBonusCount == 4)
            {
                // All four Magic +X%
                return 0x14;
            }
            else if (equipmentAbilities.Contains(0x06) && magicBonusCount == 3)
            {
                // Magic Booster and three Magic +X%
                return 0x15;
            }
            else if (equipmentAbilities.Contains(0x0C))
            {
                // Half MP Cost
                return 0x16;
            }
            else if (equipmentAbilities.Contains(0x1A))
            {
                // Gillionaire
                return 0x17;
            }
            else if (elementalStrikeCount == 3)
            {
                // Any three elemental -strike
                return 0x18;
            }
            else if (statusStrikeCount == 3)
            {
                // Any three status -strike
                return 0x19;
            }
            else if (equipmentAbilities.Contains(0x05) && (equipmentAbilities.Contains(0x03) || equipmentAbilities.Contains(0x04)))
            {
                // Magic Counter and Counter-Attack or Evade & Counter
                return 0x1A;
            }
            else if (equipmentAbilities.Contains(0x03) || equipmentAbilities.Contains(0x04))
            {
                // Counter-Attack or Evade & Counter
                return 0x1B;
            }
            else if (equipmentAbilities.Contains(0x05))
            {
                // Magic Counter
                return 0x20;
            }
            else if (equipmentAbilities.Contains(0x06))
            {
                // Magic Booster
                return 0x21;
            }
            else if (equipmentAbilities.Contains(0x07))
            {
                // Alchemy
                return 0x22;
            }
            else if (equipmentAbilities.Contains(0x01))
            {
                // First Strike
                return 0x23;
            }
            else if (equipmentAbilities.Contains(0x02))
            {
                // Initiative
                return 0x24;
            }
            else if (equipmentAbilities.Contains(0x2E))
            {
                // Deathstrike
                return 0x25;
            }
            else if (equipmentAbilities.Contains(0x4A))
            {
                // Slowstrike
                return 0x26;
            }
            else if (equipmentAbilities.Contains(0x36))
            {
                // Stonestrike
                return 0x27;
            }
            else if (equipmentAbilities.Contains(0x3A))
            {
                // Poisonstrike
                return 0x28;
            }
            else if (equipmentAbilities.Contains(0x3E))
            {
                // Sleepstrike
                return 0x29;
            }
            else if (equipmentAbilities.Contains(0x42))
            {
                // Silencestrike
                return 0x2A;
            }
            else if (equipmentAbilities.Contains(0x46))
            {
                // Darkstrike
                return 0x2B;
            }
            else if (strengthBonusCount == 3)
            {
                // Any three Strength +X%
                return 0x2C;
            }
            else if (magicBonusCount == 3)
            {
                // Any three Magic +X%
                return 0x2D;
            }
            else if (elementalStrikeCount == 2)
            {
                // Any two elemental -strike
                return 0x2E;
            }
            else if (statusTouchCount >= 2)
            {
                // Any two status -touch
                return 0x2F;
            }
            else if (equipmentAbilities.Contains(0x2F))
            {
                // Deathtouch
                return 0x30;
            }
            else if (equipmentAbilities.Contains(0x4B))
            {
                // Slowtouch
                return 0x31;
            }
            else if (equipmentAbilities.Contains(0x37))
            {
                // Stonetouch
                return 0x32;
            }
            else if (equipmentAbilities.Contains(0x3B))
            {
                // Poisontouch
                return 0x33;
            }
            else if (equipmentAbilities.Contains(0x3F))
            {
                // Sleeptouch
                return 0x34;
            }
            else if (equipmentAbilities.Contains(0x43))
            {
                // Silencetouch
                return 0x35;
            }
            else if (equipmentAbilities.Contains(0x47))
            {
                // Darktouch
                return 0x36;
            }
            else if (equipmentAbilities.Contains(0x00))
            {
                // Sensor
                return 0x37;
            }
            else if (equipmentAbilities.Contains(0x1E))
            {
                // Firestrike
                return 0x38;
            }
            else if (equipmentAbilities.Contains(0x22))
            {
                // Icestrike
                return 0x39;
            }
            else if (equipmentAbilities.Contains(0x26))
            {
                // Lightningstrike
                return 0x3A;
            }
            else if (equipmentAbilities.Contains(0x2A))
            {
                // Waterstrike
                return 0x3B;
            }
            else if (equipmentAbilities.Contains(0x7C))
            {
                // Distill Power
                return 0x1C;
            }
            else if (equipmentAbilities.Contains(0x7D))
            {
                // Distill Mana
                return 0x1D;
            }
            else if (equipmentAbilities.Contains(0x7E))
            {
                // Distill Speed
                return 0x1E;
            }
            else if (equipmentAbilities.Contains(0x7F))
            {
                // Distill Ability
                return 0x1F;
            }
            else if (equipmentSlots == 4)
            {
                // 4-slot weapon
                return 0x3C;
            }
            else if (strengthBonusCount >= 1 && magicBonusCount >= 1)
            {
                // Magic +X% and Strength +X%
                return 0x3D;
            }
            else if (equipmentSlots == 2 || equipmentSlots == 3)
            {
                // 2 or 3 slot weapon
                return 0x3E;
            }
            else if (equipmentAbilities.Contains(0x68) || equipmentAbilities.Contains(0x69))
            {
                // Magic +10% or Magic +20%
                return 0x3F;
            }
            else if (equipmentAbilities.Contains(0x64) || equipmentAbilities.Contains(0x65))
            {
                // Strength +10% or Strength +20%
                return 0x40;
            }
            else if (equipmentAbilities.Contains(0x67))
            {
                // Magic +5%
                return 0x41;
            }
            else if (equipmentAbilities.Contains(0x66))
            {
                // Magic +3%
                return 0x42;
            }
            else if (equipmentAbilities.Contains(0x63))
            {
                // Strength +5%
                return 0x43;
            }
            else if (equipmentAbilities.Contains(0x62))
            {
                // Strength +3%
                return 0x44;
            }
            else if (equipmentAbilities.Contains(0x0B))
            {
                // Piercing
                return 0x45;
            }
            else if (equipmentSlots == 1)
            {
                // One slot
                return 0x46;
            }
            else
            {
                // No slots
                return 0x46;
            }
        }

        private byte armorName(List<byte> equipmentAbilities, int equipmentSlots)
        {
            byte[] elementalEaters = new byte[] { 0x21, 0x25, 0x29, 0x2D };
            byte[] elementalProofs = new byte[] { 0x20, 0x24, 0x28, 0x2C };
            byte[] statusProofs = new byte[] { 0x30, 0x34, 0x38, 0x3C, 0x40, 0x44, 0x48, 0x4C, 0x4E, 0x50, 0x52 };
            byte[] defenseBonuses = new byte[] { 0x6A, 0x6B, 0x6C, 0x6D };
            byte[] magicDefenseBonuses = new byte[] { 0x6E, 0x6F, 0x70, 0x71 };
            byte[] hpBonuses = new byte[] { 0x72, 0x73, 0x74, 0x75 };
            byte[] mpBonuses = new byte[] { 0x76, 0x77, 0x78, 0x79 };
            byte[] autoStatuses = new byte[] { 0x54, 0x55, 0x56, 0x57, 0x58 };
            byte[] elementalSOS = new byte[] { 0x5E, 0x5F, 0x60, 0x61, 0x62 };
            byte[] statusSOS = new byte[] { 0x59, 0x5A, 0x5B, 0x5C, 0x5D };

            int elementalEaterCount = 0;
            int elementalProofCount = 0;
            int statusProofCount = 0;
            int defenseBonusCount = 0;
            int magicDefenseBonusCount = 0;
            int hpBonusCount = 0;
            int mpBonusCount = 0;
            int autoStatusCount = 0;
            int elementalSOSCount = 0;
            int statusSOSCount = 0;

            foreach (byte ability in equipmentAbilities)
            {
                if (elementalEaters.Contains(ability))
                {
                    elementalEaterCount += 1;
                }
                else if (elementalProofs.Contains(ability))
                {
                    elementalProofCount += 1;
                }
                else if (statusProofs.Contains(ability))
                {
                    statusProofCount += 1;
                }
                else if (defenseBonuses.Contains(ability))
                {
                    defenseBonusCount += 1;
                }
                else if (magicDefenseBonuses.Contains(ability))
                {
                    magicDefenseBonusCount += 1;
                }
                if (hpBonuses.Contains(ability))
                {
                    hpBonusCount += 1;
                }
                else if (mpBonuses.Contains(ability))
                {
                    mpBonusCount += 1;
                }
                else if (autoStatuses.Contains(ability))
                {
                    autoStatusCount += 1;
                }
                else if (elementalSOS.Contains(ability))
                {
                    elementalSOSCount += 1;
                }
                else if (statusSOS.Contains(ability))
                {
                    statusSOSCount += 1;
                }
            }

            if (equipmentAbilities.Contains(0x17) && equipmentAbilities.Contains(0x18))
            {
                // Break HP Limit and Break MP Limit
                return 0x4A;
            }
            else if (equipmentAbilities.Contains(0x80))
            {
                // Ribbon
                return 0x9E;
            }
            else if (equipmentAbilities.Contains(0x17))
            {
                // Break HP Limit
                return 0x4B;
            }
            else if (equipmentAbilities.Contains(0x18))
            {
                // Break MP Limit
                return 0x4C;
            }
            else if (elementalEaterCount == 4)
            {
                // Four elemental -eater abilities
                return 0x4D;
            }
            else if (elementalProofCount == 4)
            {
                // Four elemental -proof abilities
                return 0x4E;
            }
            else if (equipmentAbilities.Contains(0x54) && equipmentAbilities.Contains(0x55) && equipmentAbilities.Contains(0x88) && equipmentAbilities.Contains(0x87))
            {
                // Auto Shell, Auto Protect, Auto Reflect and Auto Regen
                return 0x4F;
            }
            else if (equipmentAbilities.Contains(0x08) && equipmentAbilities.Contains(0x09) && equipmentAbilities.Contains(0x0A))
            {
                // Auto-Potion, Auto Med and Auto Phoenix
                return 0x50;
            }
            else if (equipmentAbilities.Contains(0x08) && equipmentAbilities.Contains(0x09))
            {
                // Auto Potion and Auto Med
                return 0x51;
            }
            else if (statusProofCount == 4)
            {
                // Any four status -proof abilities
                return 0x52;
            }
            else if (defenseBonusCount == 4)
            {
                // All four Defense +X%
                return 0x53;
            }
            else if (magicDefenseBonusCount == 4)
            {
                // All four Magic Defense +X%
                return 0x54;
            }
            else if (hpBonusCount == 4)
            {
                // All four HP +X%
                return 0x55;
            }
            else if (mpBonusCount == 4)
            {
                // All four MP +X%
                return 0x56;
            }
            else if (equipmentAbilities.Contains(0x16))
            {
                // Master Thief
                return 0x57;
            }
            else if (equipmentAbilities.Contains(0x15))
            {
                // Pickpocket
                return 0x58;
            }
            else if (equipmentAbilities.Contains(0x1B) && equipmentAbilities.Contains(0x1C))
            {
                // HP Stroll and MP Stroll
                return 0x59;
            }
            else if (autoStatusCount == 3)
            {
                // Any three auto- status abilities
                return 0x5A;
            }
            else if (elementalEaterCount == 3)
            {
                // Any three -eater abilities
                return 0x5B;
            }
            else if (equipmentAbilities.Contains(0x1B))
            {
                // HP Stroll
                return 0x5C;
            }
            else if (equipmentAbilities.Contains(0x1C))
            {
                // MP Stroll
                return 0x5D;
            }
            else if (equipmentAbilities.Contains(0x0A))
            {
                // Auto Phoenix
                return 0x5E;
            }
            else if (equipmentAbilities.Contains(0x09))
            {
                // Auto Med
                return 0x5F;
            }
            else if (elementalSOSCount == 4)
            {
                // Four elemental SOS- abilities
                return 0x60;
            }
            else if (statusSOSCount == 4)
            {
                // Any four SOS- status abilities
                return 0x61;
            }
            else if (statusProofCount == 3)
            {
                // Any three status -proof abilities
                return 0x62;
            }
            else if (equipmentAbilities.Contains(0x1D))
            {
                // No Encounters
                return 0x63;
            }
            else if (equipmentAbilities.Contains(0x08))
            {
                // Auto Potion
                return 0x64;
            }
            else if (elementalProofCount == 3)
            {
                // Any three elemental -proof abilities
                return 0x65;
            }
            else if (statusSOSCount == 3)
            {
                // Any three SOS- status abilities
                return 0x66;
            }
            else if (autoStatusCount == 2)
            {
                // Any two auto- status abilities
                return 0x67;
            }
            else if (elementalSOSCount == 2)
            {
                // Any two elemental SOS- abilities
                return 0x68;
            }
            else if (equipmentAbilities.Contains(0x57) || equipmentAbilities.Contains(0x5C))
            {
                // Auto Regen or SOS Regen
                return 0x69;
            }
            else if (equipmentAbilities.Contains(0x56) || equipmentAbilities.Contains(0x5B))
            {
                // Auto Haste or SOS Haste
                return 0x6A;
            }
            else if (equipmentAbilities.Contains(0x58) || equipmentAbilities.Contains(0x5D))
            {
                // Auto Reflect or SOS Reflect
                return 0x6B;
            }
            else if (equipmentAbilities.Contains(0x84) || equipmentAbilities.Contains(0x59))
            {
                // Auto Shell or SOS Shell
                return 0x6C;
            }
            else if (equipmentAbilities.Contains(0x55) || equipmentAbilities.Contains(0x5A))
            {
                // Auto Protect or SOS Protect
                return 0x6D;
            }
            else if (defenseBonusCount == 3)
            {
                // Any three Defense +X%
                return 0x6F;
            }
            else if (magicDefenseBonusCount == 3)
            {
                // Any three Magic Defense +X%
                return 0x70;
            }
            else if (hpBonusCount == 3)
            {
                // Any three HP +X%
                return 0x71;
            }
            else if (mpBonusCount == 3)
            {
                // Any three MP +X%
                return 0x72;
            }
            else if (elementalEaterCount + elementalProofCount >= 2)
            {
                // Any two elemental -proof or -eater of different elements
                return 0x73;
            }
            else if (statusProofCount == 2)
            {
                // Any two status -proof abilities
                return 0x74;
            }
            else if (equipmentAbilities.Contains(0x21))
            {
                // Fire Eater
                return 0x75;
            }
            else if (equipmentAbilities.Contains(0x25))
            {
                // Ice Eater
                return 0x76;
            }
            else if (equipmentAbilities.Contains(0x29))
            {
                // Lightning Eater
                return 0x77;
            }
            else if (equipmentAbilities.Contains(0x2D))
            {
                // Water Eater
                return 0x78;
            }
            else if (equipmentAbilities.Contains(0x52))
            {
                // Curseproof
                return 0x79;
            }
            else if (equipmentAbilities.Contains(0x4E) || equipmentAbilities.Contains(0x4F))
            {
                // Confuse Ward/Proof
                return 0x7A;
            }
            else if (equipmentAbilities.Contains(0x50) || equipmentAbilities.Contains(0x51))
            {
                // Berserk Ward/Proof
                return 0x7B;
            }
            else if (equipmentAbilities.Contains(0x4C) || equipmentAbilities.Contains(0x4D))
            {
                // Slow Ward/Proof
                return 0x7C;
            }
            else if (equipmentAbilities.Contains(0x30) || equipmentAbilities.Contains(0x31))
            {
                // Death Ward/Proof
                return 0x7D;
            }
            else if (equipmentAbilities.Contains(0x34) || equipmentAbilities.Contains(0x35))
            {
                // Zombie Ward/Proof
                return 0x7E;
            }
            else if (equipmentAbilities.Contains(0x38) || equipmentAbilities.Contains(0x39))
            {
                // Stone Ward/Proof
                return 0x7F;
            }
            else if (equipmentAbilities.Contains(0x3C) || equipmentAbilities.Contains(0x3D))
            {
                // Poison Ward/Proof
                return 0x80;
            }
            else if (equipmentAbilities.Contains(0x40) || equipmentAbilities.Contains(0x41))
            {
                // Sleep Ward/Proof
                return 0x81;
            }
            else if (equipmentAbilities.Contains(0x44) || equipmentAbilities.Contains(0x45))
            {
                // Silence Ward/Proof
                return 0x82;
            }
            else if (equipmentAbilities.Contains(0x48) || equipmentAbilities.Contains(0x49))
            {
                // Dark Ward/Proof
                return 0x83;
            }
            else if (equipmentAbilities.Contains(0x1F) || equipmentAbilities.Contains(0x20))
            {
                // Fire Ward/Proof
                return 0x84;
            }
            else if (equipmentAbilities.Contains(0x23) || equipmentAbilities.Contains(0x24))
            {
                // Ice Ward/Proof
                return 0x85;
            }
            else if (equipmentAbilities.Contains(0x27) || equipmentAbilities.Contains(0x28))
            {
                // Lightning Ward/Proof
                return 0x86;
            }
            else if (equipmentAbilities.Contains(0x2B) || equipmentAbilities.Contains(0x2C))
            {
                // Water Ward/Proof
                return 0x87;
            }
            else if (equipmentAbilities.Contains(0x5E))
            {
                // SOS NulTide
                return 0x88;
            }
            else if (equipmentAbilities.Contains(0x61))
            {
                // SOS NulBlaze
                return 0x89;
            }
            else if (equipmentAbilities.Contains(0x60))
            {
                // SOS NulShock
                return 0x8A;
            }
            else if (equipmentAbilities.Contains(0x5F))
            {
                // SOS NulFrost
                return 0x8B;
            }
            else if (hpBonusCount == 2 && mpBonusCount == 2)
            {
                // Any two HP +X% and any two MP +X%
                return 0x8C;
            }
            else if (equipmentSlots == 4)
            {
                // Four slots
                return 0x8D;
            }
            else if (defenseBonusCount >= 1 && magicDefenseBonusCount >= 1)
            {
                // Defense +X% and Magic Defense +X%
                return 0x8E;
            }
            else if (defenseBonusCount == 2)
            {
                // Any two Defense +X%
                return 0x8F;
            }
            else if (magicDefenseBonusCount == 2)
            {
                // Any two Magic Defense +X%
                return 0x90;
            }
            else if (hpBonusCount == 2)
            {
                // Any two HP +X%
                return 0x91;
            }
            else if (mpBonusCount == 2)
            {
                // Any two MP +X%
                return 0x92;
            }
            else if (equipmentAbilities.Contains(0x6C) || equipmentAbilities.Contains(0x6D))
            {
                // Defense +10% or Defense +20%
                return 0x93;
            }
            else if (equipmentAbilities.Contains(0x70) || equipmentAbilities.Contains(0x71))
            {
                // Magic Defense +10% or Magic Defense +20%
                return 0x94;
            }
            else if (equipmentAbilities.Contains(0x78) || equipmentAbilities.Contains(0x79))
            {
                // MP +20% or MP +30%
                return 0x95;
            }
            else if (equipmentAbilities.Contains(0x74) || equipmentAbilities.Contains(0x75))
            {
                // HP +20% or HP +30%
                return 0x96;
            }
            else if (equipmentSlots == 3)
            {
                // Three slots
                return 0x97;
            }
            else if (equipmentAbilities.Contains(0x6A) || equipmentAbilities.Contains(0x6B))
            {
                // Defense +3% or Defense +5%
                return 0x98;
            }
            else if (equipmentAbilities.Contains(0x6E) || equipmentAbilities.Contains(0x6F))
            {
                // Magic Defense +3% or Magic Defense +5%
                return 0x99;
            }
            else if (equipmentAbilities.Contains(0x76) || equipmentAbilities.Contains(0x77))
            {
                // MP +5% or MP +10%
                return 0x9A;
            }
            else if (equipmentAbilities.Contains(0x72) || equipmentAbilities.Contains(0x73))
            {
                // HP +5% or HP +10%
                return 0x9B;
            }
            else if (equipmentSlots == 2)
            {
                // Two slots
                return 0x9C;
            }
            else if (equipmentSlots == 1)
            {
                // One slot
                return 0x9D;
            }
            else
            {
                // No slots
                return 0x9D;
            }
        }
    }
}