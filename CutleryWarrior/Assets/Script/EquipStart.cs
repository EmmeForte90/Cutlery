using UnityEngine;

public class EquipStart : MonoBehaviour
{
    // Start is called before the first frame update
    public Item Potions;
    public Item K_Weapon;
    public Item K_Armor;
    public Item S_Weapon;
    public Item S_Armor;
    public Item F_Weapon;
    public Item F_Armor;
    public Item Amulet;
    public int specificQuant_K = 1;
    public int specificQuant_S = 1;
    public int specificQuant_F = 1;
    public int specificQuant_I = 1;
    public int specificQuant_M = 1;
    public int specificQuant = 10;
    void Start()
    {
        Inventory.instance.AddItem(Potions, specificQuant);  
        InventoryB.instance.AddItem(Potions, specificQuant);    
        QuestsManager.instance.AddItem(Amulet, specificQuant_M);                
        //               
        EquipM_F.instance.AddItem(F_Weapon, specificQuant); 
        EquipM_F.instance.AddItem(F_Armor, specificQuant); 
        //               
        EquipM_K.instance.AddItem(F_Weapon, specificQuant_K);   
        EquipM_K.instance.AddItem(F_Armor, specificQuant_K); 
        //                          
        EquipM_S.instance.AddItem(S_Armor, specificQuant_S);
        EquipM_S.instance.AddItem(S_Weapon, specificQuant_S);
        Destroy(gameObject);
    }
}