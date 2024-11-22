using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class WireTaskManager : MonoBehaviour
{
    public TextMeshProUGUI youWinText;
    private bool isWireTaskCompleted = false;
    private int wiresConnected = 0; // To track the number of wires connected

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Ensure the "You Win" text is initially inactive
        if (youWinText != null)
        {
            youWinText.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (CheckWireTaskCompletion() && !isWireTaskCompleted)
        {
            isWireTaskCompleted = true;
            OnWireTaskComplete();
        }
    }

    bool CheckWireTaskCompletion()
    {
        return wiresConnected == 4; 
    }

    void OnWireTaskComplete()
    {
        // Display the "You did it!" text
        if (youWinText != null)
        {
            youWinText.gameObject.SetActive(true);
            youWinText.text = "You did it!";
        }

        // After displaying the text, return to the main scene
        Invoke("ReturnToMainScene", 1f); // 1 seconds delay
    }

    void ReturnToMainScene()
    {
        SceneManager.LoadScene(1);
    }

    // Method to simulate connecting a wire (Call this method when a wire is connected)
    public void ConnectWire()
    {
        wiresConnected++;
    }
}
