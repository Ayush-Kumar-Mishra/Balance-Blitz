using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovementTest : MonoBehaviour
{
    Rigidbody rb;
    public float moveSpeed;
    public float jump;

    public List<GameObject> spawnPoints;

    public Vector3 sP;
    bool collided = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horInput = Input.GetAxis("Horizontal");
        float verInput = Input.GetAxis("Vertical");

        Vector3 movement;

        movement = new Vector3(horInput, 0 ,verInput);

        rb.velocity = new Vector3 (movement.x * moveSpeed, rb.velocity.y, movement.z * moveSpeed);

        if (Input.GetButtonDown("Jump") && Mathf.Approximately(rb.velocity.y, 0)) rb.velocity = new Vector3(rb.velocity.x, jump, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == spawnPoints[0])
        {
            sP = spawnPoints[0].transform.position;
            collided = true;
        }
        
        if(collision.gameObject == spawnPoints[1])
        {
            sP = spawnPoints[1].transform.position;
            collided = true;
        }

        if (collision.gameObject.tag == "Restrict" && collided == true)
        {
            transform.position = sP;
        }
    }

}
