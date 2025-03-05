using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

namespace DeepClient.Client.Patching.Modules
{
    internal class FakeHWID
    {
        public static string newHWID = "";
        public static void Patch()
        {
            EasyPatching.EasyPatchMethodPost(typeof(SystemInfo), "deviceUniqueIdentifier", typeof(FakeHWID), "Hook");
        }
        public static bool Hook(ref string __result)
        {
            if (newHWID == string.Empty)
            {
                newHWID = KeyedHashAlgorithm.Create().ComputeHash(Encoding.UTF8.GetBytes(string.Format("{0}A-{1}{2}-{3}{4}-{5}{6}-3C-1F", new object[]
                {
                    new System.Random().Next(0, 9),
                    new System.Random().Next(0, 9),
                    new System.Random().Next(0, 9),
                    new System.Random().Next(0, 9),
                    new System.Random().Next(0, 9),
                    new System.Random().Next(0, 9),
                    new System.Random().Next(0, 9) }))).Select(delegate (byte x)
                    {
                        byte b = x;
                        return b.ToString("x2");
                    }).Aggregate((string x, string y) => x + y);

                DeepConsole.Log($"Patch", "[Spoofer]: Success Patched HWID {newHWID}");
            }
            __result = newHWID;
            return false;
        }
    }
}
