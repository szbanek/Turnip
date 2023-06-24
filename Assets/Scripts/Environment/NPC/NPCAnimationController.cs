using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animation))]
public class NPCAnimationController : MonoBehaviour
{
    [SerializeField]
    private float maxCycleOffset;
    [SerializeField]
    private float minSpeed;
    [SerializeField]
    private float maxSpeed;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetFloat("IdleCycleOffset", Random.Range(0, maxCycleOffset));
        animator.SetFloat("IdleSpeed", Random.Range(minSpeed, maxSpeed));
    }
}
