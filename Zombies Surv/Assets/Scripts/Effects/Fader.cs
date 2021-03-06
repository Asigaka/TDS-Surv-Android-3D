using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fader : MonoBehaviour
{
    private Renderer fadeRenderer;

    private const float fadeDuraction = 0.8f;
    private const float minAlpha = 0.2f;

    private bool isFade;

    private void Awake()
    {
        fadeRenderer = GetComponent<Renderer>();
    }

    public void Fade()
    {
        if (isFade) return;

        isFade = true;
        fadeRenderer.material.DOFade(minAlpha, fadeDuraction);
    }

    public void StopFade()
    {
        if (!isFade) return;

        isFade = false;
        fadeRenderer.material.DOFade(1, fadeDuraction);
    }
}
