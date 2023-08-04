using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerCharacter : MonoBehaviour
{
   // Riferimenti agli script da attivare/disattivare
    public CharacterMove Player;
    public CharacterFollow Actor;
    //public int IDCharacter;
    /*public void Update()
    {
       switch(IDCharacter)
       {
        case 1:

        break;
       }
    }*/

    // Metodo per attivare uno script e disattivarne un altro
    public void SwitchScriptsPlayer()
    {
        // Attiva lo script da attivare e disattiva lo script da disattivare
            Player.enabled = true;
            Actor.enabled = false;
            Player.Direction();


    }
    public void SwitchScriptsActor()
    {
        // Attiva lo script da attivare e disattiva lo script da disattivare
            Player.enabled = false;
            Actor.enabled = true;
            Actor.Direction();

    }
}
