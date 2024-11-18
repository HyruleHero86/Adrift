using UnityEngine;

public class BatteryPoweredLight : MonoBehaviour
{
    public Light lightSource; // The light component
    public float maxBatteryLife = 300.0f; // Battery life in seconds
    private float currentBatteryLife;
    public float flickerThreshold = 60.0f; // When to start flickering (in seconds)
    public float maxFlickerFrequency = 0.1f; // Maximum frequency of flickering (when battery is almost 0)
    public string batteryItemName = "Battery"; // The name of the item that stops battery drain

    private bool hasBatteryItem = false;
    private PlayerInventory playerInventory;
    private float initialIntensity;

    void Start()
    {
        if (lightSource == null)
        {
            lightSource = GetComponent<Light>();
        }
        currentBatteryLife = maxBatteryLife;
        playerInventory = FindObjectOfType<PlayerInventory>(); // Assuming the player has a PlayerInventory component
        initialIntensity = lightSource.intensity;
    }

    void Update()
    {
        // Check if the player has the battery item
        hasBatteryItem = playerInventory != null && playerInventory.HasItem(batteryItemName);

        if (!hasBatteryItem)
        {
            DrainBattery();
        }
    }

    void DrainBattery()
    {
        if (currentBatteryLife > 0)
        {
            currentBatteryLife -= Time.deltaTime;

            if (currentBatteryLife <= flickerThreshold)
            {
                FlickerLight();
            }

            if (currentBatteryLife <= 0)
            {
                currentBatteryLife = 0;
                lightSource.enabled = false;
            }
        }
    }

    void FlickerLight()
    {
        float flickerProbability = Mathf.Lerp(0, maxFlickerFrequency, 1 - (currentBatteryLife / flickerThreshold));
        if (Random.value < flickerProbability)
        {
            lightSource.enabled = !lightSource.enabled;
        }
    }
}

public class PlayerInventory : MonoBehaviour
{
    // Simple inventory system for demonstration purposes
    public string[] inventoryItems;

    public bool HasItem(string itemName)
    {
        foreach (string item in inventoryItems)
        {
            if (item == itemName)
            {
                return true;
            }
        }
        return false;
    }
}
