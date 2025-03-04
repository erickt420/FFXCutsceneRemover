using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using FFXCutsceneRemover.ComponentUtil;
using FFXCutsceneRemover.Logging;

namespace FFXCutsceneRemover;

class BreakTransition : Transition
{
    byte[] dialogueBoxBytes = new byte[] { };

    List<byte> originalMessageHeaderBytes1 = new List<byte> { };
    List<byte> originalMessageBytes1 = new List<byte> { };
    List<byte> originalMessageHeaderBytes2 = new List<byte> { };
    List<byte> originalMessageBytes2 = new List<byte> { };
    List<byte> remainingBytes = new List<byte> { };

    int originalScriptLength = 10240;
    int originalMessageNumBytes1 = 78;
    int originalMessageNumBytesToKeep1 = 44;

    int[] messageBoxStart = new int[2] { 0 , 0 };
    int[] messageBoxEndOriginal = new int[2] { 0, 0 };
    int[] messageBoxEndNew = new int[2] { 0, 0 };
    int[] originalMessageBoxLength = new int[2] { 0, 0 };
    int[] newMessageBoxLength = new int[2] { 0, 0 };
    int infoMessageLength = 0;
    int timerMessageLength = 0;
    int continueRunLength = 0;
    int originalMessageLengthChange;
    int totalMessageLengthChange;

    int messageBoxCount = 365;
    int messageHeaderSize = 2;

    byte totalMusicSphereCount = 70;
    DateTime breakStartTime = DateTime.MinValue;
    TimeSpan breakTimeElapsed = TimeSpan.Zero;
    TimeSpan breakTimeRemaining = TimeSpan.Zero;
    TimeSpan breakTimeRemainingPrevious = TimeSpan.Zero;
    TimeSpan breakTimeMaximum = TimeSpan.FromMinutes(5);
    //TimeSpan breakTimeMaximum = TimeSpan.FromSeconds(40);
    string infoMessageLine1 = "This is the break screen for CSR speedruns. When the countdown timer runs";
    string infoMessageLine2 = "out you will be loaded into Thunder Plains and the livesplit timer will continue.";
    string infoMessageLine3 = "You can end your break early by selecting ";
    string infoMessageContinueRun = "Continue Run";
    string defaultTimeMessage = "Time Remaining: 00:05:00";

    bool breakStarted = false;
    bool messageBoxSetUp = false;

    private Dictionary<char, (byte?, byte)> characterEncodingLatin = new Dictionary<char, (byte?, byte)>()
    {
        {'0', (null ,0x30)},
        {'1', (null ,0x31)},
        {'2', (null ,0x32)},
        {'3', (null ,0x33)},
        {'4', (null ,0x34)},
        {'5', (null ,0x35)},
        {'6', (null ,0x36)},
        {'7', (null ,0x37)},
        {'8', (null ,0x38)},
        {'9', (null ,0x39)},
        {' ', (null, 0x3A)},
        {'&', (null, 0x40)},
        //{'X', (null, 0x41)}, // Multiply Sign
        {'(', (null, 0x42)},
        {')', (null, 0x43)},
        {'*', (null, 0x44)},
        {'+', (null, 0x45)},
        {',', (null, 0x46)},
        {'-', (null, 0x47)},
        {'.', (null, 0x48)},
        {'/', (null, 0x49)},
        {':', (null, 0x4A)},
        {';', (null, 0x4B)},
        {'<', (null, 0x4C)},
        {'=', (null, 0x4D)},
        {'>', (null, 0x4E)},
        {'?', (null, 0x4F)},
        {'A', (null, 0x50)},
        {'B', (null, 0x51)},
        {'C', (null, 0x52)},
        {'D', (null, 0x53)},
        {'E', (null, 0x54)},
        {'F', (null, 0x55)},
        {'G', (null, 0x56)},
        {'H', (null, 0x57)},
        {'I', (null, 0x58)},
        {'J', (null, 0x59)},
        {'K', (null, 0x5A)},
        {'L', (null, 0x5B)},
        {'M', (null, 0x5C)},
        {'N', (null, 0x5D)},
        {'O', (null, 0x5E)},
        {'P', (null, 0x5F)},
        {'Q', (null, 0x60)},
        {'R', (null, 0x61)},
        {'S', (null, 0x62)},
        {'T', (null, 0x63)},
        {'U', (null, 0x64)},
        {'V', (null, 0x65)},
        {'W', (null, 0x66)},
        {'X', (null, 0x67)},
        {'Y', (null, 0x68)},
        {'Z', (null, 0x69)},
        {'[', (null, 0x6A)},
        //{'???', (null, 0x6B)},
        {']', (null, 0x6C)},
        {'a', (null, 0x70)},
        {'b', (null, 0x71)},
        {'c', (null, 0x72)},
        {'d', (null, 0x73)},
        {'e', (null, 0x74)},
        {'f', (null, 0x75)},
        {'g', (null, 0x76)},
        {'h', (null, 0x77)},
        {'i', (null, 0x78)},
        {'j', (null, 0x79)},
        {'k', (null, 0x7A)},
        {'l', (null, 0x7B)},
        {'m', (null, 0x7C)},
        {'n', (null, 0x7D)},
        {'o', (null, 0x7E)},
        {'p', (null, 0x7F)},
        {'q', (null, 0x80)},
        {'r', (null, 0x81)},
        {'s', (null, 0x82)},
        {'t', (null, 0x83)},
        {'u', (null, 0x84)},
        {'v', (null, 0x85)},
        {'w', (null, 0x86)},
        {'x', (null, 0x87)},
        {'y', (null, 0x88)},
        {'z', (null, 0x89)},
    };

