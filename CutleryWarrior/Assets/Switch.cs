using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public int IDEvent;
    public Animator Anm;
    public Animator AnmGate;
    public GameObject Gate;
    public GameObject Leva;

    public GameObject IconSwitch;
    public GameObject IconGate;
    public GameObject VFXTake;
    public bool canOpen = true;
    //public GameObject GateClosed;
    //public GameObject GateOpen;
    //public void Awake(){GateClosed.SetActive(true); GateOpen.SetActive(false);}

    public void Take(){
    Anm.Play("Switch_Anm");
    AnmGate.Play("GateOpen_Anm");
    Gate.SetActive(false);
    Leva.SetActive(false);
    canOpen = false;
    IconSwitch.SetActive(false);
    IconGate.SetActive(false);}

   public void OnTriggerStay(Collider other)
    {
    if (other.CompareTag("F_Player") && SwitchCharacter.instance.rotationSwitcher.CharacterID == 1)
    {Touch();}
    else if (other.CompareTag("K_Player") && SwitchCharacter.instance.rotationSwitcher.CharacterID == 2)
    {Touch();}
    else if (other.CompareTag("S_Player") && SwitchCharacter.instance.rotationSwitcher.CharacterID == 3)
    {Touch();}
    }

    public void Touch()
    {
        if(canOpen){GameManager.instance.Esclamation();}
        else if(!canOpen){GameManager.instance.EsclamationStop();}
        if(Input.GetMouseButtonDown(0) && canOpen)
        {
        //GateClosed.SetActive(false);
        //GateOpen.SetActive(true);
        canOpen = false;
        IconSwitch.SetActive(false);
        IconGate.SetActive(false);
        Anm.Play("Switch_Anm");
        AnmGate.Play("GateOpen_Anm");
        Instantiate(VFXTake, transform.position, transform.rotation);
        AudioManager.instance.PlaySFX(11);
        GameManager.instance.EsclamationStop();
        PlayerStats.instance.EventDesertEnd(IDEvent);
        print("Leva usata" + IDEvent);
        }
    }
}
