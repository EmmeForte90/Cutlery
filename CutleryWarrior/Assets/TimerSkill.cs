using UnityEngine;
using UnityEngine.UI;
public class TimerSkill : MonoBehaviour
{
    public Image FillBar;
    public GameObject Slot;
    public GameObject HandleObj;
    public float SpeedRestore = 1f; // il massimo valore di essenza disponibile
    public float curTime = 10f;
    public float TimeMin = 0f;
    public float TimeMax = 10f;
    public bool Start = false;    
    public void Update()
    {
        FillBar.fillAmount = curTime / TimeMax;
        FillBar.fillAmount = Mathf.Clamp(FillBar.fillAmount, 0.01f, 1);
        if(Start){
        curTime -= SpeedRestore * Time.deltaTime;
        if(curTime <= TimeMin)
        {curTime = TimeMax; Start = false;
        Slot.SetActive(true);
        HandleObj.SetActive(false);} 
        }
    }
    public void Timer(){Start = true;}
}