﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using VRC.UI;

namespace DeepCore.Client.Coroutine
{
    internal class CustomMenuBG
    {
        public static bool IsLoaded = false;
        public static IEnumerator Init()
        {
            while (GameObject.Find("MenuContent/Backdrop/Backdrop/Background") == null)
            {
                yield return null;
            }
            GameObject.Find("MenuContent/Backdrop/Backdrop/Background").GetComponent<Image>().overrideSprite = ReMod.Core.Managers.ResourceManager.LoadSpriteFromDisk("DeepClient/MMBG.png");
            GameObject.Find("MenuContent/Backdrop/Backdrop/Background").GetComponent<Image>().color = Color.white;
            while (GameObject.Find("Canvas_QuickMenu(Clone)") == null)
            {
                yield return null;
            }
            GameObject.Find("Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/QMParent/BackgroundLayer01").GetComponent<ImageEx>().overrideSprite = ReMod.Core.Managers.ResourceManager.LoadSpriteFromDisk("DeepClient/QMBG.png");
            while (GameObject.Find("Canvas_MainMenu(Clone)") == null)
            {
                yield return null;
            }
            GameObject.Find("Canvas_MainMenu(Clone)/Container/MMParent/BackgroundLayer01").GetComponent<ImageEx>().overrideSprite = ReMod.Core.Managers.ResourceManager.LoadSpriteFromDisk("DeepClient/MMBG.png");
            IsLoaded = true;
        }
        public static void ApplyColors()
        {
            if (IsLoaded)
            {
                GameObject.Find("Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/QMParent/BackgroundLayer01").GetComponent<ImageEx>().color = Color.white;
                GameObject.Find("Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/QMParent/BackgroundLayer01").GetComponent<ImageEx>().m_Color = Color.white;
                GameObject.Find("Canvas_MainMenu(Clone)/Container/MMParent/BackgroundLayer01").GetComponent<ImageEx>().color = Color.white;
                GameObject.Find("Canvas_MainMenu(Clone)/Container/MMParent/BackgroundLayer01").GetComponent<ImageEx>().m_Color = Color.white;
                IsLoaded = false;
            }
        }
    }
}
