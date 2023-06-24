using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerStats))]
public class PlayerStamina : MonoBehaviour
{
    [SerializeField]
    private float runStartThreshold = 2;
    [SerializeField]
    private float runCost;

    private float currentStamina;

    private PlayerStats playerStats;

    private void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        currentStamina = playerStats.MaxStamina;
    }

    public bool TryJump()
    {
        if(currentStamina < playerStats.JumpCost)
        {
            return false;
        }
        currentStamina -= playerStats.JumpCost;
        return true;
    }

    public bool TryStartRun()
    {
        return currentStamina > runStartThreshold;
    }

    public bool TryContinueRun()
    {
        float frameCost = runCost * Time.deltaTime;
        if (currentStamina > frameCost)
        {
            currentStamina -= frameCost;
            return true;
        }
        return false;
    }

    private void LateUpdate()
    {
        currentStamina += playerStats.StaminaRegen * Time.deltaTime;
        if(currentStamina > playerStats.MaxStamina)
        {
            currentStamina = playerStats.MaxStamina;
        }
        UIHUDController.Instance.StaminaBar.ChangeValue(currentStamina, playerStats.MaxStamina);
    }
}
