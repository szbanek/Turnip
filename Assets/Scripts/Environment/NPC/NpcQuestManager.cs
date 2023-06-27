using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(VegetableInteractionController))]
public class NpcQuestManager : MonoBehaviour
{
    [Header("Quest")]
    [SerializeField]
    private bool usePredefinedQuest;
    [SerializeField]
    private Vegetable.VegetableType type;
    [SerializeField]
    private int quantity;
    [SerializeField]
    private float exp;
    [SerializeField]
    private QuestText questText;
    [SerializeField]
    PlayerItem item;
    [SerializeField]
    private InteractionIconData predefinedQuestIconData;

    private Quest quest;
    public Quest Quest => quest;

    VegetableInteractionController controller;

    void Start()
    {
        controller = GetComponent<VegetableInteractionController>();
        if(!usePredefinedQuest)
        {
            quest = QuestManager.Instance.GetNewQuest();
            controller.PredefinedIconData = null;
        }
        else
        {
            quest = QuestManager.Instance.GetNewQuest(
                (Vegetable.VegetableType)type,
                quantity,
                questText.Text,
                questText.PositiveAnswer,
                questText.NegativeAnswer,
                exp,
                item
            );
            controller.PredefinedIconData = predefinedQuestIconData;
        }
    }

    public void GenerateNewQuest()
    {
        quest = QuestManager.Instance.GetNewQuest();
        controller.PredefinedIconData = null;
    }
}
