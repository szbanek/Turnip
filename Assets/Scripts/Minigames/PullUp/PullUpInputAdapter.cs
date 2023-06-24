using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PullUpInputAdapter : MonoBehaviour, IInputAdapter
{
    private PullUpLogic logic;
    [HideInInspector]
    public bool Stopped = false;

    private void Start()
    {
        logic = GetComponent<PullUpLogic>();
    }


    public void MouseMoveRelative(Vector2 deltaPos)
    {
        return;
    }

    public void MouseMovePosition(Vector2 pos)
    {
        if(Stopped) return;
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
        if(Stopped) return;
        if(pressed) logic.Pull(true);
        else logic.Pull(false);
    }
}
