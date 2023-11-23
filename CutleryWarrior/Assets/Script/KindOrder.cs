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
            case 1://Fork
            if(!GameManager.instance.F_Die)
            {
            Order_F.SetActive(false);Order_K.SetActive(true);Order_S.SetActive(true);
            //
            Order_FD.SetActive(true);Order_KD.SetActive(false);Order_SD.SetActive(false);
            }else if(GameManager.instance.F_Die){Order_FD.SetActive(true); Order_F.SetActive(false);}
            break;
            case 2: //Knife
            if(!GameManager.instance.K_Die)
            {
            Order_K.SetActive(false);Order_F.SetActive(true);Order_S.SetActive(true);
            //
            Order_KD.SetActive(true);Order_FD.SetActive(false);Order_SD.SetActive(false);
            }else if(GameManager.instance.K_Die){Order_KD.SetActive(true); Order_K.SetActive(false);}
            break;
            case 3://Spoon
            if(!GameManager.instance.S_Die)
            {
            Order_S.SetActive(false);Order_F.SetActive(true);Order_K.SetActive(true);
            //
            Order_SD.SetActive(true);Order_FD.SetActive(false);Order_KD.SetActive(false);
            }else if(GameManager.instance.S_Die){Order_SD.SetActive(true); Order_S.SetActive(false);}
            break;
        }
    }
}
