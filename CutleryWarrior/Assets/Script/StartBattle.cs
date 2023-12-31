using System.Collections;
using UnityEngine;
using Cinemachine;

public class StartBattle : MonoBehaviour
{
    #region Header
    [Header("Tutorial")]
    public bool isTutorial = false; 
    public GameObject ActiveTutorial; 
    [Header("Battle direction")]
    public bool isRight = true; 
    /*public GameObject Notte; 
    public Material newSkyboxMaterial_N;
    public GameObject Giorno;
    public Material newSkyboxMaterial_G;*/
    public GameObject PointView; // Variabile per il player
    public static StartBattle instance;
    //private SwitchCharacter Switch;
    private CinemachineVirtualCamera vCam;
    private GameObject player;
    
    [Header("Stats")]
    [Header("Fork")]
    public GameObject ForkHUD;
    private GameObject ForkActive;
    private CharacterMove F_Script;
    public GameObject F_point; // Variabile per il player
    private ChangeHeroSkin Skin_F;
    [SerializeField] CharacterFollow ch_FAc;

    [Header("Spoon")]
    public GameObject SpoonHUD;
    private GameObject SpoonActive;
    private CharacterMove S_Script;
    public GameObject S_point; // Variabile per il player
    [SerializeField] CharacterFollow ch_SAc;
    private ChangeHeroSkin Skin_S;
    [Header("Knife")]
    public GameObject KnifeHUD;
    private GameObject KnifeActive;
    private CharacterMove K_Script;
    public GameObject K_point; // Variabile per il player
    [SerializeField] CharacterFollow ch_KAc;
    private ChangeHeroSkin Skin_K;
    [Header("Enemy")]
    public DuelManager Duel_Script;
    #endregion
    public void Start()
    {
        if (instance == null){instance = this;}
        //if (Switch == null) {Switch = GameObject.Find("EquipManager").GetComponent<SwitchCharacter>();}
        vCam = GameManager.instance.vcam.GetComponent<CinemachineVirtualCamera>();
        vCam.Follow = PointView.transform;
        /*if(!GameManager.instance.Day){Giorno.SetActive(false); Notte.SetActive(true); RenderSettings.skybox = newSkyboxMaterial_N;}
        else if(GameManager.instance.Day){Giorno.SetActive(true); Notte.SetActive(false); RenderSettings.skybox = newSkyboxMaterial_G;}
        */
        GameManager.instance.inputCTRbattle = true;
        //
        GameManager.instance.NotTouchOption = true;
        //
        GameManager.instance.battle = true;
        GameManager.instance.ChStop();
        GameManager.instance.TakeCamera();
        GameManager.instance.DectiveMinimap();
        /*GameManager.instance.Inv.itemList = GameManager.instance.InvB.itemList;
        GameManager.instance.Inv.quantityList = GameManager.instance.InvB.quantityList;
        GameManager.instance.InvB.UpdateInventoryUI();*/
        GameManager.instance.Inv.UpdateInventoryUIB();
        //
        if(GameManager.instance.F_Unlock)
        {F_Script = GameManager.instance.F_Hero.GetComponent<CharacterMove>(); ForkHUD.SetActive(true);}
        else{ForkHUD.SetActive(false);}
        if(GameManager.instance.K_Unlock)
        {K_Script = GameManager.instance.K_Hero.GetComponent<CharacterMove>(); KnifeHUD.SetActive(true);}
        else{KnifeHUD.SetActive(false);}
        if(GameManager.instance.S_Unlock)
        {S_Script = GameManager.instance.S_Hero.GetComponent<CharacterMove>(); SpoonHUD.SetActive(true);}
        else{SpoonHUD.SetActive(false);}
        //
        if(GameManager.instance.F_Unlock){Skin_F = GameManager.instance.F_Hero.GetComponent<ChangeHeroSkin>();}
        if(GameManager.instance.K_Unlock){Skin_K = GameManager.instance.K_Hero.GetComponent<ChangeHeroSkin>();}
        if(GameManager.instance.S_Unlock){Skin_S = GameManager.instance.S_Hero.GetComponent<ChangeHeroSkin>();}
        GameManager.instance.Battle();
        //
        /*if(GameManager.instance.F_Unlock){Skin_F.UpdateCharacterSkin();}
		if(GameManager.instance.F_Unlock){Skin_F.UpdateCombinedSkin();}
        //
        if(GameManager.instance.S_Unlock){Skin_S.UpdateCharacterSkin();}
		if(GameManager.instance.S_Unlock){Skin_S.UpdateCombinedSkin();}
        //
        if(GameManager.instance.K_Unlock){Skin_K.UpdateCharacterSkin();}
		if(GameManager.instance.K_Unlock){Skin_K.UpdateCombinedSkin(); }*/
        GameManager.instance.Posebattle();
        //
        if(GameManager.instance.F_Unlock){ForkActive = GameManager.instance.F_Hero;}
        if(GameManager.instance.S_Unlock){SpoonActive = GameManager.instance.S_Hero;}
        if(GameManager.instance.K_Unlock){KnifeActive = GameManager.instance.K_Hero;}
        CameraZoom.instance.ZoomOut();

        if(GameManager.instance.F_Unlock){ForkActive.transform.position = F_point.transform.position;}
        if(GameManager.instance.K_Unlock){KnifeActive.transform.position = K_point.transform.position;}
        if(GameManager.instance.S_Unlock){SpoonActive.transform.position = S_point.transform.position;}
        ////////////////////////
        if(GameManager.instance.S_Unlock){ch_SAc = GameManager.instance.S_Hero.GetComponent<CharacterFollow>();}
        if(GameManager.instance.F_Unlock){ch_FAc = GameManager.instance.F_Hero.GetComponent<CharacterFollow>();}
        if(GameManager.instance.K_Unlock){ch_KAc = GameManager.instance.K_Hero.GetComponent<CharacterFollow>();}
        //
        if(GameManager.instance.F_Unlock){ForkActive = GameManager.instance.F_Hero;}
        if(GameManager.instance.S_Unlock){SpoonActive = GameManager.instance.S_Hero;}
        if(GameManager.instance.K_Unlock){KnifeActive = GameManager.instance.K_Hero;}
        //
        if(GameManager.instance.F_Unlock){PlayerStats.instance.F_curRage = 0;}       
        if(GameManager.instance.S_Unlock){PlayerStats.instance.S_curRage = 0;}
        if(GameManager.instance.K_Unlock){PlayerStats.instance.K_curRage = 0;}
        if(isRight){
        if(GameManager.instance.F_Unlock){ForkActive.transform.localScale = new Vector3(1, 1,1);}
        if(GameManager.instance.K_Unlock){KnifeActive.transform.localScale = new Vector3(1, 1,1);}
        if(GameManager.instance.S_Unlock){SpoonActive.transform.localScale = new Vector3(1, 1,1);}
        if(GameManager.instance.S_Unlock){ch_SAc.transform.localScale = new Vector3(1, 1,1);}
        if(GameManager.instance.F_Unlock){ch_FAc.transform.localScale = new Vector3(1, 1,1);}
        if(GameManager.instance.K_Unlock){ch_KAc.transform.localScale = new Vector3(1, 1,1);}
        }
        else if(!isRight){
        if(GameManager.instance.F_Unlock){ForkActive.transform.localScale = new Vector3(-1, 1,1);}
        if(GameManager.instance.K_Unlock){KnifeActive.transform.localScale = new Vector3(-1, 1,1);}
        if(GameManager.instance.S_Unlock){SpoonActive.transform.localScale = new Vector3(-1, 1,1);}
        if(GameManager.instance.S_Unlock){ch_SAc.transform.localScale = new Vector3(-1, 1,1);}
        if(GameManager.instance.F_Unlock){ch_FAc.transform.localScale = new Vector3(-1, 1,1);}
        if(GameManager.instance.K_Unlock){ch_KAc.transform.localScale = new Vector3(-1, 1,1);}
        }
        ////////////////////////
        if(!isTutorial){StartCoroutine(DuringInter());}
        else if(isTutorial){StartCoroutine(StartTutorial());}
    }
   
