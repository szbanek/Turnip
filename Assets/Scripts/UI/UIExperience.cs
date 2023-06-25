using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIExperience : Singleton<UIExperience>
{
    [SerializeField]
    private Text level;
    [SerializeField]
    private UIBarController exp;
    [SerializeField]
    private Text points;
    [SerializeField]
    private string levelText;
    [SerializeField]
    private string pointsText;

    private PlayerExperience experience;

    protected override void Awake()
    {
        base.Awake();
        experience = FindObjectOfType<PlayerExperience>();
    }

    private void OnEnable()
    {
        level.text = levelText + " " + experience.CurrentLevel.ToString();
        points.text = pointsText + " " + experience.AvailablePoints.ToString();
        exp.ChangeValue(experience.CurrentExperience, experience.RequiredExperience);
    }

    public void UpdatePoints()
    {
        points.text = pointsText + " " + experience.AvailablePoints.ToString();
    }
}
