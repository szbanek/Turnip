using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpinInputAdadpter : MonoBehaviour, IInputAdapter
{
    private SpinLogic logic;
    [HideInInspector]
    public bool Stopped = false;

    private void Start()
    {
        logic = GetComponent<SpinLogic>();
    }


    public void MouseMoveRelative(Vector2 deltaPos)
    {
        return;
    }

    public void MouseMovePosition(Vector2 pos)
    {
        if(Stopped) return;
        logic.IncreaseClicks(pos);
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
        return;
    }
}
