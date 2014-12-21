namespace libLogger {
    public interface IVMLogger {
        void CreateLog(string name);
        void CreateLog(string name, string targetName, string logDirectory);
        void Log(LogLevel level, string message);
        void Log(string message);
        void Trace(string message);
        void Debug(string message);
        void Info(string message);
        void Warn(string message);
        void Error(string message);
        void Fatal(string message);
    }
}
