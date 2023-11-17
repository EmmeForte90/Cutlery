using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    //public float speed = 10f;
    public float damage = 10;
    public float lifeTime = 2f;
    public static Bomb instance;

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy") || other.CompareTag("Collider"))
        {
        AudioManager.instance.PlayUFX(9);
        Destroy(gameObject, lifeTime);
        }
    }
}
