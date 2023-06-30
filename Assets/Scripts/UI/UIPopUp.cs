using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization;

public class UIPopUp : Singleton<UIPopUp>
{
    public enum PopUpType { Vegetable, Item, Level, TheEnd }

    [SerializeField]
    private Text label;
    [SerializeField]
    private LocalizedString vegetableString;
    [SerializeField]
    private LocalizedString itemString;
    [SerializeField]
    private LocalizedString levelString;
    [SerializeField]
    private LocalizedString theEndString;
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
    private Queue<PopUpType> awaitingPopUps = new Queue<PopUpType>();

    private void Start()
    {
        rectTransform = transform as RectTransform;
        startYPos = rectTransform.position.y;
        endYPos = localYPos;
    }

    public void PopUp(PopUpType type)
    {
        awaitingPopUps.Enqueue(type);
    }

    private void Update()
    {
        if (!isPoppingUp && awaitingPopUps.Count > 0)
        {
            StartCoroutine(PopUpCoroutine(awaitingPopUps.Dequeue()));
        }
    }

    private IEnumerator PopUpCoroutine(PopUpType type)
    {
        switch (type)
        {
            case PopUpType.Vegetable:
                label.text = vegetableString.GetLocalizedString();
                break;
            case PopUpType.Item:
                label.text = itemString.GetLocalizedString();
                break;
            case PopUpType.Level:
                label.text = levelString.GetLocalizedString();
                break;
            case PopUpType.TheEnd:
                label.text = theEndString.GetLocalizedString();
                break;
        }
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
