using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpForce = 10f;                 //for our jump
    [SerializeField] private LayerMask groundLayer;                    // ensure player is touching the ground before next jump
    [SerializeField] private Transform feetPosition;
    [SerializeField] private float groundDist = 0.15f;
    [SerializeField] private float jumpTime = 0.3f;
    [SerializeField] private Transform FlameBoy;


    //for the crouch
    [SerializeField] private float crouchH = 0.2f;

    private bool isTGround = false;
    private bool isJumping = false;
    private float jumpT;

    private void Update()
    {
        isTGround = Physics2D.OverlapCircle(feetPosition.position, groundDist, groundLayer);

       

        if (isTGround && Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            rb.velocity = Vector2.up * jumpForce;
        }

        if (isJumping && Input.GetButton("Jump"))               // keeps applying the jump force to the play as you hold the key
        {
            if (jumpT < jumpTime)
            {
                rb.velocity = Vector2.up * jumpForce;

                jumpT += Time.deltaTime;        //if the time you hold the key dowwn by is longer than the jump, it will stop applying the jump force
                                                   // it starts the player falling
            }
            else
            {
                isJumping = false;          // meant to stop me from jumping in the air but needs work*****
            }

            if (Input.GetButtonUp("Jump"))
            {
                isJumping = false;
                jumpT = 0;
            }




        }
       if(isTGround && Input.GetButtonDown("Crouch"))               //CROUCHING CODE
        {
            FlameBoy.localScale = new Vector3(FlameBoy.localScale.x, crouchH, FlameBoy.localScale.z);

        }
       
        if (Input.GetButtonUp("Crouch"))
        {
            FlameBoy.localScale = new Vector3(FlameBoy.localScale.x, 0.5f, FlameBoy.localScale.z);
            
        }





    }
}
