using UnityEngine;

namespace DeepClient.Client.Misc
{
    public static class PlayerNetEx
    {
        public static int GetFramerate(this PlayerNet_Internal playerNet)
        {
            if (playerNet == null)
                return 0;
            if (playerNet.field_Private_Byte_0 == 0)
                return 0;
            return (int)Mathf.Floor(1000f / playerNet.field_Private_Byte_0);
        }

        public static int GetPing(this PlayerNet_Internal playerNet)
        {
            if (playerNet == null)
                return 0;
            return playerNet.prop_Int16_0;
        }
    }
}