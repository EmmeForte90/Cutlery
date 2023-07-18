using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    
    public GameObject Area1;
    public GameObject Area2;


    private void OnTriggerEnter(Collider collision)
{
    // Controlliamo se il player ha toccato il collider
    if (collision.gameObject.CompareTag("Player"))
    {Area2.gameObject.SetActive(true); Area1.gameObject.SetActive(false);}
}

/*private void OnTriggerExit(Collider collision)
{
    // Controlliamo se il player ha smesso di collidere con l'oggetto
    if (collision.gameObject.CompareTag("Player"))
    {Area2.gameObject.SetActive(false); Area1.gameObject.SetActive(true);}
}*/
}
