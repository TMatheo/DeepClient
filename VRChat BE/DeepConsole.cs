using Cysharp.Threading.Tasks.Linq;
using Sentry.Unity.NativeUtils;

namespace DeepClient.Client
{
    internal class DeepConsole
    {
        public static void Log(string c, string Text)
        {
            EntryPoint.Log.LogMessage($"[{c}] "+Text);
        }
        public static void Warn(string c, string Text)
        {
            EntryPoint.Log.LogWarning($"[{c}] "+Text);
        }

        public static void Error(string c, string Text)
        {
            EntryPoint.Log.LogError($"[{c}] "+Text);
        }
        public static void Fatal(string c, string Text)
        {
            EntryPoint.Log.LogFatal($"[{c}] "+Text);
        }
        public static void LogInfo(string c, string Text)
        {
            EntryPoint.Log.LogInfo($"[{c}] "+Text);
        }
        public static void LogDebug(string c, string Text)
        {
            EntryPoint.Log.LogDebug($"[{c}] "+Text);
        }
    }
}