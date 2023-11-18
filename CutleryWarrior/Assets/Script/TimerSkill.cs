using UnityEngine;
using TMPro;
public class TimerSkill : MonoBehaviour
{ 
     [Tooltip("Che tipo di timer è? 0-Skill 1-Item ")]
    [Range(0, 1)]
    public int whatIs;
    [Header("Il timer è gestito dalle skill negli scriptable")]
    public Skill itemInfo;
    public GameObject Slot;
    public GameObject HandleObj;
    public GameObject HandleObjA;
    private float SpeedRestore = 1f; // il massimo valore di essenza disponibile
    [HideInInspector]public float curTime;
    [HideInInspector]public float TimeMin = 0f;
    private bool Start = true;        
    public TextMeshProUGUI Utilizzi;
    public static TimerSkill instance;
    private void Awake() 
    { 
        if (instance == null){instance = this;}
    switch(whatIs)
    {
    case 0:
    curTime = itemInfo.TimeSpell;
    break;
    case 1:
    curTime = 0.5f;
    break;
    }
 
    }    
    private void OnEnable()
    {
        switch(whatIs)
    {
    case 0:
    Utilizzi.text = itemInfo.Utilizzi.ToString();
    break;
    }
    }

    public void Update()
    {
        if(Start)
        {

        switch(whatIs)
        {
        case 0:
        curTime -= SpeedRestore * Time.deltaTime;
        if(curTime <= TimeMin)
        {curTime = itemInfo.TimeSpell; //Start = false;
        if(Slot != null){Slot.SetActive(true);}
        if(HandleObj != null){HandleObj.SetActive(false);}
        Start = false;}
        break; 
        case 1:
        curTime -= SpeedRestore * Time.deltaTime;
        if(curTime <= TimeMin)
        {curTime = 0.5f;Start = false;}
        break;
        }
    }
    }
    public void Notuse(){HandleObjA.SetActive(true);}
    public void Use(){HandleObjA.SetActive(false); Start = true;}
}