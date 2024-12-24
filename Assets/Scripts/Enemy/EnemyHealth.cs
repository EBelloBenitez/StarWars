using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    // Global variables
    [Header("Health")] [SerializeField] private float maxHealth,
        currentHealth,
        damageBullet;

    [SerializeField] private Image healthBar;

    [Header("Effects")] [SerializeField] private ParticleSystem bigExplosion,
        smallExplosion;
    
    // Private variables
    [HideInInspector]
    public bool isDead;

    void Awake()
    {
        bigExplosion.Stop();
        smallExplosion.Stop();
        currentHealth = maxHealth;
        healthBar.fillAmount = 1;
        isDead = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BulletPlayer"))
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
        isDead = false;
        bigExplosion.Play();
        Destroy(gameObject, 1);
    }
}
