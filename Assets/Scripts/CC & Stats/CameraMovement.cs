using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private Transform targetToFollow;
    
    void Update() {
        transform.position = new Vector3(
            Mathf.Clamp(targetToFollow.position.x, 0f, 500f),
            Mathf.Clamp(targetToFollow.position.y, -10f, 10f),
            transform.position.z);
    }
}