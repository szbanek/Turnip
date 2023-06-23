using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class ObjectKicker : MonoBehaviour
{
    [SerializeField]
    private float kickForce;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.CompareTag("Kickable"))
        {
            Rigidbody body = hit.rigidbody;
            if(body != null)
            {
                Vector3 kickDirection = (hit.transform.position - transform.position).normalized;
                body.AddForce(kickDirection * kickForce);
            }
        }
    }
}
