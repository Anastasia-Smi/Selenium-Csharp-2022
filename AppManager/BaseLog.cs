
using System.Collections.Generic;


namespace Selenium_Csharp_2022
{
    public class BaseLog
    {
        //public static List<BaseConsoleLog> LogEntries;
        //public static BaseReporting ReportingEntries;

        public BaseLog() { }

        public static int ErrorCount { get; }
        public static int InfoCount { get; }
        public static int Count { get; }
        public static int FailCount { get; }
        public static int WarningCount { get; }

        public static void And(string message) { }
        public static void AndThen(string message) { }
        public static void Bug(string msg) { }
        public static void End(string message) { }
       //public static void Error(ErrorMessage error) { }
        //public static void Error(string msg, ErrorMessage error) { }
        public static void Error(string msg) { }
        //public static void Fail(string msg, ErrorMessage error) { }
        public static void Finish(string message) { }
        public static void Given(string message) { }
        public static void Info(string msg) { }
        public static void Initialize() { }
        public static void KnownIssue(string msg) { }
        public static void OutputErrors() { }
        public static void OutputFailures() { }
        public static void Pass(string msg, string passReason) { }
        public static void Start(string message) { }
        public static void Then(string message) { }
        //public static string ToString() { }
        public static void Warning(string msg) { }
        public static void When(string message) { }
        public static void Write(string message, bool addToLogEntries = true) { }
        public static void WriteLine(string message, bool addToLogEntries = true) { }

    }
}
