using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SaveTotem : MonoBehaviour
{
    public Vector3 savedPosition;
    public string NameScene;
    private SwitchCharacter Switch;
    public GameObject VFXTake;
    private Transform Player;
    private Transform Fork;
    private Transform Spoon;
    private Transform Knife;
    private bool Var_1 = false;
    private bool Var_2 = true;
    private bool Var_3 = false;

    public void Start()
        {
        if (Switch == null) {Switch = GameObject.Find("EquipManager").GetComponent<SwitchCharacter>();} 
        //if (Dati == null) {Dati = GameObject.Find("Stats").GetComponent<PlayerStats>();} 
        if(GameManager.instance.F_Unlock){Fork = GameObject.Find("F_Player").transform;}
        if(GameManager.instance.S_Unlock){Spoon = GameObject.Find("S_Player").transform;}
        if(GameManager.instance.K_Unlock){Knife = GameObject.Find("K_Player").transform;}
        }
    public void Update()
    {
    if(Switch.isElement1Active)
    {if(GameManager.instance.S_Unlock && Var_1){Spoon = GameObject.Find("S_Player").transform;} 
    Player = Spoon; Var_1 = false; Var_2 = true;}
    else 
    if(Switch.isElement2Active && Var_2)
    {if(GameManager.instance.F_Unlock){Fork = GameObject.Find("F_Player").transform;} 
    Player = Fork;  Var_2 = false; Var_3 = true;} 
    else 
    if(Switch.isElement3Active && Var_3)
    {if(GameManager.instance.K_Unlock){Knife = GameObject.Find("K_Player").transform;} 
    Player = Knife; Var_3 = false; Var_1 = true;} 
    }

    private void OnTriggerEnter(Collider collision)
    {
    if (collision.CompareTag("F_Player") || collision.CompareTag("K_Player") || collision.CompareTag("S_Player"))
    {      
        Instantiate(VFXTake, transform.position, transform.rotation);
        AudioManager.instance.PlaySFX(12);
        if(GameManager.instance.F_Unlock){
        PlayerStats.instance.F_curHP = PlayerStats.instance.F_HP;
        PlayerStats.instance.F_curMP = PlayerStats.instance.F_MP;}
        //
        if(GameManager.instance.K_Unlock){
        PlayerStats.instance.K_curHP = PlayerStats.instance.K_HP;
        PlayerStats.instance.K_curMP = PlayerStats.instance.K_MP;}
        //
        if(GameManager.instance.S_Unlock){
        PlayerStats.instance.S_curHP = PlayerStats.instance.S_HP;
        PlayerStats.instance.S_curMP = PlayerStats.instance.S_MP;}
        
        savedPosition = Player.transform.position; 
        GameManager.instance.savedPosition = savedPosition;
        PlayerStats.instance.savedPosition = savedPosition;
        PlayerStats.instance.HaveData = true;
        PlayerStats.instance.NameScene = NameScene;
        PlayerStats.instance.UpdateInventorySaving();
        //SaveManager.instance.SalvaDati(Dati);
        print("Hai salvato");
    }
    }
}