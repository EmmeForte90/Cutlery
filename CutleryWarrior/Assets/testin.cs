using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testin : MonoBehaviour
{
    public int IdSkill;
    public void addskill()
    {
        PlayerStats.instance.FSkillATT(IdSkill);
    }
}
