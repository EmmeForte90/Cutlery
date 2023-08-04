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
    //private GameObject player;
    private GameObject FAct;
    private GameObject KAct;
    private GameObject SAct;  
    private CinemachineVirtualCamera vCam;
    public bool needDeactivateObject;
    public GameObject[] objDeactivate;
    public GameObject[] objActivate;

    // Start is called before the first frame update
    void Start()
    {        
        FAct = GameObject.FindWithTag("F_Player");
        SAct = GameObject.FindWithTag("S_Player");
        KAct = GameObject.FindWithTag("K_Player");        
        vCam = GameObject.FindWithTag("MainCamera").GetComponent<CinemachineVirtualCamera>(); //ottieni il riferimento alla virtual camera di Cinemachine
        confiner = GameObject.FindWithTag("MainCamera").GetComponent<CinemachineConfiner>(); //ottieni il riferimento alla virtual camera di Cinemachine
    }

   
    public void OnTriggerEnter(Collider collision)
{
    // Controlliamo se il player ha toccato il collider
    if (collision.gameObject.CompareTag("F_Player")||
    collision.gameObject.CompareTag("K_Player")||
    collision.gameObject.CompareTag("S_Player"))
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
        vCam.Follow = GameManager.instance.player.transform;
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
        GameManager.instance.player.transform.position = PointSpawn.transform.position;
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

