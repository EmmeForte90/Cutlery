using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using Cinemachine;

public class SwitchCharacter : MonoBehaviour
{
    public bool battle = false;

 [Header("Stats")]

    [Header("Fork")]

    public GameObject ForkActive;
    public GameObject ForckActor;

    [Header("Spoon")]

    public GameObject SpoonActive;
    public GameObject SpoonActor;

 [Header("Knife")]

    public GameObject KnifeActive;
    public GameObject KnifeActor;

    public static SwitchCharacter instance;
    public bool isElement1Active = false;
    public bool isElement2Active = true;
    public bool isElement3Active = false;
    private CinemachineVirtualCamera vCam;
    private GameObject player;
    public UIRotationSwitcher rotationSwitcher;
void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //SwitchElement();
            StartCoroutine(CoordinateActor());
            
        }    
    }
    
private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if(!battle)
        {vCam = GameObject.FindWithTag("MainCamera").GetComponent<CinemachineVirtualCamera>(); //ottieni il riferimento alla virtual camera di Cinemachine
        vCam.Follow = ForkActive.transform;}
        //TakeCharacters();
        ForkActive = GameObject.Find("F_Player");
        ForckActor = GameObject.Find("F_Actor");
        SpoonActive = GameObject.Find("S_Player");
        SpoonActor = GameObject.Find("S_Actor");
        KnifeActive = GameObject.Find("K_Player");
        KnifeActor = GameObject.Find("K_Actor");
        //
        ForckActor.gameObject.SetActive(false);
        ForkActive.gameObject.SetActive(true);
        KnifeActive.gameObject.SetActive(false);
        KnifeActor.gameObject.SetActive(true);
        SpoonActive.gameObject.SetActive(false);
        SpoonActor.gameObject.SetActive(true);
    }

    #region ChangeCharacter

public void Flip()
    {
        if (ForkActive.transform.localScale.x > 0f)
        {transform.localScale = new Vector3(1, 1,1);} 
        else if (ForkActive.transform.localScale.x < 0f)
        {transform.localScale = new Vector3(-1, 1,1);}
        if (ForckActor.transform.localScale.x > 0f)
        {transform.localScale = new Vector3(1, 1,1);} 
        else if (ForckActor.transform.localScale.x < 0f)
        {transform.localScale = new Vector3(-1, 1,1);}
        ///
        if (KnifeActive.transform.localScale.x > 0f)
        {transform.localScale = new Vector3(1, 1,1);} 
        else if (KnifeActive.transform.localScale.x < 0f)
        {transform.localScale = new Vector3(-1, 1,1);}
        if (KnifeActor.transform.localScale.x > 0f)
        {transform.localScale = new Vector3(1, 1,1);} 
        else if (KnifeActor.transform.localScale.x < 0f)
        {transform.localScale = new Vector3(-1, 1,1);}
        ///
        if (SpoonActive.transform.localScale.x > 0f)
        {transform.localScale = new Vector3(1, 1,1);} 
        else if (SpoonActive.transform.localScale.x < 0f)
        {transform.localScale = new Vector3(-1, 1,1);}
        if (SpoonActor.transform.localScale.x > 0f)
        {transform.localScale = new Vector3(1, 1,1);} 
        else if (SpoonActor.transform.localScale.x < 0f)
        {transform.localScale = new Vector3(-1, 1,1);}
    }


     public void TakeCharacters()
    {
        ForkActive = GameObject.Find("F_Player");
        ForckActor = GameObject.Find("F_Actor");
        //
        KnifeActive = GameObject.Find("K_Player");
        KnifeActor = GameObject.Find("K_Actor");
        //
        SpoonActive = GameObject.Find("S_Player");
        SpoonActor = GameObject.Find("S_Actor");
    }
IEnumerator CoordinateActor()
    {
        // Switcha tra gli elementi
    if (isElement1Active)
    {
        ForkActive.gameObject.SetActive(true);
        KnifeActor.gameObject.SetActive(true);
        SpoonActor.gameObject.SetActive(true);
        ForkActive.transform.position = ForckActor.transform.position;
        SpoonActor.transform.position = SpoonActive.transform.position;
        KnifeActor.transform.position = KnifeActive.transform.position;
        if(GameManager.instance.battle)
        {DuelManager.instance.CharacterID = 1;}
        else if(!GameManager.instance.battle)
        {rotationSwitcher.CharacterID = 1;}
        yield return new WaitForSeconds(0.01f);
        Flip();
        ForckActor.gameObject.SetActive(false);
        KnifeActive.gameObject.SetActive(false);
        SpoonActive.gameObject.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
        if(!battle){
        vCam = GameObject.FindWithTag("MainCamera").GetComponent<CinemachineVirtualCamera>(); 
        //ottieni il riferimento alla virtual camera di Cinemachine
        vCam.Follow = player.transform;}
        //////////////////////////////
        isElement1Active = false;
        isElement2Active = true;
    }
    else if (isElement2Active)
    {   
        ForckActor.gameObject.SetActive(true);
        KnifeActive.gameObject.SetActive(true);
        SpoonActor.gameObject.SetActive(true);
        KnifeActive.transform.position = KnifeActor.transform.position;
        SpoonActor.transform.position = SpoonActive.transform.position;
        ForckActor.transform.position = ForkActive.transform.position;
        if(GameManager.instance.battle)
        {DuelManager.instance.CharacterID = 2;}
        else if(!GameManager.instance.battle)
        {rotationSwitcher.CharacterID = 2;}
        yield return new WaitForSeconds(0.01f);
        Flip();
        ForkActive.gameObject.SetActive(false);
        KnifeActor.gameObject.SetActive(false);
        SpoonActive.gameObject.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
        if(!battle){
        vCam = GameObject.FindWithTag("MainCamera").GetComponent<CinemachineVirtualCamera>(); 
        //ottieni il riferimento alla virtual camera di Cinemachine
        vCam.Follow = player.transform;}
        //////////////////////////////
        isElement2Active = false;
        isElement3Active = true;
    }
    else if (isElement3Active)
    {
        ForckActor.gameObject.SetActive(true);
        KnifeActor.gameObject.SetActive(true);
        SpoonActive.gameObject.SetActive(true);
        SpoonActive.transform.position = SpoonActor.transform.position;
        KnifeActor.transform.position = KnifeActive.transform.position;
        ForckActor.transform.position = ForkActive.transform.position;
        if(GameManager.instance.battle)
        {DuelManager.instance.CharacterID = 3;}
        else if(!GameManager.instance.battle)
        {rotationSwitcher.CharacterID = 3;}
        yield return new WaitForSeconds(0.01f);
        Flip();
        ForkActive.gameObject.SetActive(false);
        KnifeActive.gameObject.SetActive(false);
        SpoonActor.gameObject.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
        if(!battle){
        vCam = GameObject.FindWithTag("MainCamera").GetComponent<CinemachineVirtualCamera>(); 
        //ottieni il riferimento alla virtual camera di Cinemachine
        vCam.Follow = player.transform;}
        //////////////////////////////
        isElement3Active = false;
        isElement1Active = true;
    }
    }
#endregion
}
