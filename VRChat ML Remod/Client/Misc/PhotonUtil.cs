using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;

namespace DeepCore.Client.Misc
{
    internal class PhotonUtil
    {
        public static void SendChatBoxMessage(string message)
        {
            OpRaiseEvent(43, message, new RaiseEventOptions
            {
                field_Public_EventCaching_0 = 0,
                field_Public_ReceiverGroup_0 = 0
            }, default(SendOptions));
        }
        public static void OpRaiseEvent(byte code, object customObject, RaiseEventOptions RaiseEventOptions, SendOptions sendOptions)
        {
            Il2CppSystem.Object customObject2 = SerializationUtil.FromManagedToIL2CPP<Il2CppSystem.Object>(customObject);
            OpRaiseEvent(code, customObject2, RaiseEventOptions, sendOptions);
        }
        public static void OpRaiseEvent(byte code, Il2CppSystem.Object customObject, RaiseEventOptions RaiseEventOptions, SendOptions sendOptions)
        {
            PhotonNetwork.Method_Public_Static_Boolean_Byte_Object_RaiseEventOptions_SendOptions_0(code, customObject, RaiseEventOptions, sendOptions);
        }
    }
}
