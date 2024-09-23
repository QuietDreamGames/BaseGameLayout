namespace Features.TimeSystem.Interfaces
{
    public interface ITimeSystem 
    {
        void SetUpdateProvider(IUpdateProvider updateProvider);

        void Subscribe(ITimeCollector timeCollector);
        void Unsubscribe(ITimeCollector timeCollector);

        float GetTimeScale();
        void  SetTimeScale(float timeScale);

        void Pause();
        void Resume();
    }
}