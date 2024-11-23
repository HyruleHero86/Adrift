using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public string LevelName;

    public void LoadLevel()
    {
        // Load the level asynchronously to ensure the GameStateManager remains in the scene
        StartCoroutine(LoadLevelCoroutine());
    }

    private IEnumerator LoadLevelCoroutine()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(LevelName);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // Load the player's initial position after the scene is loaded
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            GameStateManager.Instance.LoadInitialPlayerState(player.transform);
        }

        // Unlock the mouse cursor to allow players to click on buttons in the scene
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}


