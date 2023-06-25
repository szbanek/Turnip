using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcQuestManager : MonoBehaviour
{
    [Header("Quest")]
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
    private Quest quest;
    public Quest Quest => quest;

    void Start()
    {
        if(questText == null)
        {
            quest = QuestManager.Instance.GetNewQuest();
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
        }
    }

    public void GenerateNewQuest()
    {
        quest = QuestManager.Instance.GetNewQuest();
    }
}
