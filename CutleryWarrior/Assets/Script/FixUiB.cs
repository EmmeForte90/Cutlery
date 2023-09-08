using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixUiB : MonoBehaviour
{
    public GameObject ForkActive;
    

    // Update is called once per frame
    void Update()
    {
        if (ForkActive.transform.localScale.x > 0f){transform.localScale = new Vector3(0.1f, 0.1f,0.1f);}
        else if (ForkActive.transform.localScale.x < 0f){transform.localScale = new Vector3(0.1f, 0.1f,0.1f);}
    }
}
