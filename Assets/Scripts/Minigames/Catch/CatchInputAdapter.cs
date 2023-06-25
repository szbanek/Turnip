using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CatchInputAdapter : MonoBehaviour, IInputAdapter
{
    private CatchLogic logic;
    [HideInInspector]
    public bool Stopped = false;
    private Vector2 position;

    private void Start()
    {
        logic = GetComponent<CatchLogic>();
    }


    public void MouseMoveRelative(Vector2 deltaPos)
    {
        return;
    }

    public void MouseMovePosition(Vector2 pos)
    {
        logic.UpdatePos(pos);
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
