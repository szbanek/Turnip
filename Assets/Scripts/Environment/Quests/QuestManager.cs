using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : Singleton<QuestManager>
{
    [SerializeField]
    private List<QuestText> texts;
    public Quest GetNewQuest()
    {
        return new Quest
        (
            (Vegetable.VegetableType)UnityEngine.Random.Range(0, 5),
            UnityEngine.Random.Range(1, 6),
            texts[UnityEngine.Random.Range(0, texts.Count)].Text,
            texts[UnityEngine.Random.Range(0, texts.Count)].PositiveAnswer,
            texts[UnityEngine.Random.Range(0, texts.Count)].NegativeAnswer
        );
    }
}
