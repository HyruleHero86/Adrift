using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;

    private Vector3 initialPlayerPosition;
    private Quaternion initialPlayerRotation;
    private bool initialPositionSet = false;

    private void Awake()
    {
        // Ensure there's only one instance of the GameStateManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // Persist across scenes
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Save the initial position when the game starts
    public void SaveInitialPlayerState(Transform playerTransform)
    {
        initialPlayerPosition = playerTransform.position;
        initialPlayerRotation = playerTransform.rotation;
        initialPositionSet = true;
    }

    // Load the saved initial position when the scene loads
    public void LoadInitialPlayerState(Transform playerTransform)
    {
        if (initialPositionSet)
        {
            playerTransform.position = initialPlayerPosition;
            playerTransform.rotation = initialPlayerRotation;
        }
    }
}

