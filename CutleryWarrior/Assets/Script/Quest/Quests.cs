using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CreateAssetMenu(fileName ="New Quest", menuName = "Quest/Create New Quest")]
public class Quests : ScriptableObject
{public int id;
[Tooltip("Che tipo di Quest è? 0-Importante 1-Raccolta 2-Caccia 3-Varie")]
public int KindQuest;
public string CharacterName;
[TextArea(3, 10)]
public string questName;
[TextArea(3, 10)]
public string Description;
//public int value;
//public Sprite icon;
public Sprite Bigicon;
public Sprite Desicon;

[SerializeField][TextArea(3, 10)]
public string[] Startdialogue; // array of string to store the dialogues
[SerializeField][TextArea(3, 10)]
public string[] Middledialogue; // array of string to store the dialogues
[SerializeField][TextArea(3, 10)]
public string[] Endingdialogue; // array of string to store the dialogues
[SerializeField][TextArea(3, 10)]
public string[] Afterdialogue; // array of string to store the dialogues
//
public bool isActive;
public bool isComplete;
public bool AfterQuest;
#if UNITY_EDITOR
private void OnDisable()
{// reset dei bool quando la modalità Play di Unity viene terminata
if (!EditorApplication.isPlaying){isActive = false; isComplete = false; AfterQuest = false;}}
#endif
}