    private Dictionary<char, (byte?, byte)> characterEncodingJapanese = new Dictionary<char, (byte?, byte)>()
    {
        {'0', (null ,0x30)},
        {'1', (null ,0x31)},
        {'2', (null ,0x32)},
        {'3', (null ,0x33)},
        {'4', (null ,0x34)},
        {'5', (null ,0x35)},
        {'6', (null ,0x36)},
        {'7', (null ,0x37)},
        {'8', (null ,0x38)},
        {'9', (null ,0x39)},
        {' ', (null ,0x3A)},
        {'!', (null, 0x3B)},
        //{'-', (null, 0x3C)}, // Long Dash
        {'~', (null, 0x3D)},
        //{'...', (null, 0x3E)}, // Ellipsis
        {'%', (null, 0x3F)},
        {'&', (null, 0x40)},
        //{'X', (null, 0x41)}, // Multiply Sign
        {'(', (null, 0x42)},
        {')', (null, 0x43)},
        {'*', (null, 0x44)},
        {'+', (null, 0x45)},
        {',', (null, 0x46)},
        {'-', (null, 0x47)},
        {'.', (null, 0x48)},
        {'/', (null, 0x49)},
        {':', (null, 0x4A)},
        {';', (null, 0x4B)},
        {'[', (null, 0x4C)},
        {'=', (null, 0x4D)},
        {']', (null, 0x4E)},
        {'?', (null, 0x4F)},
        //{'X', (null, 0x50)}, // Cross Sign
        {'A', (0x2C, 0x30)},
        {'B', (0x2C, 0x31)},
        {'C', (0x2C, 0x32)},
        {'D', (0x2C, 0x33)},
        {'E', (0x2C, 0x34)},
        {'F', (0x2C, 0x35)},
        {'G', (0x2C, 0x36)},
        {'H', (0x2C, 0x37)},
        {'I', (0x2C, 0x38)},
        {'J', (0x2C, 0x39)},
        {'K', (0x2C, 0x3A)},
        {'L', (0x2C, 0x3B)},
        {'M', (0x2C, 0x3C)},
        {'N', (0x2C, 0x3D)},
        {'O', (0x2C, 0x3E)},
        {'P', (0x2C, 0x3F)},
        {'Q', (0x2C, 0x40)},
        {'R', (0x2C, 0x41)},
        {'S', (0x2C, 0x42)},
        {'T', (0x2C, 0x43)},
        {'U', (0x2C, 0x44)},
        {'V', (0x2C, 0x45)},
        {'W', (0x2C, 0x46)},
        {'X', (0x2C, 0x47)},
        {'Y', (0x2C, 0x48)},
        {'Z', (0x2C, 0x49)},
        {'a', (0x2C, 0x4A)},
        {'b', (0x2C, 0x4B)},
        {'c', (0x2C, 0x4C)},
        {'d', (0x2C, 0x4D)},
        {'e', (0x2C, 0x4E)},
        {'f', (0x2C, 0x4F)},
        {'g', (0x2C, 0x50)},
        {'h', (0x2C, 0x51)},
        {'i', (0x2C, 0x52)},
        {'j', (0x2C, 0x53)},
        {'k', (0x2C, 0x54)},
        {'l', (0x2C, 0x55)},
        {'m', (0x2C, 0x56)},
        {'n', (0x2C, 0x57)},
        {'o', (0x2C, 0x58)},
        {'p', (0x2C, 0x59)},
        {'q', (0x2C, 0x5A)},
        {'r', (0x2C, 0x5B)},
        {'s', (0x2C, 0x5C)},
        {'t', (0x2C, 0x5D)},
        {'u', (0x2C, 0x5E)},
        {'v', (0x2C, 0x5F)},
        {'w', (0x2C, 0x60)},
        {'x', (0x2C, 0x61)},
        {'y', (0x2C, 0x62)},
        {'z', (0x2C, 0x63)},
    };

