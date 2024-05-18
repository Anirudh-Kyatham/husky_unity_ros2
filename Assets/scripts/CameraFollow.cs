using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The target object to follow (Assign the Husky GameObject)
    public Vector3 offset = new Vector3(0, 2, -1); // Offset from the target object
    public float smoothSpeed = 0.125f; // How smoothly the camera catches up to its target

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(target); // Always look at the target
    }
}

