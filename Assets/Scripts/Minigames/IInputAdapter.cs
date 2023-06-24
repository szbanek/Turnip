using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public interface IInputAdapter
{
    public void MouseMoveRelative(Vector2 deltaPos);
    public void MouseMovePosition(Vector2 deltaPos);

    public void KeyboardW(bool pressed);
    public void KeyboardA(bool pressed);
    public void KeyboardS(bool pressed);
    public void KeyboardD(bool pressed);
    public void MouseClick(bool pressed);
    
}
