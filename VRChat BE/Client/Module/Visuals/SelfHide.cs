using VRC.SDKBase;

namespace DeepClient.Client.Module.Visuals
{
    internal class SelfHide
    {
        internal static void SelfHidePlayer(bool s)
        {
            if (Networking.LocalPlayer == null)
            {
                return;
            }
            if (s)
            {
                VRCPlayer.field_Internal_Static_MonoBehaviour1PublicOb_pOb_s_pBoGaOb_pStUnique_0.transform.Find("ForwardDirection").gameObject.active = !s;
            }
        }
    }
}