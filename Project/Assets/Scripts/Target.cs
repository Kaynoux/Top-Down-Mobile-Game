using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Target : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public Transform helthBarSlider;
    public SpriteRenderer glowSprite;
    public bool visibleHealthBar;
    public bool isPlayer;

    private void Start()
    {
        currentHealth = maxHealth;
    }
    public void Damage(float damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            if (isPlayer)
            {
                transform.rotation = Quaternion.Euler(0, 0, 90);
                Rigidbody2D rb = GetComponent<Rigidbody2D>();
                rb.mass = 10000000;
                helthBarSlider.transform.localScale = new Vector3(0, 1);
            }
            else
            {
                Destroy(gameObject);
            }
            
        }
        else
        {
            if (visibleHealthBar)
            {
                helthBarSlider.transform.localScale = new Vector3(currentHealth / maxHealth, 1);
            }
           
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


}
