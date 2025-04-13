using Features.InputDispatcherSystem;
using VContainer;
using JetBrains.Annotations;
using UnityEngine;

namespace Features.OsuGame
{
    public class OsuGameService
    {
        private readonly InputObjectsCollisionService _inputObjectsCollisionService;
        
        [Inject]
        [UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
        public OsuGameService(InputObjectsCollisionService inputObjectsCollisionService)
        {
            _inputObjectsCollisionService = inputObjectsCollisionService;
            
            _inputObjectsCollisionService.OnClickedGameObjectAction += OnClickedGameObject;
            _inputObjectsCollisionService.OnHeldGameObjectAction    += OnHeldGameObject;
        }
        
        private void OnClickedGameObject(GameObject gameObject)
        {
            if (gameObject == null) return;
            
            // Handle the clicked game object
            Debug.Log($"Clicked GameObject: {gameObject.name}");
        }
        
        private void OnHeldGameObject(GameObject gameObject, bool isHeld)
        {
            if (gameObject == null) return;
            
            if (isHeld)
            {
                // Handle the held game object
                Debug.Log($"Grabbed GameObject: {gameObject.name}");
            }
            else
            {
                // Handle the released game object
                Debug.Log($"Released GameObject: {gameObject.name}");
            }
        }
    }
}