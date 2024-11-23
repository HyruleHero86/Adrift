using UnityEngine;
using UnityEngine.SceneManagement;

public class TaskManager : MonoBehaviour
{
    public void CompleteTask()
    {
        SceneManager.UnloadSceneAsync("Wire");
        if (GameStateManager.Instance != null)
        {
            GameStateManager.Instance.SaveInitialPlayerState(GameObject.FindWithTag("Player").transform);
        }
    }
}


