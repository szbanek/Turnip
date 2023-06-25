using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuRotater : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 2f;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime, 0));
    }
}
