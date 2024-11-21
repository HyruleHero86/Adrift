using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WireTaskManager : MonoBehaviour
{
    public Text youWinText; // Assign this in the inspector to your "You Win" UI Text element
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

    // This method should contain your actual task completion check logic
    bool CheckWireTaskCompletion()
    {
        return wiresConnected == 4; // Assuming 4 wires need to be connected
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
        Invoke("ReturnToMainScene", 3f); // 3 seconds delay
    }

    void ReturnToMainScene()
    {
        SceneManager.LoadScene(1); // Assuming Scene 1 is the main scene
    }

    // Method to simulate connecting a wire (Call this method when a wire is connected)
    public void ConnectWire()
    {
        wiresConnected++;
    }
}
