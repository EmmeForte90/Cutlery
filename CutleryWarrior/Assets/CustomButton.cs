using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CustomButton : MonoBehaviour
{
    public float zoomFactor = 1.2f; // Fattore di ingrandimento
    public Vector3 originalScale; // Scala originale dell'icona
    public RectTransform rectTransform;

    public void Big()
    {rectTransform.localScale = originalScale * zoomFactor;}

    public void Small()
    {rectTransform.localScale = originalScale;}

}