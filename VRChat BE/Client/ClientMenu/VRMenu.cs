using System.Collections;
using UnityEngine;
using DeepClient.Client.Misc.DeepClient.Client.Misc;
using DeepClient.Client.API.ButtonAPI.QM;
using DeepClient.Client.Module.Exploits;
using DeepClient.Client.Misc;

namespace DeepClient.Client.ClientMenu
{
    public class VRMenu : MonoBehaviour
    {
        void Start()
        {
            DeepConsole.Log("Startup", "Waiting for qm...");
            QMConsole.StartConsole().Start();
            MenuMusic.MenuMusicInit().Start();
            QMMenuDashPage().Start();
            QMMenuDevPage().Start();
        }
        private IEnumerator QMMenuDashPage()
        {
            while (GameObject.Find("Canvas_QuickMenu(Clone)") == null)
            {
                yield return null;
            }
            QMDashboard.Setup();
            QMDashboard.AddHeader("DeepClient", "DeepClient");
            QMDashboard.CreateButtonPref("DeepClient");
            QMDashboard.AddButton("DeepClient", "Flight", "Flight", true, delegate ()
            {
                Module.Movement.Flight.FlyToggle();
            }); 
        }
        private IEnumerator QMMenuDevPage()
        {
            while (GameObject.Find("Canvas_QuickMenu(Clone)") == null)
            {
                yield return null;
            }
            QMDevTools.Setup("DeepClient");
            QMDevTools.AddButton("LoudMic", "LoudMic", true, delegate ()
            {
                LoudMic.IsEnabled = !LoudMic.IsEnabled;
                LoudMic.State(LoudMic.IsEnabled);
            });
            QMDevTools.AddButton("E1", "E1", true, delegate ()
            {
                EarRape.Earape = !EarRape.Earape;
                EarRape.State(EarRape.Earape);
            });
            QMDevTools.AddButton("BigAvatar", "Big Avatar", true, delegate ()
            {
                AvatarHeight.BigAvi = !AvatarHeight.BigAvi;
                AvatarHeight.BigState(AvatarHeight.BigAvi);
            });
            QMDevTools.AddButton("SmallAvata", "Small Avata", true, delegate ()
            {
                AvatarHeight.SmallAvi = !AvatarHeight.SmallAvi;
                AvatarHeight.SmallState(AvatarHeight.SmallAvi);
            });
            QMDevTools.AddButton("ItemLagger", "Item Lagger", true, delegate ()
            {
                ItemLagger.IsEnabled = !ItemLagger.IsEnabled;
                ItemLagger.State(ItemLagger.IsEnabled);
            });
            QMDevTools.AddButton("AntiTheft", "AntiTheft", true, delegate ()
            {
                AntiTheft.IsEnabled = !AntiTheft.IsEnabled;
                AntiTheft.AntiPickupTheft(AntiTheft.IsEnabled);
            });
            QMDevTools.AddButton("UdonNuke", "Udon Nuke", true, delegate ()
            {
                UdonNuker.Nuke().Start();
            });
            QMDevTools.AddButton("Unicode", "Unicode\nChat", true, delegate ()
            {
                PhotonEx.SendChatBoxMessage("\v\v\v\v\v\v\v\v\v\v\v\v\v\v\v\v\v\v\v\v\v\v\v\v\v\v\v\v\v\v\v\v\v\v\v\v\v\v\v\v\v\v\v\v\v\v\v\v\v\v\v\v\v\v\v\v\v\v\v\v\v\v\v\v\v\v\v\v\v\v\v");
            });
            QMDevTools.AddButton("DestroyPortals", "DestroyPortals", true, delegate ()
            {
                PortalEploits.DestroyPortals();
            });
        }
    }
}
