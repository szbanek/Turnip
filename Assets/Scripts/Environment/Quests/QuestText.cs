using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(menuName="Scriptable Objects/QuestText")]
public class QuestText : ScriptableObject
{
    [SerializeField]
    private LocalizedString localizedText;
    public string Text => localizedText.GetLocalizedString();

    [SerializeField]
    private LocalizedString localizedPositiveAnswer;
    public string PositiveAnswer => localizedPositiveAnswer.GetLocalizedString();

    [SerializeField]
    private LocalizedString localizedNegativeAnswer;
    public string NegativeAnswer => localizedNegativeAnswer.GetLocalizedString();
}
