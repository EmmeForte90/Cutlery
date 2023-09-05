using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateOverTime : MonoBehaviour
{
    public int lifeTime = 0;
    public bool Hide = false;
    public GameObject title;
    void Start(){StartCoroutine(Destroy());}
    void Update(){if(Hide){StartCoroutine(Destroy());}}
    IEnumerator Destroy(){yield return new WaitForSeconds(lifeTime); title.gameObject.SetActive(false);}
}