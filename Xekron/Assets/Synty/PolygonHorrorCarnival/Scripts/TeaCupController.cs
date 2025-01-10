using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeaCupController : MonoBehaviour
{
    public GameObject platform;
    public GameObject teaPot;
    public Transform[] teaCups;

    [Range(-60,60)]
    public  float rideSpeed = 15.0f;
    void Update()
    {
        //main platform rotation speed
        platform.transform.Rotate(Vector3.up * rideSpeed * Time.deltaTime);

        //centre ornament (teapot) rotation speed 
        teaPot.transform.Rotate(Vector3.down * (rideSpeed*0.5f) * Time.deltaTime);

        //tea cup rotation's in relation to set ride speed
        foreach (Transform teacup in teaCups)
            {
                teacup.Rotate(Vector3.up * (rideSpeed * 1.5f ) * Time.deltaTime);
            }
    }
}
