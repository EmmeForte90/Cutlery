using UnityEngine;
public class ManagerCharacter : MonoBehaviour
{
    public CharacterMove Player;
    public CharacterFollow Actor;
    public Winanimation WinANM;
    public ChargeSkill Skill;
    //public KnockbackController Knock;
    //public DeathAnimation Death;
    //public StunAnimation Stun;
    public int kindCH;

    public void SwitchScriptsPlayer()
    {
            Player.enabled = true;
            Actor.enabled = false;
            WinANM.enabled = false;
            Skill.enabled = false;
            //Knock.enabled = false;
           // Death.enabled = false;
            //Stun.enabled = false;
            Player.Direction();
            kindCH = 0;
    }
    public void SwitchScriptsActor()
    {
            Player.enabled = false;
            Actor.enabled = true;
            WinANM.enabled = false;
            Skill.enabled = false;
            //Knock.enabled = false;
           // Death.enabled = false;
            // Stun.enabled = false;
            Actor.Direction();
            kindCH = 1;
    }

    public void SwitchScriptsWin()
    {
            Player.enabled = false;
            Actor.enabled = false;
            WinANM.enabled = true;
            Skill.enabled = false;
            //Knock.enabled = false;
           // Death.enabled = false;
           //  Stun.enabled = false;
            WinANM.Direction();
            WinANM.Win();
    }
    public void SwitchScriptsCharge()
    {
            Player.enabled = false;
            Actor.enabled = false;
            WinANM.enabled = false;
            Skill.enabled = true;
            //Knock.enabled = false;
           // Death.enabled = false;
           //  Stun.enabled = false;
    }
    public void SwitchScriptsDeath()
    {
            Player.enabled = false;
            Actor.enabled = false;
            WinANM.enabled = false;
            Skill.enabled = false;
           // Knock.enabled = false;
           // Death.enabled = true;
           // Stun.enabled = false;
    }
    public void SwitchScriptsStun()
    {
            Player.enabled = false;
            Actor.enabled = false;
            WinANM.enabled = false;
            Skill.enabled = false;
           // Knock.enabled = false;
          //  Death.enabled = false;
          //  Stun.enabled = true;
    }
    
}
