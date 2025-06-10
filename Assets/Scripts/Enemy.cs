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

    void Start()
    {
        EnamyAnimation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            TakeDamge(Random.Range(5f, 20f));
        }

    }


    void TakeDamge(float force)
    {
        float newWidth = Mathf.Max(healthBar.sizeDelta.x - force, minWidth);
        healthBar.sizeDelta = new Vector2(newWidth, healthBar.sizeDelta.y);
        if (newWidth > 0)
        {
            EnamyAnimation.SetTrigger("HeadHitTrigger");

        }
        else
        {
            EnamyAnimation.SetTrigger("DeathTrigger");
            this.enabled = false;


        }

    }


}
