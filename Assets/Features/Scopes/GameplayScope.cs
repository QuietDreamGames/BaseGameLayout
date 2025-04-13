using Features.InputDispatcherSystem;
using Features.OsuGame;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Features.Scopes
{
    public class GameplayScope : LifetimeScope
    {
        [SerializeField] private Camera mainCamera;
        [SerializeField] private InputDispatcher inputDispatcher;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(mainCamera);
            builder.RegisterComponent(inputDispatcher);
            
            builder.Register<InputService>(Lifetime.Scoped);
            builder.Register<InputObjectsCollisionService>(Lifetime.Scoped);
            
            builder.Register<OsuGameService>(Lifetime.Scoped);

            builder.RegisterEntryPoint<OsuGameEntryPoint>();
        }
    }
}