using UnityEngine;
using UnityEngine.UI;
public class TimerSkill : MonoBehaviour
{
    public Image FillBar;
    public GameObject Slot;
    public GameObject HandleObj;
    public GameObject HandleObjA;
    public float SpeedRestore = 1f; // il massimo valore di essenza disponibile
    private float curTime = 10f;
    private float TimeMin = 0f;
    public float TimeMax = 10f;
    public bool Start = true;    
    public static TimerSkill instance;

    private void Awake() {curTime = TimeMax;if (instance == null){instance = this;}}    
    private void OnEnable(){Start = true;}
    public void Update()
    {
        FillBar.fillAmount = curTime / TimeMax;
        FillBar.fillAmount = Mathf.Clamp(FillBar.fillAmount, 0.01f, 1);
        if(Start)
        {
        curTime -= SpeedRestore * Time.deltaTime;
        if(curTime <= TimeMin)
        {curTime = TimeMax; //Start = false;
        Slot.SetActive(true);
        HandleObj.SetActive(false);} 
        }
    }
    public void Notuse(){HandleObjA.SetActive(true);}
    public void Use(){HandleObjA.SetActive(false);}
}