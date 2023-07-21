using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticleAtEnd : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.GetComponent<ParticleSystem>().time >= this.GetComponent<ParticleSystem>().main.duration)
        {
            //Destroy(gameObject);
        }   
    }
}
