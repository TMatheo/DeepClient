using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Valve.VR.InteractionSystem;
using VRC.Core;

namespace DeepClient.Client.Patching.Modules
{
    internal class UdonSync
    {
        public static bool log = false;
        public static bool block = false;

        public static void Patch()
        {
            EasyPatching.DeepCoreInstance.Patch(typeof(UdonSync).GetMethod("UdonSyncRunProgramAsRPC"), EasyPatching.GetLocalPatch<UdonSync>("OnUdon"), null, null, null, null);
        }
        internal static bool OnUdon(string __0, VRCPlayer __1)
        {
            if (log)
            {
                DeepConsole.Log("UdonSync", string.Concat(new string[]
                {
                    "Type:",
                    __0,
                    " | from:",
                    __1.field_Private_VRCPlayerApi_0.displayName,
                    "."
                }));
            }
            return !block;
        }
    }
}