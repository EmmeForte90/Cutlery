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
    private GameObject player;
    private GameObject ContainerHero;
    private GameObject FAct;
    private GameObject KAct;
    private GameObject SAct;    
    public GameObject[] SpawnArr; 
    public GameObject[] ActiveObj; 
    public GameObject[] ActiveObjAB;
    public GameObject[] Enemies; 
    public Collider[] BoxConfiner;    
    private CinemachineConfiner confiner;
    private CinemachineVirtualCamera vCam;
    public Collider bCStart;
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
    confiner = GameObject.FindWithTag("MainCamera").GetComponent<CinemachineConfiner>(); //ottieni il riferimento alla virtual camera di Cinemachine
    confiner.m_BoundingVolume = bCStart;       
    AudioManager.instance.CrossFadeINAudio(WhatMusic);
    }  
    defaultRotation = transform.rotation;
    //
    if(!GameManager.instance.StartGame){
    GameManager.instance.ChStop();
    FAct = GameObject.FindWithTag("F_Player");
    SAct = GameObject.FindWithTag("S_Player");
    KAct = GameObject.FindWithTag("K_Player");
    vCam = GameObject.FindWithTag("MainCamera").GetComponent<CinemachineVirtualCamera>(); //ottieni il riferimento alla virtual camera di Cinemachine
    confiner = GameObject.FindWithTag("MainCamera").GetComponent<CinemachineConfiner>(); //ottieni il riferimento alla virtual camera di Cinemachine
    IDPorta = GameManager.instance.IDPorta;
    ID_Enm = GameManager.instance.IdENM;
    ContainerHero = GameObject.Find("Hero");
    if(!GameManager.instance.battle){Spawn(IDPorta);}
    else if(GameManager.instance.battle){SpawnB(IDPorta);}
    if (!Testing){ Confiner(IDPorta);}
    PlayerStats.instance.DeactivateENM();
    Inventory.instance.DeactivateItem();
    Switcher = GameObject.Find("EquipManager").GetComponent<SwitchCharacter>();
    Switcher.TakeCharacters();
    StartCoroutine(BoxDel());
    }}
    public void Spawn(int ID)
    {
    ContainerHero.transform.position = SpawnArr[ID].transform.position;
    KAct.transform.position = ContainerHero.transform.position;
    FAct.transform.position = ContainerHero.transform.position;
    SAct.transform.position = ContainerHero.transform.position;
    if(ID == 4 ||ID == 3|| ID == 2 || ID == 1 || ID == 0){foreach (GameObject arenaObject in ActiveObj){arenaObject.SetActive(true); Confiner(ID);}}
    }
    public void SpawnB(int ID)
    {
    GameManager.instance.battle = false;
    KAct.transform.position = GameManager.instance.savedPosition;
    FAct.transform.position = GameManager.instance.savedPosition;
    SAct.transform.position = GameManager.instance.savedPosition;
    EnemiesActive(ID_Enm);
    if (!Testing){AreaActive(ID);}
    GameManager.instance.StopWin();
    }

    
    IEnumerator BoxDel()
    {yield return new WaitForSeconds(0.5f);
    CameraZoom.instance.ZoomOut();GameManager.instance.FadeOut(); GameManager.instance.ChCanM();}
    public void EnemiesActive(int ID){Enemies[ID].SetActive(false);}
  public void AreaActive(int ID)
    {     
        switch(ID)
        {
            case 90:
            ActiveObjAB[0].SetActive(true);
            ActiveObjAB[1].SetActive(false);
            ActiveObjAB[2].SetActive(false);
            ActiveObjAB[3].SetActive(false);
            ActiveObjAB[4].SetActive(false);
            ActiveObjAB[5].SetActive(false);
            Confiner(6);
            break;
            case 91:
            ActiveObjAB[0].SetActive(false);
            ActiveObjAB[1].SetActive(true);
            ActiveObjAB[2].SetActive(false);
            ActiveObjAB[3].SetActive(false);
            ActiveObjAB[4].SetActive(false);
            ActiveObjAB[5].SetActive(false);
            Confiner(7);
            break;
            case 92:
            ActiveObjAB[0].SetActive(false);
            ActiveObjAB[1].SetActive(false);
            ActiveObjAB[2].SetActive(true);
            ActiveObjAB[3].SetActive(false);
            ActiveObjAB[4].SetActive(false);
            ActiveObjAB[5].SetActive(false);
            Confiner(8);
            break;
            case 93:
            ActiveObjAB[0].SetActive(false);
            ActiveObjAB[1].SetActive(false);
            ActiveObjAB[2].SetActive(false);
            ActiveObjAB[3].SetActive(true);
            ActiveObjAB[4].SetActive(false);
            ActiveObjAB[5].SetActive(false);
            Confiner(9);
            break;
            case 94:
            ActiveObjAB[0].SetActive(false);
            ActiveObjAB[1].SetActive(false);
            ActiveObjAB[2].SetActive(false);
            ActiveObjAB[3].SetActive(false);
            ActiveObjAB[4].SetActive(true);
            ActiveObjAB[5].SetActive(false);
            Confiner(10);
            break;
            case 95:
            ActiveObjAB[0].SetActive(false);
            ActiveObjAB[1].SetActive(false);
            ActiveObjAB[2].SetActive(false);
            ActiveObjAB[3].SetActive(false);
            ActiveObjAB[4].SetActive(false);
            ActiveObjAB[5].SetActive(true);
            Confiner(11);
            break;
        }  
    }
    public void Confiner(int ID)
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
    }
}