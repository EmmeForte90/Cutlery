using UnityEngine;
using Cinemachine;
public class StartScene : MonoBehaviour
{
    #region Header
    public int WhatMusic;
    [Header("Metti true su Test solo per testare il livello!!!!")]
    public bool Test = false;
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
    public bool needDeactive = false;
    public GameObject[] DeActiveObj;
    public GameObject[] Notte; 
    public Material newSkyboxMaterial_N;
    public GameObject[] Giorno;
    public Material newSkyboxMaterial_G; // Il nuovo materiale Skybox che desideri applicare
    private CinemachineVirtualCamera vCam;
    private int IDPorta;
    private Quaternion defaultRotation;
    public static StartScene instance;
    #endregion
    public void Start()
    {
    if (instance == null){instance = this;}
    //////////////
    if(Test)
    {Instantiate(StartGameOBJ, PStart.transform.position, PStart.transform.rotation);
    if(SaveManager.instance == null){Instantiate(Data, transform.position, transform.rotation);}}
    //////////////
    ContainerHero = GameManager.instance.ContainerHero;
    if(GameManager.instance.F_Unlock){FAct = GameManager.instance.F_Hero;}
    if(GameManager.instance.K_Unlock){KAct = GameManager.instance.K_Hero;}
    if(GameManager.instance.S_Unlock){SAct = GameManager.instance.S_Hero;}
    vCam = GameManager.instance.vcam.GetComponent<CinemachineVirtualCamera>(); //ottieni il riferimento alla virtual camera di Cinemachine
    defaultRotation = transform.rotation;
    if(startMusic)
    {
        AudioManager.instance.CrossFadeINAudio(WhatMusic); 
        //AudioManager.instance.CrossFadeOUTAudio(PlayerStats.instance.WhatMusic);
        //AudioManager.instance.CrossFadeINAudio(WhatMusic); 
        PlayerStats.instance.WhatMusic = WhatMusic;
    }
    /////////////////
    if(PlayerStats.instance.HaveData)
    {
    SpawnB(PlayerStats.instance.IdSpawn); //Spawna nel punto dove hai salvato
    GameManager.instance.NotTouchOption = false;
    PlayerStats.instance.HaveData = false;
    UpdateInventory();
    }
    else if(!PlayerStats.instance.HaveData){IDPorta = GameManager.instance.IDPorta;Spawn(IDPorta);} //Spawna nel punto scelto dopo una transition

    }
    public void UpdateInventory()
    {
        GameManager.instance.money = PlayerStats.instance.Money;
        GameManager.instance.moneyTextM.text = GameManager.instance.money.ToString();
        GameManager.instance.QuM.UpdateInventoryUI();
        GameManager.instance.KM.UpdateInventoryUI();
        GameManager.instance.M_F.UpdateInventoryUI();
        GameManager.instance.M_S.UpdateInventoryUI();
        GameManager.instance.M_K.UpdateInventoryUI();
        //GameManager.instance.InvB.UpdateInventoryUI();
    }

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
    GameManager.instance.FadeOut();
    ContainerHero.transform.position = SpawnArr[ID].transform.position;
    if(GameManager.instance.F_Unlock){FAct.transform.position = ContainerHero.transform.position;}
    if(GameManager.instance.K_Unlock){KAct.transform.position = ContainerHero.transform.position;}
    if(GameManager.instance.S_Unlock){SAct.transform.position = ContainerHero.transform.position;}
    if(ID == 4 ||ID == 3|| ID == 2 || ID == 1 || ID == 0)
    {foreach (GameObject arenaObject in ActiveObj){arenaObject.SetActive(true);} //Confiner(ID);}}
    }}

    public void SpawnB(int ID)
    {
    GameManager.instance.FadeOut();
    foreach (GameObject arenaObject in ActiveObj){arenaObject.SetActive(true);}
    if(needDeactive){foreach (GameObject arenaObject in DeActiveObj){arenaObject.SetActive(false);}}
    vCam.Follow = FAct.transform;
    if(GameManager.instance.F_Unlock){if(!FAct){FAct.SetActive(true);}}
    if(GameManager.instance.K_Unlock){KAct.SetActive(true);}
    if(GameManager.instance.S_Unlock){SAct.SetActive(true);}
    if(GameManager.instance.F_Unlock){FAct.transform.position = PlayerStats.instance.savedPosition;}
    if(GameManager.instance.K_Unlock){KAct.transform.position = PlayerStats.instance.savedPosition;}
    if(GameManager.instance.S_Unlock){SAct.transform.position = PlayerStats.instance.savedPosition;}
    } 
}