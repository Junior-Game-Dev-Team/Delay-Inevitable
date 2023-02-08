using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightExampleFader : MonoBehaviour
{
    public HighlightProfile hp;
    public Material highlightMat;

    private void Start()
    {
        highlightMat.SetFloat("_FadeValue", 0f);
        highlightMat.color = hp.highlightColor;
        StartCoroutine(FadeHighlight(10));
    }

    IEnumerator FadeHighlight(int startDelay)
    {
        for (float i = 0; i < startDelay; i += Time.deltaTime)
        {
            yield return null;
        }
        for (float i = 0; i < 1; i+=Time.deltaTime / hp.fadeInSeconds)
        {
            highlightMat.SetFloat("_FadeValue", i);
            yield return null;
        }
        for (float i = 0; i < hp.staySeconds; i += Time.deltaTime)
        {
            yield return null;
        }
        for (float i = 1; i > 0; i -= Time.deltaTime / hp.fadeOutSeconds)
        {
            highlightMat.SetFloat("_FadeValue", i);
            yield return null;
        }

        Debug.Log("Done!");
    }
}
