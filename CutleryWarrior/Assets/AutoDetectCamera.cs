using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDetectCamera : MonoBehaviour
{
   private void Start()
    {
        Canvas canvas = GetComponent<Canvas>();
        if (canvas != null)
        {
            // Cerca una camera vicina
            Camera nearbyCamera = FindNearbyCamera();
            if (nearbyCamera != null)
            {
                canvas.renderMode = RenderMode.WorldSpace;
                canvas.worldCamera = nearbyCamera;
            }
        }
    }

    private Camera FindNearbyCamera()
    {
        Camera[] cameras = Camera.allCameras;
        foreach (Camera camera in cameras)
        {
            if (Vector3.Distance(transform.position, camera.transform.position) < 10f)
            {
                return camera;
            }
        }
        return null;
    }
}



