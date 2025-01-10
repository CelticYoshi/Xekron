using System;
using UnityEngine;

public class LightMotion : MonoBehaviour
{
    [Header("Light Settings")]
    [Tooltip("Light to access intensity.")]
    public Light targetLight; // Light to access intensity

    [Tooltip("Speed of the intensity change.")]
    public float lightIntensitySpeed = 1.0f; // Speed of the intensity change

    [Tooltip("Minimum intensity.")]
    public float minIntensity = 0.5f; // Minimum intensity

    [Tooltip("Maximum intensity.")]
    public float maxIntensity = 2.0f; // Maximum intensity

    [Header("Sway Settings")]
    [Tooltip("Speed of the swaying motion.")]
    public float swaySpeed = 2.0f; // Speed of the swaying motion

    [Tooltip("Amount of swaying in Unity units.")]
    public float swayAmount = 1.0f; // Amount of swaying in Unity units

    [Tooltip("Enable swaying in the X direction.")]
    public bool swayX = true; // Enable swaying in the X direction

    [Tooltip("Enable swaying in the Y direction.")]
    public bool swayY = false; // Enable swaying in the Y direction

    [Tooltip("Enable swaying in the Z direction.")]
    public bool swayZ = false; // Enable swaying in the Z direction

    [Header("Rotation Settings")]
    [Tooltip("Speed of the rotation in degrees per second.")]
    public float rotationSpeed = 30.0f; // Speed of the rotation in degrees per second

    [Tooltip("Duration of the transition between rotation directions in seconds.")]
    public float transitionDuration = 2.0f;
    private bool rotateClockwise = true; // Clockwise rotate flag
    private float currentSpeed = 0f; // current speed rotational speed of light
    private float targetSpeed = 0f; // 
    private float transitionTimer = 0f;

    void Start()
    {
        rotateClockwise = true;
        targetSpeed = rotateClockwise ? rotationSpeed : -rotationSpeed;
        transitionTimer = transitionDuration;
    }
    void Update()
    {
        if (targetLight != null)
        {
            // Ping Pong light intensity
            float intensity = Mathf.PingPong(Time.time * lightIntensitySpeed, maxIntensity - minIntensity) + minIntensity;

            // Apply the intensity to the light
            targetLight.intensity = intensity;
            
            // Calculate the sway based on time and speed
            float horizontalSway = swayX ? Mathf.Sin(Time.time * swaySpeed) * swayAmount : 0f;
            float verticalSway = swayY ? Mathf.Sin(Time.time * swaySpeed) * swayAmount : 0f;
            float depthSway = swayZ ? Mathf.Sin(Time.time * swaySpeed) * swayAmount : 0f;

            // Apply the sway to the light's position
            Vector3 newPosition = targetLight.transform.position;
            newPosition.x = horizontalSway;
            newPosition.y = verticalSway;
            newPosition.z = depthSway;

            //Lerp target light
            targetLight.transform.position = newPosition;
            currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, transitionTimer / transitionDuration);

            // Rotate the object
            float rotationAmount = currentSpeed * Time.deltaTime;
            transform.Rotate(0f, 0f, rotationAmount);

            // Update transition timer
            transitionTimer += Time.deltaTime;

            // Check if transition is complete, then invert rotation direction, reset timer, and set target speed to 0
            if (transitionTimer >= transitionDuration)
            {
                rotateClockwise = !rotateClockwise;
                transitionTimer = 0f;
                targetSpeed = rotateClockwise ? rotationSpeed : -rotationSpeed;
            }
        }
        else
        {
            Debug.LogWarning("Target light is not assigned to the script.");
        }
    }
}


