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
            SaveState(other.transform);
            SceneManager.LoadScene("Wire", LoadSceneMode.Additive);
        }
    }

    private void SaveState(Transform playerTransform)
    {
        GameStateManager.Instance.SaveInitialPlayerState(playerTransform);
    }
}

