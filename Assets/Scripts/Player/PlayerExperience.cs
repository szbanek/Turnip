using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExperience : MonoBehaviour
{
    [SerializeField]
    private float requiredExperience;

    private int currentLevel;
    private int availablePoints;
    private float currentExperience;

    public int CurrentLevel => currentLevel;
    public int AvailablePoints => availablePoints;
    public float CurrentExperience => currentExperience;
    public float RequiredExperience => requiredExperience;

    private void Start()
    {
        currentLevel = 1;
        availablePoints = 0;
        currentExperience = 0;
    }

    public void AddExperience(float exp)
    {
        currentExperience += exp;
        while (currentExperience >= requiredExperience)
        {
            currentLevel++;
            availablePoints++;
            currentExperience -= requiredExperience;
        }
    }

    public void SubtractPoints(int amount)
    {
        availablePoints -= amount;
    }
}
