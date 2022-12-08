using Infrastructure.Locator;

namespace Services.Factory
{
    public interface IGameFactory : IService
    {
        void CreateBackground();
        void CreatePlayer();
    }
}