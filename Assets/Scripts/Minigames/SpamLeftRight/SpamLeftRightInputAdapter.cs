using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpamLeftRightInputAdapter : MonoBehaviour, IInputAdapter
{
    private SpamLeftRightLogic logic;
    [HideInInspector]
    public bool Stopped = false;

    private void Start()
    {
        logic = GetComponent<SpamLeftRightLogic>();
    }


    public void MouseMove(Vector2 deltaPos)
    {
        return;
    }

    public void KeyboardW(bool pressed)
    {
        return;
    }

    public void KeyboardA(bool pressed)
    {
        Debug.Log('a');
        if(Stopped) return;
        if(pressed)
        {
            logic.IncreaseClicks("a");
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
            logic.IncreaseClicks("d");
        }
    }

    public void MouseClick(bool pressed)
    {
        return;
    }
}
