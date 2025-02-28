using ReMod.Core.Managers;
using ReMod.Core.UI.QuickMenu;

namespace DeepCore.Client.ClientMenu.Pages_MainMenu
{
    internal class WorldHacks
    {
        public static void WorldHacksMenu(UiManager UIManager)
        {
            ReCategoryPage reCategoryPage = UIManager.QMMenu.AddCategoryPage("WorldHacks Functions", null);
            #region Murder 4
            reCategoryPage.AddCategory("Murder 4");
            ReMenuCategory Murder4 = reCategoryPage.GetCategory("Murder 4");
            Murder4.AddButton("Start Match","Start the match.",Module.WorldHacks.Murder4.StartMatch);
            Murder4.AddButton("Stop Match","Stop the match.",Module.WorldHacks.Murder4.StopMatch);
            Murder4.AddButton("Find Habibi","Allow you to find the murder.",Module.WorldHacks.Murder4.FindHabibi);
            Murder4.AddButton("Show everyone rule","Show everyone rules.",Module.WorldHacks.Murder4.ReshowEveryoneRoles);
            Murder4.AddButton("Bystanders win","Make all bystanders win.",Module.WorldHacks.Murder4.BystandersWin);
            Murder4.AddButton("Murder win","Make all murder win.",Module.WorldHacks.Murder4.MurderWin);
            Murder4.AddButton("Bring revolver", "Bring revolver to your feet.",Module.WorldHacks.Murder4.BringRevolver);
            Murder4.AddButton("Bring Shotgun", "Bring shotgun to your feet.",Module.WorldHacks.Murder4.BringShotgun);
            Murder4.AddButton("Bring Luger", "Bring luger to your feet.",Module.WorldHacks.Murder4.BringLuger);
            Murder4.AddButton("Fire shotgun", "Make the shotgun fire.",Module.WorldHacks.Murder4.fireShotgun);
            Murder4.AddButton("Fire revolver", "Make the revolver fire.",Module.WorldHacks.Murder4.firerevolver);
            Murder4.AddButton("Fire luger", "Make the luger fire.",Module.WorldHacks.Murder4.fireLuger);
            Murder4.AddButton("Revolver Patron Skin", "Apply the Patron Skin.",Module.WorldHacks.Murder4.RevolverPatronSkin);
            Murder4.AddButton("AllaFraguakbar", "Make the Frag boom bom.", Module.WorldHacks.Murder4.Frag0Explode);
            Murder4.AddButton("Release da Snake", "Release da Snake.", Module.WorldHacks.Murder4.ReleaseSnake);
            Murder4.AddButton("ERP", "Haram.",Module.WorldHacks.Murder4.CloseAllDoors);
            Murder4.AddButton("UNERP", "Not Harem.",Module.WorldHacks.Murder4.UnlockAllDoors);
            #endregion
            reCategoryPage.AddCategory("Among Us");
            ReMenuCategory Amongus = reCategoryPage.GetCategory("Among Us");

        }
    }
}
