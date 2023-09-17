using UnityEngine;
using UnityEngine.UI;
public class TimerSkill : MonoBehaviour
{
    [Header("Serve solo per riconoscere a quale slot appartiene questo timer")]   
    public string NameSpell;
    //public Image FillBar;
    public GameObject Slot;
    public GameObject HandleObj;
    public GameObject HandleObjA;
    public float SpeedRestore = 1f; // il massimo valore di essenza disponibile
    public float curTime = 10f;
    public float TimeMin = 0f;
    public float TimeMax = 10f;
    public bool Start = true;    
    public static TimerSkill instance;

    private void Awake() {curTime = TimeMax;if (instance == null){instance = this;}}    
    private void OnEnable(){Start = true;}
    public void Update()
    {
        //FillBar.fillAmount = curTime / TimeMax;
        //FillBar.fillAmount = Mathf.Clamp(FillBar.fillAmount, 0.01f, 1);
        if(Start)
        {
        curTime -= SpeedRestore * Time.deltaTime;
        if(curTime <= TimeMin)
        {curTime = TimeMax; //Start = false;
        if(Slot != null){Slot.SetActive(true);}
        if(HandleObj != null){HandleObj.SetActive(false);}} 
        }
    }
    public void Notuse(){HandleObjA.SetActive(true);}
    public void Use(){HandleObjA.SetActive(false);}
}