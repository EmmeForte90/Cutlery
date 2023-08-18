using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KindOrder : MonoBehaviour
{
    public UIRotationSwitcher rotationSwitcher;
    public GameObject Order_F;
    public GameObject Order_K;
    public GameObject Order_S;
    public GameObject Order_FD;
    public GameObject Order_KD;
    public GameObject Order_SD;
    public void Update()
    {
      switch(rotationSwitcher.CharacterID)
        {
            case 1:
            Order_F.SetActive(false);Order_K.SetActive(true);Order_S.SetActive(true);
            //
            Order_FD.SetActive(true);Order_KD.SetActive(false);Order_SD.SetActive(false);
            break;
            case 2:
            Order_K.SetActive(false);Order_F.SetActive(true);Order_S.SetActive(true);
            Order_KD.SetActive(true);Order_FD.SetActive(false);Order_SD.SetActive(false);
            break;
            case 3:
            Order_S.SetActive(false);Order_F.SetActive(true);Order_K.SetActive(true);
            Order_SD.SetActive(true);Order_FD.SetActive(false);Order_KD.SetActive(false);
            break;
        }
    }
}
