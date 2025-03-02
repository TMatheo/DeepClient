using HarmonyLib;

namespace DeepClient.Client.Patching.Modules
{
    [HarmonyPatch(typeof(MonoBehaviourPublicDaBoAc1ObDiOb2InHaUnique), nameof(MonoBehaviourPublicDaBoAc1ObDiOb2InHaUnique.OnPlayerLeft))]
    class OnPlayerLeft
    {
        static void Postfix(VRCPlayer param_1)
        {
            DeepConsole.Log("PLogger", $" has leave.");
        }
    }
}