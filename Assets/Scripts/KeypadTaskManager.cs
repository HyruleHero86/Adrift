using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KeypadTaskManager : MonoBehaviour
{
    public Text youWinText; // Assign this in the inspector to your "Access Granted" UI Text element
    private bool isKeypadTaskCompleted = false;
    public KeypadSceneSetup keypadSceneSetup; // Assign this to your KeypadSceneSetup script in the inspector
    public string correctCode = "5567"; // The correct code to unlock
    private string inputCode = "";

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Ensure the "Access Granted" text is initially inactive
        if (youWinText != null)
        {
            youWinText.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (CheckKeypadTaskCompletion() && !isKeypadTaskCompleted)
        {
            isKeypadTaskCompleted = true;
            OnKeypadTaskComplete();
        }
    }

    public void AddDigit(string digit)
    {
        inputCode += digit;
        UpdateDisplay();
    }

    public void ClearCode()
    {
        inputCode = "";
        UpdateDisplay();
    }

    public void CheckCode()
    {
        if (inputCode == correctCode)
        {
            isKeypadTaskCompleted = true;
            OnKeypadTaskComplete();
        }
        else
        {
            youWinText.text = "Access Denied";
            Invoke("ClearCode", 1f); // Clear after 1 second
        }
    }

    bool CheckKeypadTaskCompletion()
    {
        return inputCode == correctCode;
    }

    void OnKeypadTaskComplete()
    {
        if (youWinText != null)
        {
            youWinText.gameObject.SetActive(true);
            youWinText.text = "Access Granted";
        }

        Invoke("ReturnToMainScene", 1f); // 1 seconds delay to display the text
    }

    void ReturnToMainScene()
    {
        keypadSceneSetup.ReturnToMainScene();
    }

    void UpdateDisplay()
    {
        // Update the UI display with the current input code
        // Assuming you have a Text component to display the input
    }
}
