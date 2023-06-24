using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerStats))]
[RequireComponent(typeof(PlayerStamina))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField]
    private float normalSpeed;
    [SerializeField]
    private float jumpSpeed;

    [Header("Camera")]
    [SerializeField]
    private Transform cameraParent;
    [SerializeField]
    private float cameraSesitivity;
    [SerializeField]
    private float lookXLimit = 45.0f;

    [Header("Other")]
    [SerializeField]
    private float gravity;

    [Header("References")]
    [SerializeField]
    private PlayerAnimationController animationController;

    public System.EventHandler Landed;
    public System.EventHandler<bool> WalkingStateChanged;

    [HideInInspector]
    public bool MovementEnabled = true;

    private PlayerStats playerStats;
    private CharacterController characterController;
    private PlayerStamina stamina;

    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0;
    private Vector3 forward;
    private Vector3 right;
    private Vector2 inputSpeed;
    private bool jump;
    private bool sprintInput;
    private bool sprint;
    private bool lastGroundedState = true;
    private bool lastWalkingState = true;

    public void Move(Vector2 value)
    {
        inputSpeed = value;
    }

    public void Jump()
    {
        if (characterController.isGrounded && stamina.TryJump())
        {
            jump = true;
            animationController.StartJump();
        }
    }

    public void Look(Vector2 direction)
    {
        rotationX += -direction.y * cameraSesitivity;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        cameraParent.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, direction.x * cameraSesitivity, 0);
        UpdateDirectionVectors();
    }

    public void SetSprintInput(bool input)
    {
        sprintInput = input;
    }

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerStats = GetComponent<PlayerStats>();
        stamina = GetComponent<PlayerStamina>();
        UpdateDirectionVectors();
    }

    private void Update()
    {
        float movementDirectionY = moveDirection.y;

        UpdateSprintState();
        Vector3 currentSpeed;
        float speed = sprint ? playerStats.SprintSpeed : normalSpeed;
        currentSpeed.x = speed * inputSpeed.y;
        currentSpeed.y = speed * inputSpeed.x;
        moveDirection = (forward * currentSpeed.x) + (right * currentSpeed.y);

        if (jump)
        {
            moveDirection.y = jumpSpeed;
            jump = false;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }
        characterController.Move(moveDirection * Time.deltaTime);
        SendEventIfLanded();
        lastGroundedState = characterController.isGrounded;
        SendWalkingStateEvent(new Vector2(moveDirection.x, moveDirection.z));
    }

    private void SendWalkingStateEvent(Vector2 direction)
    {
        if (lastWalkingState == true && (!characterController.isGrounded || inputSpeed == Vector2.zero))
        {
            WalkingStateChanged?.Invoke(this, false);
            lastWalkingState = false;
            animationController.StopWalking();
        }
        if (lastWalkingState == false && characterController.isGrounded && inputSpeed != Vector2.zero)
        {
            WalkingStateChanged?.Invoke(this, true);
            lastWalkingState = true;
            animationController.StartWalking();
        }
    }

    private void SendEventIfLanded()
    {
        if (lastGroundedState == false && characterController.isGrounded == true)
        {
            Landed?.Invoke(this, null);
            animationController.StopJump();
        }
    }

    private void UpdateDirectionVectors()
    {
        forward = transform.TransformDirection(Vector3.forward);
        right = transform.TransformDirection(Vector3.right);
    }

    private void UpdateSprintState()
    {
        if (sprintInput)
        {
            if (sprint)
            {
                if (!stamina.TryContinueRun())
                {
                    sprint = false;
                    sprintInput = false;
                    animationController.StopRunning();
                }
            }
            else
            {
                if (stamina.TryStartRun())
                {
                    sprint = true;
                    sprintInput = true;
                    animationController.StartRunning();
                }
                else
                {
                    sprintInput = false;
                }
            }
        }
    }
}
