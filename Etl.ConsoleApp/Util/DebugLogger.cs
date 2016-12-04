using System;
using System.Diagnostics;

namespace Etl.ConsoleApp.Util
{
    // it will log to console and debug window so you can see it depending on how you run the app. 
    public class DebugLogger : ILogger
    {
        public void Info(string text, params object[] vars) {
            if (!string.IsNullOrEmpty(text))
                Debug.WriteLine("INFO: " + text, vars);
                Console.WriteLine("INFO: " + text, vars); 
        }
        public void Warning(string text, params object[] vars) {
            if (!string.IsNullOrEmpty(text))
                Debug.WriteLine("WARNING: " + text, vars);
                Console.WriteLine("WARNING: " + text, vars);
        }
        public void Error(string text, params object[] vars) {
            if (!string.IsNullOrEmpty(text))
                Debug.WriteLine("ERROR: " + text, vars);
                Console.WriteLine("ERROR: " + text, vars);
        }
    }
}
