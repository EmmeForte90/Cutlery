using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using Spine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using Cinemachine;
using UnityEngine.UI;
using TMPro;

public class DuelManager : MonoBehaviour
{

[Header("Pause")]
    public bool stopInput = false;
    [SerializeField]  GameObject Pause;
    [SerializeField]  GameObject Item;
    [SerializeField]  GameObject Skill;
    public bool inputCTR = false;

[Header("AnimationUI")]
public Animator animator;


public static DuelManager instance;
private void Awake()
    {
         if (instance == null)
        {
            instance = this;
        }
        Animator animator = GetComponent<Animator>();


    }
void Update()
    {
    if(!inputCTR)
    {
       if (Input.GetButtonDown("Pause") && !stopInput)
        {
            stopInput = true;
            StartCoroutine(StartM());
        }
        else if(Input.GetButtonDown("Pause") && stopInput)
        {
            stopInput = false;
            ToggleTimeScale();
            Skill.gameObject.SetActive(false);
            Item.gameObject.SetActive(false);
            StartCoroutine(EndP());
        } 
    }
    }
IEnumerator StartM()
    {
        InputBattle.instance.inputCTR = true;
        Pause.gameObject.SetActive(true);
        animator.SetTrigger("Open");
        yield return new WaitForSeconds(1f);
        ToggleTimeScale();
    }
IEnumerator EndP()
    {
        animator.SetTrigger("Close");
        yield return new WaitForSeconds(1f);
        Pause.gameObject.SetActive(false);
        InputBattle.instance.inputCTR = false;

    }
private void ToggleTimeScale()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0.01f; // Rallenta il gioco a metà velocità
        }
        else
        {
            Time.timeScale = 1; // Ripristina la velocità normale del gioco
        }
    }









}

    

