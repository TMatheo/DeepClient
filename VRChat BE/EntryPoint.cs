using BepInEx;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using UnityEngine;

namespace DeepClient
{
    [BepInPlugin("Biscuit", "DeepClient", "1.0")]
    public class EntryPoint : BasePlugin
    {
        internal static new ManualLogSource Log;
        public override void Load()
        {
            Log = base.Log;
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
            Client.Module.Movement.Flight.FlyUpdate();
            Client.Module.Movement.Jetpack.Update();
            Client.Module.Movement.RayCastTP.Update();
            Client.Module.Movement.SpinBot.Update();
            Client.Module.Exploits.ItemLagger.OnUpdate();
        }
    }
}
