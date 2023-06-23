using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpamUpInputAdadpter : MonoBehaviour, IInputAdapter
{
    private SpamUpLogic logic;
    [HideInInspector]
    public bool Stopped = false;

    private void Start()
    {
        logic = GetComponent<SpamUpLogic>();
    }


    public void MouseMove(InputAction.CallbackContext context)
    {
        return;
    }

    public void KeyboardW(InputAction.CallbackContext context)
    {
        return;
    }

    public void KeyboardA(InputAction.CallbackContext context)
    {
        return;
    }

    public void KeyboardS(InputAction.CallbackContext context)
    {
        return;
    }

    public void KeyboardD(InputAction.CallbackContext context)
    {
        return;
    }

    public void MouseClick(InputAction.CallbackContext context)
    {
        if (Stopped) return;
        if (context.started)
        {
            logic.IncreaseClicks();
            Debug.Log("increased");
        }
    }
}
