using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NpcMinigameInputAdapter : MonoBehaviour, IInputAdapter
{
    public event EventHandler OnAnyClick;
    public void MouseMoveRelative(Vector2 deltaPos)
    {
        return;
    }

    public void MouseMovePosition(Vector2 deltaPos)
    {
        return;
    }

    public void KeyboardW(bool pressed)
    {
        return;
    }

    public void KeyboardA(bool pressed)
    {
        return;
    }

    public void KeyboardS(bool pressed)
    {
        return;
    }

    public void KeyboardD(bool pressed)
    {
        return;
    }

    public void MouseClick(bool pressed)
    {
        if (pressed) OnAnyClick?.Invoke(this, null);
    }
}
