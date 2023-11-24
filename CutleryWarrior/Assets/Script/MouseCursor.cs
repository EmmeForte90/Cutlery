using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class MouseCursor : MonoBehaviour
{
    public Texture2D cursorTexture;

    public bool isMouse = false;

    private RawImage rawImage;

    private float mouseSensitivity = 10.0f;
    private float joystickSensitivity = 10.0f;

    void Start()
    {
        Cursor.visible = false;

        // Ottieni il componente RawImage
        rawImage = GetComponent<RawImage>();

        // Imposta la texture iniziale
        rawImage.texture = cursorTexture;
    }

    void Update()
    {
        if(isMouse){
        // Posiziona l'immagine del cursore nella posizione del mouse
        Vector3 mousePos = Input.mousePosition;

        // Visualizza l'immagine del cursore
        rawImage.texture = cursorTexture;
        rawImage.rectTransform.position = mousePos;
        }
        else if(!isMouse)
        {
            // Leggi l'input del mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Leggi l'input del joystick
        float joystickX = Input.GetAxis("Horizontal") * joystickSensitivity;
        float joystickY = Input.GetAxis("Vertical") * joystickSensitivity;

        // Calcola la posizione combinata del cursore
        Vector3 cursorPosition = rawImage.rectTransform.anchoredPosition;
        cursorPosition.x += mouseX + joystickX;
        cursorPosition.y += mouseY + joystickY;

        // Limita la posizione del cursore all'interno dei limiti dello schermo
        cursorPosition.x = Mathf.Clamp(cursorPosition.x, 0f, Screen.width);
        cursorPosition.y = Mathf.Clamp(cursorPosition.y, 0f, Screen.height);

        // Visualizza l'immagine del cursore
        rawImage.texture = cursorTexture;
        rawImage.rectTransform.anchoredPosition = cursorPosition;

        // Controlla se il giocatore preme il pulsante di interazione (ad esempio, "Enter" o "A")
        if (Input.GetButtonDown("Fire1"))
        {
            // Ottieni il pulsante attualmente selezionato dall'EventSystem
            GameObject selectedButton = EventSystem.current.currentSelectedGameObject;

            // Esegui l'azione associata al pulsante attualmente selezionato
            if (selectedButton != null)
            {
                Button button = selectedButton.GetComponent<Button>();
                if (button != null)
                {
                    button.onClick.Invoke();  // Simula un clic sul pulsante
                }
            }
        }




        }
    }
}