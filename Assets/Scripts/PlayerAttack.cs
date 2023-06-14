using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private GameObject attackArea = default;
    private bool attacking = false;
    public Animator animator;
    private float timeToAttack = 0.4f;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        // Enter is key to attck
        if (Input.GetKeyDown(KeyCode.Return)) {
            Debug.Log("ATTACK!");
            Attack();
        }

        if (attacking) {
            timer += Time.deltaTime;
            if (timer >= timeToAttack) {
                timer = 0;
                attacking = false;
                animator.SetBool("IsAttacking", false);
                Debug.Log("attacking is false");
                attackArea.SetActive(attacking);
            }
        }
    }

    private void Attack() {
        attacking = true;
        if (attacking == true) {
            animator.SetBool("IsAttacking", true);
            Debug.Log("attacking is true");
        }
        attackArea.SetActive(attacking);
    }
}
