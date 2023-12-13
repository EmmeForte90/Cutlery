using UnityEngine;

public class ActivateOBJ : MonoBehaviour
{
    public GameObject[] OBJ;
    private bool repet = true;
    public void OnTriggerEnter(Collider other) 
    {if (other.CompareTag("F_Player") || other.CompareTag("K_Player") || other.CompareTag("S_Player"))
    {if(repet){foreach (GameObject arenaObject in OBJ){arenaObject.SetActive(true);repet=false;}}}}
}