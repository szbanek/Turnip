using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerExperience : MonoBehaviour
{
    [SerializeField]
    private float requiredExperience;

    [SerializeField]
    private AudioClip levelUpClip;

    private int currentLevel;
    private int availablePoints;
    private float currentExperience;

    public int CurrentLevel => currentLevel;
    public int AvailablePoints => availablePoints;
    public float CurrentExperience => currentExperience;
    public float RequiredExperience => requiredExperience;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        currentLevel = 1;
        availablePoints = 0;
        currentExperience = 0;
    }

    public void AddExperience(float exp)
    {
        currentExperience += exp;
        while (currentExperience >= requiredExperience)
        {
            audioSource.PlayOneShot(levelUpClip);
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
