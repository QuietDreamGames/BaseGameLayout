namespace Features.System.Interfaces.Handlers
{
    public interface IEndableSystemHandler : ISystem
    {
        void Terminate();
    }
}