using UnityEngine;
[CreateAssetMenu(fileName = "Skill", menuName = "Item/Skill")]
public class Skill : Item
{   
    public float MaxDuration;  // Durata desiderata per riempire la barra in secondi
    public float CostMP;
    [Tooltip("Che Character è? 0-Fork 1-Knife 2-Spoon")]
    [Range(0, 2)]
    public int WhoCH;
     [Tooltip("Che Skill è?")]
    [Range(0, 9)]
    public int WhoSkill;
}