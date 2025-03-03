using System.Collections;
using DeepClient.Client.Misc;
using DeepClient.Client.API.ButtonAPI.QM;
using UnityEngine;
using DeepClient.Client.Misc.DeepClient.Client.Misc;

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
        }
        private IEnumerator QMMenuDashPage()
        {
            while (GameObject.Find("Canvas_QuickMenu(Clone)") == null)
            {
                yield return null;
            }
            QMDashboard.Setup();
            GameObject.Find("Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/QMParent/Menu_Dashboard/ScrollRect").GetComponent<ScrollRectPublicIBeginDragHandlerIEventSystemHandlerIEndDragHandlerIDragHandlerIScrollHandlerSiSt_cBomiSi_aBoUI_fUnique>().enabled = true;
            QMDashboard.AddHeader("DeepClient", "DeepClient");
            QMDashboard.CreateButtonPref("DeepClient");
            QMDashboard.AddButton("DeepClient", "Flight", "Flight", true, delegate ()
            {
                Module.Movement.Flight.FlyToggle();
            }); 
        }
    }
}
