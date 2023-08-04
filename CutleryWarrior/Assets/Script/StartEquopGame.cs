using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartEquopGame : MonoBehaviour
{
//Se vuoi inserire oggetti o equipaggiamenti all'inizio del gioco, puoi farlo da questo script.


    public Item WeaponKnife;
    public Item WeaponFork;
    public Item WeaponSpoon;
    public Item ArmorKnife;
    public Item ArmorFork;
    public Item ArmorSpoon;
 [Tooltip("Che tipo di oggetto? 0-Item 1-Quest 2-Key 3-Weapom 4-Armor")]
    private int KindItem1;
     private int KindItem2;
    private int KindItem3;
    private int KindItem4;
    private int KindItem5;
    private int KindItem6;

    private int specificQuant = 1;
public void Awake() 
    {KindItem1 = WeaponKnife.KindItem;
    KindItem2 = WeaponFork.KindItem;
    KindItem3 = WeaponSpoon.KindItem;
    KindItem4 = ArmorKnife.KindItem;
    KindItem5 = ArmorFork.KindItem;
    KindItem6 = ArmorSpoon.KindItem;}
    void Start()
    {
     
          EquipM_F.instance.AddItem(WeaponFork, specificQuant);            
          EquipM_F.instance.AddItem(ArmorKnife, specificQuant);               
            
          EquipM_K.instance.AddItem(WeaponKnife, specificQuant);            
          EquipM_K.instance.AddItem(ArmorKnife, specificQuant);             
            
          EquipM_S.instance.AddItem(WeaponSpoon, specificQuant);            
          EquipM_S.instance.AddItem(ArmorSpoon, specificQuant);            
            
     }
       
} 
    

   
