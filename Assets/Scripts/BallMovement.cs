using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    private Rigidbody rb;
    public int diamondCount;

    public static bool isGrounded;
    public GameObject nextLevelImg;
    public GameObject player;
    public GameObject playerAgain;

    public GameObject[] lifeHeart;
    public GameObject[] lossHeart;
    int lifeCount=5;

    public GameObject lostScreen;


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

        for (int i = 5; lifeCount < i;i--)
        {
            Destroy(lifeHeart[i]);
            lossHeart[i].SetActive(true);
        }
        if (lifeCount < 1)
        {
            Time.timeScale = 0;
            lostScreen.SetActive(true);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Diamond" || other.gameObject.tag == "Start_Txt" || other.gameObject.tag == "End_Txt")
        {
            Destroy(other.gameObject);
        }
        
        if (other.gameObject.tag == "Diamond")
        {
            CollectablesCount.score++;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Finish" & diamondCount==CollectablesCount.score)
        {
            nextLevelImg.gameObject.SetActive(true);
            Destroy(player.gameObject);
        }

        if(collision.gameObject.tag == "Restrict")
        {
            lifeCount--;
            StartCoroutine(Respawn());/*
            player.gameObject.SetActive(false);*/
        }

        if(collision.gameObject.tag == "Obs1")
        {
            lifeCount--;
            player.gameObject.SetActive(false);
        }
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(1f);
        Instantiate(playerAgain ,transform.position + new Vector3(0,0,-1) , Quaternion.identity);
    }
}

