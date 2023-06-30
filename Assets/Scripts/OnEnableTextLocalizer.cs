using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization;

public class OnEnableTextLocalizer : MonoBehaviour
{
    [SerializeField]
    private Text text;
    [SerializeField]
    private LocalizedString localizedString;

    private void OnEnable()
    {
        text.text = localizedString.GetLocalizedString();
    }
}
