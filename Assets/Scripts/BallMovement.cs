using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.1f);

        // Movement on PC
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Movement on Android
        float touchHorizontalInput = Input.acceleration.x;
        float touchVerticalInput = Input.acceleration.y;

        Vector3 movement;

        if (Mathf.Abs(touchHorizontalInput) > 0.1f || Mathf.Abs(touchVerticalInput) > 0.1f)
        {
            // Use accelerometer input on Android if it's significant
            movement = new Vector3(touchHorizontalInput, 0, touchVerticalInput);
        }
        else
        {
            // Use keyboard input on PC
            movement = new Vector3(horizontalInput, 0, verticalInput);
        }

        // Apply movement to the Rigidbody
        rb.velocity = new Vector3(movement.x * moveSpeed, rb.velocity.y, movement.z * moveSpeed);

        // Jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}

