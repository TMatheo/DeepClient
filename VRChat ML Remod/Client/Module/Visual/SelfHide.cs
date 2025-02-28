using VRC.SDKBase;

namespace DeepCore.Client.Module.Visual
{
    internal class SelfHide
    {
        internal static void selfhidePlayer(bool s)
        {
            if (Networking.LocalPlayer == null)
            {
                return;
            }
            if (s)
            {
                if (VRCPlayer.field_Internal_Static_VRCPlayer_0._player.prop_ApiAvatar_0.id != null)
                {
                    backupid = VRCPlayer.field_Internal_Static_VRCPlayer_0._player.prop_ApiAvatar_0.id;
                }
            }
            Misc.VrcExtensions.GetLocalPlayer().transform.Find("ForwardDirection").gameObject.active = !s;
        }
        private static string backupid;
    }
}
