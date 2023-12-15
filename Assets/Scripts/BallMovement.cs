using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    public int lifeCount=5;
    public Image[] Hearts;
    public Sprite redHeart;
    public Sprite emptyHeart;

    public GameObject damageIndicator;
    

    public GameObject lostScreen;

    public List<GameObject> reSpawnPoints;

    public Vector3 sP;
    bool collided;

    public Vector3 initialPos;
    public Vector3 posExtend;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        collided = false;
        Time.timeScale = 1f;
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

        foreach (Image img in Hearts)
        {
            img.sprite = emptyHeart;
        }
        for (int i = 0; i < lifeCount; i++)
        {
            Hearts[i].sprite = redHeart;
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
            StartCoroutine(DamageIndicate());
            if (lifeCount <= 0)
            {
                Time.timeScale = 0f;
                lostScreen.SetActive(true);
            }
            StartCoroutine(Respawn());
        }

        if(collision.gameObject.tag == "Obs1")
        {
            lifeCount--;
            StartCoroutine(DamageIndicate());
            if (lifeCount <= 0)
            {
                Time.timeScale = 0f;
                lostScreen.SetActive(true);
            }
        }
        
        
        if(collision.gameObject.tag == "Destroyed_Platform")
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject == reSpawnPoints[0])
        {
            sP = reSpawnPoints[0].transform.position;
            collided = true;
        }

        if (collision.gameObject == reSpawnPoints[1])
        {
            sP = reSpawnPoints[1].transform.position;
            collided = true;
        }
        
        if (collision.gameObject == reSpawnPoints[2])
        {
            sP = reSpawnPoints[2].transform.position;
            collided = true;
        }

        if (collision.gameObject.tag == "Restrict" && collided == true)
        {
            StartCoroutine (Respawn());
        }
        
        if (collision.gameObject.tag == "Restrict" && collided == false)
        {
            transform.position = initialPos;
        }
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(1f);
        transform.position = sP + posExtend;
    }
    
    IEnumerator DamageIndicate()
    {
        damageIndicator.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        damageIndicator.gameObject.SetActive(false);
    }

}

