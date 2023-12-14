using UnityEngine;
using UnityEngine.UI;
using TMPro;

// IN THIS SCRIPT: Simple UI that shows the desription of the item that the player is currently with the mouse over
public class ItemInfoUpdate : MonoBehaviour
{
    public GameObject infoPanel;
    public bool HaveMoney = false;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI DesText;
    public TextMeshProUGUI MoneyText;
    public Image icon;
    public void UpdateInfoPanel(Item itemInfo)
    {
        if (itemInfo != null)
        {
            infoPanel.SetActive(true);
            nameText.text = itemInfo.itemName;
            DesText.text = itemInfo.itemDes;
            //icon.sprite = itemInfo.itemIcon;
             if(itemInfo.itemIcon != null){icon.sprite = itemInfo.itemIcon;}
            else if (itemInfo.itemIcon == null){icon.sprite = GameManager.instance.Inv.ItemsIcon[itemInfo.ID];}
            if(HaveMoney){MoneyText.text = itemInfo.price.ToString();}
        }
        else{infoPanel.SetActive(false);}
    }
    public void ClosePanel(){infoPanel.SetActive(false);}
}