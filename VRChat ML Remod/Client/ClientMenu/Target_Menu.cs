using DeepCore.Client.Module.Exploits;
using ReMod.Core.Managers;
using ReMod.Core.UI.QuickMenu;
using ReMod.Core.VRChat;

namespace DeepCore.Client.ClientMenu
{
    internal class Target_Menu
    {
        private static UiManager _uiManager;
        public static void InitMainMenu(UiManager UIManager)
        {
            _uiManager = UIManager;
            DeepConsole.Log("ClientUI", "Initializing Target Menu...");
            IButtonPage targetMenu = _uiManager.TargetMenu;
            targetMenu.AddButton("TestShit.", "Test 1", delegate
            {
                ForceLewd.LewdPlayer(PlayerExtensions.GetVRCPlayer());
            });
        }
    }
}
