using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBattle : MonoBehaviour
{
    public UIRotationSwitcher rotationSwitcher;
    public GameObject Skill_F;
    public GameObject Skill_K;
    public GameObject Skill_S;
    public GameObject Skill_FI;
    public GameObject Skill_KI;
    public GameObject Skill_SI;
    public void Update()
    {
      switch(rotationSwitcher.CharacterID)
        {
            case 1:
            Skill_F.SetActive(true);Skill_K.SetActive(false);Skill_S.SetActive(false);
            Skill_FI.SetActive(true);Skill_KI.SetActive(false);Skill_SI.SetActive(false);
            break;
            case 2:
            Skill_K.SetActive(true);Skill_F.SetActive(false);Skill_S.SetActive(false);
            Skill_KI.SetActive(true);Skill_FI.SetActive(false);Skill_SI.SetActive(false);
            break;
            case 3:
            Skill_S.SetActive(true);Skill_F.SetActive(false);Skill_K.SetActive(false);
            Skill_SI.SetActive(true);Skill_FI.SetActive(false);Skill_KI.SetActive(false);
            break;
        }
    }
}
