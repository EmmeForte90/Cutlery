using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using Cinemachine;

public class loading : MonoBehaviour
{
    public int Time;
    public LevelChanger Function;
    public void Start(){Function.LoadingEnd();}
}