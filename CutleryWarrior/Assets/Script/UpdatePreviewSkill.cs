
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpdatePreviewSkill : MonoBehaviour
{
    public GameObject infoPanel;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI DesText;
    public TextMeshProUGUI Utilizzi;
    public Image icon; 
    public static UpdatePreviewSkill instance;
    private void Awake() {if (instance == null){instance = this;}}    
   
    public void UpdateInfoPanel(Skill itemInfo)
    {
        if (itemInfo != null)
        {
            infoPanel.SetActive(true);
            nameText.text = itemInfo.itemName;
            DesText.text = itemInfo.itemDes;
            icon.sprite = itemInfo.itemIcon;
            Utilizzi.text = itemInfo.Utilizzi.ToString();
        }
        else{infoPanel.SetActive(false);}
    }
    public void ClosePanel(){infoPanel.SetActive(false);}
}