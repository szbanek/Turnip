using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public static class UIUtils
{
    public enum Fade { FadeIn, FadeOut }

    public static IEnumerator ChangeLocalScaleCoroutine(GameObject gameObject, Vector3 targetScale, float duration, Func<bool> additionalConditions = null)
    {
        Func<bool> func;
        if (additionalConditions == null)
        {
            func = () => true;
        }
        else
        {
            func = additionalConditions;
        }

        Vector3 beginningScale = gameObject.transform.localScale;
        float timer = 0;
        while (timer < duration && func())
        {
            yield return null;
            timer += Time.deltaTime;
            float x = Mathf.Lerp(beginningScale.x, targetScale.x, timer);
            gameObject.transform.localScale = Vector3.Lerp(beginningScale, targetScale, timer/duration);
        }
        if (func())
        {
            gameObject.transform.localScale = targetScale;
        }
    }

    public static IEnumerator TextFadeCoroutine(TextMeshProUGUI text, float duration, Fade fadeDirection, Func<bool> additionalConditions = null)
    {
        Func<bool> func;
        if (additionalConditions == null)
        {
            func = () => true;
        }
        else
        {
            func = additionalConditions;
        }

        float counter = 0;
        float start = fadeDirection == Fade.FadeIn ? 0 : 1;
        float end = fadeDirection == Fade.FadeIn ? 1 : 0;

        if (!text.gameObject.activeSelf)
        {
            text.gameObject.SetActive(true);
        }

        Color vertexColor = text.color;

        while (counter < duration && func())
        {
            counter += Time.unscaledDeltaTime;

            float alpha = Mathf.Lerp(start, end, counter / duration);

            text.color = new Color(vertexColor.r, vertexColor.g, vertexColor.b, alpha);

            yield return null;
        }

        if (fadeDirection == Fade.FadeOut && func())
        {
            text.gameObject.SetActive(false);
        }
    }
}
