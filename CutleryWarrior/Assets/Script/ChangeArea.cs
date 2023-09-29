using System.Collections;
using UnityEngine;
using Cinemachine;
public class ChangeArea : MonoBehaviour
{
    #region Header
    public GameObject PointSpawn;
    private CinemachineConfiner confiner;
    public Collider NewConfiner;
    private GameObject FAct;
    private GameObject KAct;
    private GameObject SAct;  
    private CinemachineVirtualCamera vCam;
    public bool needDeactivateObject;
    public GameObject[] objDeactivate;
    public GameObject[] objActivate;
    #endregion
    public void Start()
    {        
         if(GameManager.instance.F_Unlock){FAct = GameObject.FindWithTag("F_Player");}
         if(GameManager.instance.S_Unlock){SAct = GameObject.FindWithTag("S_Player");}
         if(GameManager.instance.K_Unlock){KAct = GameObject.FindWithTag("K_Player");}        
        vCam = GameObject.FindWithTag("MainCamera").GetComponent<CinemachineVirtualCamera>(); //ottieni il riferimento alla virtual camera di Cinemachine
        confiner = GameObject.FindWithTag("MainCamera").GetComponent<CinemachineConfiner>(); //ottieni il riferimento alla virtual camera di Cinemachine
    }
    public void OnTriggerEnter(Collider collision)
    {
        // Controlliamo se il player ha toccato il collider
        if (GameManager.instance.F_Unlock && collision.gameObject.CompareTag("F_Player"))
        {StartCoroutine(ChangeAreaF());}
        else if (GameManager.instance.S_Unlock && collision.gameObject.CompareTag("S_Player"))
        {StartCoroutine(ChangeAreaF());}
        else if (GameManager.instance.K_Unlock && collision.gameObject.CompareTag("K_Player"))
        {StartCoroutine(ChangeAreaF());}
    }
    public void ModifyConfiner()
    {
        confiner.m_BoundingVolume  = null; 
        confiner.m_BoundingVolume  = NewConfiner;       
        vCam.Follow = GameManager.instance.player.transform;
    }
    IEnumerator ChangeAreaF()
    {
        GameManager.instance.ChStop();
        CharacterMove.instance.Idle();
        GameManager.instance.FadeIn();
        yield return new WaitForSeconds(2f);
        if(needDeactivateObject)
        {Deactive(); Activate();}
        CharacterMove.instance.isRun = false;
        ModifyConfiner();
        GameManager.instance.player.transform.position = PointSpawn.transform.position;
        if(GameManager.instance.F_Unlock){FAct = GameObject.FindWithTag("F_Player");}
        if(GameManager.instance.S_Unlock){SAct = GameObject.FindWithTag("S_Player");}
        if(GameManager.instance.K_Unlock){KAct = GameObject.FindWithTag("K_Player");}  
        if(GameManager.instance.K_Unlock){KAct.transform.position = PointSpawn.transform.position;}
        if(GameManager.instance.F_Unlock){FAct.transform.position = PointSpawn.transform.position;}
        if(GameManager.instance.S_Unlock){SAct.transform.position = PointSpawn.transform.position;}
        yield return new WaitForSeconds(2f);
        GameManager.instance.ChCanM();
        GameManager.instance.FadeOut();
    }
    public void Deactive()
    {
        foreach (GameObject arenaObject in objDeactivate){arenaObject.SetActive(false);}
    }
    public void Activate()
    {
        foreach (GameObject arenaObject in objActivate){arenaObject.SetActive(true);}
    } 
}