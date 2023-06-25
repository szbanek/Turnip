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
    private float maxAlpha;

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
        float alpha = Mathf.Lerp(0, maxAlpha, t);
        Color color = renderer.material.color;
        color.a = alpha;
        renderer.material.color = color;
        print(renderer.material.color);
    }
}
