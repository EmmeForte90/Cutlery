using UnityEngine;
[CreateAssetMenu(fileName = "Consumable", menuName = "Item/Consumable")]
public class Consumable : Item
{
    public consumableType typeOfConsumable;
    public int HPRecover;
    /*public void Use(int whatDo)
    {        
        //base.Use();
        

    }*/
    public override void Sell()
    {
        base.Sell(); 
        GameManager.instance.money += price;
        Inventory.instance.RemoveItem(this, 1);
        Debug.Log("Hai Venduto!");
    }
    public enum consumableType { Potion, Food }
}