using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    public int lifeTime = 0;
    //public int IDSound = 0;
    public GameObject title;


    // Start is called before the first frame update
    void Start()
    {
    //AudioManager.instance.PlayUFX(IDSound);
    StartCoroutine(Destroy());
    }

    

    IEnumerator Destroy()
{   
    yield return new WaitForSeconds(lifeTime);
    //title.gameObject.SetActive(false);
    Destroy(title.gameObject);
    
}
}
