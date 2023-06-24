using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MazeInputAdapter : MonoBehaviour, IInputAdapter
{
    private MazeLogic logic;
    [HideInInspector]
    public bool Stopped = false;

    private void Start()
    {
        logic = GetComponent<MazeLogic>();
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
        if(pressed) logic.SetMovement(true);
        else logic.NotMoving();
    }

    public void KeyboardS(bool pressed)
    {
        return;
    }

    public void KeyboardD(bool pressed)
    {
        if(Stopped) return;
        if(pressed) logic.SetMovement(false);
        else logic.NotMoving();
    }

    public void MouseClick(bool pressed)
    {
        return;
    }
}
