using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    public Animator anim;
    public HealthBar healthBar;
    public GameManager gameManager = new GameManager();

    void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
        healthBar.SetHealth(3);
    }
    
    public void GetDamage()
    {
        currentHealth -= 1;
        healthBar.SetHealth(currentHealth);
        if (currentHealth == 0)
        {
            anim.SetBool("isDead", true);
            
            FindObjectOfType<GameManager>().EnemyKill();

        }
        
    }
    public void OnCollisionEnter(Collision collision)
    {
        GetDamage();
    }

}
