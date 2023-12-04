using UnityEngine;

public class DestroyProjectile : MonoBehaviour
{
    float LifeTime = 5;
    public void Start()
    {
        LifeTime -= Time.deltaTime;
        if(LifeTime <= 0){Destroy(gameObject);}
    }
}