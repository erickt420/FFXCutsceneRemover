﻿using FFX_Cutscene_Remover.ComponentUtil;
using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

namespace FFXCutsceneRemover
{
    class RikkuNameTransition : Transition
    {
        new byte[][] RikkuName = new byte[][]
        {
            new byte[] { 0xF8, 0xF3, 0xD1, 0xBD, 0x00, 0x00 }, // Japanese
            new byte[] { 0x61, 0x78, 0x7A, 0x7A, 0x84, 0x00 }, // English
            new byte[] { 0x61, 0x78, 0x7A, 0x7A, 0x84, 0x00 }, // French
            new byte[] { 0x61, 0x78, 0x7A, 0x7A, 0x84, 0x00 }, // Spanish
            new byte[] { 0x61, 0x78, 0x7A, 0x7A, 0x84, 0x00 }, // German
            new byte[] { 0x61, 0x78, 0x7A, 0x7A, 0x84, 0x00 }, // Italian
            new byte[] { 0x61, 0x78, 0x7A, 0x7A, 0x84, 0x00 },
            new byte[] { 0x61, 0x78, 0x7A, 0x7A, 0x84, 0x00 },
            new byte[] { 0x61, 0x78, 0x7A, 0x7A, 0x84, 0x00 },
            new byte[] { 0x2D, 0xA0, 0x2C, 0xD4, 0x00, 0x00 }, // Korean
            new byte[] { 0x2F, 0xDA, 0x2C, 0x84, 0x00, 0x00 }  // Chinese
        };
        public override void Execute(string defaultDescription = "")
        {
            byte language = base.memoryWatchers.Language.Current;
            byte[] RikkuNameBytes = RikkuName[language];

            new Transition { ForceLoad = false, ConsoleOutput = false, Description = "Naming Rikku", RikkuName = RikkuNameBytes }.Execute();

        }
    }
}