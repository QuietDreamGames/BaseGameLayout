using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;
using VContainer;

namespace Features.InputDispatcherSystem
{
    public class InputService
    {
        public Action<InputAction.CallbackContext> OnClickAction;
        public Action<InputAction.CallbackContext> OnHoldClickAction;
        
        [Inject]
        [UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
        public InputService(InputDispatcher inputDispatcher)
        {
            inputDispatcher.OnClickAction     += OnClick;
            inputDispatcher.OnHoldClickAction += OnHoldClick;
        }

        private void OnClick(InputAction.CallbackContext context)
        {
            if (!context.performed) return;
            
            // Handle the click action
            Debug.Log("Click action performed");
            OnClickAction?.Invoke(context);
        }
        
        private void OnHoldClick(InputAction.CallbackContext context)
        {
            if (context is { started: false, canceled: false }) return;
            
            // Handle the hold click action
            
            var status = context.performed ? "performed" 
                : context.started ? "started" 
                : "canceled";

            Debug.Log($"Hold click action {status}");
            OnHoldClickAction?.Invoke(context);
        }
    }
}