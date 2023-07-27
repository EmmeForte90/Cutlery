
using UnityEngine;


// BASE ITEM
public class Item : ScriptableObject
{
    public string itemName;

    public string itemDes;

    // The ID of every Item needs to be different in order to be saved and loaded 
    public int ID;
    
    [Tooltip("Che tipo di oggetto? 0-Item 1-Quest 2-Key 3-EquipFork 4-EquipKnife 5-EquipSpoon")]
    public int KindItem;

    // The price of an item can be used to set up a shop
    public int price;

    // If you want an item to be stackable, set this bool True
    public bool Stackable;

    // The UI icon of the item 
    public Sprite itemIcon;


    
    public virtual void Use()
    {
        //Use item
        //Use the following line if you want to destroy every item after use
        // Inventory.instance.RemoveItem(this, 1);
    }
}
