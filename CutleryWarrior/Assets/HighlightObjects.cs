using UnityEngine;
using Cinemachine;
using System.Linq;
using System.Collections.Generic;


public class HighlightObjects : MonoBehaviour
{
    private CinemachineVirtualCamera vCam;

    [Header("IndicatoreNemico")]
    public GameObject[] objectsToHighlight;
    public GameObject highlightedObjectIndicator;
    public float minValue = 0f;
    public float maxValue = 1f;
    public float step = 0.1f;
    private int currentIndex = 0;

    void Start()
    {
        vCam = GameObject.FindWithTag("MainCamera").GetComponent<CinemachineVirtualCamera>();
    }

    void Update()
    {
        // Input per diminuire il valore
        if (Input.GetKeyDown(KeyCode.A))
        {
            DecreaseValue();
        }

        // Input per aumentare il valore
        if (Input.GetKeyDown(KeyCode.D))
        {
            IncreaseValue();
        }

        // Input per testare la rimozione di un'unità
        if (Input.GetKeyDown(KeyCode.R))
        {
            RemoveUnitAtIndex(currentIndex);
        }

        // Assicurati che l'indice sia all'interno dei limiti dell'array
        currentIndex = Mathf.Clamp(currentIndex, 0, objectsToHighlight.Length - 1);

        // Evidenzia l'oggetto corrente
        HighlightCurrentObject();

        // Aggiorna la posizione dell'indicatore dell'oggetto evidenziato
        UpdateIndicatorPosition();
    }

    #region Indicatore per evidenziare i nemici

    void HighlightCurrentObject()
    {
        // Disattiva tutti gli oggetti
        foreach (var obj in objectsToHighlight)
        {
            obj.SetActive(false);
        }

        // Attiva l'oggetto corrente
        if (objectsToHighlight.Length > 0)
        {
            objectsToHighlight[currentIndex].SetActive(true);
        }
    }

    void UpdateIndicatorPosition()
    {
        // Posiziona l'indicatore nell'oggetto corrente
        if (highlightedObjectIndicator != null && objectsToHighlight.Length > 0)
        {
            highlightedObjectIndicator.transform.position = objectsToHighlight[currentIndex].transform.position;
        }
    }

    void IncreaseValue()
    {
        currentIndex++;
        if (currentIndex >= objectsToHighlight.Length)
        {
            // Se supera il massimo, riporta l'indice a 0
            currentIndex = 0;
        }
    }

    void DecreaseValue()
    {
        currentIndex--;
        if (currentIndex < 0)
        {
            // Se scende al di sotto del minimo, riporta l'indice al massimo
            currentIndex = objectsToHighlight.Length - 1;
        }
    }

    void RemoveUnitAtIndex(int index)
{
    if (index >= 0 && index < objectsToHighlight.Length)
    {
        GameObject removedObject = objectsToHighlight[index];

        // Rimuovi l'oggetto dall'array
        List<GameObject> tempList = objectsToHighlight.ToList();
        tempList.RemoveAt(index);
        objectsToHighlight = tempList.ToArray();

        // Distruisci l'oggetto rimosso
        Destroy(removedObject);
    }
}
#endregion
}