using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerTarget : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;
    public Transform helthBarSlider;
    public SpriteRenderer glowSprite;
    public bool visibleHealthBar;

    private float regCooldown;
    
    private void Start()
    {
        maxHealth = GlobalStats.instance.Health;
        currentHealth = GlobalStats.instance.Health;
        GlobalStats.OnStatsChange += RecalulateMaxHP;
    }

    /*private void OnEnable()
    {
        GlobalStats.OnStatsChange += RecalulateMaxHP;
    }*/


    private void OnDisable()
    {
        GlobalStats.OnStatsChange-= RecalulateMaxHP;
    }


    private void Update()
    {
        if (regCooldown <= 0)
        {

        }    
    }

    public void Damage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.mass = 10000000;
            helthBarSlider.transform.localScale = new Vector3(0, 1);
           

        }
        else
        {
            helthBarSlider.transform.localScale = new Vector3(currentHealth / maxHealth, 1);
            DamageAnimation();

            Invoke("DefaultAnimation", .1f);
        }



    }

    private void DefaultAnimation()
    {
        glowSprite.enabled = false;
    }

    private void DamageAnimation()
    {
        glowSprite.enabled = true;

    }

    private void RecalulateMaxHP(object sender, EventArgs e)
    {
        maxHealth = GlobalStats.instance.Health;
        helthBarSlider.transform.localScale = new Vector3(currentHealth / maxHealth, 1);
        Debug.Log("RecalMAx");
    }

}
