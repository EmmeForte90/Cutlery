using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using Cinemachine;
public class SwitchCharacter : MonoBehaviour
{
    #region Header
    //public bool battle = false;
    [Header("Stats")]
    [Header("Fork")]
    public GameObject Ind_F;
    public ManagerCharacter ForkActive;
    public bool isElement1Active = false;
    [Header("Knife")]
    public GameObject Ind_K;
    public ManagerCharacter KnifeActive;
    public bool isElement2Active = true;
    [Header("Spoon")]
    public GameObject Ind_S;
    public ManagerCharacter SpoonActive;
    public bool isElement3Active = false;
    public static SwitchCharacter instance;
    public CinemachineVirtualCamera vCam;
    private GameObject player;
    public int ConInt;
    public UIRotationSwitcher rotationSwitcher;
    #endregion
    public void Update()
    {if(!GameManager.instance.notChange)
    {if(Input.GetKeyDown(KeyCode.Space)){StartCoroutine(CoordinateActor()); ind();}}}
    public void Start(){TakeCharacters();}
    public void Awake(){if (instance == null){instance = this;} ConInt = 1;}
    public void Take(){StartCoroutine(CoordinateActor());}

    #region ChangeCharacter
    
    public void Flip()
    {
        if (ForkActive.transform.localScale.x > 0f)
        {transform.localScale = new Vector3(1, 1,1);} 
        else if (ForkActive.transform.localScale.x < 0f)
        {transform.localScale = new Vector3(-1, 1,1);}  
        ///
        if(GameManager.instance.K_Unlock){
        if (KnifeActive.transform.localScale.x > 0f)
        {transform.localScale = new Vector3(1, 1,1);} 
        else if (KnifeActive.transform.localScale.x < 0f)
        {transform.localScale = new Vector3(-1, 1,1);}}
        ///
        if(GameManager.instance.S_Unlock){
        if (SpoonActive.transform.localScale.x > 0f)
        {transform.localScale = new Vector3(1, 1,1);} 
        else if (SpoonActive.transform.localScale.x < 0f)
        {transform.localScale = new Vector3(-1, 1,1);}}
    }
     public void TakeCharacters()
    {
        //if(GameManager.instance.F_Unlock){ForkActive = GameObject.Find("F_Player").GetComponent<ManagerCharacter>();}
        //if(GameManager.instance.S_Unlock){SpoonActive = GameObject.Find("S_Player").GetComponent<ManagerCharacter>();}
        //if(GameManager.instance.K_Unlock){KnifeActive = GameObject.Find("K_Player").GetComponent<ManagerCharacter>();}
        //vCam = GameObject.FindWithTag("MainCamera").GetComponent<CinemachineVirtualCamera>(); 
        //ottieni il riferimento alla virtual camera di Cinemachine
        //
        switch(rotationSwitcher.CharacterID)
        {
            case 1:
            if(GameManager.instance.F_Unlock){ForkActive.SwitchScriptsPlayer();} 
            if(GameManager.instance.K_Unlock){KnifeActive.SwitchScriptsActor();} 
            if(GameManager.instance.S_Unlock){SpoonActive.SwitchScriptsActor();} 
            //
            if(GameManager.instance.F_Unlock){vCam.Follow = ForkActive.transform; ConInt = 1;}
            break;
            case 2:
            if(GameManager.instance.F_Unlock){ForkActive.SwitchScriptsActor();}
            if(GameManager.instance.K_Unlock){KnifeActive.SwitchScriptsPlayer();}
            if(GameManager.instance.S_Unlock){SpoonActive.SwitchScriptsActor();}
            //
            if(GameManager.instance.K_Unlock){vCam.Follow = KnifeActive.transform;ConInt = 2;}
            break;
            case 3:
            if(GameManager.instance.F_Unlock){ForkActive.SwitchScriptsActor();}
            if(GameManager.instance.K_Unlock){KnifeActive.SwitchScriptsActor();}
            if(GameManager.instance.S_Unlock){SpoonActive.SwitchScriptsPlayer();}
            //
            if(GameManager.instance.S_Unlock){vCam.Follow = SpoonActive.transform;ConInt = 3;}
            break;
        }
    }
    public void ActiveCH()
    {
        if(GameManager.instance.F_Unlock){ForkActive.gameObject.SetActive(true);}
        if(GameManager.instance.K_Unlock){KnifeActive.gameObject.SetActive(true);}
        if(GameManager.instance.S_Unlock){SpoonActive.gameObject.SetActive(true);}
    }
    
