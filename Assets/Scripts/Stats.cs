using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField]
    float health, MAX_HEALTH = 9f;
    
    private void Start() {
        health = MAX_HEALTH;
    }

    public float GetHealth () {
        Debug.Log("Stats script!");
        Debug.Log("Health: " + health);
        return health;
    }

    public float UpdateHealth ( float newHealth ) {
        Debug.Log("Stats script!");
        health = newHealth;
        Debug.Log("Health: " + health);
        return health;
    }
    
}