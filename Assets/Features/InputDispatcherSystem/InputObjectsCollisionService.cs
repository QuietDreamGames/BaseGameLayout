using System;
using UnityEngine;
using UnityEngine.InputSystem;
using VContainer;
using JetBrains.Annotations;

namespace Features.InputDispatcherSystem
{
    public class InputObjectsCollisionService
    {
        private readonly Camera       _mainCamera;

        private GameObject _heldGameObject;
        
        public Action<GameObject>       OnClickedGameObjectAction;
        public Action<GameObject, bool> OnHeldGameObjectAction;
        
        [Inject]
        [UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
        public InputObjectsCollisionService(InputService inputService, Camera mainCamera)
        {
            _mainCamera   = mainCamera;
            
            inputService.OnClickAction     += CheckClickedCollisionWithObjects;
            inputService.OnHoldClickAction += CheckHeldCollisionWithObjects;
        }
        
        
        private void CheckClickedCollisionWithObjects(InputAction.CallbackContext context)
        {
            var rayHit = Physics2D.GetRayIntersection(
                _mainCamera.ScreenPointToRay(InputUtils.GetPrimaryPointerScreenPosition()));
            if (!rayHit.collider) return;
            
            OnClickedGameObjectAction?.Invoke(rayHit.collider.gameObject);
        }

        private void CheckHeldCollisionWithObjects(InputAction.CallbackContext context)
        {
            if (context.canceled)
            {
                OnHeldGameObjectAction?.Invoke(_heldGameObject, false);
                _heldGameObject = null;
                return;
            }
            
            
            var rayHit = Physics2D.GetRayIntersection(
                _mainCamera.ScreenPointToRay(InputUtils.GetPrimaryPointerScreenPosition()));
            
            if (!rayHit.collider)
            {
                if (_heldGameObject == null) return;
                OnHeldGameObjectAction?.Invoke(_heldGameObject, false);
                _heldGameObject = null;
                return;
            }

            _heldGameObject = rayHit.collider.gameObject;
            OnHeldGameObjectAction?.Invoke(_heldGameObject, true);
        }
    }
}