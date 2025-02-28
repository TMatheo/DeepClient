using System.Collections;
using MelonLoader;
using UnityEngine;
using VRC.Core;
using VRC.UI;

namespace DeepCore.Client.UI.QM
{
    internal class Init
    {
        public static IEnumerator WaitForQM()
        {
            while (GameObject.Find("Canvas_QuickMenu(Clone)") == null)
            {
                yield return null;
            }
            Misc.VrcExtensions.SetQmDashbordPageTittle($"{ClientUtils.GetGreeting()}!");
            GameObject.Find("Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/QMParent/Menu_Dashboard/Header_H1/RightItemContainer").SetActive(false);
            GameObject.Find("Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Carousel_Banners").SetActive(false);
            GameObject.Find("Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_VRCPlusExperiment").SetActive(false);
            ClientMenu.MenuBuilder.MenuStart();
            MelonCoroutines.Start(QMConsole.StartConsole());
            if (ConfManager.ShouldMenuMusic.Value)
            {
                MelonCoroutines.Start(MenuMusic.MenuMusicInit());
            }
            MelonCoroutines.Start(MM.Init.WaitForMM());
            Module.QOL.ThirdPersonView.OnStart();
            DeepConsole.Log("Startup", $"Welcome Back, {APIUser.CurrentUser.displayName}");
        }
    }
}
