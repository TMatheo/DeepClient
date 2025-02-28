using UnityEngine;
using VRC.Udon;

namespace DeepCore.Client.Module.WorldHacks
{
    internal class AmongUs
    {
        public static void AmongUsCheat(string udonEvent)
        {
            foreach (GameObject gameObject in Resources.FindObjectsOfTypeAll<GameObject>())
            {
                bool flag = gameObject.name.Contains("Game Logic");
                if (flag)
                {
                    gameObject.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, udonEvent);
                }
            }
        }
    }
}
