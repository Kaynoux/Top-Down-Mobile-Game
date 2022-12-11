using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Target : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public Transform helthBarSlider;
    public SpriteRenderer glowSprite;
    public bool isBoss;

    private void Start()
    {
        currentHealth = maxHealth;
    }
    public void Damage(float _damage, bool _isCritical)
    {
        DamagePopup.Create(transform.position, _damage, _isCritical, false);
        currentHealth -= _damage;
        if(currentHealth <= 0)
        {
            if (isBoss)
            {
                MainSpawner.instance.isPauseSpawning = false;
            }
            MainSpawner.instance.enemys.Remove(transform);
            Destroy(gameObject);
            
        }
        else
        {
            if (isBoss)
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
