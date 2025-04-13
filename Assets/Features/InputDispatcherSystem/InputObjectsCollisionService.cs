using System;
using UnityEngine;
using UnityEngine.InputSystem;
using VContainer;
using JetBrains.Annotations;

namespace Features.InputDispatcherSystem
{
    public class InputObjectsCollisionService
    {
        private readonly InputService _inputService;
        private readonly Camera       _mainCamera;

        private GameObject _heldGameObject;
        
        public Action<GameObject> OnClickedGameObjectAction;
        public Action<GameObject, bool> OnHeldGameObjectAction;
        
        [Inject]
        [UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
        public InputObjectsCollisionService(InputService inputService, Camera mainCamera)
        {
            _inputService = inputService;
            _mainCamera   = mainCamera;
            
            _inputService.OnClickAction     += CheckClickedCollisionWithObjects;
            _inputService.OnHoldClickAction += CheckHoldedCollisionWithObjects;
        }
        
        
        private void CheckClickedCollisionWithObjects(InputAction.CallbackContext context)
        {
            var rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
            if (!rayHit.collider) return;
            
            OnClickedGameObjectAction?.Invoke(rayHit.collider.gameObject);
        }

        private void CheckHoldedCollisionWithObjects(InputAction.CallbackContext context)
        {
            if (context.canceled)
            {
                OnHeldGameObjectAction?.Invoke(_heldGameObject, false);
                _heldGameObject = null;
                return;
            }
            
            var rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
            if (!rayHit.collider) return;

            _heldGameObject = rayHit.collider.gameObject;
            OnHeldGameObjectAction?.Invoke(_heldGameObject, true);
        }
    }
}