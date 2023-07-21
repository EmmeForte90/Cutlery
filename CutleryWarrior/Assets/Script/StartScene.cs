using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class StartScene : MonoBehaviour
{
    private GameObject player;

    public GameObject ContainerHero;

    //public GameObject FAct;
    //public GameObject KAct;
    //public GameObject SAct;    
    public GameObject[] SpawnArr; 
    public Collider[] BoxConfiner;    
    private CinemachineConfiner confiner;
    private CinemachineVirtualCamera vCam;

    private int IDPorta;
public static StartScene instance;
void Awake()
{        
    if (instance == null){instance = this;}   
    if(!GameManager.instance.StartGame){   
    player = GameObject.FindWithTag("Player");
    vCam = GameObject.FindWithTag("MainCamera").GetComponent<CinemachineVirtualCamera>(); //ottieni il riferimento alla virtual camera di Cinemachine
    confiner = GameObject.FindWithTag("MainCamera").GetComponent<CinemachineConfiner>(); //ottieni il riferimento alla virtual camera di Cinemachine
    IDPorta = GameManager.instance.IDPorta;
    Spawn(IDPorta);
    Confiner(IDPorta);
    CharacterMove.instance.inputCTR = false; 
    GameManager.instance.FadeOut();}
}
   
    public void Spawn(int ID)
    {
    //player.transform.position = SpawnArr[ID].transform.position;
    ContainerHero.transform.position = SpawnArr[ID].transform.position;
        //KAct.transform.position = SpawnArr[ID].transform.position;
       // FAct.transform.position = SpawnArr[ID].transform.position;
        //SAct.transform.position = SpawnArr[ID].transform.position;    
    }

    public void Confiner(int ID)
    {
        confiner.m_BoundingVolume  = null; 
        confiner.m_BoundingVolume  = BoxConfiner[ID];       
        vCam.Follow = player.transform;  
    }
   
}
