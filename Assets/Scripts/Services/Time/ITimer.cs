using Infrastructure.Locator;

namespace Services.Time
{
    public interface ITimer : IService
    {
        float CurrentTime { get; }
        void Tick();
        void Reset();
    }
}