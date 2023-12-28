using System.Collections;
using UnityEngine;
public class Bullet : MonoBehaviour
{
    #region Header
    public float speed = 10f;
    public GameObject OBJ;
    public float damage = 10;
    public bool isSkill = true;
    public Skill itemInfo;
    public float lifeTime = 2f;
    public GameObject hitEffect;
    private Transform player;
    private Rigidbody rb;
    public static Bullet instance;
    #endregion
    public void OnEnable()
    {
        if (instance == null){instance = this;}
        rb = GetComponent<Rigidbody>();
        if (isSkill){damage = itemInfo.damage;}
        player = GameManager.instance.F_Hero.transform;
        if(player.transform.localScale.x == 1){Vector3 direction = player.right; rb.velocity = direction.normalized * speed;}
        else if(player.transform.localScale.x == -1){Vector3 direction = -player.right; rb.velocity = direction.normalized * speed;}
        StartCoroutine(Deactivate());
    }
    public void OnDisable()
    {
        AudioManager.instance.PlayUFX(9);
        if (hitEffect != null){hitEffect.SetActive(true); hitEffect.transform.position=transform.position;}
    }
    private IEnumerator Deactivate()
    {
    yield return new WaitForSeconds(lifeTime);
    OBJ.SetActive(false);
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy") || other.CompareTag("Collider"))
        {
        OBJ.SetActive(false);
        }
    }
}