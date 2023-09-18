using UnityEngine.UI;
using UnityEngine;

public class FillSkill : MonoBehaviour
{
    public Image FillBar;
    public TimerSkill TS;
    void Update()
    {
    FillBar.fillAmount = TS.curTime / TS.itemInfo.TimeSpell;
    FillBar.fillAmount = Mathf.Clamp(FillBar.fillAmount, 0.01f, 1); 
    }
}