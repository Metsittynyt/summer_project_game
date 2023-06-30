using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    [SerializeField]
    float health;
    [SerializeField]
    float MAX_HEALTH = 100;

    public static Action OnPlayerDeath;
    public static Action OnEnemyDeath;

    void Start()
    {
        this.health = MAX_HEALTH;
        
    }

    // Update once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            Damage(10);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            // Heal(10);
        }
    }

    public void Damage(int amount)
    {
        Debug.Log(this.health);
        Debug.Log(this);
        this.health = this.GetComponent<Stats>().GetHealth();
        Debug.Log(gameObject.name + " takes " + amount + " damage.");

        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative damage");
        }
        //health -= amount;
        this.health = this.GetComponent<Stats>().UpdateHealth(amount);

        if (health <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative healing");
        }

        bool wouldBeOverMaxHealth = health + amount > MAX_HEALTH;

        if (health + amount > MAX_HEALTH)
        {
            this.health = MAX_HEALTH;
        }
        else
        {
            this.health += amount;
        }

        this.health += amount;
    }

    private void Die()
    {
        Destroy(gameObject);
        Debug.Log(gameObject.name + " died!");

        if (this.CompareTag("Player"))
        {
            Time.timeScale = 0;
            OnPlayerDeath?.Invoke();
        }
        else
        {
            OnEnemyDeath?.Invoke();
        }
    }

}