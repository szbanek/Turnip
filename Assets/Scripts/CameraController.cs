using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Config")]
    [SerializeField]
    private float minDistance;

    private float defaultDistance;
    private Vector3 defaultDirection;

    private void Start()
    {
        defaultDistance = (transform.parent.position - transform.position).magnitude;
        defaultDirection = transform.localPosition.normalized;
    }

    private void LateUpdate()
    {
        Vector3 direction = transform.position - transform.parent.position;
        Physics.SphereCast(transform.parent.position, 0.3f, direction, out RaycastHit hit, defaultDistance, LayerMask.GetMask("Environment"));
        if (hit.collider != null)
        {
            Vector3 pos = Vector3.Project(hit.point - transform.parent.position, direction);
            if(pos.magnitude < minDistance)
            {
                pos = direction.normalized * minDistance;
            }
            float multipler = pos.magnitude / defaultDistance;
            transform.localPosition = defaultDirection * multipler;
        }
        else
        {
            transform.localPosition = defaultDirection * defaultDistance;
        }
    }
}
