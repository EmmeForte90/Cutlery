using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class StartScene : MonoBehaviour
{
    #region Header
    public int WhatMusic;
    public bool StartGame = false;
    public bool Testing = false;
    public GameObject StartGameOBJ;
    public GameObject PStart;
    //private GameObject player;
    private GameObject ContainerHero;
    private GameObject FAct;
    private GameObject KAct;
    private GameObject SAct;    
    public GameObject[] SpawnArr; 
    public GameObject[] ActiveObj; 
    public GameObject[] ActiveObjAB;
    public GameObject[] Notte; 
    public Material newSkyboxMaterial_N;
    public GameObject[] Giorno;
    public Material newSkyboxMaterial_G; // Il nuovo materiale Skybox che desideri applicare
    public GameObject[] Enemies; 
    //public Collider[] BoxConfiner;    
    private CinemachineConfiner confiner;
    private CinemachineVirtualCamera vCam;
    //public Collider bCStart;
    private SwitchCharacter Switcher;
    private int IDPorta;
    private int ID_Enm;
    private Quaternion defaultRotation;
    public static StartScene instance;
    #endregion
    public void Awake()
    {
    if (instance == null){instance = this;}
    if (StartGame)
    {
    Instantiate(StartGameOBJ, PStart.transform.position, PStart.transform.rotation);
    //confiner = GameObject.FindWithTag("MainCamera").GetComponent<CinemachineConfiner>(); //ottieni il riferimento alla virtual camera di Cinemachine
    //confiner.m_BoundingVolume = bCStart;       
    AudioManager.instance.CrossFadeINAudio(WhatMusic);
    }  
    defaultRotation = transform.rotation;
    //
    if(!GameManager.instance.StartGame){
    GameManager.instance.ChStop();
    FAct = GameObject.FindWithTag("F_Player");
    if(GameManager.instance.S_Unlock){SAct = GameObject.FindWithTag("S_Player");}
    if(GameManager.instance.K_Unlock){KAct = GameObject.FindWithTag("K_Player");}
    vCam = GameObject.FindWithTag("MainCamera").GetComponent<CinemachineVirtualCamera>(); //ottieni il riferimento alla virtual camera di Cinemachine
    confiner = GameObject.FindWithTag("MainCamera").GetComponent<CinemachineConfiner>(); //ottieni il riferimento alla virtual camera di Cinemachine
    IDPorta = GameManager.instance.IDPorta;
    ID_Enm = GameManager.instance.IdENM;
    ContainerHero = GameObject.Find("Hero");
    if(!GameManager.instance.battle){Spawn(IDPorta);}
    else if(GameManager.instance.battle){SpawnB(IDPorta);}
    //if (!Testing){ Confiner(IDPorta);}
    //PlayerStats.instance.DeactivateENM();
    Inventory.instance.DeactivateItem();
    Switcher = GameObject.Find("EquipManager").GetComponent<SwitchCharacter>();
    Switcher.TakeCharacters();
    StartCoroutine(BoxDel());
    }}
    public void Update()
    {
        if(!GameManager.instance.Day)
        {foreach (GameObject arenaObject in Giorno){arenaObject.SetActive(false);}
        foreach (GameObject arenaObjectN in Notte){arenaObjectN.SetActive(true);}
        RenderSettings.skybox = newSkyboxMaterial_N;}
        else if(GameManager.instance.Day)
        {foreach (GameObject arenaObject in Giorno){arenaObject.SetActive(true);}
        foreach (GameObject arenaObjectN in Notte){arenaObjectN.SetActive(false);}
        RenderSettings.skybox = newSkyboxMaterial_G;}
    }

    public void Spawn(int ID)
    {
    ContainerHero.transform.position = SpawnArr[ID].transform.position;
    
    if(GameManager.instance.F_Unlock){FAct.transform.position = ContainerHero.transform.position;}
    if(GameManager.instance.K_Unlock){KAct.transform.position = ContainerHero.transform.position;}
    if(GameManager.instance.S_Unlock){SAct.transform.position = ContainerHero.transform.position;}
    if(ID == 4 ||ID == 3|| ID == 2 || ID == 1 || ID == 0)
    {foreach (GameObject arenaObject in ActiveObj){arenaObject.SetActive(true);} //Confiner(ID);}}
    }}
    public void SpawnB(int ID)
    {
    GameManager.instance.battle = false;
    if(GameManager.instance.F_Unlock){FAct.transform.position = GameManager.instance.savedPosition;}
    if(GameManager.instance.K_Unlock){KAct.transform.position = GameManager.instance.savedPosition;}
    if(GameManager.instance.S_Unlock){SAct.transform.position = GameManager.instance.savedPosition;}
    EnemiesActive(ID_Enm);
    if (!Testing){AreaActive(GameManager.instance.IdAreaAtt);}
    GameManager.instance.StopWin();
    }
    IEnumerator BoxDel()
    {yield return new WaitForSeconds(0.5f);
    CameraZoom.instance.ZoomOut();GameManager.instance.FadeOut(); GameManager.instance.ChCanM();}
    public void EnemiesActive(int ID){Enemies[ID].SetActive(false);}
    public void AreaActive(int ID)
    {
            // Disattiva tutti gli oggetti nel tuo array
            for (int i = 0; i < ActiveObjAB.Length; i++)
            {
                ActiveObjAB[i].SetActive(false);
            }

            // Calcola l'indice dell'array in base all'ID
            int arrayIndex = ID;

            // Attiva l'oggetto corrispondente
            ActiveObjAB[arrayIndex].SetActive(true);

            // Chiama la funzione Confiner con l'ID + 5
            //Confiner(ID);
        
    }

    /*public void Confiner(int ID)
    {
        confiner.m_BoundingVolume  = null; 
        confiner.m_BoundingVolume  = BoxConfiner[ID];       
        switch(GameManager.instance.IDCharacter)
        {
            case 1:
            vCam.Follow = FAct.transform;
            break;
            case 2:
            vCam.Follow = KAct.transform;
            break;
            case 3:
            vCam.Follow = SAct.transform;
            break;
        }  
    }*/
}