    public void ind()
    {// Switcha tra gli elementi
    if (isElement1Active)
    {
        if(GameManager.instance.F_Unlock){Ind_F.gameObject.SetActive(true);} 
    }
    else if (isElement2Active)
    {   
        if(GameManager.instance.K_Unlock){Ind_K.gameObject.SetActive(true);}
    }
    else if (isElement3Active)
    {
        if(GameManager.instance.S_Unlock){Ind_S.gameObject.SetActive(true);}
    }
    }
    
    IEnumerator CoordinateActor()
    {// Switcha tra gli elementi
    if (isElement1Active)
    {
        if(GameManager.instance.F_Unlock){
        if(GameManager.instance.F_Unlock){ForkActive.SwitchScriptsPlayer();Ind_F.gameObject.SetActive(true);}
        if(GameManager.instance.K_Unlock){KnifeActive.SwitchScriptsActor();Ind_K.gameObject.SetActive(false);}
        if(GameManager.instance.S_Unlock){SpoonActive.SwitchScriptsActor();Ind_S.gameObject.SetActive(false);}
        rotationSwitcher.CharacterID = 1;
        rotationSwitcher.CharacterIDSec = 3;
        rotationSwitcher.CharacterIDTer = 2;
        yield return new WaitForSeconds(0.01f);
        Flip();
        player = GameObject.FindGameObjectWithTag("F_Player");
        AudioManager.instance.PlayUFX(3);
        vCam = GameObject.FindWithTag("MainCamera").GetComponent<CinemachineVirtualCamera>(); 
        vCam.Follow = player.transform;
        }
        //////////////////////////////
        if(GameManager.instance.K_Unlock){isElement1Active = false;isElement2Active = true;}
        else if(!GameManager.instance.K_Unlock){isElement1Active = false;isElement3Active = true;}
        else if(!GameManager.instance.S_Unlock){isElement1Active = false;isElement2Active = true;}
        else if(!GameManager.instance.S_Unlock && !GameManager.instance.K_Unlock){isElement1Active = true;}
    }
    else if (isElement2Active)
    {   
        if(GameManager.instance.K_Unlock){
        if(GameManager.instance.F_Unlock){ForkActive.SwitchScriptsActor(); Ind_F.gameObject.SetActive(false);}
        if(GameManager.instance.K_Unlock){KnifeActive.SwitchScriptsPlayer(); Ind_K.gameObject.SetActive(true);}
        if(GameManager.instance.S_Unlock){SpoonActive.SwitchScriptsActor();Ind_S.gameObject.SetActive(false);}
        rotationSwitcher.CharacterID = 2;
        rotationSwitcher.CharacterIDSec = 1;
        rotationSwitcher.CharacterIDTer = 3;
        yield return new WaitForSeconds(0.01f);
        Flip();
        player = GameObject.FindGameObjectWithTag("K_Player");
        AudioManager.instance.PlayUFX(3);
        vCam = GameObject.FindWithTag("MainCamera").GetComponent<CinemachineVirtualCamera>(); 
        vCam.Follow = player.transform;
        }
        //////////////////////////////
        if(GameManager.instance.S_Unlock){isElement2Active = false;isElement3Active = true;}
        else if(!GameManager.instance.S_Unlock){isElement2Active = false;isElement1Active = true;}
    }
    else if (isElement3Active)
    {   
        if(GameManager.instance.S_Unlock){
        if(GameManager.instance.F_Unlock){ForkActive.SwitchScriptsActor();Ind_F.gameObject.SetActive(false);}
        if(GameManager.instance.K_Unlock){KnifeActive.SwitchScriptsActor();Ind_K.gameObject.SetActive(false);}
        if(GameManager.instance.S_Unlock){SpoonActive.SwitchScriptsPlayer();Ind_S.gameObject.SetActive(true);}
        rotationSwitcher.CharacterID = 3;
        rotationSwitcher.CharacterIDSec = 2;
        rotationSwitcher.CharacterIDTer = 1;
        yield return new WaitForSeconds(0.01f);
        Flip();
        player = GameObject.FindGameObjectWithTag("S_Player");
        AudioManager.instance.PlayUFX(3);
        vCam = GameObject.FindWithTag("MainCamera").GetComponent<CinemachineVirtualCamera>(); 
        vCam.Follow = player.transform;
        }
        //////////////////////////////
        if(GameManager.instance.F_Unlock){isElement3Active = false; isElement1Active = true;}
        else if(!GameManager.instance.F_Unlock){isElement3Active = false;isElement2Active = true;}
    }
    }
#endregion
}