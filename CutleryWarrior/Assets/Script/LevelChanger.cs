using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelChanger : MonoBehaviour
{
    public string sceneName;
    public int IDPorta;
    public bool Loading = false;
    private SceneEvent sceneEvent;


    public void Start()
    {
    sceneEvent = GetComponent<SceneEvent>();
    sceneEvent.onSceneChange.AddListener(ChangeScene);

    }
    private void ChangeScene()
    {
    SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {SceneManager.sceneLoaded -= OnSceneLoaded;}  
    public void Escape()
    {
    GameManager.instance.FadeOut();
    GameManager.instance.ChStop();
    CameraZoom.instance.ZoomIn();
    GameManager.instance.StopWin();
    GameManager.instance.ChMov();
    StartCoroutine(RetunBattle());
    }
    public void LoadingEnd(){StartCoroutine(StartLoad());}
    public void OnTriggerEnter(Collider other)
    {
    if (other.CompareTag("F_Player") ||
    other.CompareTag("K_Player") ||
    other.CompareTag("S_Player"))
    {GameManager.instance.ChStop();
    //StartScene.instance.Start = false;
    CameraZoom.instance.ZoomIn();
    StartCoroutine(WaitForSceneLoad());}
    }
    IEnumerator StartLoad()
    {    
    yield return new WaitForSeconds(3f);
    sceneEvent.InvokeOnSceneChange();
    }
    
    IEnumerator WaitForSceneLoad()
    {   
    GameManager.instance.StartGame = false;
    CharacterMove.instance.inputCTR = true;
    CharacterMove.instance.Idle();
    GameManager.instance.FadeIn();
    yield return new WaitForSeconds(2f);
    SwitchCharacter.instance.ActiveCH();
    GameManager.instance.IDPorta = IDPorta;
    sceneEvent.InvokeOnSceneChange();
    CharacterMove.instance.isRun = false;
    yield return new WaitForSeconds(2f);
    CharacterMove.instance.inputCTR = false; 
    //GameManager.instance.FadeOut();
    yield return new WaitForSeconds(2f);
    }
    IEnumerator RetunBattle()
    {   
    GameManager.instance.StartGame = false;
    CharacterMove.instance.inputCTR = true;
    CharacterMove.instance.Idle();
    GameManager.instance.FadeIn();
    AudioManager.instance.CrossFadeOUTAudio(1);
    yield return new WaitForSeconds(2f);
    SwitchCharacter.instance.ActiveCH();
    GameManager.instance.Exploration();
    GameManager.instance.Change();
    sceneEvent.InvokeOnSceneChange();
    }
}