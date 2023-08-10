using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 10;
    public float lifeTime = 2f;
    public GameObject hitEffect;
    private Transform player;
    private Rigidbody rb;
    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("F_Player").transform;
        if(player.transform.localScale.x == 1){Vector3 direction = player.right; rb.velocity = direction.normalized * speed;}
        else if(player.transform.localScale.x == -1){Vector3 direction = -player.right; rb.velocity = direction.normalized * speed;}
        Destroy(gameObject, lifeTime);
    }
    public void OnTriggerEnter(Collider other)
    {
        // Se il proiettile colpisce un nemico, applica il danno e distruggi il proiettile
        //EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
        if(other.CompareTag("Enemy"))
        {
        // Crea l'effetto di impatto
        AudioManager.instance.PlayUFX(9);
        if (hitEffect != null)
        {Instantiate(hitEffect, transform.position, transform.rotation);}
        // Distruggi il proiettile dopo l'impatto
        Destroy(gameObject);
        }
    }
}
