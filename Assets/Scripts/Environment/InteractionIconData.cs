using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(menuName="Scriptable Objects/Interaction Icon Data")]
public class InteractionIconData : ScriptableObject
{
    [SerializeField]
    private LocalizedString text;
    public string Text => text.GetLocalizedString();

    [SerializeField]
    private Sprite icon;
    public Sprite Icon => icon;
}
