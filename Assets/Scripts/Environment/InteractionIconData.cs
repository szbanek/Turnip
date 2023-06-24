using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Scriptable Objects/Interaction Icon Data")]
public class InteractionIconData : ScriptableObject
{
    [SerializeField]
    private string text;
    public string Text => text;

    [SerializeField]
    private Sprite icon;
    public Sprite Icon => icon;
}
