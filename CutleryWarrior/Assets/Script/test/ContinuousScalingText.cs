using UnityEngine;
using System.Collections;
using TMPro;

public class ContinuousScalingText : MonoBehaviour
{
    public float scaleSpeed = 1.0f;

    private TextMeshProUGUI textMeshPro;

    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        float scaleValue = 1.0f + Mathf.Sin(Time.time * scaleSpeed) * 0.5f;
        textMeshPro.transform.localScale = new Vector3(scaleValue, scaleValue, 1.0f);
    }
}