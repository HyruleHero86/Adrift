using UnityEngine;

public class CameraActivation : MonoBehaviour
{
    public Camera mainCamera;    // Main camera to activate when clicked
    private bool isCameraActive = false;  // Flag to track if the camera is active

    void Update()
    {
        // Raycast to detect click on the object
        if (Input.GetMouseButtonDown(0)) // Left mouse button click
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                // Check if the object clicked is this object
                if (hit.collider.gameObject == gameObject)
                {
                    ActivateCamera();
                }
            }
        }

        // Deactivate the camera when pressing 'E'
        if (isCameraActive && Input.GetKeyDown(KeyCode.E))
        {
            DeactivateCamera();
        }
    }

    void ActivateCamera()
    {
        // Activate the main camera
        if (mainCamera != null)
        {
            mainCamera.gameObject.SetActive(true);  // Activate the main camera
            isCameraActive = true;  // Camera is now active
        }
    }

    void DeactivateCamera()
    {
        // Deactivate the main camera
        if (mainCamera != null)
        {
            mainCamera.gameObject.SetActive(false); // Deactivate the main camera
            isCameraActive = false;  // Camera is no longer active
        }
    }
}

