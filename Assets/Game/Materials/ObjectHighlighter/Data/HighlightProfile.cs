using UnityEngine;

[CreateAssetMenu(fileName = "HighlightProfile", menuName = "Data Storage/Highlight Profile")]

public class HighlightProfile : ScriptableObject
{
    public float fadeInSeconds;
    public float staySeconds;
    public float fadeOutSeconds;

    [ColorUsage(true, true)]
    public Color highlightColor;
}
