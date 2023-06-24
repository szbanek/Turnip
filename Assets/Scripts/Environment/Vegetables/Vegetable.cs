using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

[CreateAssetMenu(menuName="Scriptable Objects/Vegetable")]
public class Vegetable : ScriptableObject
{
    public enum VegetableType { Carrot, Lettuce, Pepper, Horseradish, Turnip }

    [SerializeField]
    private VegetableType type;
    public VegetableType Type => type;

    [SerializeField]
    [TextArea]
    private string description;
    public string Description => description;

    [SerializeField]
    private Sprite icon;
    public Sprite Icon => icon;

    [SerializeField]
    private List<GameObject> minigames;
    public List<GameObject> Minigames => minigames;

    public string Name => TypeToString(type);

    public static string TypeToString(VegetableType type)
    {
        switch (type)
        {
            case VegetableType.Carrot:
                return "Marchew";
            case VegetableType.Turnip:
                return "Rzepa";
            case VegetableType.Pepper:
                return "Papryka";
            case VegetableType.Lettuce:
                return "Sałata";
            case VegetableType.Horseradish:
                return "Chrzan";
            default:
                return "";
        }
    }
}
