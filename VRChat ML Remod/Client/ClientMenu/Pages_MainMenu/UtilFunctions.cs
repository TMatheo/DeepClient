using System;
using DeepCore.Client.Misc;
using MelonLoader;
using ReMod.Core.Managers;
using ReMod.Core.UI.QuickMenu;

namespace DeepCore.Client.ClientMenu.Pages_MainMenu
{
    internal class UtilFunctions
    {
        public static void UtilFunctionsMenu(UiManager UIManager)
        {
            ReCategoryPage reCategoryPage = UIManager.QMMenu.AddCategoryPage("Utils Functions", null);
            reCategoryPage.AddCategory("Functions");
            ReMenuCategory category = reCategoryPage.GetCategory("Functions");
            category.AddButton("Backup FrindIDs", "Allow you to bacups all of your frinds to a TXT.", delegate
            {
                ClientUtils.SaveFrinds();
            });
            category.AddButton("Russian Roulette", "Suka Blyat :3", delegate
            {
                Module.Funnies.RussianRoulette.RouletteStart();
            });
            category.AddButton("Log Udon", "Allow you to log all udon in a TXT.", delegate
            {
                ClientUtils.LogUdon();
            });
            category.AddButton("Log VRCPickups", "Allow you to log all pickups in a TXT.", delegate
            {
                ClientUtils.LogItems();
            });
            category.AddButton("Clear Log", "Allow you to clear all log in debug/console.", delegate
            {
                Console.Clear();
                UI.QM.QMConsole.ClearLog();
            });
            category.AddToggle("HideShow QMConsole", "Allow you to show and hide qmconsole.", delegate (bool s)
            {
                UI.QM.QMConsole.ConsoleVisuabillity(s);
            },false);
        }
    }
}
