using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Character", menuName = "Character")]
public class Character : ScriptableObject
{
    public new string name;
    public Sprite artwork;

    public int attackPower;

    public float currentHealth;
    public float MAX_HEALTH;
    public float movementSpeed;
}
