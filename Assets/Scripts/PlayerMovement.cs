using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float rotateSpeed;
    public float jumpForce;
    public float horizontalInput;
    public float forwardInput;
    public float jumpInput;
    private float gravityModifier = 1.5f;
    private Rigidbody playerRb;
    public bool isOnGround = true;


    void Start()
    {
        Physics.gravity *= gravityModifier;
        playerRb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");


        Vector3 movement = new Vector3 (horizontalInput, 0.0f, forwardInput);
        playerRb.AddForce(movement * rotateSpeed);


        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }
}
