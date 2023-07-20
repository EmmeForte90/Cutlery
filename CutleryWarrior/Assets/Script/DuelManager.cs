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

[Header("Stats")]

     public float maxHealth = 100f;
    public float currentHealth;
    public Scrollbar healthBar;
     public float maxMP = 100f;
    public float currentMP;
    public Scrollbar MPBar;
   
    public float SpeeRestore = 5f; // il massimo valore di essenza disponibile



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
        currentHealth = maxHealth;
        currentMP = maxMP;

    }
void Update()
    {
        healthBar.size = currentHealth / maxHealth;
        healthBar.size = Mathf.Clamp(healthBar.size, 0.01f, 1);
        //
        MPBar.size = currentMP / maxMP;
        MPBar.size = Mathf.Clamp(MPBar.size, 0.01f, 1);
        //
      


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

    

