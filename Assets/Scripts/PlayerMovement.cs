using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private float speed = 10.0f;
    private float turnSpeed = 40.0f;
    //private float jumpSpeed = 10.0f;
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
        //jumpInput = Input.GetAxis("Jump");



        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);
        //transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        //transform.Translate(Vector3.up * Time.deltaTime * jumpSpeed * jumpInput);


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
