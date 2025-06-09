using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    // public Image healthBar;
    public Scrollbar healthBar;
    public Animator EnamyAnimation;

    public float helathAmount = 100f;
    public bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        EnamyAnimation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead) return;
        if (Input.GetKeyDown(KeyCode.Z))
        {
            EnamyAnimation.SetTrigger("HitToBodyTrigger");
            TakeDamge(20);

        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            EnamyAnimation.SetTrigger("HeadHitTrigger");
            TakeDamge(20);

        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            EnamyAnimation.SetTrigger("StomchHitTriggerr");
            TakeDamge(20);

        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            EnamyAnimation.SetTrigger("KickTrigger");
            TakeDamge(20);

        }

    }

    void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.size = helathAmount / 100;
        }
    }
    void TakeDamge(float force)
    {
        helathAmount = Mathf.Max(0, helathAmount - force);
        if (helathAmount <= 0)
        {
            EnamyAnimation.SetTrigger("DeathTrigger");
            isDead = true;

        }
        UpdateHealthBar();
    }


}
