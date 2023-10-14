using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	private CharacterController characterController;
	public float speed = 5f;
    private float gravity = -9.81f;
    public float jumpForce = 3f;
    private Vector3 playerVelocity;
    private bool isGrounded;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {

		isGrounded = characterController.isGrounded;
        
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(x, 0, z);
        move = transform.TransformDirection(move);
        move *= speed * Time.deltaTime;
        characterController.Move(move);

		if (Input.GetButton("Jump") && isGrounded)
        {
            playerVelocity.y += Mathf.Sqrt(jumpForce * -gravity);
        }

        playerVelocity.y += gravity * Time.deltaTime;
        characterController.Move(playerVelocity * Time.deltaTime);
    }
}
