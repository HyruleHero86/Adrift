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
    internal bool wiresConnected;

    private void Awake()
    {
        Instance = this;
    }

    public void SwitchChange(int points)
    {
        onCount += points; // Update the count of switches that are turned on
        if (onCount >= switchCount)
        {
            winText.SetActive(true); // Display the "You did it!" text
            StartCoroutine(ReturnToMainScene()); // Start the coroutine to return to the main scene
        }
    }

    // Coroutine to return to the main scene after a delay
    private IEnumerator ReturnToMainScene()
    {
        yield return new WaitForSeconds(3f); // Wait for 3 seconds
        SceneManager.LoadScene(1); // Assuming Scene 1 is the main scene
    }
}
