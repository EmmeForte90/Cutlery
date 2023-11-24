using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class StartScene : MonoBehaviour
{
    #region Header
    public int WhatMusic;
    public bool Start = false;
    public bool startMusic = false;
    public GameObject StartGameOBJ;
    public GameObject Data;
    public GameObject PStart;
    private GameObject ContainerHero;
    private GameObject FAct;
    private GameObject KAct;
    private GameObject SAct;    
    public GameObject[] SpawnArr; 
    public GameObject[] ActiveObj; 
    //public GameObject[] ActiveObjAB;
    public GameObject[] Notte; 
    public Material newSkyboxMaterial_N;
    public GameObject[] Giorno;
    public Material newSkyboxMaterial_G; // Il nuovo materiale Skybox che desideri applicare
    public GameObject[] Enemies; 
    private CinemachineConfiner confiner;
    private CinemachineVirtualCamera vCam;
    private SwitchCharacter Switcher;
    private int IDPorta;
    private int ID_Enm;
    public bool Once = true;
    private Quaternion defaultRotation;
    public static StartScene instance;
    #endregion
    public void Awake()
    {
    if (instance == null){instance = this;}
    if(SaveManager.instance != null){Once = false;}
    else  if(SaveManager.instance == null){Once = true;}

    if (Start)
    {if (Once)
    {
    Instantiate(StartGameOBJ, PStart.transform.position, PStart.transform.rotation);
    Instantiate(Data, transform.position, transform.rotation); 
    PlayerStats.instance.StartData = true;
    AudioManager.instance.CrossFadeINAudio(WhatMusic); Once = false;
    }
    else if(!Once)
    {if(SaveManager.instance.Saving)
    {   SaveManager.instance.LoadGame();
        if(GameManager.instance.F_Unlock){FAct = GameManager.instance.F_Hero;}
        if(GameManager.instance.S_Unlock){SAct = GameManager.instance.S_Hero;}
        if(GameManager.instance.K_Unlock){KAct = GameManager.instance.K_Hero;}
        if(GameManager.instance.F_Unlock){FAct.transform.position = PlayerStats.instance.savedPosition;}
        if(GameManager.instance.K_Unlock){KAct.transform.position = PlayerStats.instance.savedPosition;}
        if(GameManager.instance.S_Unlock){SAct.transform.position = PlayerStats.instance.savedPosition;}
    }}
    }
    
    if(startMusic)
    {
        AudioManager.instance.CrossFadeOUTAudio(PlayerStats.instance.WhatMusic);
        AudioManager.instance.CrossFadeINAudio(WhatMusic); 
        PlayerStats.instance.WhatMusic = WhatMusic;
    }
    
    defaultRotation = transform.rotation;
    //
    if(!GameManager.instance.StartGame){
    GameManager.instance.ChStop();
    if(GameManager.instance.F_Unlock){FAct = GameManager.instance.F_Hero;}
    if(GameManager.instance.S_Unlock){SAct = GameManager.instance.S_Hero;}
    if(GameManager.instance.K_Unlock){KAct = GameManager.instance.K_Hero;}
    vCam = GameManager.instance.vcam.GetComponent<CinemachineVirtualCamera>(); //ottieni il riferimento alla virtual camera di Cinemachine
    confiner = GameManager.instance.vcam.GetComponent<CinemachineConfiner>(); //ottieni il riferimento alla virtual camera di Cinemachine
    
    IDPorta = GameManager.instance.IDPorta;
    ID_Enm = GameManager.instance.IdENM;
    ContainerHero = GameObject.Find("Hero");
    if(!GameManager.instance.battle && !PlayerStats.instance.CanLoading){Spawn(IDPorta);}
    else if(GameManager.instance.battle && !PlayerStats.instance.CanLoading){SpawnB(IDPorta);}
    else if(PlayerStats.instance.CanLoading)
    {
    if(GameManager.instance.F_Unlock){FAct.transform.position = PlayerStats.instance.savedPosition;}
    if(GameManager.instance.K_Unlock){KAct.transform.position = PlayerStats.instance.savedPosition;}
    if(GameManager.instance.S_Unlock){SAct.transform.position = PlayerStats.instance.savedPosition;}
    PlayerStats.instance.CanLoading = false;
    }  
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
    GameManager.instance.StopWin();
    }
    IEnumerator BoxDel()
    {yield return new WaitForSeconds(0.5f);
    CameraZoom.instance.ZoomOut();GameManager.instance.FadeOut(); GameManager.instance.ChCanM(); 
    PlayerStats.instance.DeactivateWarning();
    PlayerStats.instance.DeactivateSwitch();
    PlayerStats.instance.DeactivateCHEST();}
    public void EnemiesActive(int ID){Enemies[ID].SetActive(false);}
    /*public void AreaActive(int ID)
    {
            // Disattiva tutti gli oggetti nel tuo array
            for (int i = 0; i < ActiveObjAB.Length; i++){ActiveObjAB[i].SetActive(false);}

            // Calcola l'indice dell'array in base all'ID
            int arrayIndex = ID;

            // Attiva l'oggetto corrispondente
            ActiveObjAB[arrayIndex].SetActive(true);
    }*/
}