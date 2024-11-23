using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuitAndReturnScript : MonoBehaviour
{
    public Button quitButton; // Reference to the UI Button for quitting the application
    public string titleSceneName = "Title"; // Name of the title scene to return to
    public string[] mouseClickScenes; // List of scenes that require mouse clicks

    private bool isCursorUnlocked = false; // Track the cursor state

    private void Start()
    {
        // Add a listener to the quit button to call the Quit method when clicked
        if (quitButton != null)
        {
            quitButton.onClick.AddListener(Quit);
        }

        // Unlock the cursor if the current scene requires mouse clicks
        if (IsMouseClickScene(SceneManager.GetActiveScene().name))
        {
            UnlockCursor();
        }
        else
        {
            LockCursor();
        }
    }

    private void Update()
    {
        // Check if the escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isCursorUnlocked)
            {
                ReturnToTitle();
            }
            else
            {
                UnlockCursor();
            }
        }
    }

    // Method to return to the title scene
    public void ReturnToTitle()
    {
        SceneManager.LoadScene(titleSceneName);
        if (IsMouseClickScene(titleSceneName))
        {
            UnlockCursor();
        }
        else
        {
            LockCursor();
        }
    }

    // Method to quit the application
    public void Quit()
    {
        // If we are running in a standalone build of the game
#if UNITY_STANDALONE
        // Quit the application
        Application.Quit();
#endif

        // If we are running in the editor
#if UNITY_EDITOR
        // Stop playing the scene
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    // Method to unlock the cursor
    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isCursorUnlocked = true;
    }

    // Method to lock the cursor
    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isCursorUnlocked = false;
    }

    // Check if the given scene name is in the list of mouse click scenes
    private bool IsMouseClickScene(string sceneName)
    {
        foreach (string mouseClickScene in mouseClickScenes)
        {
            if (mouseClickScene == sceneName)
            {
                return true;
            }
        }
        return false;
    }
}



