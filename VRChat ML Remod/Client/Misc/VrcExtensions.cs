﻿using System.Collections;
using System.Linq;
using System.Windows.Forms;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRC;
using VRC.Core;
using VRC.Localization;
using VRC.Networking;
using VRC.SDKBase;
using VRC.UI;
using VRC.UI.Elements.Controls;

namespace DeepCore.Client.Misc
{
    public static class VrcExtensions
    {
        public static void AlertPopup(string tittle, string content, int time)
        {
            VRCUiPopupManager.field_Private_Static_VRCUiPopupManager_0.Method_Public_Void_LocalizableString_LocalizableString_Single_0(LocalizableStringExtensions.Localize(tittle, null, null, null), LocalizableStringExtensions.Localize(content, null, null, null), time);
        }
        public static Player GetPlayerNewtworkedId(int id)
        {
            return (from player in GetAllPlayers()
                    where player.prop_PlayerNet_0.field_Private_Int32_0 == id
                    select player).FirstOrDefault<Player>();
        }
        public static Player[] GetAllPlayers()
        {
            return PlayerManager.prop_PlayerManager_0.field_Private_List_1_Player_0.ToArray();
        }
        public static VRCPlayer GetLocalVRCPlayer()
        {
            return VRCPlayer.field_Internal_Static_VRCPlayer_0;
        }
        public static void Toast(string content, string description = null, Sprite icon = null, float duration = 5f)
        {
            LocalizableString localizableString = LocalizableStringExtensions.Localize(content, null, null, null);
            LocalizableString localizableString2 = LocalizableStringExtensions.Localize(description, null, null, null);
            VRCUiManager.field_Private_Static_VRCUiManager_0.field_Private_HudController_0.notification.Method_Public_Void_Sprite_LocalizableString_LocalizableString_Single_Object1PublicTYBoTYUnique_1_Boolean_0(SpriteManager.clientIcon, localizableString, localizableString2, duration, null);
        }
        public static void HudNotif(string Text)
        {
            LocalizableString localizableString = LocalizableStringExtensions.Localize(Text, null, null, null);
            VRCUiManager.field_Private_Static_VRCUiManager_0.field_Private_HudController_0.userEventCarousel.Method_Public_Void_LocalizableString_Sprite_0(localizableString, SpriteManager.clientIcon);
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
        public static void LogAvatar(VRCPlayer player)
        {
            Clipboard.SetText($@"
---------------------------------------------------------------------------------------------------------------------
Author:{player.field_Private_ApiAvatar_0.authorName}
ID:{player.field_Private_ApiAvatar_0.authorId}
Image URL:{player.field_Private_ApiAvatar_0.imageUrl}
Avatar id:{player.field_Private_ApiAvatar_0.id}
Avatar name:{player.field_Private_ApiAvatar_0.name}
Asset url:{player.field_Private_ApiAvatar_0.assetUrl}
Release status:{player.field_Private_ApiAvatar_0.releaseStatus}
Platform:{player.field_Private_ApiAvatar_0.platform}
Version:{player.field_Private_ApiAvatar_0.version}
---------------------------------------------------------------------------------------------------------------------");
        }
        public static void TpickupsToPlayer(VRCPlayer player)
        {
            if (Networking.LocalPlayer != null)
            {
                foreach (VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC_Pickup>())
                {
                    Networking.SetOwner(Networking.LocalPlayer, vrc_Pickup.gameObject);
                    vrc_Pickup.transform.position = player.gameObject.transform.position + new Vector3(0f, 0.1f, 0f);
                }
            }
        }
        public static void TpToPlayer(VRCPlayer player)
        {
            if (Networking.LocalPlayer != null)
            {
                Networking.LocalPlayer.gameObject.transform.position = player.gameObject.transform.position;
            }
        }
        public static void LoudMic(bool enable)
        {
            if (enable)
            {
                USpeaker.field_Internal_Static_Single_1 = float.MaxValue;
            }
            else
            {
                USpeaker.field_Internal_Static_Single_1 = 1f;
            }
        }
        internal static void ToggleCharacterController(bool toggle)
        {
            Player.prop_Player_0.gameObject.GetComponent<CharacterController>().enabled = toggle;
        }
        internal static void ToggleNetworkSerializer(bool toggle)
        {
            Player.prop_Player_0.gameObject.GetComponent<FlatBufferNetworkSerializer>().enabled = toggle;
        }
        public static VRCPlayerApi GetPlayerByUsername(string username)
        {
            VRCPlayerApi[] allPlayers = new VRCPlayerApi[VRCPlayerApi.GetPlayerCount()];
            foreach (VRCPlayerApi player in allPlayers)
            {
                if (player != null && player.displayName == username)
                {
                    return player;
                }
            }
            return null;
        }

        public static GameObject GetPlayerGameObject(VRCPlayerApi player)
        {
            return player.gameObject;
        }
        public static string QM_GetSelectedUserName()
        {
            return (GameObject.Find("Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/QMParent/Menu_SelectedUser_Local/ScrollRect/Viewport/VerticalLayoutGroup/UserProfile_Compact/PanelBG/Info/Text_Username_NonFriend"))?.GetComponent<TextMeshProUGUI>()?.text;
        }
        public static void SetQmDashbordPageTittle(string name)
        {
            GameObject.Find("Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/QMParent/Menu_Dashboard/Header_H1/LeftItemContainer/Text_Title").GetComponent<TextMeshProUGUI>().text = name;
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
        public static void ChangeAvatar(string avatar_id)
        {
            PageAvatar.Method_Public_Static_Void_ApiAvatar_String_0(new ApiAvatar
            {
                id = avatar_id
            }, "AvatarMenu");
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