    IEnumerator StartTutorial()
    {vCam.Follow = PointView.transform;
    yield return new WaitForSeconds(2f);
    ActiveTutorial.SetActive(true); 
    GameManager.instance.FadeOut();}
    IEnumerator DuringInter()
    {
        GameManager.instance.FadeOut();
        GameManager.instance.StopAllarm();
        GameManager.instance.Posebattle();
        yield return new WaitForSeconds(2f);
        GameManager.instance.ChCanM();
        vCam = GameManager.instance.vcam.GetComponent<CinemachineVirtualCamera>();
        switch(GameManager.instance.CharacterID)
        {
            case 1:
            if(GameManager.instance.F_Unlock){player = GameManager.instance.F_Hero;}
            vCam.Follow = player.transform;
            break;
            case 2:
             if(GameManager.instance.K_Unlock){player = GameManager.instance.K_Hero;}  
            vCam.Follow = player.transform;
            break;
            case 3:
            if(GameManager.instance.S_Unlock){player = GameManager.instance.S_Hero;}
            vCam.Follow = player.transform;
            break;
        }
        GameManager.instance.Change();
        GameManager.instance.ChCanM();
        GameManager.instance.NotTouchOption = false;
        GameManager.instance.inputCTRbattle = false;
        GameManager.instance.ComandBattle = true;
    }

    public void AfterTutorial()
    {
        GameManager.instance.StopAllarm();
        GameManager.instance.Posebattle();
        GameManager.instance.ChCanM();
        vCam = GameManager.instance.vcam.GetComponent<CinemachineVirtualCamera>();
        switch(GameManager.instance.CharacterID)
        {
            case 1:
            if(GameManager.instance.F_Unlock){player = GameManager.instance.F_Hero;}
            vCam.Follow = player.transform;
            break;
            case 2:
             if(GameManager.instance.K_Unlock){player = GameManager.instance.K_Hero;}  
            vCam.Follow = player.transform;
            break;
            case 3:
            if(GameManager.instance.S_Unlock){player = GameManager.instance.S_Hero;}
            vCam.Follow = player.transform;
            break;
        }
        GameManager.instance.Change();
        GameManager.instance.ChCanM();
        GameManager.instance.NotTouchOption = false;
        GameManager.instance.inputCTRbattle = false;
        GameManager.instance.ComandBattle = true;
    }
}