using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SceneBattle : MonoBehaviour
{
    public int IdEvent;
    public GameObject BattleObj;
    public GameObject[] DeactiveObj; 
    public GameObject This;
    public GameObject PointView;
    public float stoppingDistance = 1f;
    public Vector3 savedPosition;
    private Transform Player;
    private Transform Fork;
    private Transform Spoon;
    private Transform Knife;
    //private SwitchCharacter Switch;
    public bool takeCoo = false;
    public bool isRight = false;
    private CinemachineVirtualCamera vcam; // La telecamera virtuale Cinemachine

    public void Start()
    {
    vcam = GameManager.instance.vcam.GetComponent<CinemachineVirtualCamera>(); //ottieni il riferimento alla virtual camera di Cinemachine
    //if (Switch == null) {Switch = GameObject.Find("EquipManager").GetComponent<SwitchCharacter>();} 
    if(GameManager.instance.F_Unlock){Fork = GameManager.instance.F_Hero.transform;}
    if(GameManager.instance.S_Unlock){Spoon = GameManager.instance.S_Hero.transform;}
    if(GameManager.instance.K_Unlock){Knife = GameManager.instance.K_Hero.transform;}
    BattleObj.SetActive(false);
    }
    public void Take(){Destroy(This);}
    public void Update()
    {
    Chose();
    //
    if(!takeCoo){
    if ((transform.position - Player.transform.position).sqrMagnitude < stoppingDistance * stoppingDistance)
    {savedPosition = Player.transform.position; GameManager.instance.savedPosition = savedPosition; takeCoo = true;
    if(!isRight){Player.transform.localScale = new Vector3(-1, 1,1);}else if(isRight){Player.transform.localScale = new Vector3(1, 1,1);}
    }
    }
    if ((transform.position - Player.transform.position).sqrMagnitude > stoppingDistance * stoppingDistance)
    {savedPosition = Player.transform.position; GameManager.instance.savedPosition = savedPosition; takeCoo = false;}
    }
    public void Chose()
    {
        switch(GameManager.instance.CharacterID)
        {
            case 1:
            if(GameManager.instance.F_Unlock)
            {
                Fork = GameManager.instance.F_Hero.transform;
                Player = GameManager.instance.F_Hero.transform;
            }
            Player = Fork.transform;
            break;
            case 2:
            if(GameManager.instance.K_Unlock)
            {
                Knife = GameManager.instance.K_Hero.transform;
                Player = GameManager.instance.K_Hero.transform; 
            }  
            Player = Knife.transform;
            break;
            case 3:
            if(GameManager.instance.S_Unlock)
            {
                Spoon = GameManager.instance.S_Hero.transform;
                Player = GameManager.instance.S_Hero.transform;
            }
            Player = Spoon.transform;
            break;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
    if (other.CompareTag("F_Player") && GameManager.instance.CharacterID == 1)
    {Touch();}
    else if (other.CompareTag("K_Player") && GameManager.instance.CharacterID == 2)
    {Touch();}
    else if (other.CompareTag("S_Player") && GameManager.instance.CharacterID == 3)
    {Touch();}
    }
    public void Touch()
    {   
        AudioManager.instance.CrossFadeOUTAudio(0);
        GameManager.instance.NotChange();
        AudioManager.instance.PlayUFX(7);
        GameManager.instance.ChStop();
        GameManager.instance.Allarm();
        CameraZoom.instance.ZoomIn();
        vcam.Follow = PointView.transform;
        AudioManager.instance.CrossFadeINAudio(1);
        StartCoroutine(WaitForSceneLoad());
    }
    IEnumerator WaitForSceneLoad()
    {   
    GameManager.instance.ChStop();
    yield return new WaitForSeconds(1f);
    GameManager.instance.battle = true;
    GameManager.instance.savedPosition = savedPosition;
    GameManager.instance.FadeIn();
    yield return new WaitForSeconds(1f);
    GameManager.instance.StopAllarm();
    GameManager.instance.Posebattle();
    BattleObj.SetActive(true);
    PlayerStats.instance.EventDesertEnd(IdEvent);
    foreach (GameObject arenaObject in DeactiveObj){arenaObject.SetActive(false);}
    }
}
