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

    private GameObject selectedObject = null;
    private CharacterController characterController;

    private HashSet<GameObject> selectedObjects = new HashSet<GameObject>();

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
                selectedObjects.Add(collider.gameObject);
            }
        }
        UpdateSelectedObject();
    }

    private void UpdateSelectedObject()
    {
        GameObject minSelect = null;
        float minDistance = Mathf.Infinity;
        foreach (GameObject select in selectedObjects)
        {
            float distance = (select.transform.position - transform.position).magnitude;
            if (distance <= minDistance)
            {
                minDistance = distance;
                minSelect = select;
            }
        }
        if (selectedObject != minSelect && debugInfo)
        {
            if (minSelect == null)
            {
                Debug.LogFormat("Selected nothing");
            }
            else
            {
                Debug.LogFormat("Selected object '{0}'", minSelect.name);
            }
        }
        selectedObject = minSelect;
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
