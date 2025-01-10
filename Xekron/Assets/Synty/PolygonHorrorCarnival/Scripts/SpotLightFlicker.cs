using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLightFlicker : MonoBehaviour
{
    public Light spotLight;

    //time between main flicker
    public float flickerInterval = 7.0f;

    //max intensity (set by gameobject light in void start)
    private float maxIntensity;
    public float minIntensity = 0.5f;

    //intervals between flickering light on/off & amount of times to flicker to simulate "malfunctioning"
    private int burstAmount;
    private int burst = 3;
    private float burstInterval = 0.2f;

    private float burstTimer;

    [Header("Random Power Loss")]
    public bool PowerLossEnable;
    public ParticleSystem sparks;

    private Coroutine flickerSpotlightCoroutine;

    void Start()
    {
        //check if there is a light
        if (spotLight == null)
        {
            //attempt to get light transform if none is defined
            spotLight = GetComponent<Light>();
            {
                //disable script if nothing is found
                if (!spotLight)
                {
                    Debug.LogError("No Light Source Detected, Disabling Script:  " + transform.name);
                    enabled = false;
                    return;
                }
            }
        }

        flickerSpotlightCoroutine = StartCoroutine(flickerSpotLight());
    }

    IEnumerator flickerSpotLight()
    {
        //initial random values to base flickering off
        burstAmount = Random.Range(0, burst);
        maxIntensity = spotLight.intensity;
        burstTimer = Random.Range(flickerInterval / 2f, flickerInterval);
        float minIntensityVariation = minIntensity;
        float maxIntensityVariation = maxIntensity;


        //preset clamp values for instantiated material emission color to usuable values and get material.
        float minIntensityEmission = minIntensity / maxIntensity;

        //run indefinetely
        while (true)
        {
            yield return new WaitForSeconds(burstTimer);

            //run this x times based on random burst amount, each burst randomises some slight intensity and intervals
            for (int i = 0; i < burstAmount; i++)
            {

                spotLight.intensity = minIntensityVariation;
                yield return new WaitForSeconds(Random.Range(burstInterval * .1f, burstInterval * 1.5f));
                spotLight.intensity = maxIntensity;
                yield return new WaitForSeconds(Random.Range(burstInterval * .1f, burstInterval));
                minIntensityVariation = Random.Range(minIntensity, minIntensity * 1.2f);

                minIntensityEmission = minIntensityVariation / maxIntensity;

            }

            //get new random ranges for next burst, flicker interval and reset light to original values
            burstAmount = Random.Range(0, burst);
            burstTimer = Random.Range(flickerInterval * 0.8f, flickerInterval * 1.1f);
            spotLight.intensity = maxIntensity;

            int powerCheck = Random.Range(1, 10);
            if (PowerLossEnable && powerCheck == 1)
            {
                spotLight.intensity = 0;
                if (sparks)
                {
                    ParticleSystem ps = (ParticleSystem)Instantiate(sparks, spotLight.transform.position, spotLight.transform.rotation);
                    Destroy(ps.gameObject, ps.main.duration * 1.5f);
                }
                yield return new WaitForSeconds(Random.Range(flickerInterval, flickerInterval * 2));
            }
        }
    }

    //stops coroutine if disabled in scene
    void OnDisable()
    {
        if (flickerSpotlightCoroutine != null)
        {
            StopCoroutine(flickerSpotlightCoroutine);
        }
    }

}
