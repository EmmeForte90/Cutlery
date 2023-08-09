using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerCharacter : MonoBehaviour
{
    public CharacterMove Player;
    public CharacterFollow Actor;
   
    public void SwitchScriptsPlayer()
    {
            Player.enabled = true;
            Actor.enabled = false;
            Player.Direction();
    }
    public void SwitchScriptsActor()
    {
            Player.enabled = false;
            Actor.enabled = true;
            Actor.Direction();
    }
}
