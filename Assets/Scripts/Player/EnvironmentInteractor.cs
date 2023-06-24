using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class EnvironmentInteractor : MonoBehaviour
{
    [Header("Config")]
    [SerializeField]
    private float interactionRange;

    [Header("References")]
    [SerializeField]
    private Camera playerCamera;

    [Header("Debug")]
    [SerializeField]
    private bool debugInfo;

    private IInteractable selectedObject = null;
    private CharacterController characterController;

    private List<IInteractable> selectedObjects = new List<IInteractable>();

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Vector3 boxCenter = transform.position + transform.forward * (interactionRange / 2 + characterController.radius);
        Vector3 halfExtents = new Vector3(interactionRange, characterController.height, interactionRange) / 2;
        Collider[] colliders = Physics.OverlapBox(boxCenter, halfExtents, transform.rotation);
        selectedObjects.Clear();
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Interactive"))
            {
                if (collider.TryGetComponent(out IInteractable interactable))
                {
                    selectedObjects.Add(interactable);
                }
            }
        }
        UpdateSelectedObject();
    }

    private void UpdateSelectedObject()
    {
        IInteractable minSelect = null;
        float minDistance = Mathf.Infinity;
        foreach (IInteractable selected in selectedObjects)
        {
            float distance = (selected.Position - transform.position).magnitude;
            if (distance <= minDistance)
            {
                minDistance = distance;
                minSelect = selected;
            }
        }
        bool unselect = false;
        bool select = false;
        if (selectedObject != minSelect)
        {
            unselect = true;
            if (minSelect == null)
            {
                if (debugInfo)
                {
                    Debug.LogFormat("Selected nothing");
                }
            }
            else
            {
                if (debugInfo)
                {
                    Debug.LogFormat("Selected object");
                }
                select = true;
            }
        }
        if (selectedObject != null && unselect)
        {
            selectedObject.Unselect();
        }
        selectedObject = minSelect;
        if (selectedObject != null && select)
        {
            selectedObject.Select();
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
                Debug.LogFormat("Interacting with object");
            }
            //selectedObject.GetComponent<Triggers.InteractiveTrigger>()?.Interact();
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (characterController == null)
        {
            return;
        }
        Gizmos.color = Color.yellow;
        Vector3 boxCenter = Vector3.forward * (interactionRange / 2 + characterController.radius);
        Vector3 size = new Vector3(interactionRange, characterController.height, interactionRange);
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.DrawWireCube(boxCenter, size);
    }
}
