using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WasdClickInputAdapter : MonoBehaviour, IInputAdapter
{
    private WasdClickLogic logic;
    [HideInInspector]
    public bool Stopped = false;

    private void Start()
    {
        logic = GetComponent<WasdClickLogic>();
    }


    public void MouseMove(Vector2 deltaPos)
    {
        return;
    }

    public void KeyboardW(bool pressed)
    {
        if(Stopped) return;
        if(pressed)
        {
            logic.IncreaseClicks("w");
        }
    }

    public void KeyboardA(bool pressed)
    {
        if(Stopped) return;
        if(pressed)
        {
            logic.IncreaseClicks("a");
        }
    }

    public void KeyboardS(bool pressed)
    {
        if(Stopped) return;
        if(pressed)
        {
            logic.IncreaseClicks("s");
        }
    }

    public void KeyboardD(bool pressed)
    {
        if(Stopped) return;
        if(pressed)
        {
            logic.IncreaseClicks("d");
        }
    }

    public void MouseClick(bool pressed)
    {
        return;
    }
}