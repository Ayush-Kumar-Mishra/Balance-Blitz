using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public Transform groundCheck; // Reference to the ground check point
    public LayerMask groundLayer; // Layer(s) to consider as ground

    private Rigidbody rb;
    private bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Perform the ground check
        isGrounded = Physics.Raycast(groundCheck.position, Vector3.down, 0.1f, groundLayer);
    }

    private void FixedUpdate()
    {
        // Perform physics-based actions here
        if (isGrounded)
        {
            // The ball is grounded, you can apply jumping or other actions here
        }
    }
}
