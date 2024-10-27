using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class UiFader : Singleton<UiFader>
{
    [SerializeField] private Image fadeImage;
    [SerializeField] private float fadeSpeed = 1f;

    private IEnumerator fadeRoutine;

    public void FadeToBlack()
    {
        if (fadeRoutine != null)
        {
            StopCoroutine(fadeRoutine);
        }

        fadeRoutine = FadeRoutine(1f);
        StartCoroutine(fadeRoutine);
    }

    public void FadeFromBlack()
    {
        if (fadeRoutine != null)
        {
            StopCoroutine(fadeRoutine);
        }

        fadeRoutine = FadeRoutine(0f);
        StartCoroutine(fadeRoutine);
    }

    private IEnumerator FadeRoutine(float targetAlpha)
    {
        while (!Mathf.Approximately(fadeImage.color.a, targetAlpha))
        {
            float newAlpha = Mathf.MoveTowards(fadeImage.color.a, targetAlpha, fadeSpeed * Time.deltaTime);
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, newAlpha);
            yield return null;
        }

    }


}
