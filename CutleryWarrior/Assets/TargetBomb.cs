using System.Collections;
using UnityEngine;

public class TargetBomb : MonoBehaviour
{
    public GameObject objectToSpawn;
    public GameObject Bullet;
        public GameObject Bp;

    public float spawnRadius = 5f;

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }

    public void SpawnObjectInRandomPosition()
    {
        Vector2 randomPoint = Random.insideUnitCircle * spawnRadius;
        Vector3 spawnPosition = new Vector3(randomPoint.x, 0f, randomPoint.y) + transform.position;

        Instantiate(objectToSpawn, spawnPosition, objectToSpawn.transform.rotation);
        StartCoroutine(Lunch());
    }
    IEnumerator Lunch()
    {
    yield return new WaitForSeconds(2); 
    Instantiate(Bullet, Bp.transform.position, Bullet.transform.rotation);
    }
}