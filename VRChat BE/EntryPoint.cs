using BepInEx;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using DeepClient.Client;
using UnityEngine;

namespace DeepClient
{
    [BepInPlugin("Biscuit", "DeepClient", "1.0")]
    public class EntryPoint : BasePlugin
    {
        internal static new ManualLogSource Log;
        public static bool IsBot = false;
        public override void Load()
        {
            Log = base.Log;
            DeepConsole.Alloc();
            Client.Patching.InitPatch.Start();
            Client.Coroutines.CoroutineManager.Init();
            AddComponent<MainMonoBehaviour>();
            AddComponent<Client.ClientMenu.VRMenu>();
        }
    }
    public class MainMonoBehaviour : MonoBehaviour
    {
        void OnEnable()
        {
            DearImGuiInjection.DearImGuiInjection.Render += Client.GUI.Rendering.RenderGui;
        }
        void Update()
        {
            Client.Module.Visuals.FlipScreen.OnUpdate();
            Client.Module.Visuals.OptifineZoom.Update();
            Client.Module.Visuals.ThirdPersonView.Update();
            Client.Module.Movement.Flight.FlyUpdate();
            Client.Module.Movement.Jetpack.Update();
            Client.Module.Movement.RayCastTP.Update();
            Client.Module.Movement.SpinBot.Update();
            Client.Module.Exploits.ItemLagger.OnUpdate();
        }
    }
}
