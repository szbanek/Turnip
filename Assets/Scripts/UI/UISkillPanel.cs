using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

public class UISkillPanel : MonoBehaviour
{
    [SerializeField]
    private Text level;
    [SerializeField]
    private Button levelUp;
    [SerializeField]
    private PlayerTree.Choice type;

    private void Awake()
    {
        levelUp.onClick.AddListener(LevelUp);
    }

    private void OnEnable()
    {
        level.text = FindObjectOfType<PlayerTree>().Levels[type].ToString();
    }

    private void LevelUp()
    {
        PlayerTree tree = FindObjectOfType<PlayerTree>();
        tree.TryToLevelUp(type);
        level.text = tree.Levels[type].ToString();
        UIExperience.Instance.UpdatePoints();
    }
}
