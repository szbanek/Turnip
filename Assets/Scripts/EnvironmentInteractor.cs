using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentInteractor : MonoBehaviour
{
    [Header("Config")]
    [SerializeField]
    private float interactionRange;
    [SerializeField]
    private LayerMask interactionLayerMask;

    [Header("References")]
    [SerializeField]
    private Camera playerCamera;

    [Header("Debug")]
    [SerializeField]
    private bool debugInfo;

    private GameObject selectedObject = null;

    private void Update()
    {
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out RaycastHit raycastHit, interactionRange, interactionLayerMask))
        {
            Vector3 hitPosition = playerCamera.WorldToScreenPoint(raycastHit.point);
            GameObject hitObject = raycastHit.collider.gameObject;
            if (hitObject.CompareTag("Interactive") && IsScreenPointInViewport(hitPosition))
            {
                if (selectedObject != hitObject && debugInfo)
                {
                    Debug.LogFormat("Selected object '{0}'", hitObject.name);
                }
                selectedObject = hitObject;
            }
            else
            {
                if (selectedObject != null && debugInfo)
                {
                    Debug.LogFormat("Selected nothing");
                }
                selectedObject = null;
            }
        }
        else
        {
            if (selectedObject != null && debugInfo)
            {
                Debug.LogFormat("Selected nothing");
            }
            selectedObject = null;
        }
    }

    private bool IsScreenPointInViewport(Vector3 screenPos)
    {
        bool onScreenX = screenPos.x > 0 && screenPos.x < playerCamera.pixelWidth;
        bool onScreenY = screenPos.y > 0 && screenPos.y < playerCamera.pixelHeight;
        bool onScreenZ = screenPos.z > 0;
        return onScreenX && onScreenY && onScreenZ;
    }

    public void InteractWithSelected()
    {
        if (selectedObject != null)
        {
            if (debugInfo)
            {
                Debug.LogFormat("Interacting with '{0}'", selectedObject.name);
            }
            //selectedObject.GetComponent<Triggers.InteractiveTrigger>()?.Interact();
        }
    }
}
