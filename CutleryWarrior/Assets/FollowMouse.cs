using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    private float moveSpeed = 50f; // Velocità di movimento dello sprite

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        // Ottieni la posizione del mouse in coordinate dello schermo
        Vector3 mousePositionScreen = Input.mousePosition;

        // Converti la posizione del mouse da coordinate dello schermo a coordinate del mondo
        Vector3 mousePositionWorld = mainCamera.ScreenToWorldPoint(new Vector3(mousePositionScreen.x, mousePositionScreen.y, 10f)); 
        // Usa 10f come posizione Z

        // Muovi lo sprite verso la posizione del mouse con una velocità specifica
        transform.position = Vector3.Lerp(transform.position, mousePositionWorld, moveSpeed * Time.deltaTime);
    }
}
