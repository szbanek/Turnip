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
    private Sprite icon;
    public Sprite Icon => icon;

    [SerializeField]
    private List<GameObject> minigames;
    public List<GameObject> Minigames => minigames;

    [SerializeField]
    private float expGiven;
    public float ExpGiven => expGiven;

    public string Name => TypeToString(type);
    public string Description => TypeToDescription(type);

    private static LocalizedStringTable localizedStringTable = new LocalizedStringTable { TableReference = "Strings" };

    public static string TypeToString(VegetableType type)
    {
        return localizedStringTable.GetTable().GetEntry(type.ToString().ToLower()).GetLocalizedString();
    }

    public static string TypeToDescription(VegetableType type)
    {
        return localizedStringTable.GetTable().GetEntry(type.ToString().ToLower() + "_desc").GetLocalizedString();
    }
}
