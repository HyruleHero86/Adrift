using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAnimation : MonoBehaviour
{
    Animator anim;
    bool isDowned = false;
    bool isReviving = false;
    float reviveTime = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDowned)
        {
            return;
        }
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("NPC"))
        {
            isDowned = true;
            anim.SetTrigger("Downed");
            Debug.Log("Player is downed!");
        }
    }

    public void Revive()
    {
        if(isDowned && !isReviving)
        {
            StartCoroutine(RevivePlayer());
        }
    }

    IEnumerator RevivePlayer()
    {
        isReviving = true;
        Debug.Log("Reviving Player...");
        yield return new WaitForSeconds(reviveTime);
        isDowned = false;
        isReviving = false;
        anim.SetTrigger("Revived");
        Debug.Log("Player revived!");
    }
}
