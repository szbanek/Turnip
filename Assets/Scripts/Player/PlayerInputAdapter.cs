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
    private PlayerVegetableSense sense;

    [HideInInspector]
    public bool EnableMovement = true;

    public IInputAdapter inputAdapter { set { ignoreInputThisFrame = true; _inputAdapter = value; } private get => _inputAdapter; }

    private IInputAdapter _inputAdapter = null;
    private bool ignoreInputThisFrame = false;

    public void Move(InputAction.CallbackContext context)
    {
        if (ignoreInputThisFrame)
        {
            return;
        }

        if (inputAdapter != null)
        {
            movement.Move(Vector2.zero);
            return;
        }

        if (!EnableMovement)
        {
            movement.Move(Vector2.zero);
            return;
        }
        movement.Move(context.ReadValue<Vector2>());
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (ignoreInputThisFrame)
        {
            return;
        }

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
        if (ignoreInputThisFrame)
        {
            return;
        }

        if (inputAdapter != null)
        {
            inputAdapter.MouseMoveRelative(context.ReadValue<Vector2>());
            inputAdapter.MouseMovePosition(Mouse.current.position.ReadUnprocessedValue());
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
        if (ignoreInputThisFrame)
        {
            return;
        }

        if (inputAdapter != null)
        {
            if (context.started || context.canceled)
            {
                inputAdapter.MouseClick(context.started);
            }
            return;
        }

        if (!EnableMovement)
        {
            return;
        }
        if (context.started)
        {
            interactor.InteractWithSelected();
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

    public void Sprint(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            movement.SetSprintInput(true);
        }
        else if(context.canceled)
        {
            movement.SetSprintInput(false);
        }
    }

    public void SwitchMenu(InputAction.CallbackContext context)
    {
        if (ignoreInputThisFrame)
        {
            return;
        }

        if (inputAdapter != null)
        {
            return;
        }

        if (context.started)
        {
            UIHUDController.Instance.MenuVisibilityManager.SwitchMenu();
        }
    }

    public void SenseVegetables(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            sense.StartSense();
        }
        else if (context.canceled)
        {
            sense.StopSense();
        }
    }

    public void Pause(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            PauseScreen.Instance.SwitchPause();
        }
    }

    private void Update()
    {
        ignoreInputThisFrame = false;
    }
}
