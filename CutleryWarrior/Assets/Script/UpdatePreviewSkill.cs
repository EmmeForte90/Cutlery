
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpdatePreviewSkill : MonoBehaviour
{
    public Skill item;
    public GameObject infoPanel;
    public bool isRage = true;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI DesText;
    public TextMeshProUGUI Utilizzi;
    public Image icon; 
    public static UpdatePreviewSkill instance;
    private void Awake() {if (instance == null){instance = this;}} 

    public void OnEnable(){Utilizzi.text = item.Utilizzi.ToString();}

    public void UpdateInfoPanel(Skill itemInfo)
    {
        if (itemInfo != null)
        {
            infoPanel.SetActive(true);
            nameText.text = itemInfo.itemName;
            DesText.text = itemInfo.itemDes;
            icon.sprite = itemInfo.SkillIcon;
            if(!isRage){Utilizzi.text = itemInfo.Utilizzi.ToString();}
        }
        else{infoPanel.SetActive(false);}
    }
    public void RageUpdateInfoPanel(Skill itemInfo)
    {
        if (itemInfo != null)
        {
            infoPanel.SetActive(true);
            nameText.text = itemInfo.itemName;
            DesText.text = itemInfo.itemDes;
            icon.sprite = itemInfo.SkillIcon;
        }
        else{infoPanel.SetActive(false);}
    }
    public void ClosePanel(){infoPanel.SetActive(false);}
}