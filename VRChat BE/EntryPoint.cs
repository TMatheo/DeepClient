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
        public override void Load()
        {
            Log = base.Log;
            //Client.Patching.InitPatch.Start();
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
    }
}
