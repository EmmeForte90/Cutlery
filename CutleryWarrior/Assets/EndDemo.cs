using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndDemo : MonoBehaviour
{
    public void Start()
    {
        GameManager.instance.NotTouchOption = true;
        GameManager.instance.ChStop();
    }
    public void ReturnMainMenu()
        {   
        GameManager.instance.FadeIn();
        GameManager.instance.StartGame = true;
        StartCoroutine(enoughGame());
        }
    IEnumerator enoughGame()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene (sceneName:"MainMenu");
        GameManager.instance.DestroyManager();
    }
}
