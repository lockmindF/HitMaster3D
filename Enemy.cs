using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 4;
    public int currentHealth;

    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetHealth(4);
    }
    public void GetDamage()
    {
        currentHealth -= 1;
        healthBar.SetHealth(currentHealth);
    }
}
