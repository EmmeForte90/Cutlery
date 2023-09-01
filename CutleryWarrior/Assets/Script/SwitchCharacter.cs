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
    public bool battle = false;
    [Header("Stats")]
    [Header("Fork")]
    public GameObject Ind_F;
    private ManagerCharacter ForkActive;
    public bool isElement1Active = false;
    [Header("Knife")]
    public GameObject Ind_K;
    private ManagerCharacter KnifeActive;
    public bool isElement2Active = true;
    [Header("Spoon")]
    public GameObject Ind_S;
    private ManagerCharacter SpoonActive;
    public bool isElement3Active = false;
    public static SwitchCharacter instance;
    private CinemachineVirtualCamera vCam;
    private GameObject player;
    public int ConInt;
    public UIRotationSwitcher rotationSwitcher;
    #endregion
    public void Update()
    {if(!GameManager.instance.notChange){if(Input.GetKeyDown(KeyCode.Space)){StartCoroutine(CoordinateActor());}}}
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
        if (KnifeActive.transform.localScale.x > 0f)
        {transform.localScale = new Vector3(1, 1,1);} 
        else if (KnifeActive.transform.localScale.x < 0f)
        {transform.localScale = new Vector3(-1, 1,1);}
        ///
        if (SpoonActive.transform.localScale.x > 0f)
        {transform.localScale = new Vector3(1, 1,1);} 
        else if (SpoonActive.transform.localScale.x < 0f)
        {transform.localScale = new Vector3(-1, 1,1);}
    }
     public void TakeCharacters()
    {
        ForkActive = GameObject.Find("F_Player").GetComponent<ManagerCharacter>();
        SpoonActive = GameObject.Find("S_Player").GetComponent<ManagerCharacter>();
        KnifeActive = GameObject.Find("K_Player").GetComponent<ManagerCharacter>();
        vCam = GameObject.FindWithTag("MainCamera").GetComponent<CinemachineVirtualCamera>(); 
        //ottieni il riferimento alla virtual camera di Cinemachine
        //
        switch(rotationSwitcher.CharacterID)
        {
            case 1:
            ForkActive.SwitchScriptsPlayer(); KnifeActive.SwitchScriptsActor(); SpoonActive.SwitchScriptsActor(); ConInt = 1;
            vCam.Follow = ForkActive.transform;
            break;
            case 2:
            ForkActive.SwitchScriptsActor(); KnifeActive.SwitchScriptsPlayer(); SpoonActive.SwitchScriptsActor(); ConInt = 2;
            vCam.Follow = KnifeActive.transform;
            break;
            case 3:
            ForkActive.SwitchScriptsActor(); KnifeActive.SwitchScriptsActor(); SpoonActive.SwitchScriptsPlayer(); ConInt = 3;
            vCam.Follow = SpoonActive.transform;
            break;
        }
    }
    public void ActiveCH()
    {
        ForkActive.gameObject.SetActive(true);
        KnifeActive.gameObject.SetActive(true);
        SpoonActive.gameObject.SetActive(true);
    }
    IEnumerator CoordinateActor()
    {// Switcha tra gli elementi
    if (isElement1Active)
    {
        ForkActive.SwitchScriptsPlayer();
        KnifeActive.SwitchScriptsActor();
        SpoonActive.SwitchScriptsActor();
        Ind_F.gameObject.SetActive(true); 
        Ind_K.gameObject.SetActive(false); 
        Ind_S.gameObject.SetActive(false);
        rotationSwitcher.CharacterID = 1;
        yield return new WaitForSeconds(0.01f);
        Flip();
        player = GameObject.FindGameObjectWithTag("F_Player");
        AudioManager.instance.PlayUFX(3);
        vCam = GameObject.FindWithTag("MainCamera").GetComponent<CinemachineVirtualCamera>(); 
        vCam.Follow = player.transform;
        //////////////////////////////
        isElement1Active = false;
        isElement2Active = true;
    }
    else if (isElement2Active)
    {   
        ForkActive.SwitchScriptsActor();
        KnifeActive.SwitchScriptsPlayer();
        SpoonActive.SwitchScriptsActor();
        Ind_F.gameObject.SetActive(false); 
        Ind_K.gameObject.SetActive(true); 
        Ind_S.gameObject.SetActive(false); 
        rotationSwitcher.CharacterID = 2;
        yield return new WaitForSeconds(0.01f);
        Flip();
        player = GameObject.FindGameObjectWithTag("K_Player");
        AudioManager.instance.PlayUFX(3);
        vCam = GameObject.FindWithTag("MainCamera").GetComponent<CinemachineVirtualCamera>(); 
        vCam.Follow = player.transform;
        //////////////////////////////
        isElement2Active = false;
        isElement3Active = true;
    }
    else if (isElement3Active)
    {
        ForkActive.SwitchScriptsActor();
        KnifeActive.SwitchScriptsActor();
        SpoonActive.SwitchScriptsPlayer();
        Ind_F.gameObject.SetActive(false); 
        Ind_K.gameObject.SetActive(false); 
        Ind_S.gameObject.SetActive(true);
        rotationSwitcher.CharacterID = 3;
        yield return new WaitForSeconds(0.01f);
        Flip();
        player = GameObject.FindGameObjectWithTag("S_Player");
        AudioManager.instance.PlayUFX(3);
        vCam = GameObject.FindWithTag("MainCamera").GetComponent<CinemachineVirtualCamera>(); 
        vCam.Follow = player.transform;
        //////////////////////////////
        isElement3Active = false;
        isElement1Active = true;
    }
    }
#endregion
}