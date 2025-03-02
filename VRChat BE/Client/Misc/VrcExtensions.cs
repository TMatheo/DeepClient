using UnityEngine;

namespace DeepClient.Client.Misc
{
    internal class VrcExtensions
    {
        internal static void ToggleCharacterController(bool toggle)
        {
            VRCPlayer.field_Internal_Static_MonoBehaviour1PublicOb_pOb_s_pBoGaOb_pStUnique_0.gameObject.GetComponent<CharacterController>().enabled = toggle;
        }
    }
}
