using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputAdapter : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private PlayerMovement movement;

    [HideInInspector]
    public bool EnableMovement = true;
    [HideInInspector]
    public IInputAdapter inputAdapter = null;

    public void Move(InputAction.CallbackContext context)
    {
        if (inputAdapter != null)
        {
            return;
        }

        if (!EnableMovement)
        {
            return;
        }
        movement.Move(context.ReadValue<Vector2>());
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (inputAdapter != null)
        {
            return;
        }

        if (!EnableMovement)
        {
            return;
        }
        if (context.started)
        {
            movement.Jump();
        }
    }

    public void Look(InputAction.CallbackContext context)
    {
        if (inputAdapter != null)
        {
            inputAdapter.MouseMove(context.ReadValue<Vector2>());
            return;
        }

        if (!EnableMovement)
        {
            return;
        }
        movement.Look(context.ReadValue<Vector2>());
    }

    public void Interact(InputAction.CallbackContext context)
    {
        if (inputAdapter != null)
        {
            if (context.started || context.canceled)
            {
                inputAdapter.MouseClick(context.started);
            }
            return;
        }
    }

    public void KeyboardW(InputAction.CallbackContext context)
    {
        if (inputAdapter == null)
        {
            return;
        }
        if (context.started || context.canceled)
        {
            inputAdapter.KeyboardW(context.started);
        }
    }

    public void KeyboardA(InputAction.CallbackContext context)
    {
        if (inputAdapter == null)
        {
            return;
        }
        if (context.started || context.canceled)
        {
            inputAdapter.KeyboardA(context.started);
        }
    }

    public void KeyboardS(InputAction.CallbackContext context)
    {
        if (inputAdapter == null)
        {
            return;
        }
        if (context.started || context.canceled)
        {
            inputAdapter.KeyboardS(context.started);
        }
    }

    public void KeyboardD(InputAction.CallbackContext context)
    {
        if (inputAdapter == null)
        {
            return;
        }
        if (context.started || context.canceled)
        {
            inputAdapter.KeyboardD(context.started);
        }
    }
}
