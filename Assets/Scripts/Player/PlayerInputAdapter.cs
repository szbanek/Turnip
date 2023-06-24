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

    private Vector2 lastMoveInput = Vector2.zero;

    public void Move(InputAction.CallbackContext context)
    {
        Vector2 moveInput = context.ReadValue<Vector2>();

        if (inputAdapter != null)
        {
            switch (moveInput.x)
            {
                case > 0:
                    break;

                case < 0:
                    break;

                default:
                    switch(lastMoveInput.x)
                    {
                        case > 0:
                            
                            break;

                        case < 0:
                            break;
                    }
                    break;
            }
        }

        if (!EnableMovement)
        {
            return;
        }
        movement.Move(moveInput);
        lastMoveInput = moveInput;
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
        }

        if (!EnableMovement)
        {
            return;
        }
        movement.Look(context.ReadValue<Vector2>());
    }

    public void MouseClick(InputAction.CallbackContext context)
    {
        if (inputAdapter != null)
        {
            if (context.started || context.canceled)
            {
                inputAdapter.MouseClick(context.started);
            }
        }
    }


}
