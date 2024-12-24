using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class XwingHealth : MonoBehaviour
{
    // Global variables
    [Header("Health")] 
    [SerializeField] private float maxHealth,
                                   currentHealth,
                                   damageBullet;
    [SerializeField] private Image healthBar;

    [Header("Effects")] 
    [SerializeField] 
    private ParticleSystem bigExplosion,
                           smallExplosion;
    
    [Header("Others")] 
    [SerializeField] 
    private GameManager gameManager;


    void Awake()
    {
        bigExplosion.Stop();
        smallExplosion.Stop();
        currentHealth = maxHealth;
        healthBar.fillAmount = 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BulletEnemy"))
        {
            smallExplosion.Play();
            currentHealth -= damageBullet;
            healthBar.fillAmount = currentHealth / maxHealth;
            Destroy(other.gameObject);

            if (currentHealth <= 0)
            {
                Death();
            }
        }
    }

    private void Death()
    {
        gameManager.GameOver();
        bigExplosion.Play();
        Camera.main.transform.SetParent(null);
        Destroy(gameObject, 1);
    }
    
    
}
