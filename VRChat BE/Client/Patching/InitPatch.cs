using System;
using System.Reflection;
using DeepClient.Client.Patching.Modules;
using HarmonyLib;

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
            }
            catch (Exception ex)
            {
                DeepConsole.Log(ModuleName, "allowAvatarCopying:" + ex.Message);
            }
            try
            {
                Spoofer.InitSpoofs();
            }
            catch (Exception ex)
            {
                DeepConsole.Log(ModuleName, "Spoofer:" + ex.Message);
            }
            try
            {
                EasyPatching.DeepCoreInstance.PatchAll(typeof(HighlightColor));
            }
            catch (Exception ex)
            {
                DeepConsole.Log(ModuleName, "HighlightColor:" + ex.Message);
            }
            try
            {
                EasyPatching.DeepCoreInstance.PatchAll(typeof(OnPlayerJoined));
            }
            catch (Exception ex)
            {
                DeepConsole.Log(ModuleName, "OnPlayerJoined:" + ex.Message);
            }
            try
            {
                EasyPatching.DeepCoreInstance.PatchAll(typeof(OnPlayerLeft));
            }
            catch (Exception ex)
            {
                DeepConsole.Log(ModuleName, "OnPlayerLeft:" + ex.Message);
            }
            try
            {
                LoadBalancingClienta.Patch();
            }
            catch (Exception ex)
            {
                DeepConsole.Log(ModuleName, "LoadBalancingClient.OnEvent:" + ex.Message);
            }
            try
            {
                OnAvatarChanged.Patch();
            }
            catch (Exception ex)
            {
                DeepConsole.Log(ModuleName, "OnAvatarChanged:" + ex.Message);
            }
            try
            {
                RoomManagera.Patch();
            }
            catch (Exception ex)
            {
                DeepConsole.Log(ModuleName, "RoomManager:" + ex.Message);
            }
            try
            {
                TriggerWorld.Patch();
            }
            catch (Exception ex)
            {
                DeepConsole.Log(ModuleName, "TriggerWorld:" + ex.Message);
            }
            try
            {
                UdonSync.Patch();
            }
            catch (Exception ex)
            {
                DeepConsole.Log(ModuleName, "UdonSync:" + ex.Message);
            }
            try
            {
                EasyPatching.DeepCoreInstance.Patch(typeof(QuickMenu).GetMethod("OnEnable"), GetLocalPatch("QmOpen"), null, null, null, null);
                EasyPatching.DeepCoreInstance.Patch(typeof(QuickMenu).GetMethod("OnDisable"), GetLocalPatch("QmClose"), null, null, null, null);
            }
            catch (Exception ex)
            {
                DeepConsole.Log(ModuleName, "QuickMenu:" + ex.Message);
            }
            DeepConsole.Log(ModuleName, $"Placed hook successfully.");
        }
        private static void QmOpen()
        {
            DeepConsole.Log(ModuleName,"QM Open.");
            Coroutines.CustomMenuBG.ApplyColors();
            ClientMenu.MenuMusic.State(true);
        }
        private static void QmClose()
        {
            DeepConsole.Log(ModuleName, "QM Closed.");
            ClientMenu.MenuMusic.State(false);
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
