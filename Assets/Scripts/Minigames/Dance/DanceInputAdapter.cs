using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DanceInputAdapter : MonoBehaviour, IInputAdapter
{
    private DanceLogic logic;
    [HideInInspector]
    public bool Stopped = false;

    private void Start()
    {
        logic = GetComponent<DanceLogic>();
    }


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
        if(Stopped) return;
        if(pressed)
        {
            logic.Click("a");
        }
    }

    public void KeyboardS(bool pressed)
    {
        return;
    }

    public void KeyboardD(bool pressed)
    {
        if(Stopped) return;
        if(pressed)
        {
            logic.Click("d");
        }
    }

    public void MouseClick(bool pressed)
    {
        return;
    }
}
