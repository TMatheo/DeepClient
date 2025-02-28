using UnityEngine;
using VRC.SDKBase;

namespace DeepCore.Client.Module.Visual
{
    internal class ESP
    {
        #region PickupsESP
        public static void ObjectState(bool s)
        {
            if (Networking.LocalPlayer == null)
                return;
            foreach (var pickup in GameObject.FindObjectsOfType<VRC_Pickup>())
            {
                var renderers = pickup.GetComponentsInChildren<Renderer>();
                foreach (var renderer in renderers)
                {
                    InputManager.EnableObjectHighlight(renderer.gameObject, s);
                }
            }
        }
        #endregion
        #region CapsuleESP
        public static void CapsuleState(bool s)
        {
            foreach (var player in VRCPlayerApi.AllPlayers)
            {
                if (player.isLocal)
                    continue;
                Transform transform = player.gameObject.transform.Find("SelectRegion");
                InputManager.EnableObjectHighlight(transform.GetComponent<Renderer>(), s);
            }
        }
        #endregion
        public static void ESPTest()
        {
            GameObject[] array = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject gameObject in array)
            {
                bool flag = gameObject.transform.Find("SelectRegion");
                if (flag)
                {
                    gameObject.transform.Find("SelectRegion").GetComponent<Renderer>().material.SetColor("_Color", Color.red);
                    gameObject.transform.Find("SelectRegion").GetComponent<Renderer>().sharedMaterial.SetColor("_Color", Color.red);
                    ToggleOutline(gameObject.transform.Find("SelectRegion").GetComponent<Renderer>(), false);
                }
            }
        }
        public static void ToggleOutline(Renderer renderer, bool state)
        {
            bool flag = HighlightsFX.field_Private_Static_HighlightsFX_0 == null;
            if (!flag)
            {
                HighlightsFX.field_Private_Static_HighlightsFX_0.Method_Protected_Boolean_Boolean_Boolean_PDM_0(renderer, state);
            }
        }
    }
}
