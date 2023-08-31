using UnityEngine;
public class MinimapScroll : MonoBehaviour
{
   public float zoomSpeed = 2.0f; // Velocità di zoom
    public float minSize = 1.0f; // Size minimo
    public float maxSize = 10.0f; // Size massimo
    public Camera cam;
    private float originalSize;
    private bool canZoom = true;
    public void Start(){originalSize = cam.orthographicSize;}
    public void Update()
    {
        if (canZoom)
        {
            float zoomAmount = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
            float newSize = cam.orthographicSize - zoomAmount;
            // Limita il size
            newSize = Mathf.Clamp(newSize, minSize, maxSize);
            cam.orthographicSize = newSize;
        }
    }
    public void CanZoom(){cam.orthographicSize = originalSize; canZoom = true;}
    public void RestoreZoom()
    {cam.orthographicSize = originalSize; canZoom = false;}
}