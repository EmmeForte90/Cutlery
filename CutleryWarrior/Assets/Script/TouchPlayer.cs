using System.Collections;
using UnityEngine;
public class TouchPlayer : MonoBehaviour
{
    #region Header
    public int IdENM;
    [Header("AudioBattle")]
    public int IdAudioBattle;
    public int IdAudioLevel;
    [Header("Is Boss")]
    public int AudioBoss;
    public bool isBoss = false;
    [Header("Active/Deactive Battle")]
    public GameObject BattleObj;
    public GameObject[] DeactiveObj; 
    //public GameObject This;
    public float stoppingDistance = 1f;
    public Vector3 savedPosition;
    public Transform savedPositionEscape;
    private Transform Player;
    private Transform Fork;
    private Transform Spoon;
    private Transform Knife;
    public Transform ENM;
    //private SwitchCharacter Switch;
    public bool takeCoo = false;
    public bool isMove = true;
    public NPCMove Mnpc;
    #endregion
    public void Start()
    {
    //if (Switch == null) {Switch = GameObject.Find("EquipManager").GetComponent<SwitchCharacter>();} 
    if(GameManager.instance.F_Unlock){Fork = GameManager.instance.F_Hero.transform;}
    if(GameManager.instance.S_Unlock){Spoon = GameManager.instance.S_Hero.transform;}
    if(GameManager.instance.K_Unlock){Knife = GameManager.instance.K_Hero.transform;}
    BattleObj.SetActive(false);
    }
    public void Update()
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
    //
    if(!takeCoo){
    if ((transform.position - Player.transform.position).sqrMagnitude < stoppingDistance * stoppingDistance)
    {savedPosition = Player.transform.position; GameManager.instance.savedPosition = savedPosition; takeCoo = true;}}
    if ((transform.position - Player.transform.position).sqrMagnitude > stoppingDistance * stoppingDistance)
    {savedPosition = Player.transform.position; GameManager.instance.savedPosition = savedPosition; takeCoo = false;}
    }
    
    IEnumerator WaitForSceneLoad()
    {   
    GameManager.instance.ChStop();
    yield return new WaitForSeconds(1f);
    if(isBoss){ GameManager.instance.AM.CrossFadeINAudio(AudioBoss); 
    GameManager.instance.AM.CrossFadeOUTAudio(IdAudioLevel);}
    else if(!isBoss){GameManager.instance.AM.CrossFadeINAudio(IdAudioBattle); 
    GameManager.instance.AM.CrossFadeOUTAudio(IdAudioLevel);}
    GameManager.instance.savedPositionEscape = savedPositionEscape;
    GameManager.instance.FadeIn();
    if(GameManager.instance.activeMinimap){GameManager.instance.AllarmMap.SetActive(false);}
    yield return new WaitForSeconds(3f);
    GameManager.instance.StopAllarm();
    GameManager.instance.Posebattle();
    GameManager.instance.EnemyCanTouch = true;
    BattleObj.SetActive(true);
    foreach (GameObject arenaObject in DeactiveObj){arenaObject.SetActive(false);}
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
        if(!GameManager.instance.EnemyCanTouch){
        if (isMove) {Mnpc.Behav = 0; Mnpc.isPaused = true;}
        GameManager.instance.IdENM = IdENM;
        GameManager.instance.NotChange();
        GameManager.instance.AM.PlayUFX(7);
        GameManager.instance.ChStop();
        GameManager.instance.Allarm();
        GameManager.instance.CZ.ZoomIn();
        StartCoroutine(WaitForSceneLoad());}}
    #if(UNITY_EDITOR)
    #region Gizmos
        private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(ENM.transform.position, stoppingDistance);
    }
    #endregion
    #endif
}