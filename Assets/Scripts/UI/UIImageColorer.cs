using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIImageColorer : MonoBehaviour
{
    [SerializeField]
    private Image image;
    [SerializeField]
    private Color color;

    public void ColorImage()
    {
        image.color = color;
    }

    public void DecolorImage()
    {
        image.color = Color.white;
    }
}
