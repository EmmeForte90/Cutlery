using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAndJoystickControl : MonoBehaviour
{
    public float mouseSensitivity = 2.0f;
    public float joystickSensitivity = 2.0f;

    private void Update()
    {
        
        // Leggi l'input del mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Leggi l'input del joystick
        float joystickX = Input.GetAxis("Horizontal") * joystickSensitivity;
        float joystickY = Input.GetAxis("Vertical") * joystickSensitivity;

        // Calcola la rotazione combinata
        float rotationX = transform.localEulerAngles.x - mouseY + joystickY;
        float rotationY = transform.localEulerAngles.y + mouseX + joystickX;

        // Limita l'angolo di inclinazione verticale per evitare inversioni
        rotationX = Mathf.Clamp(rotationX, 0f, 180f);

        // Applica la rotazione all'oggetto
        transform.localEulerAngles = new Vector3(rotationX, rotationY, 0f);
    }
}
