using Core.Game.UI;
using Core.MainMenu.UI;
using Infrastructure.Locator;

namespace Services.Factory
{
    public interface IUIFactory : IService
    {
        MainMenuUIController MainMenuUIController { get; }
        AfterMatchUIController AfterMatchUIController { get; }
        void CreateMainMenu();
        void CreateAfterMatchScreen();
    }
}