using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerJump))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField]
    private float speed;

    [Header("Camera")]
    [SerializeField]
    [Tooltip("The part of the player that is being rotated in X axis")]
    private GameObject playerXRotationRoot;
    [SerializeField]
    private float cameraSesitivity;
    [SerializeField]
    private float lookXLimit = 45.0f;

    [HideInInspector]
    public float SpeedMultiplier = 1;

    public System.EventHandler Landed;

    public Vector3 MovementVelocity { get => movementVelocity; }

    private Vector3 movementVelocity = Vector3.zero;

    private float xRotation = 0;
    private Vector2 inputSpeed;

    private CharacterController characterController;
    private PlayerJump playerJump;

    private bool wasWalkingLastFrame = true;

    private const float epsilon = 0.0001f;

    [System.Serializable]
    private class PlayerMovementSnapshot
    {
        public float SpeedMultiplier { get => speedMultiplier; }
        [SerializeField]
        private float speedMultiplier;

        public PlayerMovementSnapshot(float multiplier)
        {
            speedMultiplier = multiplier;
        }
    }

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerJump = GetComponent<PlayerJump>();

        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Enemies"), false);
    }

    public void Move(Vector2 value)
    {
        inputSpeed = value;
    }

    public void Look(Vector2 direction)
    {
        CalculateAndSetXRotation(direction);
        RotatePlayer(direction);
    }

    private void Update()
    {
        ApplyPlayerInput();

        MovePlayer();

        UpdateAnimations();
    }

    private void RotatePlayer(Vector2 direction)
    {
        playerXRotationRoot.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.rotation *= Quaternion.Euler(0, direction.x * cameraSesitivity, 0);
    }

    private void CalculateAndSetXRotation(Vector2 direction)
    {
        xRotation += -direction.y * cameraSesitivity;
        xRotation = Mathf.Clamp(xRotation, -lookXLimit, lookXLimit);
    }

    private void MovePlayer()
    {
        characterController.Move(movementVelocity * Time.deltaTime);
    }

    private void ApplyPlayerInput()
    {
        Vector3 newTargetSpeed = new Vector3(inputSpeed.y, inputSpeed.x) * speed * SpeedMultiplier;

        movementVelocity = (transform.forward * newTargetSpeed.x) + (transform.right * newTargetSpeed.y);
        movementVelocity.y = 0;
    }

    private void UpdateAnimations()
    {
        if (wasWalkingLastFrame)
        {
            if (!playerJump.WasGroundedLastFrame || 
                inputSpeed == Vector2.zero)
            {
                wasWalkingLastFrame = false;
                //animationController.StopWalking();
            }
        }
        else
        {
            if (playerJump.WasGroundedLastFrame && inputSpeed != Vector2.zero)
            {
                wasWalkingLastFrame = true;
                //animationController.StartWalking();
            }
        }
    }

    private void RotateTowardsDefaultPosition()
    {
        if ( Mathf.Abs(Quaternion.Dot(playerXRotationRoot.transform.localRotation, Quaternion.Euler(0, 0, 0))) >= 1 - epsilon)
        {
            playerXRotationRoot.transform.localRotation = Quaternion.Euler(0, 0, 0);
            return;
        }
        playerXRotationRoot.transform.localRotation *= Quaternion.Euler(-Mathf.MoveTowards(0, xRotation, 100 * Time.deltaTime), 0, 0);
    }

    private void StopMovement()
    {
        inputSpeed = Vector2.zero;
        movementVelocity = Vector3.zero;
    }
}
