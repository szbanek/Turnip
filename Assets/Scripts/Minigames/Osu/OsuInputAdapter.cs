using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OsuInputAdapter : MonoBehaviour, IInputAdapter
{
    private OsuLogic logic;
    [HideInInspector]
    public bool Stopped = false;
    private Vector2 position;

    private void Start()
    {
        logic = GetComponent<OsuLogic>();
    }


    public void MouseMoveRelative(Vector2 deltaPos)
    {
        return;
    }

    public void MouseMovePosition(Vector2 pos)
    {
        if(Stopped) return;
        position = pos;
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
        if(Stopped) return;
        if(pressed) logic.Click(position);
    }
}
