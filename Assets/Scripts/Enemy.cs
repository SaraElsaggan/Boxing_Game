using System.Collections;
using System.Collections.Generic;
// using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    // public Image healthBar;
    public Animator EnamyAnimation;
    public RectTransform healthBar;
    public float minWidth = 0f;       // Prevent it from going negative
    private List<string> myList = new List<string> { "StomchHitTrigger", "RibHitTrigger", "HeadHitTrigger" };
    public int enemyLevel;
    public AudioClip punch; // Reference to the AudioSource component
    public AudioClip win; // Reference to the AudioSource component
    public AudioClip start; // Reference to the AudioSource component
    private AudioSource audioSource;



    void Start()
    {
        EnamyAnimation = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(start);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            TakeDamge(Random.Range(5f, 20f), myList[Random.Range(0, myList.Count)]);
        }

    }


    void TakeDamge(float force, string triggerName)
    {
        float newWidth = Mathf.Max(healthBar.sizeDelta.x - (force / enemyLevel), minWidth);
        healthBar.sizeDelta = new Vector2(newWidth, healthBar.sizeDelta.y);
        if (newWidth > 0)
        {
            EnamyAnimation.SetTrigger(triggerName);
            audioSource.PlayOneShot(punch);
        }
        else
        {
            EnamyAnimation.SetTrigger("DeathTrigger");
            audioSource.PlayOneShot(win);
            this.enabled = false;


        }

    }


}
