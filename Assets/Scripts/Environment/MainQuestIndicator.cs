using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainQuestIndicator : MonoBehaviour
{
    [SerializeField]
    private new MeshRenderer renderer;
    [SerializeField]
    private Vector2 fadeRange;
    [SerializeField]
    private Color color = Color.yellow;

    private Transform playerTransform;

    private void Start()
    {
        playerTransform = FindObjectOfType<PlayerMovement>().transform;
        UpdateFade();
    }

    private void Update()
    {
        UpdateFade();
    }

    private void UpdateFade()
    {
        float distance = Vector3.Distance(playerTransform.position, transform.position);
        distance = Mathf.Clamp(distance, fadeRange.x, fadeRange.y);
        float t = Mathf.InverseLerp(fadeRange.x, fadeRange.y, distance);
        renderer.material.color = Color.Lerp(Color.black, color, t);
    }
}
