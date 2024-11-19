using UnityEngine;
using UnityEngine.UI;

public class StartLight : MonoBehaviour
{
    public Light targetLight; // The light to flicker
    public Button flickerButton; // The button to trigger flickering
    public float flickerDuration = 1.0f; // Duration of the flicker effect
    public float flickerSpeed = 0.1f; // Speed of the flicker effect

    private bool isFlickering = false;

    void Start()
    {
        // Add a listener to the button to call the FlickerLight method when clicked
        if (flickerButton != null)
        {
            flickerButton.onClick.AddListener(FlickerLight);
        }
    }

    void FlickerLight()
    {
        if (!isFlickering)
        {
            StartCoroutine(Flicker());
        }
    }

    System.Collections.IEnumerator Flicker()
    {
        isFlickering = true;
        float endTime = Time.time + flickerDuration;

        while (Time.time < endTime)
        {
            targetLight.enabled = !targetLight.enabled;
            yield return new WaitForSeconds(flickerSpeed);
        }

        // Ensure the light is on at the end of the flicker effect
        targetLight.enabled = true;
        isFlickering = false;
    }
}