    private Dictionary<char, (byte?, byte)> characterEncodingChinese = new Dictionary<char, (byte?, byte)>()
    {
        {'0', (null ,0x30)},
        {'1', (null ,0x31)},
        {'2', (null ,0x32)},
        {'3', (null ,0x33)},
        {'4', (null ,0x34)},
        {'5', (null ,0x35)},
        {'6', (null ,0x36)},
        {'7', (null ,0x37)},
        {'8', (null ,0x38)},
        {'9', (null ,0x39)},
        {' ', (null ,0x3A)},
        {'!', (null, 0x3B)},
        //{'-', (null, 0x3C)}, // Long Dash
        {'~', (null, 0x3D)},
        //{'...', (null, 0x3E)}, // Ellipsis
        {'%', (null, 0x3F)},
        {'&', (null, 0x40)},
        //{'X', (null, 0x41)}, // Multiply Sign
        {'(', (null, 0x42)},
        {')', (null, 0x43)},
        {'*', (null, 0x44)},
        {'+', (null, 0x45)},
        {',', (null, 0x46)},
        {'-', (null, 0x47)},
        {'.', (null, 0x48)},
        {'/', (null, 0x49)},
        {':', (null, 0x4A)},
        {';', (null, 0x4B)},
        {'[', (null, 0x4C)},
        {'=', (null, 0x4D)},
        {']', (null, 0x4E)},
        {'?', (null, 0x4F)},
        //{'X', (null, 0x50)}, // Cross Sign
        {'A', (null, 0x5A)},
        {'B', (null, 0x5B)},
        {'C', (null, 0x5C)},
        {'D', (null, 0x5D)},
        {'E', (null, 0x5E)},
        {'F', (null, 0x5F)},
        {'G', (null, 0x60)},
        {'H', (null, 0x61)},
        {'I', (null, 0x62)},
        {'J', (null, 0x63)},
        {'K', (null, 0x64)},
        {'L', (null, 0x65)},
        {'M', (null, 0x66)},
        {'N', (null, 0x67)},
        {'O', (null, 0x68)},
        {'P', (null, 0x69)},
        {'Q', (null, 0x6A)},
        {'R', (null, 0x6B)},
        {'S', (null, 0x6C)},
        {'T', (null, 0x6D)},
        {'U', (null, 0x6E)},
        {'V', (null, 0x6F)},
        {'W', (null, 0x70)},
        {'X', (null, 0x71)},
        {'Y', (null, 0x72)},
        {'Z', (null, 0x73)},
        {'a', (null, 0x74)},
        {'b', (null, 0x75)},
        {'c', (null, 0x76)},
        {'d', (null, 0x77)},
        {'e', (null, 0x78)},
        {'f', (null, 0x79)},
        {'g', (null, 0x7A)},
        {'h', (null, 0x7B)},
        {'i', (null, 0x7C)},
        {'j', (null, 0x7D)},
        {'k', (null, 0x7E)},
        {'l', (null, 0x7F)},
        {'m', (null, 0x80)},
        {'n', (null, 0x81)},
        {'o', (null, 0x82)},
        {'p', (null, 0x83)},
        {'q', (null, 0x84)},
        {'r', (null, 0x85)},
        {'s', (null, 0x86)},
        {'t', (null, 0x87)},
        {'u', (null, 0x88)},
        {'v', (null, 0x89)},
        {'w', (null, 0x8A)},
        {'x', (null, 0x8B)},
        {'y', (null, 0x8C)},
        {'z', (null, 0x8D)},
    };

