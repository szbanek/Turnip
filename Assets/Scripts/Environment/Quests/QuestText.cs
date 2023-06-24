using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Scriptable Objects/QuestText")]
public class QuestText : ScriptableObject
{
    [SerializeField]
    [TextArea]
    private string text;
    public string Text => text;
    [SerializeField]
    [TextArea]
    private string positiveAnswer;
    public string PositiveAnswer => positiveAnswer;
    [SerializeField]
    [TextArea]
    private string negativeAnswer;
    public string NegativeAnswer => negativeAnswer;
}
