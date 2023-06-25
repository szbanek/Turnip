using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : Singleton<QuestManager>
{
    [SerializeField]
    private Vector2 expRange;
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
            texts[UnityEngine.Random.Range(0, texts.Count)].NegativeAnswer,
            Random.Range(expRange.x, expRange.y)
        );
    }

    public Quest GetNewQuest
    (
        Vegetable.VegetableType type,
        int quantity,
        string text,
        string positiveAnswer,
        string negativeAnswer,
        float exp
    )
    {
        return new Quest
        (
            type,
            quantity,
            text,
            positiveAnswer,
            negativeAnswer,
            exp
        );
    }
}
