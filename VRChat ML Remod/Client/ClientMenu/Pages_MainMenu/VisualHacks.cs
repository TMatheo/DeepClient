using MelonLoader;
using ReMod.Core.Managers;
using ReMod.Core.UI.QuickMenu;

namespace DeepCore.Client.ClientMenu.Pages_MainMenu
{
    internal class VisualHacks
    {
        public static void VisualSettingsMenu(UiManager UIManager)
        {
            ReCategoryPage reCategoryPage = UIManager.QMMenu.AddCategoryPage("Visuals Functions", null);
            reCategoryPage.AddCategory("Visuals");
            ReMenuCategory category = reCategoryPage.GetCategory("Visuals");
            category.AddToggle("Object ESP", "Allow you to see all pickups.", delegate (bool s)
            {
                Module.Visual.ESP.ObjectState(s);
            });
            category.AddToggle("Capsules ESP", "Allow you to see all players.", delegate (bool s)
            {
                Module.Visual.ESP.CapsuleState(s);
            });
            category.AddToggle("Optifine Zoom", "Hold [ALT] to zoom.", delegate (bool s)
            {
                ConfManager.OptifineZoom.Value = s;
                MelonPreferences.Save();
            });
            category.AddToggle("SelfHide", "Allow you to hide yourself (if you use crash avatar).", delegate (bool s)
            {
                Module.Visual.SelfHide.selfhidePlayer(s);
            });
            category.AddToggle("Flashlight", "Allow you to see in the dark.", delegate (bool s)
            {
                Module.Visual.Flashlight.State(s);
            });
            category.AddToggle("FlipScreen", "Allow you to rotate your pc cam by holding [R-CTRL + Scrolling].", delegate (bool s)
            {
                Module.Visual.FlipScreen.IsEnabled = s;
            });
            reCategoryPage.AddSliderCategory("Flashlight Settings");
            ReMenuSliderCategory category1 = reCategoryPage.GetSliderCategory("Flashlight Settings");
        }
    }
}
