using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject OBJ;
    public float damage = 10;
    public float lifeTime = 2f;
    public static Bomb instance;

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy") || other.CompareTag("Collider"))
        {
        AudioManager.instance.PlayUFX(9);
        StartCoroutine(Deactivate());
        }
    }
     private IEnumerator Deactivate()
    {
    yield return new WaitForSeconds(lifeTime);
    OBJ.SetActive(false);
    }
}
