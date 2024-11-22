using UnityEngine;
using UnityEngine.SceneManagement;

public class Fusebox : MonoBehaviour, IInteractable
{
    public new Renderer renderer; // Assign this in the Inspector
    public Material highlightMaterial; // Assign this in the Inspector
    public Material originalMaterial; // Assign this in the Inspector

    private void Start()
    {
        // Ensure the original material is set at the start
        if (renderer == null)
        {
            renderer = GetComponent<Renderer>();
        }
        if (renderer != null)
        {
            originalMaterial = renderer.material;
        }
    }

    public void Interact()
    {
        // Logic to switch to the wire scene
        Debug.Log("Interacting with Fusebox");
        SceneManager.LoadScene(2); 
    }

    public void Highlight(bool highlight)
    {
        if (renderer == null)
        {
            Debug.LogError("Renderer is null in Highlight!");
            return;
        }
        renderer.material = highlight ? highlightMaterial : originalMaterial;
        Debug.Log($"Highlighting: {name} - {highlight}");
    }
}
