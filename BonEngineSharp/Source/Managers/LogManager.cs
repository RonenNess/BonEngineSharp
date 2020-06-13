using BonEngineSharp.Defs;

namespace BonEngineSharp.Managers
{
    /// <summary>
    /// Log manager.
    /// Provides basic logging functionality.
    /// </summary>
    public class LogManager : IManager
    {
        /// <summary>
        /// Get manager id.
        /// </summary>
        public override string Id => "log";

        /// <summary>
        /// Write a log message.
        /// </summary>
        /// <param name="level">Log level to write.</param>
        /// <param name="message">Message to write.</param>
        /// <param name="_params">Optional params to format string.</param>
        public void Write(LogLevel level, string message, params object[] _params)
        {
            if (_params != null)
            {
                message = string.Format(message, _params);
            }
            _BonEngineBind.BON_Log_Write((int)level, message);
        }

        /// <summary>
        /// Write a log debug message.
        /// </summary>
        /// <param name="message">Message to write.</param>
        /// <param name="_params">Optional params to format string.</param>
        public void Debug(string message, params object[] _params)
        {
            Write(LogLevel.Debug, message, _params);
        }

        /// <summary>
        /// Write a log info message.
        /// </summary>
        /// <param name="message">Message to write.</param>
        /// <param name="_params">Optional params to format string.</param>
        public void Info(string message, params object[] _params)
        {
            Write(LogLevel.Info, message, _params);
        }

        /// <summary>
        /// Write a log warn message.
        /// </summary>
        /// <param name="message">Message to write.</param>
        /// <param name="_params">Optional params to format string.</param> 
        public void Warn(string message, params object[] _params)
        {
            Write(LogLevel.Warn, message, _params);
        }

        /// <summary>
        /// Write a log error message.
        /// </summary>
        /// <param name="message">Message to write.</param>
        /// <param name="_params">Optional params to format string.</param>
        public void Error(string message, params object[] _params)
        {
            Write(LogLevel.Error, message, _params);
        }

        /// <summary>
        /// Write a log critical message.
        /// </summary>
        /// <param name="message">Message to write.</param>
        /// <param name="_params">Optional params to format string.</param>
        public void Critical(string message, params object[] _params)
        {
            Write(LogLevel.Critical, message, _params);
        }

        /// <summary>
        /// Get / set logs level.
        /// </summary>
        public LogLevel Level
        {
            get { return (LogLevel)_BonEngineBind.BON_Log_GetLevel(); }
            set { _BonEngineBind.BON_Log_SetLevel((int)value); }
        }

        /// <summary>
        /// Get if a given log level is currently valid and will be written to log.
        /// </summary>
        /// <param name="level">Log level to check.</param>
        /// <returns>True if log level is valid</returns>
        public bool IsValid(LogLevel level)
        {
            return _BonEngineBind.BON_Log_IsValid((int)level);
        }
    }
}
