using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractableObject : MonoBehaviour
{
    private bool isInteracting = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isInteracting)
        {
            isInteracting = true;
            SaveState();
            SceneManager.LoadScene("Wire", LoadSceneMode.Additive);
        }
    }

    private void SaveState()
    {
        // Implement your state-saving logic here
        // For example, save the player's position, game objects states, etc.
    }
}

