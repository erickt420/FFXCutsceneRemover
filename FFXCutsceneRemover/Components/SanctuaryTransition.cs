﻿using FFX_Cutscene_Remover.ComponentUtil;
using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

namespace FFXCutsceneRemover
{
    class SanctuaryTransition : Transition
    {
        static private byte[] formation = new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06 };

        public override void Execute(string defaultDescription = "")
        {
            Process process = memoryWatchers.Process;

            if (base.memoryWatchers.SanctuaryTransition.Current > 0)
            {
                formation = process.ReadBytes(base.memoryWatchers.Formation.Address, 7);

                if (Stage == 0)
                {
                    process.Suspend();

                    new Transition
                    {
                        EncounterMapID = 68,
                        EncounterFormationID2 = 0,
                        ScriptedBattleFlag1 = 0,
                        ScriptedBattleFlag2 = 1,
                        ScriptedBattleVar1 = 0x00010504,
                        ScriptedBattleVar3 = 0x0000013C,
                        ScriptedBattleVar4 = 0x00000014,
                        EncounterTrigger = 2,
                        Description = "Sanctuary Keeper",
                        ForceLoad = false
                    }.Execute();

                    Stage += 1;

                    process.Resume();
                }
                else if (base.memoryWatchers.BattleState2.Current == 22 && Stage == 1)
                {
                    Transition actorPositions;
                    //Position Party Member 1
                    actorPositions = new Transition { ForceLoad = false, ConsoleOutput = false, TargetActorIDs = new short[] { (short)(formation[0] + 1) }, Target_x = 1173.339722f, Target_y = -30.04813004f, Target_z = -1097.457031f };
                    actorPositions.Execute();

                    //Position Party Member 2
                    actorPositions = new Transition { ForceLoad = false, ConsoleOutput = false, TargetActorIDs = new short[] { (short)(formation[1] + 1) }, Target_x = 1178.746948f, Target_y = -30.04813004f, Target_z = -1135.846924f };
                    actorPositions.Execute();

                    //Position Party Member 3
                    actorPositions = new Transition { ForceLoad = false, ConsoleOutput = false, TargetActorIDs = new short[] { (short)(formation[2] + 1) }, Target_x = 1173.22583f, Target_y = -30.04813004f, Target_z = -1180.447388f };
                    actorPositions.Execute();

                    Stage += 1;
                }
            }
        }
    }
}