using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    private Rigidbody rb;

    public static bool isGrounded;
    public GameObject nextLevelImg;
    public GameObject player;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

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
        if (Input.GetButtonDown("Jump")/* & isGrounded*/)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Diamond" || other.gameObject.tag == "Start_Txt" || other.gameObject.tag == "End_Txt")
        {
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            nextLevelImg.gameObject.SetActive(true);
            Destroy(player.gameObject);
        }

        if(collision.gameObject.tag == "Restrict")
        {
            Destroy(this.gameObject);
        }

        if(collision.gameObject.tag == "Obs1")
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator Respawn()
    {
        yield return null;
    }
}

