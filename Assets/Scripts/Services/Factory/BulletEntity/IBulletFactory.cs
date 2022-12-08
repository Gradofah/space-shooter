using Core.Game.BulletEntity;
using Infrastructure.Locator;

namespace Services.Factory.BulletEntity
{
    public interface IBulletFactory : IService
    {
        Bullet CreateBullet();
    }
}