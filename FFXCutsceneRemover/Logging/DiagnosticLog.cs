// DiagnosticLog.cs - logging basics

// System imports
using System;
using System.IO;
using System.Runtime.CompilerServices;

// Third-party imports
using Serilog;
using Serilog.Events;

namespace FFXCutsceneRemover.Logging
{
    public static class DiagnosticLog
    {
        private static readonly ILogger Log;
        public static           bool    ExtraAnnotations;

        static DiagnosticLog()
        {
            string rootPath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory) ??
                              Environment.ExpandEnvironmentVariables("%APPDATA%/FFXCutsceneRemover/Logs");

            Log = new LoggerConfiguration().
                  WriteTo.Console(LogEventLevel.Information, 
                                  "{Message:l}{NewLine}{Exception}").
                  WriteTo.File(Path.Combine(rootPath, "debug.log"),
                               LogEventLevel.Information).
                  CreateLogger();
        }

        public static void Fatal(string                    msg,
                                 [CallerMemberName] string mname = "",
                                 [CallerFilePath]   string fpath = "",
                                 [CallerLineNumber] int    lnb   = 0)
        {
            Log.Fatal(ExtraAnnotations
                          ? $"[{fpath.Substring(fpath.IndexOf("FFXCutscene", StringComparison.Ordinal))}:{lnb}] {mname}: {msg}"
                          : msg);
        }

        public static void Error(string                    msg,
                                 [CallerMemberName] string mname = "",
                                 [CallerFilePath]   string fpath = "",
                                 [CallerLineNumber] int    lnb   = 0)
        {
            Log.Error(ExtraAnnotations
                          ? $"[{fpath.Substring(fpath.IndexOf("FFXCutscene", StringComparison.Ordinal))}:{lnb}] {mname}: {msg}"
                          : msg);
        }

        public static void Warning(string                    msg,
                                   [CallerMemberName] string mname = "",
                                   [CallerFilePath]   string fpath = "",
                                   [CallerLineNumber] int    lnb   = 0)
        {
            Log.Warning(ExtraAnnotations
                            ? $"[{fpath.Substring(fpath.IndexOf("FFXCutscene", StringComparison.Ordinal))}:{lnb}] {mname}: {msg}"
                            : msg);
        }

        public static void Information(string                    msg,
                                       [CallerMemberName] string mname = "",
                                       [CallerFilePath]   string fpath = "",
                                       [CallerLineNumber] int    lnb   = 0)
        {
            Log.Information(ExtraAnnotations
                                ? $"[{fpath.Substring(fpath.IndexOf("FFXCutscene", StringComparison.Ordinal))}:{lnb}] {mname}: {msg}"
                                : msg);
        }

        public static void Debug(string                    msg,
                                 [CallerMemberName] string mname = "",
                                 [CallerFilePath]   string fpath = "",
                                 [CallerLineNumber] int    lnb   = 0)
        {
            Log.Debug(ExtraAnnotations
                          ? $"[{fpath.Substring(fpath.IndexOf("FFXCutscene", StringComparison.Ordinal))}:{lnb}] {mname}: {msg}"
                          : msg);
        }

        public static void Verbose(string                    msg,
                                   [CallerMemberName] string mname = "",
                                   [CallerFilePath]   string fpath = "",
                                   [CallerLineNumber] int    lnb   = 0)
        {
            Log.Verbose(ExtraAnnotations
                            ? $"[{fpath.Substring(fpath.IndexOf("FFXCutscene", StringComparison.Ordinal))}:{lnb}] {mname}: {msg}"
                            : msg);
        }
    }
}