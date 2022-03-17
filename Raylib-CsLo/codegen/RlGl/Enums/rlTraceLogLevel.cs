// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

// Warning This file is auto generated and changes will be lost

namespace Raylib_CsLo;

/// <summary> Trace log level </summary>
public enum rlTraceLogLevel
{
    /// <summary> Display all logs </summary>
    RL_LOG_ALL = 0,
    /// <summary> Trace logging, intended for internal use only </summary>
    RL_LOG_TRACE = 1,
    /// <summary> Debug logging, used for internal debugging, it should be disabled on release builds </summary>
    RL_LOG_DEBUG = 2,
    /// <summary> Info logging, used for program execution info </summary>
    RL_LOG_INFO = 3,
    /// <summary> Warning logging, used on recoverable failures </summary>
    RL_LOG_WARNING = 4,
    /// <summary> Error logging, used on unrecoverable failures </summary>
    RL_LOG_ERROR = 5,
    /// <summary> Fatal logging, used to abort program: exit(EXIT_FAILURE) </summary>
    RL_LOG_FATAL = 6,
    /// <summary> Disable logging </summary>
    RL_LOG_NONE = 7,
}
