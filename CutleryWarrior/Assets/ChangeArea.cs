using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using Cinemachine;



public class ChangeArea : MonoBehaviour
{
    //public GameObject Activator;
    public GameObject PointSpawn;
    private CinemachineConfiner confiner;
    public Collider NewConfiner;
    private GameObject player;
    private CinemachineVirtualCamera vCam;
    public bool needDeactivateObject;
    public GameObject objDeactivate;
    public GameObject objActivate;

    // Start is called before the first frame update
    void Start()
    {        
        player = GameObject.FindGameObjectWithTag("Player");
        vCam = GameObject.FindWithTag("MainCamera").GetComponent<CinemachineVirtualCamera>(); //ottieni il riferimento alla virtual camera di Cinemachine
        confiner = GameObject.FindWithTag("MainCamera").GetComponent<CinemachineConfiner>(); //ottieni il riferimento alla virtual camera di Cinemachine
    }

   
    private void OnTriggerEnter(Collider collision)
{
    // Controlliamo se il player ha toccato il collider
    if (collision.gameObject.CompareTag("Player"))
    {
        StartCoroutine(ChangeAreaF());
    }
}

    public void ModifyConfiner()
    {
        // Svuota la variabile boundingVolume
        confiner.m_BoundingVolume  = null; 
        // Assegna un nuovo boundingVolume
        confiner.m_BoundingVolume  = NewConfiner;       
        vCam.Follow = player.transform;
    }

    IEnumerator ChangeAreaF()
    {
        CharacterMove.instance.inputCTR = true;
        CharacterMove.instance.Idle();
        GameManager.instance.FadeIn();
        yield return new WaitForSeconds(2f);
        if(needDeactivateObject)
        {objDeactivate.gameObject.SetActive(false); objActivate.gameObject.SetActive(true);}
        CharacterMove.instance.isRun = false;
        ModifyConfiner();
        player.transform.position = PointSpawn.transform.position;
        GameManager.instance.FadeOut();
        yield return new WaitForSeconds(2f);
        CharacterMove.instance.inputCTR = false; 
    }
}

