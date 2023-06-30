using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class UITooltipContentManager : MonoBehaviour
{
    [SerializeField]
    private Text header;
    [SerializeField]
    private Text content;

    [SerializeField]
    private float maxLength;
    [SerializeField]
    private LayoutElement layoutElement;

    public void SetContent(string headerText, string contentText)
    {
        header.text = headerText;
        content.text = contentText;
        layoutElement.enabled = Mathf.Max(header.text.Length, content.text.Length) > maxLength;
    }
}
