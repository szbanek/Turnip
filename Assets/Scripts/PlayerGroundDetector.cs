using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PlayerGroundDetector : MonoBehaviour
{
    public bool IsGrounded { get => colliding.Count != 0; }

    private HashSet<Collider> colliding = new HashSet<Collider>();

    private void OnTriggerEnter(Collider other)
    {
        colliding.Add(other);
    }

    private void OnTriggerExit(Collider other)
    {
        colliding.Remove(other);
    }

    public void PrintColliding()
    {
        foreach (Collider collider in colliding)
        {
            Debug.Log(collider.gameObject.name);
        }
    }
}
