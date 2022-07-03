using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fader : MonoBehaviour
{
    [SerializeField] private Renderer fadeRenderer;
    [SerializeField] private float fadeDuraction = 2f;
    [SerializeField] private float minAlpha = 0.2f;

    private bool isFade;

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
