using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    [SerializeField] private int damage = 3;

    private void OnTriggerEnter2D(Collider2D collider) {

        if (collider.GetComponent<Health>() != null) {
            Health health = collider.GetComponent<Health>();
            Debug.Log("Enemy's health should decrease");
            health.Damage(damage);
        }
        
    }
}
