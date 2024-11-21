using UnityEngine;
using UnityEngine.SceneManagement;

public class FuseBoxTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Ensure the wiring scene is added to the build settings
            SceneManager.LoadScene("Wire");
        }
    }
}
