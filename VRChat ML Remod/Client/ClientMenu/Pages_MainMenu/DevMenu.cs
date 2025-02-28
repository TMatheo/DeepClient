using ReMod.Core.Managers;
using ReMod.Core.UI.QuickMenu;
using UnityEngine;

namespace DeepCore.Client.ClientMenu.Pages_MainMenu
{
    internal class DevMenu
    {
        public static void DevFunctionsMenu(UiManager UIManager)
        {
            ReCategoryPage reCategoryPage = UIManager.QMMenu.AddCategoryPage("Dev Functions", null);
            reCategoryPage.AddCategory("Functions");
            ReMenuCategory category = reCategoryPage.GetCategory("Functions");
            category.AddButton("Test\nAlertPopup", "", delegate
            {
                Misc.PopupHelper.AlertPopup("Dev Test", "Dev Test MSG",100);
            });
            category.AddButton("Test\nStandardPopup", "", delegate
            {
                Misc.PopupHelper.StandardPopup("Dev Test", "Dev Test MSG","nigga",null);
            });
            category.AddButton("Test\nStandardPopupV2", "", delegate
            {
                Misc.PopupHelper.StandardPopupV2("Dev Test", "Dev Test MSG", "nigga", null);
            });
            category.AddButton("Test\nThings", "", delegate
            {
                Misc.PopupHelper.testthings();
            });
            category.AddButton("Become the bot", "", delegate
            {
                Module.ApplicationBot.SocketConnection.Client();
            });
            category.AddButton("Test LogConsole", "", delegate
            {
                UI.QM.QMConsole.LogMessage("Test","Shit");
            });
            category.AddButton("Test E1", "", delegate
            {
                Module.Exploits.EarRape.Teste1();
            });
            category.AddButton("Test Spoofer", "", delegate
            {
                DeepConsole.LogConsole("Spoofer", $"PC Name New: {SystemInfo.deviceName}");
                DeepConsole.LogConsole("Spoofer", $"Model New: {SystemInfo.deviceModel}");
                DeepConsole.LogConsole("Spoofer", $"PBU New: {SystemInfo.graphicsDeviceName}");
                DeepConsole.LogConsole("Spoofer", $"CPU New: {SystemInfo.processorType}");
                DeepConsole.LogConsole("Spoofer", $"PBU ID New: {SystemInfo.graphicsDeviceID.ToString()}");
                DeepConsole.LogConsole("Spoofer", $"OS New:{SystemInfo.operatingSystem}");
            });
        }
    }
}
