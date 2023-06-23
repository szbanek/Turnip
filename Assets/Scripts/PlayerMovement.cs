using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
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

    public System.EventHandler Landed;
    public System.EventHandler<bool> WalkingStateChanged;

    [HideInInspector]
    public bool MovementEnabled = true;

    private CharacterController characterController;
    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0;
    private Vector3 forward;
    private Vector3 right;
    private Vector2 inputSpeed;
    private bool jump;
    private bool lastGroundedState = true;
    private bool lastWalkingState = true;

    public void Move(Vector2 value)
    {
        inputSpeed = value;
    }

    public void Jump()
    {
        if (characterController.isGrounded)
        {
            jump = true;
            //_animationController.StartJump();
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

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        UpdateDirectionVectors();
    }

    private void Update()
    {
        float movementDirectionY = moveDirection.y;
        Vector3 currentSpeed;
        currentSpeed.x = normalSpeed * inputSpeed.y;
        currentSpeed.y = normalSpeed * inputSpeed.x;
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
            //_animationController.StopWalking();
        }
        if (lastWalkingState == false && characterController.isGrounded && inputSpeed != Vector2.zero)
        {
            WalkingStateChanged?.Invoke(this, true);
            lastWalkingState = true;
            //_animationController.StartWalking(direction);
        }
    }

    private void SendEventIfLanded()
    {
        if (lastGroundedState == false && characterController.isGrounded == true)
        {
            Landed?.Invoke(this, null);
            //_animationController.StopJump();
        }
    }

    private void UpdateDirectionVectors()
    {
        forward = transform.TransformDirection(Vector3.forward);
        right = transform.TransformDirection(Vector3.right);
    }
}
