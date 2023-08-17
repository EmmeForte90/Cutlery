using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class StartScene : MonoBehaviour
{
    public int WhatMusic;
    private GameObject player;

    private GameObject ContainerHero;

    private GameObject FAct;
    private GameObject KAct;
    private GameObject SAct;    
    public GameObject[] SpawnArr; 

    public Collider[] BoxConfiner;    
    private CinemachineConfiner confiner;
    private CinemachineVirtualCamera vCam;
    private SwitchCharacter Switcher;

    private int IDPorta;
    public static StartScene instance;
    public void Awake()
    {       
    if (instance == null){instance = this;}  
    if(!GameManager.instance.StartGame)
    {   
    FAct = GameObject.FindWithTag("F_Player");
    SAct = GameObject.FindWithTag("S_Player");
    KAct = GameObject.FindWithTag("K_Player");
    vCam = GameObject.FindWithTag("MainCamera").GetComponent<CinemachineVirtualCamera>(); //ottieni il riferimento alla virtual camera di Cinemachine
    confiner = GameObject.FindWithTag("MainCamera").GetComponent<CinemachineConfiner>(); //ottieni il riferimento alla virtual camera di Cinemachine
    IDPorta = GameManager.instance.IDPorta;
    ContainerHero = GameObject.Find("Hero");
    AudioManager.instance.CrossFadeINAudio(WhatMusic);
    Spawn(IDPorta);
    Confiner(IDPorta);
    GameManager.instance.ChCanM();
    Switcher = GameObject.Find("EquipManager").GetComponent<SwitchCharacter>();
    Switcher.inizial();
    CameraZoom.instance.ZoomOut();
    GameManager.instance.FadeOut();
    }}
    public void Spawn(int ID)
    {
    if(!GameManager.instance.battle)
    {ContainerHero.transform.position = SpawnArr[ID].transform.position;
    KAct.transform.position = ContainerHero.transform.position;
    FAct.transform.position = ContainerHero.transform.position;
    SAct.transform.position = ContainerHero.transform.position;
    }else if (GameManager.instance.battle)
    {GameManager.instance.battle = false;
    KAct.transform.position = GameManager.instance.savedPosition;
    FAct.transform.position = GameManager.instance.savedPosition;
    SAct.transform.position = GameManager.instance.savedPosition;
    GameManager.instance.StopWin();
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
