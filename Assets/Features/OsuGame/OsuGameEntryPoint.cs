using VContainer;
using VContainer.Unity;

namespace Features.OsuGame
{
    public class OsuGameEntryPoint : IStartable
    {
        [Inject] private readonly OsuGameService _osuGameService;
        
        public void Start()
        {
            
        }
    }
}