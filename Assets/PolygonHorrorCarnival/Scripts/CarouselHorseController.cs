using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarouselHorseController : MonoBehaviour
{
    private Vector3 originalLocalPosition; // Original local position
    public float maxDistance = 0.4f;
    public float speed = 0.3f;
    public bool reverseMotion = false;    // Reverse the motion

    private float startTime;
    private bool movingToEnd = true;

    private void Start()
    {
        originalLocalPosition = transform.localPosition;
        startTime = Time.time;
    }


    // Used to smooth out the motion as it reaches its destinations
    private float SmoothStep(float t)
    {
        return t * t * (3f - 2f * t);
    }

    private void Update()
    {
        float distanceCovered = (Time.time - startTime) * speed;
        float fractionOfJourney = distanceCovered / maxDistance;
        fractionOfJourney = Mathf.Clamp01(fractionOfJourney);

        if (reverseMotion)
        {
            movingToEnd = !movingToEnd;
            reverseMotion = false;
        }

        //get Original position to know where to return
        Vector3 startLocalPosition = originalLocalPosition;

        //get Target position to move to. Change Vector3.up to change direction of where Target is. 
        Vector3 endLocalPosition = originalLocalPosition + Vector3.up * maxDistance;

        // Used to track local position of objects if parent shapes are moving in scene
        if (transform.parent != null)
        {
            Matrix4x4 parentMatrix = transform.parent.localToWorldMatrix;

            startLocalPosition = parentMatrix.MultiplyPoint3x4(startLocalPosition);
            endLocalPosition = parentMatrix.MultiplyPoint3x4(endLocalPosition);
        }

        // Move objects to target destination
        if (movingToEnd)
        {
            float easedFraction = SmoothStep(fractionOfJourney);
            transform.position = Vector3.Lerp(startLocalPosition, endLocalPosition, easedFraction);
        }
        else
        {
            float easedFraction = SmoothStep(fractionOfJourney);
            transform.position = Vector3.Lerp(endLocalPosition, startLocalPosition, easedFraction);
        }

        if (fractionOfJourney >= 1.0f)
        {
            movingToEnd = !movingToEnd;
            startTime = Time.time;
        }
    }
}