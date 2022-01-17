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

        byte[] baseItemBytes = new byte[] { 0x00, 0x50, 0x00, 0x00, 0x00, 0x00, 0xFF, 0x00, };

        public override void Execute(string defaultDescription = "")
        {
            base.Execute();

            if (options.RandomiseShops == 1)
            {
                RandomiseShop();
            }
            
        }
        
        private void RandomiseShop()
        {/*
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
            }//*/
        }
    }
}