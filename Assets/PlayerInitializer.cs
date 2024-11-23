using UnityEngine;

public class PlayerInitializer : MonoBehaviour
{
    private void Start()
    {
        // Ensure the player starts in the initial position when the game begins
        GameStateManager.Instance.LoadInitialPlayerState(transform);
    }
}

