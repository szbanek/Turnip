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
        int tmp = UnityEngine.Random.Range(0, texts.Count);
        return new Quest
        (
            (Vegetable.VegetableType)UnityEngine.Random.Range(0, 5),
            UnityEngine.Random.Range(1, 6),
            texts[tmp].Text,
            texts[tmp].PositiveAnswer,
            texts[tmp].NegativeAnswer,
            Random.Range(expRange.x, expRange.y),
            ItemsGenerator.Instance.GenerateItem()
        );
    }

    public Quest GetNewQuest
    (
        Vegetable.VegetableType type,
        int quantity,
        string text,
        string positiveAnswer,
        string negativeAnswer,
        float exp,
        PlayerItem item
    )
    {
        return new Quest
        (
            type,
            quantity,
            text,
            positiveAnswer,
            negativeAnswer,
            exp,
            ItemsGenerator.Instance.GenerateItem(item)
        );
    }
}
