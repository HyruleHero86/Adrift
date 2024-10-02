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

        // Set walking and sprinting booleans based on input
        anim.SetBool("isWalking", isWalking && !isSprinting);  // Walk only if not sprinting
        anim.SetBool("isSprinting", isSprinting);  // Sprint if both W and Shift are pressed

    }
}
