using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SnakeInputAdapter : MonoBehaviour, IInputAdapter
{
    private SnakeLogic logic;
    [HideInInspector]
    public bool Stopped = false;

    private void Start()
    {
        logic = GetComponent<SnakeLogic>();
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
        if(Stopped) return;
        if(pressed)
        {
            logic.Click("w");
        }
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
        if(Stopped) return;
        if(pressed)
        {
            logic.Click("s");
        }
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
