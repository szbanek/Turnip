using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputAdapter : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private PlayerMovement movement;
    [SerializeField]
    private EnvironmentInteractor interactor;
    [SerializeField]
    private PlayerJump jump;

    [HideInInspector]
    public bool EnableMovement = true;

    private bool paused = false;

    private void Start()
    {
        CheckReferencesForNulls();
    }

    private void CheckReferencesForNulls()
    {
        if (movement == null)
        {
            Debug.LogError("movement in PlayerInputAdapter in null");
        }
        if (interactor == null)
        {
            Debug.LogError("interactor in PlayerInputAdapter in null");
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        if (!EnableMovement || paused)
        {
            return;
        }
        movement.Move(context.ReadValue<Vector2>());
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (paused)
        {
            return;
        }
        if (context.started)
        {
            jump.StartJump();
        }
        if (context.canceled)
        {
            jump.StopJump();
        }
    }

    public void Look(InputAction.CallbackContext context)
    {
        if (!EnableMovement || paused)
        {
            return;
        }
        movement.Look(context.ReadValue<Vector2>());
    }

    public void Interact(InputAction.CallbackContext context)
    {
        if (!EnableMovement || paused)
        {
            return;
        }
        if (context.started)
        {
            interactor.InteractWithSelected();
        }
    }
}
