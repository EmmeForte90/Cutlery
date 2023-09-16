using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Spine.Unity.AttachmentTools;
using Spine;
using Spine.Unity;
public class UIRotationSwitcher : MonoBehaviour
{
    #region Header
    public GameObject element1;
    public GameObject element2;
    public GameObject element3;
    public float switchSpeed = 5f;
    public Color color1;
    public Color color2;
    private Vector3 element1StartPosition;
    private Vector3 element2StartPosition;
    private Vector3 element3StartPosition;
    private bool isElement1Active = true;
    private bool isElement2Active = false;
    private bool isElement3Active = false;
    public GameObject M_F;
    public GameObject M_K;
    public GameObject M_S;
    public GameObject D_F;
    public GameObject D_K;
    public GameObject D_S;
    public int CharacterID = 1;
    public int CharacterIDSec = 3;
    public int CharacterIDTer = 2;
    public Spine.Unity.SkeletonGraphic skeletonGraphic1;
    public GameObject F_Puppet;
    public Spine.Unity.SkeletonGraphic skeletonGraphic2;
    public GameObject S_Puppet;
    public Spine.Unity.SkeletonGraphic skeletonGraphic3;
    public GameObject K_Puppet;

    [Header("Fork")]
    public Scrollbar FhealthBar;
    //public Image FRageBar;
    //public GameObject MaxRageF;
    public Scrollbar FMPBar;
    [Header("Knife")]
    //public float KcurrentHealth;
    public Scrollbar KhealthBar;
    //public Image KRageBar;
    //public GameObject MaxRageK;
    public Scrollbar KMPBar;
    [Header("Spoon")]
    //public float ScurrentHealth;
    public Scrollbar ShealthBar;
    //public Image SRageBar;
    //public GameObject MaxRageS;
    public Scrollbar SMPBar;
    public static UIRotationSwitcher instance;
    #endregion
    public void Start()
    {
        if (instance == null){instance = this;}
        // Salva le posizioni iniziali degli elementi
        element1StartPosition = element1.transform.position;
        element2StartPosition = element2.transform.position;
        element3StartPosition = element3.transform.position;
        CharacterID = 1;
        CharacterIDSec = 3;
        CharacterIDTer = 2;
       // Assicurati che il componente SkeletonGraphic sia assegnato nell'ispettore di Unity
        if (skeletonGraphic1 == null){Debug.LogError("SkeletonGraphic is not assigned!");return;}
        // Imposta il colore iniziale
        SetColor1(color1);
        SetColor2(color2);
        SetColor3(color2);
    }
    private void SetColor1(Color color){if(GameManager.instance.F_Unlock){skeletonGraphic1.color = color;}}
    private void SetColor2(Color color){if(GameManager.instance.S_Unlock){skeletonGraphic2.color = color;}}
    private void SetColor3(Color color){if(GameManager.instance.K_Unlock){skeletonGraphic3.color = color;}}
    public void Update()
    {
        if(!GameManager.instance.F_Unlock){F_Puppet.SetActive(false);}
        else if(GameManager.instance.F_Unlock){F_Puppet.SetActive(true);}
        if(!GameManager.instance.K_Unlock){K_Puppet.SetActive(false);}
        else if(GameManager.instance.K_Unlock){K_Puppet.SetActive(true);}
        if(!GameManager.instance.S_Unlock){S_Puppet.SetActive(false);}
        else if(GameManager.instance.S_Unlock){S_Puppet.SetActive(true);}
        //
        if(GameManager.instance.F_Unlock){
        FhealthBar.size = PlayerStats.instance.F_curHP / PlayerStats.instance.F_HP;
        FhealthBar.size = Mathf.Clamp(FhealthBar.size, 0.01f, 1);
        //
        FMPBar.size = PlayerStats.instance.F_curMP / PlayerStats.instance.F_MP;
        FMPBar.size = Mathf.Clamp(FMPBar.size, 0.01f, 1);
        //
        //FRageBar.fillAmount = PlayerStats.instance.F_curRage / PlayerStats.instance.F_Rage;
        //FRageBar.fillAmount = Mathf.Clamp(FRageBar.fillAmount, 0.01f, 1);}
        }
        ////////////////////////////////////////////////////////
        if(GameManager.instance.K_Unlock){
        KhealthBar.size = PlayerStats.instance.K_curHP / PlayerStats.instance.K_HP;
        KhealthBar.size = Mathf.Clamp(KhealthBar.size, 0.01f, 1);
        //
        KMPBar.size = PlayerStats.instance.K_curMP / PlayerStats.instance.K_MP;
        KMPBar.size = Mathf.Clamp(KMPBar.size, 0.01f, 1);
        //
        //KRageBar.fillAmount = PlayerStats.instance.K_curRage / PlayerStats.instance.K_Rage;
        //KRageBar.fillAmount = Mathf.Clamp(KRageBar.fillAmount, 0.01f, 1);}
        }
        //////////////////////////////////////////////////////////
        if(GameManager.instance.S_Unlock){
        ShealthBar.size = PlayerStats.instance.S_curHP / PlayerStats.instance.S_HP;
        ShealthBar.size = Mathf.Clamp(ShealthBar.size, 0.01f, 1);
        //
        SMPBar.size = PlayerStats.instance.S_curMP / PlayerStats.instance.S_MP;
        SMPBar.size = Mathf.Clamp(SMPBar.size, 0.01f, 1);
        //
        //SRageBar.fillAmount = PlayerStats.instance.S_curRage / PlayerStats.instance.S_Rage;
        //SRageBar.fillAmount = Mathf.Clamp(SRageBar.fillAmount, 0.01f, 1);}
        //           
        }
    if (Input.GetKeyDown(KeyCode.Space)){SwitchElement(); AudioManager.instance.PlayUFX(3);}
    }
    
