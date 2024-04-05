using NLog;
using System;

namespace NatyBeautyModel
{
    public static class LoggerUtil
    {
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Log the exception and message into the Nlog.config file.
        /// </summary>
        /// <param name="ex">Exception to be logged.</param>
        /// <param name="message">Message string to be logged (optional).</param>
        /// <example>
        /// This example shows to call the method <c>LogException</c>:
        /// <code>
        /// LoggerUtil.LogException(ex, "Your custom error message here.");
        /// </code>
        /// </example>
        public static void LogException(Exception ex, string message = "")
        {
            if (!string.IsNullOrEmpty(message))
            {
                logger.Error(ex, message);
            }
            else
            {
                logger.Error(ex);
            }
        }
    }
}
