using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 100;
    private int MAX_HEALTH = 100;

    public static Action OnPlayerDeath;
    public static Action OnEnemyDeath;


    // Update once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.H)) {
            // Damage(10);
        }

        if (Input.GetKeyDown(KeyCode.R)) {
            // Heal(10);
        }
    }

    public void Damage(int amount) {
        if (amount < 0) {
            throw new System.ArgumentOutOfRangeException("Cannot have negative damage");
        }
        this.health -= amount;

        if ( health <= 0) {
            Die();
        }
    }

    public void Heal(int amount) {
        if (amount < 0) {
            throw new System.ArgumentOutOfRangeException("Cannot have negative healing");
        }

        bool wouldBeOverMaxHealth = health + amount > MAX_HEALTH;

        if (health + amount > MAX_HEALTH) {
            this.health = MAX_HEALTH;
        } else {
            this.health += amount;
        }

        this.health += amount;
    }

    private void Die() {
        Debug.Log("Player is dead. Rip player :( ");
        Destroy(gameObject);

        if (this.CompareTag("Player")) {
            Time.timeScale = 0;
            OnPlayerDeath?.Invoke();
        }
        else {
            OnEnemyDeath?.Invoke();
        }
    }

}