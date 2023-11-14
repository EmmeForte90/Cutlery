using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public bool[] EventsDesert;    

    public static EventManager instance;
    public void Awake(){instance = this;}

    public void EventDesertEnd(int id){EventsDesert[id] = true;}

    public void DeactivateWarning()
    {
        // Cerca tutti i GameObjects con il tag "Enemy"
        GameObject[] WarningEvent = GameObject.FindGameObjectsWithTag("Event");
    
    foreach (GameObject Character in WarningEvent)
        {
            // Ottiene il componente QuestCharacters
            CameraWarning Event = Character.GetComponent<CameraWarning>();

            // Verifica se il componente esiste
            if (Event != null)
            {
                // Verifica se l'id della quest corrisponde all'id di un gameobject in OrdaliaActive
                int Id = Event.IdEvent;
                for (int i = 0; i <  EventsDesert.Length; i++)
                {
                    if ( EventsDesert[i] && i == Id)
                    {
                        // Imposta ordaliT.FirstD a false
                        Event.Take();
                        break;
                    }
                }
            }
        }
    }

}
