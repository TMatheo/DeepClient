using ReMod.Core.Managers;
using ReMod.Core.UI.QuickMenu;
using VRC.SDKBase;

namespace DeepCore.Client.ClientMenu
{
    internal class LaunchPad_Menu
    {
        private static UiManager _uiManager;
        public static void InitLaunchPadMenu(UiManager UIManager)
        {
            _uiManager = UIManager;
            DeepConsole.Log("ClientUI","Initializing LaunchPad Menu...");
            IButtonPage launchPad = _uiManager.LaunchPad;
            launchPad.AddButton("Join By ID", "Allows you to join a world by it's ID.", delegate ()
            {
                Misc.PopupHelper.PopupCall("Join By ID","Enter the ID to join","Join",false,userInput =>
                {
                    DeepConsole.Log("IDJoiner", $"Joining ID: {userInput}");
                    Networking.GoToRoom(userInput);
                });
            });
            launchPad.AddButton("Change By ID", "Allows you to change avatar by it's ID.", delegate ()
            {
                Misc.PopupHelper.PopupCall("Change By ID", "Enter ID", "Set", false, userInput =>
                {
                    DeepConsole.Log("AviLogger", $"Changing to: {userInput}");
                    Misc.VrcExtensions.ChangeAvatar(userInput);
                });
            });
            launchPad.AddButton("Rejoin Last Instance", "OWO.", delegate ()
            {
                Module.QOL.LastInstanceRejoiner.Rejoin();
            });
        }
    }
}
