using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public Transform camara;
    
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;

    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    private bool isGrounded;

    float turnVelocitySmooth;
    float turnSmoothTime = 0.1f;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


        Vector3 move;
        float targetAngle;
        targetAngle = camara.eulerAngles.y;

        move = transform.forward * vertical + transform.right * horizontal;

        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnVelocitySmooth, turnSmoothTime);

        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        controller.Move(move * Time.deltaTime * playerSpeed);

        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {

            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
