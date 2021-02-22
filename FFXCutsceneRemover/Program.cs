using System;

namespace FFXCutsceneRemover
{
    class Program
    {
        private static bool debug = false;
        private static int loopSleepMillis = 16;

        static void Main(string[] args)
        {
            Console.WriteLine("Program starting...");

            switch(args.Length)
            {
                case 1:
                    if (!bool.TryParse(args[0], out debug))
                    {
                        int.TryParse(args[0], out loopSleepMillis);
                    }
                    break;
                case 2:
                    bool.TryParse(args[0], out debug);
                    int.TryParse(args[1], out loopSleepMillis);
                    break;
            }

            CutsceneRemover mainProgram = new CutsceneRemover(debug, loopSleepMillis);
            mainProgram.MainLoop();
        }
    }
}
