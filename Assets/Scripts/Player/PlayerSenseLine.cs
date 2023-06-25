using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class PlayerSenseLine : MonoBehaviour
{
    [HideInInspector]
    public Transform StartTransform;
    [HideInInspector]
    public Transform EndTransform;

    public float Length;

    private LineRenderer line;

    private void Start()
    {
        line = GetComponent<LineRenderer>();
        line.SetPositions(new Vector3[] { StartTransform.position, Vector3.MoveTowards(StartTransform.position, EndTransform.position, Length) });
    }

    private void Update()
    {
        line.SetPositions(new Vector3[] { StartTransform.position, Vector3.MoveTowards(StartTransform.position, EndTransform.position, Length) });
    }
}
