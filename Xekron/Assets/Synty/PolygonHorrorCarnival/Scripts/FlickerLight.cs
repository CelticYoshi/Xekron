using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerLight : MonoBehaviour
{
    public Light lightAsset;

    // min max intensities
    public float minIntensity = 1.25f;
    public float maxIntensity = 2f;


    public float flickerSpeed = 3.75f; // Speed of the flickering effect.
    public float smoothingFactor = 9f; // Controls the smoothness of intensity changes.

    private Coroutine flickerCoroutine;
    private float targetIntensity;

    void Start()
    {
        //check if there is a light
        if (lightAsset == null)
        {
            //attempt to get light transform if none is defined
            lightAsset = GetComponent<Light>();
            {
                //disable script if nothing is found
                if (!lightAsset)
                {
                    Debug.LogError("No Light Source Detected, Disabling Script:  " + transform.name);
                    enabled = false;
                    return;
                }
            }
        }

        flickerCoroutine = StartCoroutine(ambientLight());
    }

    IEnumerator ambientLight()
    {
        while (true)
        {
            //random initial target intensity
            targetIntensity = Random.Range(minIntensity, maxIntensity);

            float elapsedTime = 0f;
            float startIntensity = lightAsset.intensity;

            while (elapsedTime < 1f)
            {
                lightAsset.intensity = Mathf.SmoothStep(startIntensity, targetIntensity, elapsedTime);
                elapsedTime += Time.deltaTime * smoothingFactor;
                yield return null;
            }

            //time to wait before next flicker target
            yield return new WaitForSeconds(Random.Range(0.05f, 0.2f) / flickerSpeed);
        }
    }

    //stops coroutine if disabled in scene
    void OnDisable()
    {
        if (flickerCoroutine != null)
        {
            StopCoroutine(flickerCoroutine);
        }
    }
}