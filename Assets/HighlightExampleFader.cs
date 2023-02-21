using System.Collections;
using UnityEngine;

public class HighlightExampleFader : MonoBehaviour
{
    [Header("Data Storage")]
    [SerializeField] private HighlightProfile hp;

    [Header("Material")]
    [SerializeField] private Material highlightMat;

    [Header("Highlight Configuration")]
    [SerializeField] private int highlightDelay = 10;

    private void Start()
    {
        highlightMat.SetFloat("_FadeValue", 0f);
        highlightMat.color = hp.highlightColor;
        StartCoroutine(FadeHighlight(highlightDelay));
    }

    private IEnumerator FadeHighlight(int startDelay)
    {
        // Sets a delay before the highligt appears
        for (float i = 0; i < startDelay; i += Time.deltaTime)
        {
            yield return null;
        }

        // How long it takes for the highligt to fade in
        for (float i = 0; i < 1; i += Time.deltaTime / hp.fadeInSeconds)
        {
            highlightMat.SetFloat("_FadeValue", i);
            yield return null;
        }

        // The duration of the highlight
        for (float i = 0; i < hp.staySeconds; i += Time.deltaTime)
        {
            yield return null;
        }

        // How long it takes for the highlight to fade out
        for (float i = 1; i > 0; i -= Time.deltaTime / hp.fadeOutSeconds)
        {
            highlightMat.SetFloat("_FadeValue", i);
            yield return null;
        }

        Debug.Log("Done!");
    }
}