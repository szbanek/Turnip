using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerJump : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private PlayerGroundDetector groundDetector;

    [Header("Config")]
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    [Tooltip("How long the player needs to hold the jump button to jump to the maximum height")]
    private float jumpHoldTime = 0.7f;
    [SerializeField]
    private float jumpBuffer = 0.5f;

    [Header("Other")]
    [SerializeField]
    private float gravity;
    [SerializeField]
    private float groundForce;
    [SerializeField]
    private float slowestAllowedJumpSpeed = 1;

    public bool WasGroundedLastFrame { get => wasGroundedLastFrame; }

    private CharacterController characterController;

    private bool jumpInput;
    private bool isJumping = false;
    private float jumpTimeCounter;

    private float ySpeed = 0;

    private Vector3 lastPosition;
    private bool wasGroundedLastFrame = true;

    public void StartJump()
    {
        jumpInput = true;
        lastPosition = transform.position;
        //animationController.StartJump();
    }

    public void StopJump()
    {
        jumpInput = false;
    }

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        lastPosition = transform.position;
    }

    private void FixedUpdate()
    {
        ySpeed = CalculateJumpVelocity(ySpeed);

        ApplyGravityIfNeeded();

        characterController.Move(new Vector3(0, 1, 0) * ySpeed * Time.fixedDeltaTime);

        UpdateAnimations();
    }

    private void UpdateAnimations()
    {
        if (!WasGroundedLastFrame && groundDetector.IsGrounded)
        {
            //animationController.StopJump();
        }
        wasGroundedLastFrame = groundDetector.IsGrounded;
    }

    private void ApplyGravityIfNeeded()
    {
        if (!groundDetector.IsGrounded)
        {
            ySpeed -= gravity * Time.fixedDeltaTime;
        }
    }

    private float CalculateJumpVelocity(float currentYVelocity)
    {
        if (isJumping)
        {
            if (jumpInput)
            {
                jumpTimeCounter += Time.fixedDeltaTime;
                if (jumpTimeCounter >= jumpHoldTime)
                {
                    isJumping = false;
                }
                return jumpForce;
            }
            else
            {
                isJumping = false;
            }
        }
        if (jumpInput)
        {
            if (groundDetector.IsGrounded)
            {
                isJumping = true;
                jumpTimeCounter = Time.fixedDeltaTime;
                return jumpForce;
            }
        }
        else if (groundDetector.IsGrounded)
        {
            return groundForce;
        }
        else if ((transform.position.y - lastPosition.y) / Time.fixedDeltaTime < slowestAllowedJumpSpeed)
        { 
            if (transform.position.y == lastPosition.y)
            {
                return 0;
            }
            else
            {
                lastPosition = transform.position;
            }
        }
        return currentYVelocity;
    }
}
