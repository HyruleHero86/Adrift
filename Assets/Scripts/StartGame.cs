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
        GameStateManager.Instance.LoadInitialPlayerState(GameObject.FindWithTag("Player").transform);
    }
}

