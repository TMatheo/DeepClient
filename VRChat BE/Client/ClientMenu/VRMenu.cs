using System.Collections;
using DeepClient.Client.Misc;
using DeepClient.Client.API.ButtonAPI.QM;
using UnityEngine;

namespace DeepClient.Client.ClientMenu
{
    public class VRMenu : MonoBehaviour
    {
        void Start()
        {
            DeepConsole.Log("Startup", "Waiting for qm...");
            QMMenuDashPage().Start();
        }
        private IEnumerator QMMenuDashPage()
        {
            while (GameObject.Find("Canvas_QuickMenu(Clone)") == null)
            {
                yield return null;
            }
            GameObject.Find("Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/QMParent/Menu_Dashboard/ScrollRect").GetComponent<ScrollRectPublicIBeginDragHandlerIEventSystemHandlerIEndDragHandlerIDragHandlerIScrollHandlerSiSt_cBomiSi_aBoUI_fUnique>().enabled = true;
            QMDashboard.AddHeader("DeepClient", "DeepClient");
            QMDashboard.CreateButtonPref("DeepClient");
            QMDashboard.AddButton("DeepClient", "Test1", "Test1", true, delegate ()
            {
            }); 
        }
    }
}