    public override void Execute(string defaultDescription = "")
    {
        Process process = MemoryWatchers.Process;

        if (MemoryWatchers.IsLoading.Current == 0)
        {
            new Transition { IsLoading = 0x02, LucaMusicSpheresUnlocked = totalMusicSphereCount, ForceLoad = false, Description = "Break Setup" }.Execute();
            breakStarted = true;
        }

        if (breakStartTime == DateTime.MinValue)
        {
            breakStartTime = DateTime.Now;
            breakTimeRemainingPrevious = breakTimeMaximum;
        }

        breakTimeElapsed = DateTime.Now - breakStartTime;
        breakTimeElapsed = TimeSpan.FromSeconds(Math.Floor(breakTimeElapsed.TotalSeconds));
        breakTimeRemaining = breakTimeMaximum - breakTimeElapsed;

        if (breakTimeRemaining <= TimeSpan.Zero)
        {
            new Transition { RoomNumber = 158, Description = "Break Time Over!" }.Execute();
        }

        string timeMessage = $"Time Remaining: {breakTimeRemaining.ToString()}";

        List<byte> modDialogueBytes = new List<byte> { };

        byte language = MemoryWatchers.Language.Current;
        Dictionary<char, (byte?, byte)> characterEncoding;

        switch (language)
        {
            case 0x00: // Japanese
                characterEncoding = characterEncodingJapanese;
                break;
            case 0x09: // Korean - Same Encoding as Chinese
                characterEncoding = characterEncodingChinese;
                break;
            case 0x0A: // Chinese
                characterEncoding = characterEncodingChinese;
                break;
            default:
                characterEncoding = characterEncodingLatin;
                break;
        }

        if (!messageBoxSetUp && breakStarted && MemoryWatchers.FrameCounterFromLoad.Current < 20)
        {
            dialogueBoxBytes = MemoryWatchers.DialogueFile.DeepPtr.DerefBytes(process, originalScriptLength); // Add 2 for new line characters

            messageBoxStart[0] = dialogueBoxBytes[4 * 0] + dialogueBoxBytes[4 * 0 + 1] * 0x100;
            messageBoxEndOriginal[0] = dialogueBoxBytes[4 * 2] + dialogueBoxBytes[4 * 2 + 1] * 0x100 - 1;

            originalMessageBoxLength[0] = messageBoxEndOriginal[0] - messageBoxStart[0] + 1;
            newMessageBoxLength[0] = originalMessageBoxLength[0] + defaultTimeMessage.Length + 2; // Add 2 for new line characters

            messageBoxEndNew[0] = messageBoxStart[0] + newMessageBoxLength[0] + 1;

            messageBoxStart[1] = dialogueBoxBytes[4 * 2] + dialogueBoxBytes[4 * 2 + 1] * 0x100;
            messageBoxEndOriginal[1] = dialogueBoxBytes[4 * 4] + dialogueBoxBytes[4 * 4 + 1] * 0x100 - 1;

            originalMessageBoxLength[1] = messageBoxEndOriginal[1] - messageBoxStart[1] + 1;
            newMessageBoxLength[1] = originalMessageBoxLength[1] + defaultTimeMessage.Length + 2; // Add 2 for new line characters

            messageBoxEndNew[1] = messageBoxStart[1] + newMessageBoxLength[1] + 1;

            //DiagnosticLog.Information($"Message Box Start: {messageBoxStart}");
            //DiagnosticLog.Information($"Message Box End: {messageBoxEndOriginal}");
            //DiagnosticLog.Information($"Message Box New Length: {newMessageBoxLength}");
            //DiagnosticLog.Information($"Message Box End New: {messageBoxEndOriginal.ToString("X")}");

            originalMessageNumBytes1 = messageBoxEndOriginal[0] - messageBoxStart[0] + 1;

            for (int i = originalMessageNumBytes1; i > 0; i--)
            {
                if (dialogueBoxBytes[messageBoxStart[0] + i - 1] == 0x03)
                {
                    originalMessageNumBytesToKeep1 = i + 2; // Add 2 for the option selection bytes after the new line
                    break;
                }
            }

            // get original message box bytes

            for (int i = messageBoxStart[0]; i < messageBoxStart[0] + messageHeaderSize; i++)
            {
                originalMessageHeaderBytes1.Add(dialogueBoxBytes[i]);
            }
            
            for (int i = messageBoxStart[0] + messageHeaderSize; i < messageBoxStart[0] + originalMessageNumBytesToKeep1; i++)
            {
                originalMessageBytes1.Add(dialogueBoxBytes[i]);
            }

            for (int i = messageBoxStart[1]; i < messageBoxStart[1] + messageHeaderSize; i++)
            {
                originalMessageHeaderBytes2.Add(dialogueBoxBytes[i]);
            }

            for (int i = messageBoxStart[1] + messageHeaderSize; i < messageBoxEndOriginal[1]; i++) // Intentionally miss the last byte 0x00 so we can add on the end later
            {
                originalMessageBytes2.Add(dialogueBoxBytes[i]);
            }

            for (int i = messageBoxEndOriginal[1] + 1; i < originalScriptLength; i++)
            {
                remainingBytes.Add(dialogueBoxBytes[i]);
            }

            modDialogueBytes.AddRange(originalMessageHeaderBytes1);

            foreach (char character in infoMessageLine1)
            {
                (byte?, byte) encodedCharacter = characterEncoding[character];
                if (!(encodedCharacter.Item1 is null))
                {
                    modDialogueBytes.Add((byte)encodedCharacter.Item1);
                    infoMessageLength++;
                }
                modDialogueBytes.Add(encodedCharacter.Item2);
                infoMessageLength++;
            }

            modDialogueBytes.Add(0x03);

            foreach (char character in infoMessageLine2)
            {
                (byte?, byte) encodedCharacter = characterEncoding[character];
                if (!(encodedCharacter.Item1 is null))
                {
                    modDialogueBytes.Add((byte)encodedCharacter.Item1);
                    infoMessageLength++;
                }
                modDialogueBytes.Add(encodedCharacter.Item2);
                infoMessageLength++;
            }

            modDialogueBytes.Add(0x03);

            foreach (char character in infoMessageLine3)
            {
                (byte?, byte) encodedCharacter = characterEncoding[character];
                if (!(encodedCharacter.Item1 is null))
                {
                    modDialogueBytes.Add((byte)encodedCharacter.Item1);
                    infoMessageLength++;
                }
                modDialogueBytes.Add(encodedCharacter.Item2);
                infoMessageLength++;
            }

            // Add Colour Change
            modDialogueBytes.Add(0x0A);
            modDialogueBytes.Add(0x43);

            foreach (char character in infoMessageContinueRun)
            {
                (byte?, byte) encodedCharacter = characterEncoding[character];
                if (!(encodedCharacter.Item1 is null))
                {
                    modDialogueBytes.Add((byte)encodedCharacter.Item1);
                    infoMessageLength++;
                }
                modDialogueBytes.Add(encodedCharacter.Item2);
                infoMessageLength++;
            }

            // Colour Back to Normal and Full Stop
            modDialogueBytes.Add(0x0A);
            modDialogueBytes.Add(0x41);
            modDialogueBytes.Add(0x48);

            modDialogueBytes.Add(0x03);
            modDialogueBytes.Add(0x03);

            foreach (char character in defaultTimeMessage)
            {
                (byte?, byte) encodedCharacter = characterEncoding[character];
                if (!(encodedCharacter.Item1 is null))
                {
                    modDialogueBytes.Add((byte)encodedCharacter.Item1);
                    timerMessageLength++;
                }
                modDialogueBytes.Add(encodedCharacter.Item2);
                timerMessageLength++;
            }

            modDialogueBytes.Add(0x03);
            modDialogueBytes.Add(0x03);

            modDialogueBytes.AddRange(originalMessageBytes1);

            // Add Colour Change
            modDialogueBytes.Add(0x0A);
            modDialogueBytes.Add(0x43);

            foreach (char character in infoMessageContinueRun)
            {
                (byte?, byte) encodedCharacter = characterEncoding[character];
                if (!(encodedCharacter.Item1 is null))
                {
                    modDialogueBytes.Add((byte)encodedCharacter.Item1);
                    continueRunLength++;
                }
                modDialogueBytes.Add(encodedCharacter.Item2);
                continueRunLength++;
            }

            // Colour Back to Normal, Full Stop and Terminate Message Box
            modDialogueBytes.Add(0x0A);
            modDialogueBytes.Add(0x41);
            modDialogueBytes.Add(0x48);
            modDialogueBytes.Add(0x00);

            modDialogueBytes.AddRange(originalMessageHeaderBytes2);
            modDialogueBytes.AddRange(originalMessageBytes2);

            modDialogueBytes.Add(0x03);
            modDialogueBytes.Add(0x03);

            foreach (char character in defaultTimeMessage)
            {
                (byte?, byte) encodedCharacter = characterEncoding[character];
                if (!(encodedCharacter.Item1 is null))
                {
                    modDialogueBytes.Add((byte)encodedCharacter.Item1);
                }
                modDialogueBytes.Add(encodedCharacter.Item2);
            }

            modDialogueBytes.Add(0x00);

            modDialogueBytes.AddRange(remainingBytes);
            
            // Update body data with message box new bytes

            for (int i = 0; i < Math.Min(modDialogueBytes.Count, originalScriptLength); i++)
            {
                try
                {
                    dialogueBoxBytes[messageBoxStart[0] + i] = modDialogueBytes[i];
                }
                catch (IndexOutOfRangeException e)
                {
                    DiagnosticLog.Information("Exception: " + e.Message);
                }
            }

            infoMessageLength += (1 + 1 + 2 + 4 + 1); // Add 1s and 2s for new line characters, 4 for Colour Changes
            timerMessageLength += 2; // Add 2 for new line characters
            originalMessageLengthChange = originalMessageNumBytesToKeep1 - originalMessageNumBytes1 + continueRunLength + 1 + 4 + 1; // Add one for full stop, 4 for colour change and 1 for null termination
            totalMessageLengthChange = infoMessageLength + 2 * timerMessageLength + originalMessageLengthChange;

            DiagnosticLog.Information($"originalMessageNumBytesToKeep1: {originalMessageNumBytesToKeep1}");
            DiagnosticLog.Information($"originalMessageNumBytes1: {originalMessageNumBytes1}");
            DiagnosticLog.Information($"originalMessageLengthChange: {originalMessageLengthChange}");
            DiagnosticLog.Information($"totalMessageLengthChange: {totalMessageLengthChange}");

            // Skip the first message box at i = 0 because that message box doesn't change start point
            // Update the start positions for all other message boxes in the binary file

            int originalPosition = dialogueBoxBytes[8] + dialogueBoxBytes[8 + 1] * 0x100;
            int newPosition = originalPosition + infoMessageLength + timerMessageLength + 2 + originalMessageLengthChange;

            dialogueBoxBytes[8] = (byte)(newPosition & 0xFF);
            dialogueBoxBytes[8 + 1] = (byte)((newPosition & 0xFF00) >> 8);
            dialogueBoxBytes[8 + 4] = (byte)(newPosition & 0xFF);
            dialogueBoxBytes[8 + 5] = (byte)((newPosition & 0xFF00) >> 8);

            for (int i = 2; i < messageBoxCount; i++)
            {
                originalPosition = dialogueBoxBytes[8 * i] + dialogueBoxBytes[8 * i + 1] * 0x100;
                newPosition = originalPosition + totalMessageLengthChange;

                dialogueBoxBytes[8 * i] = (byte)(newPosition & 0xFF);
                dialogueBoxBytes[8 * i + 1] = (byte)((newPosition & 0xFF00) >> 8);
                dialogueBoxBytes[8 * i + 4] = (byte)(newPosition & 0xFF);
                dialogueBoxBytes[8 * i + 5] = (byte)((newPosition & 0xFF00) >> 8);
            }

            new Transition { ForceLoad = false, Description = "Break Information Setup", ConsoleOutput = true, DialogueFile = dialogueBoxBytes }.Execute();

            messageBoxSetUp = true;
        }

        if (messageBoxSetUp && breakStarted && breakTimeRemaining < breakTimeRemainingPrevious)
        {
            modDialogueBytes.Clear();
            modDialogueBytes.AddRange(originalMessageHeaderBytes1);

            foreach (char character in infoMessageLine1)
            {
                (byte?, byte) encodedCharacter = characterEncoding[character];
                if (!(encodedCharacter.Item1 is null))
                {
                    modDialogueBytes.Add((byte)encodedCharacter.Item1);
                }
                modDialogueBytes.Add(encodedCharacter.Item2);
            }

            modDialogueBytes.Add(0x03);

            foreach (char character in infoMessageLine2)
            {
                (byte?, byte) encodedCharacter = characterEncoding[character];
                if (!(encodedCharacter.Item1 is null))
                {
                    modDialogueBytes.Add((byte)encodedCharacter.Item1);
                }
                modDialogueBytes.Add(encodedCharacter.Item2);
            }

            modDialogueBytes.Add(0x03);

            foreach (char character in infoMessageLine3)
            {
                (byte?, byte) encodedCharacter = characterEncoding[character];
                if (!(encodedCharacter.Item1 is null))
                {
                    modDialogueBytes.Add((byte)encodedCharacter.Item1);
                }
                modDialogueBytes.Add(encodedCharacter.Item2);
            }

            // Add Colour Change
            modDialogueBytes.Add(0x0A);
            modDialogueBytes.Add(0x43);

            foreach (char character in infoMessageContinueRun)
            {
                (byte?, byte) encodedCharacter = characterEncoding[character];
                if (!(encodedCharacter.Item1 is null))
                {
                    modDialogueBytes.Add((byte)encodedCharacter.Item1);
                }
                modDialogueBytes.Add(encodedCharacter.Item2);
            }

            // Colour Back to Normal and Full Stop
            modDialogueBytes.Add(0x0A);
            modDialogueBytes.Add(0x41);
            modDialogueBytes.Add(0x48);

            modDialogueBytes.Add(0x03);
            modDialogueBytes.Add(0x03);

            foreach (char character in timeMessage)
            {
                (byte?, byte) encodedCharacter = characterEncoding[character];
                if (!(encodedCharacter.Item1 is null))
                {
                    modDialogueBytes.Add((byte)encodedCharacter.Item1);
                }
                modDialogueBytes.Add(encodedCharacter.Item2);
            }

            modDialogueBytes.Add(0x03);
            modDialogueBytes.Add(0x03);

            modDialogueBytes.AddRange(originalMessageBytes1);

            // Add Colour Change
            modDialogueBytes.Add(0x0A);
            modDialogueBytes.Add(0x43);

            foreach (char character in infoMessageContinueRun)
            {
                (byte?, byte) encodedCharacter = characterEncoding[character];
                if (!(encodedCharacter.Item1 is null))
                {
                    modDialogueBytes.Add((byte)encodedCharacter.Item1);
                }
                modDialogueBytes.Add(encodedCharacter.Item2);
            }

            // Colour Back to Normal, Full Stop and Terminate Message Box
            modDialogueBytes.Add(0x0A);
            modDialogueBytes.Add(0x41);
            modDialogueBytes.Add(0x48);
            modDialogueBytes.Add(0x00);

            modDialogueBytes.AddRange(originalMessageHeaderBytes2);
            modDialogueBytes.AddRange(originalMessageBytes2);

            modDialogueBytes.Add(0x03);
            modDialogueBytes.Add(0x03);

            foreach (char character in timeMessage)
            {
                (byte?, byte) encodedCharacter = characterEncoding[character];
                if (!(encodedCharacter.Item1 is null))
                {
                    modDialogueBytes.Add((byte)encodedCharacter.Item1);
                }
                modDialogueBytes.Add(encodedCharacter.Item2);
            }

            modDialogueBytes.Add(0x00);

            // Update body data with message box new bytes

            for (int i = 0; i < modDialogueBytes.Count; i++)
            {
                try
                {
                    dialogueBoxBytes[messageBoxStart[0] + i] = modDialogueBytes[i];
                }
                catch (IndexOutOfRangeException e)
                {
                    DiagnosticLog.Information("Exception: " + e.Message);
                }
            }

            new Transition { ForceLoad = false, Description = "Break Information", ConsoleOutput = false,  DialogueFile = dialogueBoxBytes }.Execute();

            breakTimeRemainingPrevious = breakTimeRemaining;
        }
    }
}