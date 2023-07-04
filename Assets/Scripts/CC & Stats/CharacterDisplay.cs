using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterDisplay : MonoBehaviour
{
    public Character character;
    public Image artworkImage;


    // Use this for initialization
    void Start()
    {
        Debug.Log(character.name);
        artworkImage.sprite = character.artwork;
    }

}
