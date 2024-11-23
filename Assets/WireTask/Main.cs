using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public static Main Instance;

    public int switchCount; // Total number of switches that need to be turned on
    public GameObject winText; // The UI text element that displays "You did it!"
    private int onCount = 0; // Current count of switches that are turned on
    public bool wiresConnected = false;

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

    public void SwitchChange(int points)
    {
        onCount += points; // Update the count of switches that are turned on
        if (onCount >= switchCount)
        {
            winText.SetActive(true); // Display the "You did it!" text
            wiresConnected = true;
            StartCoroutine(ReturnToMainScene()); // Start the coroutine to return to the main scene
        }
    }

    // Coroutine to return to the main scene after a delay
    private IEnumerator ReturnToMainScene()
    {
        yield return new WaitForSeconds(1f); // Wait for 1 seconds
        SceneManager.LoadScene(1); // Assuming Scene 1 is the main scene
    }
}
