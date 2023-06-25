using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(LayoutElement))]
[ExecuteInEditMode()]
public class UITooltipContentManager : MonoBehaviour
{
    [SerializeField]
    private Text header;
    [SerializeField]
    private Text content;

    [SerializeField]
    private float maxLength;

    private LayoutElement layoutElement;

    private void Start()
    {
        layoutElement = GetComponent<LayoutElement>();
    }

    public void SetContent(string headerText, string contentText)
    {
        header.text = headerText;
        content.text = contentText;
        layoutElement.enabled = Mathf.Max(header.text.Length, content.text.Length) > maxLength;
    }
}
