using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleArea : MonoBehaviour
{
    public GameObject Title;
    public int lifeTime = 0;
    public void Start(){Title.gameObject.SetActive(false);}
    public void OnTriggerEnter(Collider other) 
    {if (other.CompareTag("F_Player") || other.CompareTag("K_Player") || other.CompareTag("S_Player"))
    {Title.gameObject.SetActive(true); StartCoroutine(CoordinateActor());}}
    IEnumerator CoordinateActor()
    {yield return new WaitForSeconds(lifeTime);Title.gameObject.SetActive(false);}
}