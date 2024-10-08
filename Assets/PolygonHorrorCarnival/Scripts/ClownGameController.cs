using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClownGameController : MonoBehaviour
{
    public GameObject clownHead;
    private float timeCounter = 0.0f;
    public float rotationAmount = 40f;

    [Range(0,5)]
    public float speed = 0.5f;

    private void Update()
    {
        float rotationSpeed = speed / rotationAmount;
        timeCounter += rotationAmount * Time.deltaTime * rotationSpeed;
        float rotationOffset = Mathf.Sin(timeCounter) * rotationAmount;
        clownHead.transform.localRotation = Quaternion.Euler(0, rotationOffset, 0);
    }
}
