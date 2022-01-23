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
    class RandoBlitzballTransition : Transition
    {
        RandoOptions options = JsonSerializer.Deserialize<RandoOptions>(File.ReadAllText(@".\RandomiserOptions.json"));

        // Blitzball
        List<byte> blitzballForwards = new List<byte>() { 0x00, 0x02, 0x07, 0x08, 0x0D, 0x0E, 0x13, 0x14, 0x19, 0x1A, 0x1F, 0x20, 0x29, 0x2A, 0x2B, 0x2D, 0x34, 0x35, 0x3A }; // 0x01 (Wakka) intentionally omitted
        List<byte> blitzballMidfielders = new List<byte>() { 0x03, 0x09, 0x0F, 0x15, 0x1B, 0x21, 0x25, 0x26, 0x28, 0x30, 0x33, 0x36, 0x38, 0x39 };
        List<byte> blitzballDefenders = new List<byte>() { 0x04, 0x05, 0x0A, 0x0B, 0x10, 0x11, 0x16, 0x17, 0x1C, 0x1D, 0x22, 0x23, 0x27, 0x2C, 0x2E, 0x2F };
        List<byte> blitzballGoalkeepers = new List<byte>() { 0x06, 0x0C, 0x12, 0x18, 0x1E, 0x24, 0x31, 0x32, 0x37, 0x3B };

        public override void Execute(string defaultDescription = "")
        {
            base.Execute();

            if (options.RandomiseBlitzball == 1)
            {
                RandomiseBlitzballTeams();
            }
            
        }

        private void RandomiseBlitzballTeams()
        {
            int teamBytesStartLocation = 1050;
            int contractedGamesBytesStartLocation = 1322;

            blitzballForwards.Shuffle<byte>();
            blitzballMidfielders.Shuffle<byte>();
            blitzballDefenders.Shuffle<byte>();
            blitzballGoalkeepers.Shuffle<byte>();

            // Set contracted games for all players to 0
            for (int i = 0; i < 60; i++)
            {
                Transitions.BlitzballBytes[contractedGamesBytesStartLocation + i] = 0x00;
            }

            int forwardCount = 0;
            int midfielderCount = 0;
            int defenderCount = 0;
            int goalkeeperCount = 0;

            // Iterate through teams
            for (int i = 0; i < 6; i++)
            {
                // Iterate through player slots
                for (int j = 0; j < 8; j++)
                {
                    int byteNum = 8 * i + j;
                    byte player = 0x3C;

                    if (j < 2)
                    {
                        player = blitzballForwards[forwardCount];
                        forwardCount += 1;
                    }
                    else if (j < 3)
                    {
                        player = blitzballMidfielders[midfielderCount];
                        midfielderCount += 1;
                    }
                    else if (j < 5)
                    {
                        player = blitzballDefenders[defenderCount];
                        defenderCount += 1;
                    }
                    else if (j < 6)
                    {
                        player = blitzballGoalkeepers[goalkeeperCount];
                        goalkeeperCount += 1;
                    }

                    Transitions.BlitzballBytes[teamBytesStartLocation + byteNum] = player;

                    if (player < 0x3C)
                    {
                        Transitions.BlitzballBytes[contractedGamesBytesStartLocation + player] = 0x05;
                    }
                }
            }
        }
    }
}