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
    public GameObject FAct;
    public GameObject KAct;
    public GameObject SAct;
    private CinemachineVirtualCamera vCam;
    public bool needDeactivateObject;
    public GameObject[] objDeactivate;
    public GameObject[] objActivate;

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
        {Deactive(); Activate();}
        CharacterMove.instance.isRun = false;
        ModifyConfiner();
        player.transform.position = PointSpawn.transform.position;
        KAct.transform.position = PointSpawn.transform.position;
        FAct.transform.position = PointSpawn.transform.position;
        SAct.transform.position = PointSpawn.transform.position;
        yield return new WaitForSeconds(2f);
        CharacterMove.instance.inputCTR = false; 
        GameManager.instance.FadeOut();
    }


    public void Deactive()
    {
        foreach (GameObject arenaObject in objDeactivate)
        {
            arenaObject.SetActive(false);
        }
    }

    public void Activate()
    {
        foreach (GameObject arenaObject in objActivate)
        {
            arenaObject.SetActive(true);
        }
    }

    
}

