using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    public Transform attackArea;
    public LayerMask enemyLayers;

    public float attackRange = 0.5f;
    public int attackDamage = 3;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
            Attack();
        }
    }

    void Attack() {
        // Play attack animation
        animator.SetTrigger("Attack");

        // Deteck enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackArea.position, attackRange, enemyLayers);
        
        // Damage enemies
        foreach(Collider2D enemy in hitEnemies) {
            Debug.Log("Player hit " + enemy.name + "!");
            enemy.GetComponent<Health>().Damage(attackDamage);
        }
        
    }

    void OnDrawGizmosSelected() {
        if (attackArea == null) {
            return;
        }
        Gizmos.DrawWireSphere(attackArea.position, attackRange);

    }
}
