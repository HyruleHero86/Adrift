using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitchWire : MonoBehaviour
{
    public string LevelName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(2);
        }
    }
}
