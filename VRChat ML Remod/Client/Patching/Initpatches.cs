using System;
using System.Reflection;
using ExitGames.Client.Photon;
using HarmonyLib;
using MelonLoader;
using Photon.Realtime;
using VRC.Economy;
using VRC.SDKBase;
using VRC.UI.Elements;

namespace DeepCore.Client.Patching
{
    internal class Initpatches
    {
        public static string ModuleName = "HookManager";
        public static int pass = 0;
        public static int fail = 0;
        [Obsolete]
        public static void Start()
        {
            DeepConsole.Log("Startup", "Starting Hooks...");
            try
            {
                ClonePatch.Patch();
                pass++;
            }
            catch (Exception ex)
            {
                DeepConsole.Log(ModuleName, "allowAvatarCopying:" + ex.Message);
                fail++;
            }
            try
            {
                SpooferPatch.InitSpoofs();
                pass++;
            }
            catch (Exception ex)
            {
                DeepConsole.Log(ModuleName, "Spoofer:" + ex.Message);
                fail++;
            }
            try
            {
                EasyPatching.DeepCoreInstance.PatchAll(typeof(HighlightColorPatch));
                pass++;
            }
            catch (Exception ex)
            {
                DeepConsole.Log(ModuleName, "HighlightColor:" + ex.Message);
                fail++;
            }
            try
            {
                LoadBalancingClientPatch.Patch();
                pass++;
            }
            catch (Exception ex)
            {
                DeepConsole.Log(ModuleName, "LoadBalancingClient.OnEvent:" + ex.Message);
                fail++;
            }
            try
            {
                EasyPatching.DeepCoreInstance.Patch(typeof(LoadBalancingClient).GetMethod("Method_Public_Virtual_New_Boolean_Byte_Object_RaiseEventOptions_SendOptions_0"), GetLocalPatch("Patch_OnEventSent"), null, null, null, null);
                pass++;
            }
            catch (Exception ex)
            {
                DeepConsole.Log(ModuleName, "LoadBalancingClient.OnEventSent:" + ex.Message);
                fail++;
            }
            try
            {
                NetworkManagerPatch.Patch();
                pass++;
            }
            catch (Exception ex)
            {
                DeepConsole.Log(ModuleName, "NetworkManager:" + ex.Message);
                fail++;
            }
            try
            {
                OnAvatarChangedPatch.Patch();
                pass++;
            }
            catch (Exception ex)
            {
                DeepConsole.Log(ModuleName,"OnAvatarChanged:"+ex.Message);
                fail++;
            }
            try
            {
                RoomManagerPatch.Patch();
                pass++;
            }
            catch (Exception ex)
            {
                DeepConsole.Log(ModuleName, "RoomManager:" + ex.Message);
                fail++;
            }
            try
            {
                TriggerWorldPatch.Patch();
                pass++;
            }
            catch (Exception ex)
            {
                DeepConsole.Log(ModuleName, "TriggerWorld:" + ex.Message);
                fail++;
            }
            try
            {
                UdonSyncPatch.Patch();
                pass++;
            }
            catch (Exception ex)
            {
                DeepConsole.Log(ModuleName, "UdonSync:" + ex.Message);
                fail++;
            }
            try
            {
                EasyPatching.DeepCoreInstance.Patch(typeof(VRCPlusStatus).GetProperty("prop_Object1PublicTYBoTYUnique_1_Boolean_0").GetGetMethod(), null,GetLocalPatch("GetVRCPlusStatus"), null, null, null);
                pass++;
            }
            catch (Exception ex)
            {
                DeepConsole.Log(ModuleName, "VRCPlusStatus:" + ex.Message);
                fail++;
            }
            try
            {
                EasyPatching.DeepCoreInstance.Patch(typeof(Store).GetMethod("Method_Private_Boolean_VRCPlayerApi_IProduct_PDM_0"), new HarmonyMethod(typeof(Initpatches).GetMethod("MarketPatch", BindingFlags.Static | BindingFlags.NonPublic)), null, null, null, null);
                pass++;
            }
            catch (Exception ex)
            {
                DeepConsole.Log(ModuleName, "Store:" + ex.Message);
                fail++;
            }
            try
            {
                EasyPatching.DeepCoreInstance.Patch(typeof(QuickMenu).GetMethod("OnEnable"),GetLocalPatch("QmOpen"), null, null, null, null);
                EasyPatching.DeepCoreInstance.Patch(typeof(QuickMenu).GetMethod("OnDisable"),GetLocalPatch("QmClose"), null, null, null, null);
                pass++;
            }
            catch (Exception ex)
            {
                DeepConsole.Log(ModuleName, "QuickMenu:" + ex.Message);
                fail++;
            }
            DeepConsole.Log(ModuleName, $"Placed {pass} hook successfully, with {fail} failed.");
        }
        private static void QmOpen()
        {
            if (ConfManager.ShouldQMFreeze.Value)
            {
                Module.QOL.QMFreeze.State(true);
            }
            Coroutine.CustomMenuBG.ApplyColors();
            UI.QM.MenuMusic.State(true);
        }
        private static void QmClose()
        {
            if (ConfManager.ShouldQMFreeze.Value)
            {
                Module.QOL.QMFreeze.State(false);
            }
            UI.QM.MenuMusic.State(false);
        }
        private static void GetVRCPlusStatus(ref Object1PublicTYBoTYUnique<bool> __result)
        {
            bool flag = __result == null;
            if (!flag)
            {
                __result.prop_TYPE_0 = true;
            }
        }
        private static bool MarketPatch(VRCPlayerApi __0, IProduct __1, ref bool __result)
        {
            __result = true;
            return false;
        }
        internal static bool Patch_OnEventSent(byte __0, object __1, RaiseEventOptions __2, SendOptions __3)
        {
            if (Module.Photon.MovementSerilize.IsEnabled)
            {
                return Module.Photon.MovementSerilize.OnEventSent(__0, __1, __2, __3);
            }
            if (Module.Photon.PhotonDebugger.IsOnEventSendDebug)
            {
                return Module.Photon.PhotonDebugger.OnEventSent(__0, __1, __2, __3);
            }
            return true;
        }

        public static HarmonyMethod GetLocalPatch(string name)
        {
            HarmonyMethod result;
            try
            {
                result = (HarmonyMethod)typeof(Initpatches).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic).ToNewHarmonyMethod();
            }
            catch (Exception arg)
            {
                DeepConsole.Log(ModuleName, (string.Format("{0}: {1}", name, arg)));
                result = null;
            }
            return result;
        }
    }
}
