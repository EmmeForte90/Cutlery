using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using Cinemachine;

public class TouchPlayer : MonoBehaviour
{
    public string spawnPointTag = "SpawnPoint";
    private CinemachineVirtualCamera vCam;
    public bool camFollowPlayer = true;
    private SceneEvent sceneEvent;
    public string sceneName;
    public float stoppingDistance = 1f;
    public Vector3 savedPosition;
    private Transform Player;
    private Transform Fork;
    private Transform Spoon;
    private Transform Knife;
    private SwitchCharacter Switch;
    public bool takeCoo = false;

    public void Start()
    {
    if (Switch == null) {Switch = GameObject.Find("EquipManager").GetComponent<SwitchCharacter>();} 
    sceneEvent = GetComponent<SceneEvent>();
    sceneEvent.onSceneChange.AddListener(ChangeScene);
    Fork = GameObject.Find("F_Player").transform;
    Spoon = GameObject.Find("S_Player").transform;
    Knife = GameObject.Find("K_Player").transform;
    }
    public void Update()
    {
        if(Switch.isElement1Active){Player = Spoon;}
        else if(Switch.isElement2Active){Player = Fork;} 
        else if(Switch.isElement3Active){Player = Knife;} 
    if(!takeCoo){
    if ((transform.position - Player.transform.position).sqrMagnitude < stoppingDistance * stoppingDistance)
    {savedPosition = Player.transform.position; GameManager.instance.savedPosition = savedPosition; takeCoo = true;}}
   
    if ((transform.position - Player.transform.position).sqrMagnitude > stoppingDistance * stoppingDistance)
    {savedPosition = Player.transform.position; GameManager.instance.savedPosition = savedPosition; takeCoo = false;}
    }
    private void ChangeScene()
    {   
    SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {SceneManager.sceneLoaded -= OnSceneLoaded;}
IEnumerator WaitForSceneLoad()
{   
    GameManager.instance.ChStop();
    yield return new WaitForSeconds(2f);
    GameManager.instance.battle = true;
    GameManager.instance.savedPosition = savedPosition;
    GameManager.instance.FadeIn();
    yield return new WaitForSeconds(2f);
    GameManager.instance.StopAllarm();
    GameManager.instance.Posebattle();
    sceneEvent.InvokeOnSceneChange();
}
public void Flip()
    {
        if (Player.localScale.x > 0f){transform.localScale = new Vector3(1, 1,1);}
        else if (Player.localScale.x < 0f){transform.localScale = new Vector3(-1, 1,1);}
    }
public void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("F_Player") || other.CompareTag("K_Player") || other.CompareTag("S_Player"))
    {
        GameManager.instance.ChStop();
        GameManager.instance.Allarm();
        CameraZoom.instance.ZoomIn();
        StartCoroutine(WaitForSceneLoad());
}}
#if(UNITY_EDITOR)
#region Gizmos
private void OnDrawGizmos()
    {
    Gizmos.color = Color.red;
    //Gizmos.DrawLine(transform.position, transform.position + new Vector3(transform.localScale.x, 0, 0) * wallDistance);
    //Gizmos.color = Color.blue;
    Gizmos.DrawWireSphere(transform.position, stoppingDistance);
    }
#endregion
#endif
}