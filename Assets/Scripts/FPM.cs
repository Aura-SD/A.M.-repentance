using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPM : MonoBehaviour
{
    public Transform camara;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

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

        Vector3 move = camara.forward * vertical + camara.right * horizontal;
        move.y = 0f; // Ensure movement stays horizontal

        Quaternion movementDirection = Quaternion.LookRotation(move);
        transform.rotation = Quaternion.Slerp(transform.rotation, movementDirection, turnSmoothTime * Time.deltaTime);

        controller.Move(move * Time.deltaTime * playerSpeed);

        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}