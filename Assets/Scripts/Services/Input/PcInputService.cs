using UnityEngine;

namespace Services.Input
{
    public class PcInputService : IInputService
    {
        public bool FireButtonClicked
        {
            get
            {
                return UnityEngine.Input.GetMouseButtonDown(0);
            }
        }

        public Vector3 Position
        {
            get
            {
                return UnityEngine.Input.mousePosition;
            }
        }
    }
}