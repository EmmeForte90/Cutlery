using UnityEngine;

public class DeactivateEvent : MonoBehaviour
{
    public int IdEvent;
    public GameObject OBJ;
    public static DeactivateEvent instance;

    void Start()
    {
        if (ContainsIdEvent(PlayerStats.instance.MinieraSwitch, IdEvent))
        {
            // Se la condizione è vera, disattiva il gameObject
            OBJ.SetActive(false);
        }
    }

    bool ContainsIdEvent(bool[] array, int idEvent)
    {
        // Controlla se l'indice idEvent è valido nell'array
        if (idEvent >= 0 && idEvent < array.Length)
        {
            // Restituisci true se l'elemento nell'array corrispondente all'idEvent è true
            return array[idEvent];
        }

        // Restituisci false se l'indice idEvent non è valido
        return false;
    }

    public void ConfirmDeactivation(){PlayerStats.instance.MinieraSwitchEnd(IdEvent);}
}