using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerLight : MonoBehaviour
{
    public Light flickerLight;      // The light component to flicker
    public float minIntensity = 0.5f; // Minimum light intensity
    public float maxIntensity = 1.5f; // Maximum light intensity
    public float flickerSpeed = 0.1f; // Speed of flickering

    private float targetIntensity;
    private float time;

    void Start()
    {
        if (flickerLight == null)
        {
            flickerLight = GetComponent<Light>();
        }
        time = 0f;
        targetIntensity = Random.Range(minIntensity, maxIntensity);
    }

    void Update()
    {
        time += Time.deltaTime * flickerSpeed;
        if (time >= 1f)
        {
            time = 0f;
            targetIntensity = Random.Range(minIntensity, maxIntensity);
        }
        flickerLight.intensity = Mathf.Lerp(flickerLight.intensity, targetIntensity, time);
    }
}

