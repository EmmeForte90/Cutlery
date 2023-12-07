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
    public GameObject VFXSegnal;
    public bool canOpen = true;
    public void Take(){
    Anm.Play("Switch_Anm");
    AnmGate.Play("GateOpen_Anm");
    canOpen = false;
    IconSwitch.SetActive(false);
    IconGate.SetActive(false);}

   public void OnTriggerStay(Collider other)
    {
    if (other.CompareTag("F_Player") && GameManager.instance.CharacterID == 1)
    {Touch();}
    else if (other.CompareTag("K_Player") && GameManager.instance.CharacterID == 2)
    {Touch();}
    else if (other.CompareTag("S_Player") && GameManager.instance.CharacterID == 3)
    {Touch();}
    }

    public void OnTriggerExit(Collider other)
    {
    if (other.CompareTag("F_Player") && GameManager.instance.CharacterID == 1)
    {GameManager.instance.EsclamationStop();}
    else if (other.CompareTag("K_Player") && GameManager.instance.CharacterID == 2)
    {GameManager.instance.EsclamationStop();}
    else if (other.CompareTag("S_Player") && GameManager.instance.CharacterID == 3)
    {GameManager.instance.EsclamationStop();}
    }

    public void Touch()
    {
        if(canOpen){GameManager.instance.Esclamation();}
        else if(!canOpen){GameManager.instance.EsclamationStop();}
        if(Input.GetMouseButtonDown(0) && canOpen)
        {
        canOpen = false;
        IconSwitch.SetActive(false);
        IconGate.SetActive(false);
        Anm.Play("Switch_Anm");
        AnmGate.Play("GateOpen_Anm");
        Instantiate(VFXTake, transform.position, transform.rotation);
        VFXSegnal.SetActive(false);
        AudioManager.instance.PlaySFX(11);
        GameManager.instance.EsclamationStop();
        PlayerStats.instance.EventSwitchEnd(IDEvent);
        //print("Leva usata" + IDEvent);
        }
    }
}
