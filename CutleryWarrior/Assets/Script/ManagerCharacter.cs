using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerCharacter : MonoBehaviour
{
    public CharacterMove Player;
    public CharacterFollow Actor;
    public Winanimation WinANM;
    public ChargeSkill Skill;
    public DeathAnimation Death;

    public void SwitchScriptsPlayer()
    {
            Player.enabled = true;
            Actor.enabled = false;
            WinANM.enabled = false;
            Skill.enabled = false;
            Death.enabled = false;
            Player.Direction();
    }
    public void SwitchScriptsActor()
    {
            Player.enabled = false;
            Actor.enabled = true;
            WinANM.enabled = false;
            Skill.enabled = false;
            Death.enabled = false;
            Actor.Direction();
    }

    public void SwitchScriptsWin()
    {
            Player.enabled = false;
            Actor.enabled = false;
            WinANM.enabled = true;
            Skill.enabled = false;
            Death.enabled = false;
            WinANM.Direction();
            WinANM.Win();
    }
    public void SwitchScriptsCharge()
    {
            Player.enabled = false;
            Actor.enabled = false;
            WinANM.enabled = false;
            Skill.enabled = true;
            Death.enabled = false;
    }
    public void SwitchScriptsDeath()
    {
            Player.enabled = false;
            Actor.enabled = false;
            WinANM.enabled = false;
            Skill.enabled = false;
            Death.enabled = true;
    }
}
