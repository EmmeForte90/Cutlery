using UnityEngine;
using System.Collections;
using TMPro;

public class WaveText : MonoBehaviour
{
    public float amplitude = 1.0f;
    public float frequency = 1.0f;
    public float speed = 1.0f;

    private TextMeshProUGUI textMeshPro;
    private float originalX;

    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        originalX = transform.position.x;
    }

    void Update()
    {
        // Applica l'effetto d'onda orizzontale al testo
        float waveValue = Mathf.Sin(Time.time * frequency) * amplitude;
        float offsetX = Mathf.Sin(Time.time * speed) * waveValue;
        
        Vector3 newPosition = new Vector3(originalX + offsetX, transform.position.y, transform.position.z);
        transform.position = newPosition;
    }
}