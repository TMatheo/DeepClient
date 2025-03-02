using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Valve.VR.InteractionSystem;
using VRC.Core;
using VRC.SDKBase;

namespace DeepClient.Client.Patching.Modules
{
    internal class OnAvatarChanged
    {
        public static void Patch()
        {
            (from m in typeof(VRCPlayer).GetMethods()
             where m.Name.StartsWith("Method_Private_Void_GameObject_VRC_AvatarDescriptor_")
             select m).ToList<MethodInfo>().ForEach(delegate (MethodInfo m)
             {
                 EasyPatching.DeepCoreInstance.Patch(typeof(VRCPlayer).GetMethod(m.Name), EasyPatching.GetLocalPatch<OnAvatarChanged>("OnAvaLoaded"), null, null, null, null);
             });
        }
        internal static void OnAvaLoaded(GameObject __0, VRC_AvatarDescriptor __1, VRCPlayer __instance)
        {
            try
            {
                DeepConsole.Log("AvaLogger",$"New Avi < INSERTY HERE > {__instance._player.field_Private_APIUser_0.displayName}");
            }
            catch (Exception ex)
            {
            }
        }
        private static string last_log;
    }
}