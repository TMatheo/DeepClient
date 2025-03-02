using System;
using System.Reflection;
using DeepClient.Client.Patching.Modules;
using HarmonyLib;
using VRC.SDKBase;

namespace DeepClient.Client.Patching
{
    internal class InitPatch
    {
        public static string ModuleName = "HookManager";
        public static int pass = 0;
        public static int fail = 0;
        public static void Start()
        {
            DeepConsole.Log("Startup", "Starting Hooks...");
            try
            {
                ForceClone.Patch();
                pass++;
            }
            catch (Exception ex)
            {
                DeepConsole.Log(ModuleName, "allowAvatarCopying:" + ex.Message);
                fail++;
            }
            try
            {
                Spoofer.InitSpoofs();
                pass++;
            }
            catch (Exception ex)
            {
                DeepConsole.Log(ModuleName, "Spoofer:" + ex.Message);
                fail++;
            }
            try
            {
                LoadBalancingClienta.Patch();
                pass++;
            }
            catch (Exception ex)
            {
                DeepConsole.Log(ModuleName, "LoadBalancingClient.OnEvent:" + ex.Message);
                fail++;
            }
            try
            {
                EasyPatching.DeepCoreInstance.PatchAll(typeof(OnPlayerJoined));
                pass++;
            }
            catch (Exception ex)
            {
                DeepConsole.Log(ModuleName, "NetworkManager.OnPlayerJoined" + ex.Message);
                fail++;
            }
            try
            {
                EasyPatching.DeepCoreInstance.PatchAll(typeof(OnPlayerLeft));
                pass++;
            }
            catch (Exception ex)
            {
                DeepConsole.Log(ModuleName, "NetworkManager.OnPlayerLeft" + ex.Message);
                fail++;
            }
        }
        public static HarmonyMethod GetLocalPatch(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                DeepConsole.Log(ModuleName, "Method name cannot be null or empty.");
                return null;
            }
            try
            {
                MethodInfo method = typeof(InitPatch).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic);
                if (method == null)
                {
                    DeepConsole.Log(ModuleName, $"Method '{name}' not found in InitPatch.");
                    return null;
                }
                return ToHarmonyMethod(method);
            }
            catch (Exception ex)
            {
                DeepConsole.Log(ModuleName, $"Error in GetLocalPatch '{name}': {ex}");
                return null;
            }
        }
        private static HarmonyMethod ToHarmonyMethod(MethodInfo method)
        {
            return method != null ? new HarmonyMethod(method) : null;
        }
    }
}
