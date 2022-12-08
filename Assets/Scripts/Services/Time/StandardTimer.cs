namespace Services.Time
{
    public class StandardTimer : ITimer
    {
        public float CurrentTime { get; private set; } = 0.0f;
        
        public void Tick()
        {
            CurrentTime += UnityEngine.Time.deltaTime;
        }

        public void Reset()
        {
            CurrentTime = 0.0f;
        }
    }
}