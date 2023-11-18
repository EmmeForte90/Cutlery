using UnityEngine;
using System.Collections;
using TMPro;

public class TextShake : MonoBehaviour
{
    public float shakeIntensity = 3f;
    //public float shakeDuration = 1f;
   // public bool Haveduration = false;

    private TextMeshProUGUI textMeshPro;
    private Vector3 originalPosition;

    void Start()
    {
        // Assicurati di avere TextMeshProUGUI aggiunto all'oggetto Text
        textMeshPro = GetComponent<TextMeshProUGUI>();
        originalPosition = transform.position;
    }

    void Update()
    {
       
        float x = originalPosition.x + Random.Range(-1f, 1f) * shakeIntensity;
            float y = originalPosition.y + Random.Range(-1f, 1f) * shakeIntensity;
            transform.position = new Vector3(x, y, originalPosition.z);
            
        
        
    }

    /*IEnumerator ShakeText()
    {
        float elapsedTime = 0f;
       
        while (elapsedTime < shakeDuration)
        {
            float x = originalPosition.x + Random.Range(-1f, 1f) * shakeIntensity;
            float y = originalPosition.y + Random.Range(-1f, 1f) * shakeIntensity;

            transform.position = new Vector3(x, y, originalPosition.z);

            elapsedTime += Time.deltaTime;
            yield return null;
        }
        // Ripristina la posizione originale del testo
        transform.position = originalPosition;
    }*/
}