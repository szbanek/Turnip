using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPopUp : Singleton<UIPopUp>
{
    public enum PopUpType { Vegetable, Item }

    [SerializeField]
    private Text label;
    [SerializeField]
    private string vegetableString;
    [SerializeField]
    private string itemString;
    [SerializeField]
    private float localYPos;
    [SerializeField]
    private float moveTime;
    [SerializeField]
    private float stopTime;

    private float startYPos;
    private float endYPos;
    private RectTransform rectTransform;

    private bool isPoppingUp = false;

    private void Start()
    {
        rectTransform = transform as RectTransform;
        startYPos = rectTransform.position.y;
        endYPos = localYPos;
    }

    public void PopUp(PopUpType type)
    {
        if (isPoppingUp)
        {
            return;
        }

        label.text = type == PopUpType.Vegetable ? vegetableString : itemString;
        StartCoroutine(PopUpCoroutine());
    }

    private IEnumerator PopUpCoroutine()
    {
        isPoppingUp = true;

        float counter = 0;
        while ((counter += Time.deltaTime) < moveTime)
        {
            yield return null;
            Vector3 pos = rectTransform.position;
            pos.y = Mathf.Lerp(startYPos, endYPos, counter/moveTime);
            rectTransform.position = pos;
        }

        yield return new WaitForSeconds(stopTime);

        while ((counter -= Time.deltaTime) > 0)
        {
            yield return null;
            Vector3 pos = rectTransform.position;
            pos.y = Mathf.Lerp(startYPos, endYPos, counter / moveTime);
            rectTransform.position = pos;
        }

        isPoppingUp = false;
    }
}
