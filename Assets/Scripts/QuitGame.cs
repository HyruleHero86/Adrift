using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject menuPanel; // Reference to the menu panel
    public Text controlsText;    // Reference to the controls text (use TextMeshProUGUI if using TextMeshPro)
    public Slider volumeSlider;  // Reference to the volume slider
    public Button backButton;    // Reference to the back button

    private void Start()
    {
        // Set up initial states
        menuPanel.SetActive(false);

        // Set the controls text
        controlsText.text = "W - Move Forward\n" +
                            "S - Move Backward\n" +
                            "A - Move Left\n" +
                            "D - Move Right\n" +
                            "Space - Jump\n" +
                            "Left Shift - Sprint\n" +
                            "E - Player Interaction\n";

        // Add listener for volume slider
        volumeSlider.onValueChanged.AddListener(SetVolume);

        // Add listener for back button
        backButton.onClick.AddListener(CloseMenu);
    }

    private void Update()
    {
        // Open the menu when the Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OpenMenu();
        }
    }

    private void OpenMenu()
    {
        menuPanel.SetActive(true);
        Time.timeScale = 0f; // Pause the game
    }

    private void CloseMenu()
    {
        menuPanel.SetActive(false);
        Time.timeScale = 1f; // Resume the game
    }

    private void SetVolume(float value)
    {
        AudioListener.volume = value;
    }
}

