using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization;

public class OnEnableImageLocalizer : MonoBehaviour
{
    [SerializeField]
    private Image image;
    [SerializeField]
    private LocalizedSprite localizedSprite;

    private void OnEnable()
    {
        image.sprite = localizedSprite.LoadAsset();
    }
}
