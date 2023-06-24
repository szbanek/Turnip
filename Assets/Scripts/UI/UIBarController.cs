using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBarController : MonoBehaviour
{
    [SerializeField]
    private List<Image> images;

    public void ChangeValueInverted(float current, float maxVal)
    {
        ChangeValue((maxVal - current), maxVal);
    }

    public void ChangeValue(float current, float maxVal)
    {
        foreach (Image image in images)
        {
            image.fillAmount = current / maxVal;
        }
    }

    public void ImageSetEnabled(int index, bool enabled)
    {
        if (index > images.Count || index < 0)
        {
            return;
        }
        images[index].enabled = enabled;
    }
}
