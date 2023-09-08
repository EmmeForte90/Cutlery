
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpdatePreviewSkill : MonoBehaviour
{
    public GameObject infoPanel;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI DesText;
    public Image icon;    
    public void UpdateInfoPanel(Skill itemInfo)
    {
        if (itemInfo != null)
        {
            infoPanel.SetActive(true);
            nameText.text = itemInfo.itemName;
            DesText.text = itemInfo.itemDes;
            icon.sprite = itemInfo.itemIcon;
        }
        else{infoPanel.SetActive(false);}
    }
    public void ClosePanel(){infoPanel.SetActive(false);}
}
