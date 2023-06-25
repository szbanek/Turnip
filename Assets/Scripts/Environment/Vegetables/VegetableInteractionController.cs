using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RandomSoundPlayer))]
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
    private PlayerStats stats;
    private NpcQuestManager questManager;

    public event System.EventHandler OnPickedUp;

    private InteractionIconController interactionIconController = null;
    public Vector3 Position => transform.position;
    private bool selected = false;

    private RandomSoundPlayer soundPlayer;

    public void Interact()
    {
        int index = Random.Range(0, vegetable.Minigames.Count);
        if (questManager != null)
        {
            MinigameManager.Instance.SpawnMinigame(vegetable.Minigames[index], this, questManager.Quest);
            return;
        }
        MinigameManager.Instance.SpawnMinigame(vegetable.Minigames[index], this);
        soundPlayer.PlayRandom();
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
        if (questManager != null)
        {
            if (win)
            {
                FindObjectOfType<PlayerExperience>().AddExperience(questManager.Quest.Exp);
                FindObjectOfType<PlayerItemsInventory>().Items.Add(questManager.Quest.Item);
                questManager.GenerateNewQuest();
            }
            return;
        }
        if (win)
        {
            FindObjectOfType<PlayerExperience>().AddExperience(vegetable.ExpGiven);
            FindObjectOfType<PlayerVegetableInventory>().AddItem(vegetable.Type,
            1 + (int)(stats.AdditionalVegetableChance/100 + UnityEngine.Random.Range(0f, 0.49f)));
            OnPickedUp?.Invoke(this, null);
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        questManager = GetComponent<NpcQuestManager>();
        stats = FindObjectOfType<PlayerStats>();
        if (interactionIconPrefab == null)
        {
            Debug.LogError("No interactionIconPrefab in VegatableInteractionController");
        }
        if (interactionIconData == null)
        {
            Debug.LogError("No interactionIconData in VegatableInteractionController");
        }
        soundPlayer = GetComponent<RandomSoundPlayer>();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position + iconPosition, 0.3f);
    }
}
