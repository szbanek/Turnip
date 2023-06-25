using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RandomSoundPlayer))]
public class VegetableInteractionController : MonoBehaviour, IInteractable
{
    [Header("Config")]
    [SerializeField]
    private Vector3 iconPosition;
    [SerializeField]
    private float minQuestGenerationTime;
    [SerializeField]
    private float maxQuestGenerationTime;

    [Header("References")]
    [SerializeField]
    private GameObject interactionIconPrefab;
    [SerializeField]
    private InteractionIconData interactionIconData;
    [SerializeField]
    private Vegetable vegetable;

    [Header("Quest marker")]
    [SerializeField]
    private GameObject questMarkerPrefab;
    [SerializeField]
    private Vector3 questMarkerOffset;

    private PlayerStats stats;
    private NpcQuestManager questManager;
    private GameObject questMarker;

    public event System.EventHandler OnPickedUp;
    public event System.EventHandler QuestCompleteEvent;

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
                gameObject.tag = "Untagged";
                if (questMarker)
                {
                    Destroy(questMarker);
                }
                UIPopUp.Instance.PopUp(UIPopUp.PopUpType.Item);
                StartCoroutine(GenerateQuestCoroutine());
                QuestCompleteEvent?.Invoke(this, null);
            }
            return;
        }
        if (win)
        {
            FindObjectOfType<PlayerExperience>().AddExperience(vegetable.ExpGiven);
            FindObjectOfType<PlayerVegetableInventory>().AddItem(vegetable.Type,
            1 + (int)(stats.AdditionalVegetableChance / 100 + Random.Range(0f, 0.49f)));
            UIPopUp.Instance.PopUp(UIPopUp.PopUpType.Vegetable);
            OnPickedUp?.Invoke(this, null);
            Destroy(gameObject);
        }
        else
        {
            Select();
        }
    }

    private IEnumerator GenerateQuestCoroutine()
    {
        yield return new WaitForSeconds(Random.Range(minQuestGenerationTime, maxQuestGenerationTime));
        questManager.GenerateNewQuest();
        gameObject.tag = "Interactive";
        if (questMarkerPrefab != null)
        {
            questMarker = Instantiate(questMarkerPrefab, transform.position + questMarkerOffset, transform.rotation);
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

        if (questManager != null && questMarkerPrefab != null)
        {
            questMarker = Instantiate(questMarkerPrefab, transform.position + questMarkerOffset, transform.rotation);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position + iconPosition, 0.3f);
    }
}
