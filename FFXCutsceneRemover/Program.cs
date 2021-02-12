using System;

namespace FFXCutsceneRemover
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program starting...");

            CutsceneRemover mainProgram = new CutsceneRemover();
            mainProgram.MainLoop();
        }
    }
}
