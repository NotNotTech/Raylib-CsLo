// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

// Warning This file is auto generated and changes will be lost

namespace Raylib_CsLo;

/// <summary> Trace log level </summary>
public enum RlTraceLogLevel
{
    /// <summary> Display all logs </summary>
    RlLogAll = 0,
    /// <summary> Trace logging, intended for internal use only </summary>
    RlLogTrace = 1,
    /// <summary> Debug logging, used for internal debugging, it should be disabled on release builds </summary>
    RlLogDebug = 2,
    /// <summary> Info logging, used for program execution info </summary>
    RlLogInfo = 3,
    /// <summary> Warning logging, used on recoverable failures </summary>
    RlLogWarning = 4,
    /// <summary> Error logging, used on unrecoverable failures </summary>
    RlLogError = 5,
    /// <summary> Fatal logging, used to abort program: exit(EXIT_FAILURE) </summary>
    RlLogFatal = 6,
    /// <summary> Disable logging </summary>
    RlLogNone = 7,
}
