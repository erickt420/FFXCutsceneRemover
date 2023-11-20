// DiagnosticLog.cs - logging basics

// System imports
using System;
using System.IO;
using System.Runtime.CompilerServices;

// Third-party imports
using Serilog;
using Serilog.Events;

namespace FFXCutsceneRemover.Logging;

public static class DiagnosticLog
{
    static DiagnosticLog()
    {
        string rootPath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory) ??
                          Environment.ExpandEnvironmentVariables("%APPDATA%/FFXCutsceneRemover/Logs");

        Log.Logger = new LoggerConfiguration().
                     MinimumLevel.Debug().
                     WriteTo.Console(LogEventLevel.Information).
                     WriteTo.File(Path.Combine(rootPath, "csr-log.log"),
                                  LogEventLevel.Debug).
                     CreateLogger();
    }

    public static string TrimFilePath(string filePath)
    {
        return Path.GetFileName(filePath);
    }

    public static void Fatal(string                    msg,
                             [CallerMemberName] string mname = "",
                             [CallerFilePath]   string fpath = "",
                             [CallerLineNumber] int    lnb   = 0)
    {
        Log.Fatal($"[{TrimFilePath(fpath)}:{lnb}] {mname}: {msg}");
    }

    public static void Error(string                    msg,
                             [CallerMemberName] string mname = "",
                             [CallerFilePath]   string fpath = "",
                             [CallerLineNumber] int    lnb   = 0)
    {
        Log.Error($"[{TrimFilePath(fpath)}:{lnb}] {mname}: {msg}");
    }

    public static void Warning(string                    msg,
                               [CallerMemberName] string mname = "",
                               [CallerFilePath]   string fpath = "",
                               [CallerLineNumber] int    lnb   = 0)
    {
        Log.Warning($"[{TrimFilePath(fpath)}:{lnb}] {mname}: {msg}");
    }

    public static void Information(string                    msg,
                                   [CallerMemberName] string mname = "",
                                   [CallerFilePath]   string fpath = "",
                                   [CallerLineNumber] int    lnb   = 0)
    {
        Log.Information($"[{TrimFilePath(fpath)}:{lnb}] {mname}: {msg}");
    }

    public static void Debug(string                    msg,
                             [CallerMemberName] string mname = "",
                             [CallerFilePath]   string fpath = "",
                             [CallerLineNumber] int    lnb   = 0)
    {
        Log.Debug($"[{TrimFilePath(fpath)}:{lnb}] {mname}: {msg}");
    }

    public static void Verbose(string                    msg,
                               [CallerMemberName] string mname = "",
                               [CallerFilePath]   string fpath = "",
                               [CallerLineNumber] int    lnb   = 0)
    {
        Log.Verbose($"[{TrimFilePath(fpath)}:{lnb}] {mname}: {msg}");
    }
}