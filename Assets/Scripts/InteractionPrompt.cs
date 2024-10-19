using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionPrompt : MonoBehaviour
{

    public Text promptText;
    public float interactionDistance = 3f;
    public LayerMask interactableLayer;

    void Update()
    {
        {
            if (promptText == null)
            {
                Debug.LogError("Prompt Text is not assigned!");
                return;
            }
                Ray ray = new Ray(transform.position, transform.forward);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, interactionDistance, interactableLayer))
                {
                    IInteractable interactable = hit.collider.GetComponent<IInteractable>();
                    if (interactable != null)
                    {
                        promptText.gameObject.SetActive(true);

                        if (Input.GetButtonDown("Interact"))
                        {
                            interactable.Interact();
                        }
                    }
                    else
                    {
                        promptText.gameObject.SetActive(false);
                    }
                }
                else
                {
                    promptText.gameObject.SetActive(false);
                }
            }
        }
    }
