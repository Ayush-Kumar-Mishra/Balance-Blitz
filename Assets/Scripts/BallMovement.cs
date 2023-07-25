using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed;
    float xInput , zInput ;

    void Start()
    {
        
    }

    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");
        transform.position = new Vector3(transform.position.x + xInput*speed, 0, transform.position.z + zInput*speed);
    }
}