    private void SwitchElement()
    {// Switcha tra gli elementi
    if (CharacterID == 1)
    {
        StartCoroutine(MoveElement(element1, element1StartPosition));
        StartCoroutine(MoveElement(element2, element2StartPosition));
        StartCoroutine(MoveElement(element3, element3StartPosition));
        if(GameManager.instance.F_Unlock){M_F.SetActive(true);}
        if(GameManager.instance.K_Unlock){M_K.SetActive(false);}
        if(GameManager.instance.S_Unlock){M_S.SetActive(false);}
        if(GameManager.instance.F_Unlock){D_F.SetActive(true);}
        if(GameManager.instance.K_Unlock){D_K.SetActive(false);}
        if(GameManager.instance.S_Unlock){D_S.SetActive(false);}
        SetColor1(color1);
        SetColor2(color2);
        SetColor3(color2);
        isElement1Active = false;
        isElement2Active = true;
    }
    else if (CharacterID == 2)
    {
        StartCoroutine(MoveElement(element1, element2StartPosition));
        StartCoroutine(MoveElement(element2, element3StartPosition));
        StartCoroutine(MoveElement(element3, element1StartPosition));
        if(GameManager.instance.F_Unlock){M_F.SetActive(false);}
        if(GameManager.instance.K_Unlock){M_K.SetActive(true);}
        if(GameManager.instance.S_Unlock){M_S.SetActive(false);}
        if(GameManager.instance.F_Unlock){D_F.SetActive(false);}
        if(GameManager.instance.K_Unlock){D_K.SetActive(true);}
        if(GameManager.instance.S_Unlock){D_S.SetActive(false);}
        SetColor1(color2);
        SetColor2(color2);
        SetColor3(color1);
        isElement2Active = false;
        isElement3Active = true;
    }
    else if (CharacterID == 3)
    {
        StartCoroutine(MoveElement(element3, element2StartPosition));
        StartCoroutine(MoveElement(element2, element1StartPosition));
        StartCoroutine(MoveElement(element1, element3StartPosition));
        if(GameManager.instance.F_Unlock){M_F.SetActive(false);}
        if(GameManager.instance.K_Unlock){M_K.SetActive(false);}
        if(GameManager.instance.S_Unlock){M_S.SetActive(true);}
        if(GameManager.instance.F_Unlock){D_F.SetActive(false);}
        if(GameManager.instance.K_Unlock){D_K.SetActive(false);}
        if(GameManager.instance.S_Unlock){D_S.SetActive(true);}
        SetColor1(color2);
        SetColor2(color1);
        SetColor3(color2);
        isElement3Active = false;
        isElement1Active = true;
    }
}
    private IEnumerator MoveElement(GameObject element, Vector3 targetPosition)
    {
        Quaternion startRotation = element.transform.rotation;
        Vector3 startPosition = element.transform.position;
        float elapsedTime = 0f;
        while (elapsedTime < switchSpeed)
        {
            float t = elapsedTime / switchSpeed;
            element.transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            element.transform.rotation = Quaternion.Slerp(startRotation, Quaternion.identity, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        element.transform.position = targetPosition;
        element.transform.rotation = Quaternion.identity;
    }
}