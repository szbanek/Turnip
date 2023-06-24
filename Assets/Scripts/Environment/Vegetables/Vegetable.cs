using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Scriptable Objects/Vegetable")]
public class Vegetable : ScriptableObject
{
    public enum VegetableType { Carrot, Lettuce, Pepper, Horseradish, Turnip }

    [SerializeField]
    private VegetableType type;
    public VegetableType Type => type;

    [SerializeField]
    private Sprite icon;
    public Sprite Icon => icon;

    [SerializeField]
    private List<GameObject> minigames;
    public List<GameObject> Minigames => minigames;
}
