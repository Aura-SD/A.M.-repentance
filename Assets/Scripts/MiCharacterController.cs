using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiCharacterController : MonoBehaviour
{
    [SerializeField]
    private CharacterController controller;
    [SerializeField]
    private Animator anim;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 10f;
    private float sprintSpeed = 20f;
    private float jumpHeight = 2.0f;
    private float gravityValue = -15f;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        anim = gameObject.GetComponent<Animator>();
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

        float sprinting = Input.GetAxis("Fire3");

        Vector3 move;

        move = transform.forward * vertical + transform.right * horizontal;

        controller.Move(move * Time.deltaTime * (playerSpeed + sprinting * sprintSpeed));

        anim.SetFloat("SpeedX", horizontal);
        anim.SetFloat("SpeedZ", vertical);
        anim.SetFloat("SpeedMag", move.magnitude);



        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}