using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Spine.Unity.AttachmentTools;
using Spine;
using Spine.Unity;
public class UIRotationSwitcher : MonoBehaviour
{
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
        
    public Spine.Unity.SkeletonGraphic skeletonGraphic1;
    public Spine.Unity.SkeletonGraphic skeletonGraphic2;
    public Spine.Unity.SkeletonGraphic skeletonGraphic3;
  
    private void Start()
    {
        // Salva le posizioni iniziali degli elementi
        element1StartPosition = element1.transform.position;
        element2StartPosition = element2.transform.position;
        element3StartPosition = element3.transform.position;

       // Assicurati che il componente SkeletonGraphic sia assegnato nell'ispettore di Unity
        if (skeletonGraphic1 == null)
        {
            Debug.LogError("SkeletonGraphic is not assigned!");
            return;
        }

        // Imposta il colore iniziale
        SetColor1(color1);
        SetColor2(color2);
        SetColor3(color2);
    }
private void SetColor1(Color color)
    {
        // Imposta il colore sull'elemento SkeletonGraphic
        skeletonGraphic1.color = color;
    }
private void SetColor2(Color color)
    {
        // Imposta il colore sull'elemento SkeletonGraphic
        skeletonGraphic2.color = color;
    }
    private void SetColor3(Color color)
    {
        // Imposta il colore sull'elemento SkeletonGraphic
        skeletonGraphic3.color = color;
    }


    private void Update()
    {
        // Verifica l'input dell'utente per switchare tra gli elementi
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwitchElement();
        }
    }

    private void SwitchElement()
{
    // Switcha tra gli elementi
    if (isElement1Active)
    {
        StartCoroutine(MoveElement(element1, element2StartPosition));
        StartCoroutine(MoveElement(element2, element3StartPosition));
        StartCoroutine(MoveElement(element3, element1StartPosition));
        SetColor1(color2);
        SetColor2(color2);
        SetColor3(color1);


        isElement1Active = false;
        isElement2Active = true;
    }
    else if (isElement2Active)
    {
        StartCoroutine(MoveElement(element3, element2StartPosition));
        StartCoroutine(MoveElement(element2, element1StartPosition));
        StartCoroutine(MoveElement(element1, element3StartPosition));
        SetColor1(color2);
        SetColor2(color1);
        SetColor3(color2);

        isElement2Active = false;
        isElement3Active = true;
    }
    else if (isElement3Active)
    {
        StartCoroutine(MoveElement(element1, element1StartPosition));
        StartCoroutine(MoveElement(element2, element2StartPosition));
        StartCoroutine(MoveElement(element3, element3StartPosition));
        SetColor1(color1);
        SetColor2(color2);
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