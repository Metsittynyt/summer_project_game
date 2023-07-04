using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    [SerializeField]
    Character c;
    [SerializeField]
    private float health;
    private float MAX_HEALTH;
    public static Action OnPlayerDeath;
    public static Action OnEnemyDeath;

    public void Start()
    {
        this.MAX_HEALTH = c.MAX_HEALTH;
        this.health = c.MAX_HEALTH;
        Debug.Log(this.name + "'s health is " + this.health);
    }

    public void Damage(int amount)
    {
        Debug.Log(gameObject.name + " takes " + amount + " damage.");

        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative damage");
        }
        this.health -= amount;

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