using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DeepClient.Client.Misc
{
    internal class VrcExtensions
    {
        internal static void ToggleCharacterController(bool toggle)
        {
            VRCPlayer.field_Internal_Static_MonoBehaviour1PublicOb_pOb_s_pBoGaOb_pStUnique_0.gameObject.GetComponent<CharacterController>().enabled = toggle;
        }
        public static void SetQmDashbordPageTittle(string name)
        {
            GameObject.Find("Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/QMParent/Menu_Dashboard/Header_H1/LeftItemContainer/Text_Title").GetComponent<TextMeshProUGUI>().text = name;
        }
        public static string QM_GetSelectedUserName()
        {
            return (GameObject.Find("Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/QMParent/Menu_SelectedUser_Local/ScrollRect/Viewport/VerticalLayoutGroup/UserProfile_Compact/PanelBG/Info/Text_Username_NonFriend"))?.GetComponent<TextMeshProUGUI>()?.text;
        }
        public static void ListenPlayer(VRCPlayer player, bool state)
        {
            if (!state)
            {
                player.field_Private_VRCPlayerApi_0.SetVoiceDistanceFar(25f);
                return;
            }
            player.field_Private_VRCPlayerApi_0.SetVoiceDistanceFar(float.PositiveInfinity);
        }
        public static IEnumerator SetMicColor()
        {
            while (GameObject.Find("UnscaledUI/HudContent/HUD_UI 2(Clone)/VR Canvas/Container/Left/Icons/Mic") == null)
            {
                yield return null;
            }
            GameObject.Find("UnscaledUI/HudContent/HUD_UI 2(Clone)/VR Canvas/Container/Left/Icons/Mic").GetComponent<MonoBehaviourPublicImCoImVeCoBoVeSiAuVeUnique>().field_Public_Color_0 = Color.blue;
            GameObject.Find("UnscaledUI/HudContent/HUD_UI 2(Clone)/VR Canvas/Container/Left/Icons/Mic").GetComponent<MonoBehaviourPublicImCoImVeCoBoVeSiAuVeUnique>().field_Public_Color_1 = Color.blue;
        }
        private static GameObject[] GetAllRootGameObjects()
        {
            return SceneManager.GetActiveScene().GetRootGameObjects();
        }
        internal static GameObject GetLocalPlayer()
        {
            foreach (GameObject gameObject in GetAllRootGameObjects())
            {
                if (gameObject.name.StartsWith("VRCPlayer[Local]"))
                {
                    return gameObject;
                }
            }
            return new GameObject();
        }
    }
}