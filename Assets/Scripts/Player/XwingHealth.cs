using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XwingHealth : MonoBehaviour
{
    // Global variables
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
    [SerializeField] private float damageBullet;
    [SerializeField] private Image healthBar;

    // Private variables


    void Awake()
    {
        currentHealth = maxHealth;
        healthBar.fillAmount = 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BulletEnemy"))
        {
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
        Camera.main.transform.SetParent(null);
        Destroy(gameObject);
    }
    
    
}
