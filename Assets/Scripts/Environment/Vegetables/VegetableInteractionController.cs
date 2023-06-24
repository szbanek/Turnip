using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegetableInteractionController : MonoBehaviour, IInteractable
{
    [Header("Config")]
    [SerializeField]
    private Vector3 iconPosition;

    [Header("References")]
    [SerializeField]
    private GameObject interactionIconPrefab;
    [SerializeField]
    private InteractionIconData interactionIconData;
    [SerializeField]
    private Vegetable vegetable;

    private InteractionIconController interactionIconController = null;
    public Vector3 Position => transform.position;
    private bool selected = false;

    public void Interact()
    {
        int index = Random.Range(0, vegetable.Minigames.Count);
        MinigameManager.Instance.SpawnMinigame(vegetable.Minigames[index], this);
        Unselect();
    }

    public void Select()
    {
        if (selected)
        {
            return;
        }
        selected = true;
        interactionIconController = Instantiate(interactionIconPrefab, UIHUDController.Instance.InteractionIconCanvas).GetComponent<InteractionIconController>();
        interactionIconController.ShowIcon(interactionIconData, transform.position + iconPosition);
    }

    public void Unselect()
    {
        if (!selected)
        {
            return;
        }
        selected = false;
        interactionIconController.OnHideEvent += (_, _) => Destroy(interactionIconController.gameObject);
        interactionIconController.HideIcon();
    }

    public void MinigameEnd(bool win)
    {
        if (win)
        {
            FindObjectOfType<PlayerVegetableInventory>().AddItem(vegetable.Type, 1);
        }
        Destroy(gameObject);
    }

    private void Start()
    {
        if (interactionIconPrefab == null)
        {
            Debug.LogError("No interactionIconPrefab in VegatableInteractionController");
        }
        if (interactionIconData == null)
        {
            Debug.LogError("No interactionIconData in VegatableInteractionController");
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position + iconPosition, 0.3f);
    }
}
