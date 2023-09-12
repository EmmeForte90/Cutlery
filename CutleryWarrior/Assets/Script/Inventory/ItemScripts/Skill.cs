using UnityEngine;
using UnityEditor;
[CreateAssetMenu(fileName = "Skill", menuName = "Item/Skill")]
public class Skill : Item
{   
    public float MaxDuration;  // Durata desiderata per riempire la barra in secondi
    public bool isRage = false;
    public float CostMP;
    [Tooltip("Che Character è? 0-Fork 1-Knife 2-Spoon")]
    [Range(0, 2)]
    public int WhoCH;
     [Tooltip("Che Skill è?")]
    [Range(0, 10)]
    public int WhoSkill;
    //Il time skill NON è il tempo per attivare la skill, ma il tempo per farla finire una volta lanciata per
    //sapere quanto tempo serve per lanciare la skill guarda nello script "TimerSkill"
    public int TimeSkill;
    //[HideInInspector]
    public int Utilizzi;
    public int UtilizziMAX;
    #if UNITY_EDITOR
    private void OnDisable()
    {
    // reset dei bool quando la modalità Play di Unity viene terminata
    if (!EditorApplication.isPlaying){Utilizzi = UtilizziMAX;}
    }
    #endif
}