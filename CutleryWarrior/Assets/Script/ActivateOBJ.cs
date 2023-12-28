using System.Collections;
using UnityEngine;

public class ActivateOBJ : MonoBehaviour
{
    public GameObject[] OBJ;
    private bool repet = true;
    public void OnTriggerEnter(Collider other) 
    {if (other.CompareTag("F_Player") || other.CompareTag("K_Player") || other.CompareTag("S_Player"))
    {
        GameManager.instance.ChStop();
        GameManager.instance.AM.StopSFX(0);  
    StartCoroutine(WaitForSceneLoad());
    }
    }
    IEnumerator WaitForSceneLoad()
    {   
    yield return new WaitForSeconds(0.001f);
    if(repet){foreach (GameObject arenaObject in OBJ){arenaObject.SetActive(true);repet=false;}}
    }
}