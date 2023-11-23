using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
public class TouchPlayer : MonoBehaviour
{
    #region Header
    public int IdENM;
    //public int IDBattle;
    public int IdAreaAtt;
    public GameObject BattleObj;
    public GameObject[] DeactiveObj; 
    public GameObject This;
    
    //private SceneEvent sceneEvent;
    //public string sceneName;
    //public string sceneReturn;
    public float stoppingDistance = 1f;
    public Vector3 savedPosition;
    private Transform Player;
    private Transform Fork;
    private Transform Spoon;
    private Transform Knife;
    public Transform ENM;
    private SwitchCharacter Switch;
    public bool takeCoo = false;
    public bool isMove = true;
    private bool Var_1 = false;
    private bool Var_2 = true;
    private bool Var_3 = false;
    public NPCMove Mnpc;
    #endregion
    public void Start()
    {
    if (Switch == null) {Switch = GameObject.Find("EquipManager").GetComponent<SwitchCharacter>();} 
    if(GameManager.instance.F_Unlock){Fork = GameObject.Find("F_Player").transform;}
    if(GameManager.instance.S_Unlock){Spoon = GameObject.Find("S_Player").transform;}
    if(GameManager.instance.K_Unlock){Knife = GameObject.Find("K_Player").transform;}
    BattleObj.SetActive(false);
    }
    public void Take(){Destroy(This);}
    public void Update()
    {
    if(Switch.isElement1Active && Var_1)
    {if(GameManager.instance.S_Unlock && Var_1){Spoon = GameObject.Find("S_Player").transform;} 
    Player = Spoon; Var_1 = false; Var_2 = true;}
    else 
    if(Switch.isElement2Active && Var_2)
    {if(GameManager.instance.F_Unlock){Fork = GameObject.Find("F_Player").transform;} 
    Player = Fork;  Var_2 = false; Var_3 = true;} 
    else 
    if(Switch.isElement3Active && Var_3)
    {if(GameManager.instance.K_Unlock){Knife = GameObject.Find("K_Player").transform;} 
    Player = Knife; Var_3 = false; Var_1 = true;} 
    //
    if (SwitchCharacter.instance.rotationSwitcher.CharacterID == 1 &&
    SwitchCharacter.instance.rotationSwitcher.CharacterIDSec == 3 &&
    SwitchCharacter.instance.rotationSwitcher.CharacterIDTer == 2)
    {if(GameManager.instance.F_Unlock){Fork = GameObject.Find("F_Player").transform;}
    }
    if (SwitchCharacter.instance.rotationSwitcher.CharacterID == 2 &&
    SwitchCharacter.instance.rotationSwitcher.CharacterIDSec == 1 &&
    SwitchCharacter.instance.rotationSwitcher.CharacterIDTer == 3)
    {if(GameManager.instance.K_Unlock){Knife = GameObject.Find("K_Player").transform;}
    }
    if (SwitchCharacter.instance.rotationSwitcher.CharacterID == 3 &&
    SwitchCharacter.instance.rotationSwitcher.CharacterIDSec == 2 &&
    SwitchCharacter.instance.rotationSwitcher.CharacterIDTer == 1)
    {if(GameManager.instance.S_Unlock){Spoon = GameObject.Find("S_Player").transform;}}
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
    GameManager.instance.battle = true;
    GameManager.instance.savedPosition = savedPosition;
    GameManager.instance.FadeIn();
    yield return new WaitForSeconds(1f);
    GameManager.instance.StopAllarm();
    GameManager.instance.Posebattle();
    BattleObj.SetActive(true);
    foreach (GameObject arenaObject in DeactiveObj){arenaObject.SetActive(false);}
    //sceneEvent.InvokeOnSceneChange();
    }
    public void OnTriggerEnter(Collider other)
    {
    if (other.CompareTag("F_Player") && SwitchCharacter.instance.rotationSwitcher.CharacterID == 1)
    {Touch();}
    else if (other.CompareTag("K_Player") && SwitchCharacter.instance.rotationSwitcher.CharacterID == 2)
    {Touch();}
    else if (other.CompareTag("S_Player") && SwitchCharacter.instance.rotationSwitcher.CharacterID == 3)
    {Touch();}
    }
    
    public void Touch()
    {   if (isMove) {Mnpc.Behav = 0; Mnpc.isPaused = true;}
        AudioManager.instance.CrossFadeOUTAudio(0);
        //if (isRight) {GameManager.instance.Right();}
        //else if (!isRight) {GameManager.instance.Left();}
        //GameManager.instance.sceneName = sceneReturn;
        //GameManager.instance.IdAreaAtt = IdAreaAtt;
        //GameManager.instance.IDPorta = IDBattle;
        GameManager.instance.IdENM = IdENM;
        GameManager.instance.NotChange();
        AudioManager.instance.PlayUFX(7);
        GameManager.instance.ChStop();
        GameManager.instance.Allarm();
        CameraZoom.instance.ZoomIn();
        AudioManager.instance.CrossFadeINAudio(1);
        StartCoroutine(WaitForSceneLoad());}
    #if(UNITY_EDITOR)
    #region Gizmos
        private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(ENM.transform.position, stoppingDistance);
        //Gizmos.color = Color.blue;
        //Gizmos.DrawWireSphere(Agro.position, agroDistance);
    }
    #endregion
    #endif
}