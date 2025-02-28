using System;
using System.Collections;
using DeepCore.Client.Module.Exploits;
using ReMod.Core.UI.MainMenu;
using ReMod.Core.VRChat;
using UnityEngine;

namespace DeepCore.Client.UI.MM
{
    internal class Init
    {
        public static IEnumerator WaitForMM()
        {
            while (GameObject.Find("Canvas_MainMenu(Clone)") == null)
            {
                yield return null;
            }
            new ReMMUserButton("Invite x10", "Invite x10.", delegate ()
            {
                InvSpammer.Spasm();
            }, null, MMenuPrefabs.MMUserDetailButton.transform.parent);
            yield break;
        }
    }
}