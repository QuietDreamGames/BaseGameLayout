namespace Features.System.Interfaces.Handlers
{
    public interface IPausableSystemHandler : ISystem
    {
        void Pause();
        void Resume();
    }
}