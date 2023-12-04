using UnityEngine;
public class TargetLaser : MonoBehaviour
{
    public Transform target;
    public GameObject PointLaser;
    public GameObject BossCoordinate;
     private void OnEnable()
    {
        PointLaser.transform.position = BossCoordinate.transform.position;
    }

    void Update()
    {
        if (target != null)
        {
            // Calcola la direzione dal nostro oggetto alla destinazione
            Vector3 direction = target.position - transform.position;

            // Calcola la rotazione per guardare nella direzione della destinazione
            Quaternion rotation = Quaternion.LookRotation(direction);

            // Applica la rotazione all'oggetto corrente
            PointLaser.transform.rotation = rotation;
        }
    }
}