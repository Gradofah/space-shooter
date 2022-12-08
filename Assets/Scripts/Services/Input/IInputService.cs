using Infrastructure.Locator;
using UnityEngine;

namespace Services.Input
{
    public interface IInputService : IService
    {
        bool FireButtonClicked { get; }
        Vector3 Position { get; }
    }
}