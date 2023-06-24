using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void StartWalking()
    {
        animator.SetBool("Move", true);
    }

    public void StopWalking()
    {
        animator.SetBool("Move", false);
    }

    public void StartRunning()
    {
        animator.SetBool("Run", true);
    }

    public void StopRunning()
    {
        animator.SetBool("Run", false);
    }

    public void StartJump()
    {
        animator.SetBool("Jump", true);
    }

    public void StopJump()
    {
        animator.SetBool("Jump", false);
    }
}
