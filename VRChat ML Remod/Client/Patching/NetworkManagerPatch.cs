using DeepCore.Client.Misc;
using DeepCore.Client.Mono;
using VRC;

namespace DeepCore.Client.Patching
{
    internal class NetworkManagerPatch
    {
        public static void Patch()
        {
            EasyPatching.EasyPatchMethodPost(typeof(NetworkManager), "Method_Public_Void_Player_0", typeof(NetworkManagerPatch), "OnLeaveEvent");
            EasyPatching.EasyPatchMethodPost(typeof(NetworkManager), "Method_Public_Void_Player_1", typeof(NetworkManagerPatch), "OnJoinEvent");
        }
        internal static void OnJoinEvent(Player __0)
        {
            if (__0.field_Private_VRCPlayerApi_0.isLocal)
            {
                if (ConfManager.OwnerSpoof.Value)
                {
                    var localPlayer = PlayerUtil.GetLocalVRCPlayer().field_Private_VRCPlayerApi_0;
                    localPlayer.displayName = RoomManager.field_Internal_Static_ApiWorld_0.authorName;

                    string spoofMessage = $"Spoofed as: {localPlayer.displayName} | World Author: {RoomManager.field_Internal_Static_ApiWorld_0.authorName}";
                    DeepConsole.Log("OwnerSpoof", spoofMessage);
                    VrcExtensions.HudNotif(spoofMessage);
                }
                Module.QOL.LastInstanceRejoiner.SaveInstanceID();
                return;
            }
            if (ConfManager.playerLogger.Value)
            {
                DeepConsole.Log("PLogger", $"{__0.field_Private_APIUser_0.displayName} has joined.");
            }
            if (ConfManager.customnameplate.Value)
            {
                var nameplate = __0.gameObject.AddComponent<CustomNameplate>();
                nameplate.Player = __0;
            }
            API.PlayerTagSystem.CheckPlayer(__0);
            if (ConfManager.VRCAdminStaffLogger.Value && __0.field_Private_APIUser_0.hasModerationPowers)
            {
                string alertMessage = $"There is a VRChat mod in the lobby!\nName: {__0.field_Private_APIUser_0.displayName}";
                for (int i = 0; i < 3; i++)
                {
                    VrcExtensions.AlertPopup("ALERT: [MODERATOR/ADMIN]", alertMessage, 20);
                }
            }
            if (ConfManager.AntiQuest.Value && __0.field_Private_APIUser_0.IsOnMobile)
            {
                __0.gameObject.SetActive(false);
                DeepConsole.Log("AntiQuest", $"Locally Blocked Quest Player -> {__0.field_Private_APIUser_0.displayName}");
            }
        }
        internal static void OnLeaveEvent(Player __0)
        {
            if (__0.field_Private_VRCPlayerApi_0.isLocal)
            {
                Module.QOL.LastInstanceRejoiner.SaveInstanceID();
                return;
            }
            if (ConfManager.playerLogger.Value)
            {
                DeepConsole.Log("PLogger", $"{__0.field_Private_APIUser_0.displayName} has left.");
            }
        }
    }
}
