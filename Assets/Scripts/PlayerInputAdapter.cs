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

    public void Move(InputAction.CallbackContext context)
    {
        if (!EnableMovement)
        {
            return;
        }
        movement.Move(context.ReadValue<Vector2>());
    }

    public void Jump(InputAction.CallbackContext context)
    {
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
        if (!EnableMovement)
        {
            return;
        }
        movement.Look(context.ReadValue<Vector2>());
    }
}
