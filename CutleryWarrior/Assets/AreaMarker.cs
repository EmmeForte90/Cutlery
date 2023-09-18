using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaMarker : MonoBehaviour
{
  public GameObject selectionMarkerPrefab; // Il prefab del marker di selezione

    private Vector3 startPosition;
    private GameObject selectionMarker;
    private bool isSelecting = false;

    void Update()
    {
        // Inizia la selezione quando il pulsante del mouse sinistro viene premuto
        if (Input.GetMouseButtonDown(0))
        {
            isSelecting = true;
            startPosition = Input.mousePosition;
            CreateSelectionMarker(startPosition);
        }

        // Continua a selezionare mentre il pulsante del mouse sinistro è premuto
        if (isSelecting && Input.GetMouseButton(0))
        {
            UpdateSelectionMarker(Input.mousePosition);
        }

        // Termina la selezione quando il pulsante del mouse sinistro viene rilasciato
        if (Input.GetMouseButtonUp(0))
        {
            isSelecting = false;
            DestroySelectionMarker();
          //  SelectUnitsInArea(startPosition, Input.mousePosition);
        }
    }

    // Crea il marker di selezione iniziale
    private void CreateSelectionMarker(Vector3 position)
    {
        selectionMarker = Instantiate(selectionMarkerPrefab);
        selectionMarker.transform.position = position;
    }

    // Aggiorna la posizione del marker di selezione durante la selezione
    private void UpdateSelectionMarker(Vector3 endPosition)
    {
        Vector3 center = (startPosition + endPosition) / 2f;
        //Vector3 size = new Vector3(Mathf.Abs(endPosition.x - startPosition.x), 1f, Mathf.Abs(endPosition.y - startPosition.y));
        selectionMarker.transform.position = center;
        //selectionMarker.transform.localScale = size;
    }

    // Distrugge il marker di selezione quando la selezione è terminata
    private void DestroySelectionMarker()
    {
        if (selectionMarker != null)
        {
            //Destroy(selectionMarker);
        }
    }

    // Seleziona le unità all'interno dell'area
    /*private void SelectUnitsInArea(Vector3 start, Vector3 end)
    {
        // Effettua il raycast dal punto di inizio al punto di fine per selezionare le unità
        Ray selectionRay = Camera.main.ScreenPointToRay(start);
        RaycastHit[] hits;
        hits = Physics.RaycastAll(selectionRay, Vector3.Distance(start, end));

        // Deseleziona tutte le unità prima di selezionarne di nuove
        DeselectAllUnits();

        foreach (RaycastHit hit in hits)
        {
            if (hit.collider.CompareTag("SelectableUnit"))
            {
                // Seleziona l'unità
                hit.collider.GetComponent<SelectableUnit>().Select();
            }
        }
    }

    // Deseleziona tutte le unità
    private void DeselectAllUnits()
    {
        SelectableUnit[] units = FindObjectsOfType<SelectableUnit>();
        foreach (SelectableUnit unit in units)
        {
            unit.Deselect();
        }
    }*/
}