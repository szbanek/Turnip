using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(menuName="Scriptable Objects/Vegetable")]
public class Vegetable : ScriptableObject
{
    public enum VegetableType { Carrot, Lettuce, Pepper, Horseradish, Turnip, Npc}

    [SerializeField]
    private VegetableType type;
    public VegetableType Type => type;

    [SerializeField]
    private new LocalizedString name;

    [SerializeField]
    private LocalizedString description;

    [SerializeField]
    private Sprite icon;
    public Sprite Icon => icon;

    [SerializeField]
    private List<GameObject> minigames;
    public List<GameObject> Minigames => minigames;

    [SerializeField]
    private float expGiven;
    public float ExpGiven => expGiven;

    public string Name => name.GetLocalizedString();
    public string Description => description.GetLocalizedString();
}
