using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{
    public SpriteRenderer wireEnd;
    public GameObject lightOn;
    Vector3 startPoint;
    Vector3 startPosition;

    void Start()
    {
        startPoint = transform.parent.position;
        startPosition = transform.position;
    }

    private void OnMouseDrag()
    {
        // Convert mouse position to world point
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0;

        // Check for nearby connection points
        Collider2D[] colliders = Physics2D.OverlapCircleAll(newPosition, .2f);
        foreach (Collider2D collider in colliders)
        {
            // Ensure not my own collider
            if (collider.gameObject != gameObject)
            {
                // Update wire to the connection point position
                UpdateWire(collider.transform.position);

                // Check if the wires are the same color
                if (transform.parent.name.Equals(collider.transform.parent.name))
                {
                    // Count connection
                    Main.Instance.SwitchChange(1);
                    // Finish step
                    collider.GetComponent<Wire>()?.Done();
                    Done();
                }
                return;
            }
        }
        // Update wire
        UpdateWire(newPosition);
    }

    void Done()
    {
        // Turn on light
        lightOn.SetActive(true);

        // Destroy the script
        Destroy(this);
    }

    private void OnMouseUp()
    {
        // Reset wire position
        UpdateWire(startPosition);
    }

    void UpdateWire(Vector3 newPosition)
    {
        // Update position
        transform.position = newPosition;

        // Update direction
        Vector3 direction = newPosition - startPoint;
        transform.right = direction * transform.lossyScale.x;

        // Update scale
        float dist = Vector2.Distance(startPoint, newPosition);
        wireEnd.size = new Vector2(dist, wireEnd.size.y);
    }
}
