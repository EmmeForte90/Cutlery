using UnityEngine;
using TMPro;
public class TimerSkill : MonoBehaviour
{
    [Header("Il timer è gestito dalle skill negli scriptable")]
    public Skill itemInfo;
    public GameObject Slot;
    public GameObject HandleObj;
    public GameObject HandleObjA;
    private float SpeedRestore = 1f; // il massimo valore di essenza disponibile
    [HideInInspector]public float curTime;
    private float TimeMin = 0f;
    private bool Start = true;        
    public TextMeshProUGUI Utilizzi;
    public static TimerSkill instance;
    private void Awake() {curTime = itemInfo.TimeSpell; if (instance == null){instance = this;}}    
    private void OnEnable(){Utilizzi.text = itemInfo.Utilizzi.ToString();}
    public void Update()
    {
        //FillBar.fillAmount = curTime / TimeMax;
        //FillBar.fillAmount = Mathf.Clamp(FillBar.fillAmount, 0.01f, 1);
        if(Start)
        {
        curTime -= SpeedRestore * Time.deltaTime;
        if(curTime <= TimeMin)
        {curTime = itemInfo.TimeSpell; //Start = false;
        if(Slot != null){Slot.SetActive(true);}
        if(HandleObj != null){HandleObj.SetActive(false);}
        Start = false;}   
        }
    }
    public void Notuse(){HandleObjA.SetActive(true);}
    public void Use(){HandleObjA.SetActive(false); Start = true;}
}