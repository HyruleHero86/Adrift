using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public Animator doorAnimator; // Animator component for the door

    private void Start()
    {
        if (Main.Instance != null && Main.Instance.wiresConnected)
        {
            ActivateDoorAnimation();
        }
    }

    private void ActivateDoorAnimation()
    {
        // Trigger the animation on the door
        doorAnimator.SetTrigger("OpenDoor");
    }
}
