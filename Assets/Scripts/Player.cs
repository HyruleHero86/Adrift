using UnityEngine;

public class Player : MonoBehaviour
{
    private void OnEnable()
    {
        GameStateManager.Instance.LoadPlayerState(transform);
    }
}

