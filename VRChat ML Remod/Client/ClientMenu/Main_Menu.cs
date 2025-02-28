using DeepCore.Client.ClientMenu.Pages_MainMenu;
using ReMod.Core.Managers;

namespace DeepCore.Client.ClientMenu
{
    internal class Main_Menu
    {
        private static UiManager _uiManager;
        public static void InitMainMenu(UiManager UIManager)
        {
            _uiManager = UIManager;
            DeepConsole.Log("ClientUI","Initializing Main Menu...");
            VisualHacks.VisualSettingsMenu(_uiManager);
            MovementHacks.MovementHacksMenu(_uiManager);
            WorldHacks.WorldHacksMenu(_uiManager);
            ExploitHacks.ExploitHacksMenu(_uiManager);
            UtilFunctions.UtilFunctionsMenu(_uiManager);
            Module.ApplicationBot.AppBotMenu.APBFunctionsMenu(_uiManager);
            LastSeenAvatars.LoggedAvatarsMenu(_uiManager);
            InstaceHistory.InstaceHistoryHacksMenu(_uiManager);
            ClientSettings.ClientSettingsMenu(_uiManager);
        }
        public static void AddSpacers()
        {
            for (int i = 0; i < 8; i++)
            {
                _uiManager.QMMenu.AddSpacer();
            }
        }
    }
}
