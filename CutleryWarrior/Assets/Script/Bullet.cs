using UnityEngine;
public class Bullet : MonoBehaviour
{
    #region Header
    public float speed = 10f;
    public int damage = 10;
    public bool isSkill = true;
    public Skill itemInfo;
    public float lifeTime = 2f;
    public GameObject hitEffect;
    private Transform player;
    private Rigidbody rb;
    public static Bullet instance;
    #endregion
    public void Start()
    {
        if (instance == null){instance = this;}
        rb = GetComponent<Rigidbody>();
        if (isSkill){damage = itemInfo.damage;}
        player = GameObject.FindGameObjectWithTag("F_Player").transform;
        if(player.transform.localScale.x == 1){Vector3 direction = player.right; rb.velocity = direction.normalized * speed;}
        else if(player.transform.localScale.x == -1){Vector3 direction = -player.right; rb.velocity = direction.normalized * speed;}
        Destroy(gameObject, lifeTime);
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
        AudioManager.instance.PlayUFX(9);
        if (hitEffect != null){Instantiate(hitEffect, transform.position, transform.rotation);}
        Destroy(gameObject);
        }
    }
}