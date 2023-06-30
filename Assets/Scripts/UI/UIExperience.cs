using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization;

public class UIExperience : Singleton<UIExperience>
{
    [SerializeField]
    private Text level;
    [SerializeField]
    private UIBarController exp;
    [SerializeField]
    private Text points;
    [SerializeField]
    private LocalizedString levelText;
    [SerializeField]
    private LocalizedString pointsText;

    private PlayerExperience experience;

    protected override void Awake()
    {
        base.Awake();
        experience = FindObjectOfType<PlayerExperience>();
    }

    private void OnEnable()
    {
        level.text = levelText.GetLocalizedString() + " " + experience.CurrentLevel.ToString();
        points.text = pointsText.GetLocalizedString() + " " + experience.AvailablePoints.ToString();
        exp.ChangeValue(experience.CurrentExperience, experience.RequiredExperience);
    }

    public void UpdatePoints()
    {
        points.text = pointsText.GetLocalizedString() + " " + experience.AvailablePoints.ToString();
    }
}
