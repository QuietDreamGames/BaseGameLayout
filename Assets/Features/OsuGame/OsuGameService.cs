using Features.InputDispatcherSystem;
using VContainer;
using JetBrains.Annotations;
using UnityEngine;
using VContainer.Unity;

namespace Features.OsuGame
{
    public class OsuGameService : ITickable
    {
        private readonly Camera _camera;
        
        private GameObject _heldGameObject;
        private bool       _holding;
        private Vector2    _grabbedPosition;
        private Vector2    _lastPointerPosition;
        
        [Inject]
        [UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
        public OsuGameService(Camera camera, InputObjectsCollisionService inputObjectsCollisionService)
        {
            _camera = camera;
            
            inputObjectsCollisionService.OnClickedGameObjectAction += OnClickedGameObject;
            inputObjectsCollisionService.OnHeldGameObjectAction    += OnHeldGameObject;
        }
        
        private void OnClickedGameObject(GameObject gameObject)
        {
            if (gameObject == null) return;
            
            // Handle the clicked game object
            Debug.Log($"Clicked GameObject: {gameObject.name}");
        }
        
        private void OnHeldGameObject(GameObject heldGameObject, bool isHeld)
        {
            if (heldGameObject == null)
            {
                return;
            }

            _holding             = isHeld;
            _lastPointerPosition = InputUtils.GetPrimaryPointerScreenPosition();
            
            if (isHeld)
            {
                // Handle the held game object
                Debug.Log($"Grabbed GameObject: {heldGameObject.name}");
                _heldGameObject = heldGameObject;
                _grabbedPosition = heldGameObject.transform.position;
            }
            else
            {
                // Handle the released game object
                Debug.Log($"Released GameObject: {heldGameObject.name}");
                heldGameObject.transform.position = _grabbedPosition;
                _heldGameObject = null;
            }
        }

        public void Tick()
        {
            Debug.Log(InputUtils.GetPrimaryPointerScreenPosition());
            if (!_holding) return;
            
            // Handle the held game object position
            var currentPointerPosition      = InputUtils.GetPrimaryPointerScreenPosition();
            var currentPointerWorldPosition = _camera.ScreenToWorldPoint(new Vector3(currentPointerPosition.x, currentPointerPosition.y, _camera.nearClipPlane));
            var lastPointerWorldPosition    = _camera.ScreenToWorldPoint(new Vector3(_lastPointerPosition.x, _lastPointerPosition.y, _camera.nearClipPlane));
            var deltaPosition               = currentPointerWorldPosition - lastPointerWorldPosition;
            _heldGameObject.transform.position += deltaPosition;
            
            _lastPointerPosition = currentPointerPosition;
        }
    }
}