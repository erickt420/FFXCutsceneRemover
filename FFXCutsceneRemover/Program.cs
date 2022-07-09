using System;
using FFXCutsceneRemover.Logging;

namespace FFXCutsceneRemover
{
    class Program
    {
        private static bool debug = false;
        private static int loopSleepMillis = 16;

        static void Main(string[] args)
        {
            DiagnosticLog.Information("FFX Cutscene Remover Version " + NewGameTransition.GetVersion());

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

            DiagnosticLog.ExtraAnnotations = debug;
            CutsceneRemover mainProgram = new CutsceneRemover(debug, loopSleepMillis);
            mainProgram.MainLoop();
        }
    }
}
