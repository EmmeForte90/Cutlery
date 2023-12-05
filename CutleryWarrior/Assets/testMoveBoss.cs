using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testMoveBoss : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 2.0f;
    
    private int currentWaypointIndex = 0;

    void Update()
    {
        // Verifica se ci sono waypoints
        if (waypoints.Length == 0)
        {
            Debug.LogError("Nessun waypoint definito.");
            return;
        }

        // Muovi il GameObject verso il waypoint corrente
        Transform targetWaypoint = waypoints[currentWaypointIndex];
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);

        // Verifica se il GameObject ha raggiunto il waypoint corrente
        if (transform.position == targetWaypoint.position)
        {
            // Passa al prossimo waypoint in modo ciclico
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }
}
