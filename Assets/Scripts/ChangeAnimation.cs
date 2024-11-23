using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAnimation : MonoBehaviour
{
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Jump
        if (Input.GetButtonDown("Jump"))
        {
            anim.SetTrigger("Jump");
        }

        // Walk / Sprint 
        // Handle Walking and Sprinting
        bool isWalking = Input.GetKey(KeyCode.W);
        bool isSprinting = Input.GetKey(KeyCode.LeftShift) && isWalking; // Sprint only if walking
        bool isWalkingBackward = Input.GetKey(KeyCode.S);
        bool isWalkingLeft = Input.GetKey(KeyCode.A);
        bool isWalkingRight = Input.GetKey(KeyCode.D);

        // Set walking and sprinting booleans based on input
        anim.SetBool("isWalking", isWalking && !isSprinting);  // Walk only if not sprinting
        anim.SetBool("isSprinting", isSprinting);  // Sprint if both W and Shift are pressed
        anim.SetBool("isWalkingBackward", isWalkingBackward);
        anim.SetBool("isWalkingLeft", isWalkingLeft);
        anim.SetBool("isWalkingRight", isWalkingRight);
    }

    public void PlayDownedAnimation()
    {
        anim.SetTrigger("Downed"); // Trigger for the downed animation
    }

    public void PlayReviveAnimation()
    {
        anim.SetTrigger("isRevived"); // Trigger for the player being revived
    }

    public void PlayRevivingAnimation()
    {
        anim.SetTrigger("Reviving"); // Trigger for the player performing the revive
    }
}
