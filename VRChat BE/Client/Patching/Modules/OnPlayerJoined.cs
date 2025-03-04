using HarmonyLib;

namespace DeepClient.Client.Patching.Modules
{
    [HarmonyPatch(typeof(MonoBehaviourPublicDaBoAc1ObDiOb2InHaUnique), nameof(MonoBehaviourPublicDaBoAc1ObDiOb2InHaUnique.OnPlayerJoined))]
    class OnPlayerJoined
    {
        static void Postfix(PlayerNet_Internal param_1)
        {
            DeepConsole.Log("PLogger", $"{param_1.prop_MonoBehaviourPublicAPOb_vOb_l_pBoOb1BoUnique_0.field_Private_VRCPlayerApi_0.displayName} has joined.");
        }
    }
}
