using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;

    private Vector3 initialPlayerPosition;
    private Quaternion initialPlayerRotation;
    private Vector3 playerPosition;
    private Quaternion playerRotation;
    private bool hasSavedInitialState = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveInitialPlayerState(Transform playerTransform)
    {
        if (!hasSavedInitialState)
        {
            initialPlayerPosition = playerTransform.position;
            initialPlayerRotation = playerTransform.rotation;
            hasSavedInitialState = true;
        }
    }

    public void SavePlayerState(Transform playerTransform)
    {
        playerPosition = playerTransform.position;
        playerRotation = playerTransform.rotation;
    }

    public void LoadPlayerState(Transform playerTransform)
    {
        playerTransform.position = playerPosition;
        playerTransform.rotation = playerRotation;
    }

    public void LoadInitialPlayerState(Transform playerTransform)
    {
        playerTransform.position = initialPlayerPosition;
        playerTransform.rotation = initialPlayerRotation;
    }
}
