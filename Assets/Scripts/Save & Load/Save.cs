using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    public int playerHealth;
    public int MAX_HEALTH = 20;
    public int level = 1;

    public void GetHealth () {
        Debug.Log("Save script!");
    }
    public void SavePlayer () {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer () {
        PlayerData data = SaveSystem.LoadPlayer();

        level = data.level;
        playerHealth = data.health;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }
}