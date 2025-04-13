using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Features.InputDispatcherSystem
{
    public class InputDispatcher : MonoBehaviour
    {
        public Action<InputAction.CallbackContext> OnClickAction;
        public Action<InputAction.CallbackContext> OnHoldClickAction;
        
        public void OnClick(InputAction.CallbackContext context)
        {
            OnClickAction?.Invoke(context);
        }
        
        public void OnHoldClick(InputAction.CallbackContext context)
        {
            OnHoldClickAction?.Invoke(context);
        }
    }
}