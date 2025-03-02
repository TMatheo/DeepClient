using System.Linq;
using System.Reflection;
using ExitGames.Client.Photon;
using HarmonyLib;

namespace DeepClient.Client.Patching.Modules
{
    internal class LoadBalancingClienta
    {
        public static bool isdebugtime = false;
        public static void Patch()
        {
            EasyPatching.DeepCoreInstance.Patch(typeof(LoadBalancingClient_Internal).GetMethods().LastOrDefault((MethodInfo x) => x.Name.Equals("OnEvent")), new HarmonyMethod(AccessTools.Method(typeof(LoadBalancingClienta), "OnEvent", null, null)), null, null, null, null);
        }
        internal static bool OnEvent(EventData param_1)
        {
            if (isdebugtime)
            {
                DeepConsole.Log("Photon", "--------------------------------------------------");
                DeepConsole.Log("Photon", $"Event Code:{param_1.Code}");
                DeepConsole.Log("Photon", $"Event type:{param_1.Sender}");
                DeepConsole.Log("Photon", $"Sender:{param_1.Sender}");
                DeepConsole.Log("Photon", $"SenderKey:{param_1.SenderKey}");
                DeepConsole.Log("Photon", $"Parameters:{param_1.Parameters}");
                DeepConsole.Log("Photon", $"Pointer:{param_1.Pointer}");
                //DeepConsole.Log("Photon", $"Data:{PrintByteArray(SerializationUtil.ToByteArray(param_1.CustomData))}");
                DeepConsole.Log("Photon", "--------------------------------------------------");
            }
            return true;
        }
    }
}
