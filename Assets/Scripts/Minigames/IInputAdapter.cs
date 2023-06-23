using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public interface IInputAdapter
{
    public void MouseMove(InputAction.CallbackContext context);
    public void KeyboardW(InputAction.CallbackContext context);
    public void KeyboardA(InputAction.CallbackContext context);
    public void KeyboardS(InputAction.CallbackContext context);
    public void KeyboardD(InputAction.CallbackContext context);
    public void MouseClick(InputAction.CallbackContext context);
    
}
