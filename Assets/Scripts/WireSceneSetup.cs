using UnityEngine;
using UnityEngine.SceneManagement;

public class WireSceneSetup : MonoBehaviour
{
    void Start()
    {
        // Make sure the cursor is visible and unlocked
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Method to return to the main scene and restore player position
    public void ReturnToMainScene()
    {
        SceneManager.UnloadSceneAsync("Wire").completed += OnWireSceneUnloaded;
    }

    private void OnWireSceneUnloaded(AsyncOperation obj)
    {
        float posX = PlayerPrefs.GetFloat("PlayerPosX");
        float posY = PlayerPrefs.GetFloat("PlayerPosY");
        float posZ = PlayerPrefs.GetFloat("PlayerPosZ");

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            player.transform.position = new Vector3(posX, posY, posZ);
        }

        SceneManager.LoadScene(1);
    }
}
