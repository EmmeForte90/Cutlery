using UnityEngine;

public class DestroyProjectile : MonoBehaviour
{
    public GameObject Projectile;
    public string Target;
    public GameObject BP;
    public float LunchTime = 2f;
    float LifeTime = 10f;
    public void Start()
    {
        BP = GameObject.Find(Target);
        Projectile.transform.position = BP.transform.position; 
        Projectile.SetActive(false);       
    }
    public void Update()
    {
        LifeTime -= Time.deltaTime;
        LunchTime -= Time.deltaTime;
        if(LifeTime <= 0){Destroy(gameObject);}
        if(LunchTime <= 0){Projectile.SetActive(true);}
    }
}