using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using LogLevel = libLogger.LogLevel;
using System.IO;
using NLog.Config;
using NLog.Targets;
using System.Reflection;

namespace libLogger {
    public class VMLogger: IVMLogger {

        private NLog.Logger _logger;

        public void CreateLog(string name) {
            _logger = LogManager.GetLogger(name);
        }

        public void CreateLog(string name, string targetName, string logDirectory) {
            var instance = new LogFactory(AddConfig(name, targetName, logDirectory));
            _logger = instance.GetLogger(targetName);
        }

        public void Log(LogLevel level, string message) {
            switch (level) {
                case LogLevel.Error:
                    Error(message);
                    break;
                case LogLevel.Fatal:
                    Fatal(message);
                    break;
                case LogLevel.Debug:
                    Debug(message);
                    break;
                case LogLevel.Trace:
                    Trace(message);
                    break;
                case LogLevel.Warn:
                    Warn(message);
                    break;
                case LogLevel.Info:
                    Info(message);
                    break;
            }
        }

        public void Log(string message) {
            Info(message);
        }

        public void Trace(string message) {
            _logger.Trace(message);
        }

        public void Debug(string message) {
            _logger.Debug(message);
        }

        public void Info(string message) {
            _logger.Info(message);
        }

        public void Warn(string message) {
            _logger.Warn(message);
        }

        public void Error(string message) {
            _logger.Error(message);
        }

        public void Fatal(string message) {
            _logger.Fatal(message);
        }

