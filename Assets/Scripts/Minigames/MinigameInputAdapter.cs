using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MinigameInputAdapter : MonoBehaviour
{
    [SerializeField]
    [RequireInterface(typeof(IInputAdapter))]
    Object adapterSerialised;
    IInputAdapter adapter;

    private void Start()
    {
        adapter = adapterSerialised as IInputAdapter;
    }
    public void MouseMoveRelative(InputAction.CallbackContext context)
    {
        adapter.MouseMoveRelative(context.ReadValue<Vector2>());
    }

    public void MouseMovePosition(InputAction.CallbackContext context)
    {
        adapter.MouseMovePosition(context.ReadValue<Vector2>());
    }

    public void KeyboardW(InputAction.CallbackContext context)
    {
        if (context.started) adapter.KeyboardW(true);
        if (context.canceled) adapter.KeyboardW(false);
    }

    public void KeyboardA(InputAction.CallbackContext context)
    {
        if (context.started) adapter.KeyboardA(true);
        if (context.canceled) adapter.KeyboardA(false);
    }

    public void KeyboardS(InputAction.CallbackContext context)
    {
        if (context.started) adapter.KeyboardS(true);
        if (context.canceled) adapter.KeyboardS(false);
    }

    public void KeyboardD(InputAction.CallbackContext context)
    {
        if (context.started) adapter.KeyboardD(true);
        if (context.canceled) adapter.KeyboardD(false);
    }

    public void MouseClick(InputAction.CallbackContext context)
    {
        if (context.started) adapter.MouseClick(true);
        if (context.canceled) adapter.MouseClick(false);
    }
}
