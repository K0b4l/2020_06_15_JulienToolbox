using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsHighlighTag : MonoBehaviour
{
    public static List<IsHighlighTag> inScene = new List<IsHighlighTag>();

    public static List<IsHighlighTag> GetAllHighlightable() { return inScene; }
    private void Start()
    {
        inScene.Add(this);
    }
    private void OnDestroy()
    {
        inScene.Remove(this);
    }
}
