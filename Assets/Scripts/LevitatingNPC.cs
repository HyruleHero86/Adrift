using UnityEngine;

public class LevitatingNPC : MonoBehaviour
{
    public float floatAmplitude = 0.5f; // How much the NPC will float up and down
    public float floatFrequency = 1f; // Speed of the floating movement
    public float rotationSpeed = 50f; // Speed of the rotation

    private Vector3 startPosition;

    void Start()
    {
        // Save the initial position of the NPC
        startPosition = transform.position;
    }

    void Update()
    {
        // Calculate the new Y position for the floating effect
        float newY = startPosition.y + Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;

        // Apply the new position to the NPC
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);

        // Apply a slow rotation around the Y axis
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}

