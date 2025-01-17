using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerTwo : MonoBehaviour
{
    public Transform objectToFollow;

    // Update is called once per frame
    void LateUpdate()
    {
       transform.position = objectToFollow.position;
       transform.rotation = objectToFollow.rotation; 
    }
}