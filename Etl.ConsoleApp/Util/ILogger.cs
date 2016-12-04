

namespace Etl.ConsoleApp.Util
{
    public interface ILogger
    {
        void Info(string text, params object[] vars);
        void Warning(string text, params object[] vars);
        void Error(string text, params object[] vars);
    }
}
