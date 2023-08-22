using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public float Timelife;
    public GameObject Fade;
    public AudioSource Music;
    public string startScene;
    public AudioMixer MSX;
    public AudioMixer SFX;
    Resolution[] resolutions;
    public static MainMenu instance;
    public void Start()
    {
        if (instance == null){instance = this;}
        Application.targetFrameRate = 60;
        StartCoroutine(StartM());
    }
    public void SetVolume(float volume){MSX.SetFloat("Volume", volume);}
    public void SetSFX(float volume){SFX.SetFloat("Volume", volume);}
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void StartGame(){StartCoroutine(fade());}
    public void SetQuality(int qualityIndex){QualitySettings.SetQualityLevel(qualityIndex);}
    public void SetFullscreen(bool isFullScreen){Screen.fullScreen = isFullScreen;}
    IEnumerator StartM(){yield return new WaitForSeconds(13);Music.Play();}
    IEnumerator fade()
    {           
        Fade.gameObject.SetActive(true);
        yield return new WaitForSeconds(Timelife);
        SceneManager.LoadScene(startScene);       
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting Game");
    }
}