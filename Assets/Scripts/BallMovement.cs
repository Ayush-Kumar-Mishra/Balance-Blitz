using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed;
    float xInput , zInput ;
    public GameObject cam1, cam2, cam3, cam4;

    void Start()
    {
        Time.timeScale = 1f;
    }

    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");
        transform.position = new Vector3(transform.position.x + xInput*speed, transform.position.y, transform.position.z + zInput*speed);

        if (Input.GetKeyDown(KeyCode.E))
        {
            cam2.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                cam3.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    cam4.SetActive(true);
                }
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            cam2.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                cam3.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    cam4.SetActive(true);
                }
            }
        }
    }
}
