using UnityEngine;
using UnityEngine.SceneManagement;

public class FuseBoxTrigger : MonoBehaviour
{
    public string LevelName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Ensure the wiring scene is added to the build settings
            SceneManager.LoadScene("Wire");
        }
    }
}
