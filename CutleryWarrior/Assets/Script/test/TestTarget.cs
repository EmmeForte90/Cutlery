using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTarget : MonoBehaviour
{
    public GameObject target;
    public float AiSpeed = 3f;

    // Update is called once per frame
    void Update()
    {
    if(target != null){transform.position = Vector3.MoveTowards(transform.position, target.transform.position, AiSpeed * Time.deltaTime);}
    }
}
