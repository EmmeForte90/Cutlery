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
    //public string spawnPointTag = "SpawnPoint";
    //private CinemachineVirtualCamera vCam;
    //public bool camFollowPlayer = true;
    private SceneEvent sceneEvent;
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
    //public int IDAudio;
    public NPCMove Mnpc;
    #endregion
    public void Start()
    {
    if (Switch == null) {Switch = GameObject.Find("EquipManager").GetComponent<SwitchCharacter>();} 
    sceneEvent = GetComponent<SceneEvent>();
    sceneEvent.onSceneChange.AddListener(ChangeScene);
    if(GameManager.instance.F_Unlock){Fork = GameObject.Find("F_Player").transform;}
    if(GameManager.instance.S_Unlock){Spoon = GameObject.Find("S_Player").transform;}
    if(GameManager.instance.K_Unlock){Knife = GameObject.Find("K_Player").transform;}
    BattleObj.SetActive(false);
    }
    public void Take(){Destroy(This);}
    public void Update()
    {
    if(Switch.isElement1Active){Player = Spoon;}
    else if(Switch.isElement2Active){Player = Fork;} 
    else if(Switch.isElement3Active){Player = Knife;} 
    //
    if(!takeCoo){
    if ((transform.position - Player.transform.position).sqrMagnitude < stoppingDistance * stoppingDistance)
    {savedPosition = Player.transform.position; GameManager.instance.savedPosition = savedPosition; takeCoo = true;}}
    if ((transform.position - Player.transform.position).sqrMagnitude > stoppingDistance * stoppingDistance)
    {savedPosition = Player.transform.position; GameManager.instance.savedPosition = savedPosition; takeCoo = false;}
    }
    private void ChangeScene()
    {   
    //SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    //SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode){SceneManager.sceneLoaded -= OnSceneLoaded;}
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
    public void Flip()
    {
        if (Player.localScale.z > 0f){transform.localScale = new Vector3(1, 1,1);}
        else if (Player.localScale.z < 0f){transform.localScale = new Vector3(-1, 1,1);}
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
    {   Mnpc.Behav = 0; Mnpc.isPaused = true;
        AudioManager.instance.CrossFadeOUTAudio(0);
        //GameManager.instance.sceneName = sceneReturn;
        GameManager.instance.IdAreaAtt = IdAreaAtt;
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