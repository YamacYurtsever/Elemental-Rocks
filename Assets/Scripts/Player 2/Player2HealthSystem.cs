using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2HealthSystem : MonoBehaviour
{
    //Public Variables
    public int currentHealth;
    public int maxHealth = 500;
    public Animator animator;
    public Player2HealthBar healthBar;

    //Private Variables
    private GameObject healthTextObject;
    private Rigidbody2D rb;

    private void Start()
    {
        //Connections
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int damage)
    {
        //Take Damage
        currentHealth -= damage;
        animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            healthBar.SetHealth(0);
            //Death Animation
            Destroy(gameObject);
        }

        else
        {
            healthBar.SetHealth(currentHealth);
        }
    }
}