        /// <summary>
        /// Add Config
        /// </summary>
        /// <param name="name"></param>
        /// <param name="targetName"></param>
        /// <param name="logDirectory"></param>
        /// <param name="clientName"></param>
        /// <param name="serverAddress"></param>
        /// <param name="emailName"></param>
        /// <param name="smtpServer"></param>
        /// <param name="receiver"></param>
        /// <param name="subject"></param>
        /// <param name="sender"></param>
        /// <returns></returns>
        public LoggingConfiguration AddConfig(string name, string targetName, string logDirectory, string clientName, string serverAddress, string emailName, string smtpServer, string receiver, string subject, string sender) {
            if (!Directory.Exists(logDirectory))
                Directory.CreateDirectory(logDirectory);

            var config = new LoggingConfiguration();
            var logFile = new FileTarget();

            try {
                config.AddTarget(targetName, logFile);
                var archiveDir = Path.Combine(logDirectory, "Log.txt");
                const string archiveFile = "Log.{#}.txt";

                logFile.Name = targetName;
                logFile.ArchiveFileName = Path.Combine(archiveDir, archiveFile);
                logFile.ArchiveNumbering = ArchiveNumberingMode.Rolling;
                logFile.MaxArchiveFiles = 10;
                logFile.ConcurrentWrites = true;
                logFile.ArchiveEvery = FileArchivePeriod.Day;
                logFile.KeepFileOpen = false;

                var rule = new LoggingRule("*", NLog.LogLevel.Info, logFile);
                config.LoggingRules.Add(rule);

                var logEmail = new MailTarget();
                config.AddTarget(emailName, logEmail);
                logEmail.SmtpAuthentication = SmtpAuthenticationMode.None;
                logEmail.Name = emailName;
                logEmail.SmtpServer = smtpServer;
                logEmail.To = receiver;
                logEmail.Subject = clientName + " " + subject;
                logEmail.From = sender;
                logEmail.Body = "Server Address: " + serverAddress + ". \nClient: ".Replace("\n", Environment.NewLine) + clientName + ". \nProject: ".Replace("\n", Environment.NewLine) + targetName + ". \nStep: ".Replace("\n", Environment.NewLine) + name + ". \nError details: ${message}".Replace("\n", Environment.NewLine);
                var rule2 = new LoggingRule("*", NLog.LogLevel.Error, logEmail);
                config.LoggingRules.Add(rule2);

                var logConsole = new ConsoleTarget();
                config.AddTarget("ConsoleNotification", logConsole);
                logConsole.Name = "ConsoleNotification";
                var rule3 = new LoggingRule("*", NLog.LogLevel.Info, logConsole);
                config.LoggingRules.Add(rule3);
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            
            return config;
        }

        /// <summary>
        /// Add configuration
        /// </summary>
        /// <param name="name"></param>
        /// <param name="targetName"></param>
        /// <param name="logDirectory"></param>
        /// <returns></returns>
        public LoggingConfiguration AddConfig(string name, string targetName, string logDirectory) {
            if (!Directory.Exists(logDirectory)) {
                Directory.CreateDirectory(logDirectory);
            }

            var config = new LoggingConfiguration();
            var logFile = new FileTarget();
            config.AddTarget(targetName, logFile);
            var archiveDirectory = Path.Combine(logDirectory, "Archive");
            const string archiveFile = "Log.{#}.txt";

            logFile.Name = targetName;
            logFile.FileName = Path.Combine(logDirectory, "Log.txt");
            logFile.ArchiveFileName = Path.Combine(archiveDirectory, archiveFile);
            logFile.ArchiveNumbering = ArchiveNumberingMode.Rolling;
            logFile.MaxArchiveFiles = 10;
            logFile.ConcurrentWrites = true;
            logFile.ArchiveEvery = FileArchivePeriod.Day;
            logFile.KeepFileOpen = false;

            
            var rule = new LoggingRule("*", NLog.LogLevel.Info, logFile);
            config.LoggingRules.Add(rule);

            var settings = new libLogger.EmailSettings();
            settings.EmailFrom = "";
            settings.EmailTo = "";
            settings.EnableSSL = true;
            settings.SmtpPassword = "";
            settings.SmtpPort = 222;
            settings.SmtpUserName = "";
            settings.SmtpServer = "";

            var directoryInfo = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            string text = null;

            if (File.Exists(Path.Combine(directoryInfo, @"EmailErrorLogConfig.xml"))) {
                text = File.ReadAllText(Path.Combine(directoryInfo, @"EmailErrorLogConfig.xml"));
             
                var logEmail = new MailTarget();
                config.AddTarget("EmailNotification", logEmail);
                logEmail.Name = "EmailNotification";
                // logEmail.SmtpServer = "";

                if (settings.EmailFrom != null && settings.EmailTo != null && settings.SmtpServer != null) {
                    logEmail.SmtpServer = settings.SmtpServer;
                    // logEmail.SmtpUserName = "dev.test@test.com";

                    if (settings.SmtpUserName != null)
                        logEmail.SmtpUserName = settings.SmtpUserName;

                    if (settings.SmtpPassword != null)
                        logEmail.SmtpPassword = settings.SmtpPassword;

                    logEmail.EnableSsl = settings.EnableSSL;

                    if (settings.SmtpPort != 0)
                        logEmail.SmtpPort = settings.SmtpPort;

                    logEmail.SmtpAuthentication = SmtpAuthenticationMode.None;
                    logEmail.To = "erwinczerniawski@gmail.com;";
                    logEmail.To = settings.EmailTo;

                    logEmail.Subject = targetName + " VirtualManager failed";
                    logEmail.From = settings.EmailFrom;
                    logEmail.Body = "Project: " + targetName + ". Step: " + name + ". Error details: ${message}";
                    var rule2 = new LoggingRule("*", NLog.LogLevel.Error, logEmail);
                    config.LoggingRules.Add(rule2);
                }
            }

            var logConsole = new ConsoleTarget();
            config.AddTarget("ConsoleNotification", logConsole);
            logConsole.Name = "ConsoleNotification";
            var rule3 = new LoggingRule("*", NLog.LogLevel.Info, logConsole);
            config.LoggingRules.Add(rule3);

            return config;
        }
    }

    public class EmailSettings {
        public string EmailTo { get; set; }
        public string EmailFrom { get; set; }
        public string SmtpServer { get; set; }
        public string SmtpUserName { get; set; }
        public string SmtpPassword { get; set; }
        public int SmtpPort { get; set; }
        public bool EnableSSL { get; set; }
    }
}
