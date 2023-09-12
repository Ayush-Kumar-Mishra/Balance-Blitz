using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollow : MonoBehaviour
{
    public Transform target; // The target to follow (the ball)
    public float smoothSpeed = 0.125f; // Smoothing factor for camera movement
    public Vector3 offset; // The offset from the target position

    void LateUpdate()
    {
        if (target != null)
        {
            // Calculate the desired position for the camera
            Vector3 desiredPosition = target.position + offset;

            // Use SmoothDamp to interpolate between the current camera position
            // and the desired position smoothly
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Set the camera's position to the smoothed position
            transform.position = smoothedPosition;

            // Make the camera look at the target
            transform.LookAt(target);
        }
    }
}

