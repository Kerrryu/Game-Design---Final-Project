using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    private float lastPlayerX = 0.0f;

    private void FixedUpdate() {
        var desiredHorizontalPosition = lastPlayerX;
        var desiredVerticalPosition = 0f;

        if(lastPlayerX < target.position.x) {
            lastPlayerX = target.position.x;
            desiredHorizontalPosition = target.position.x;
        }

        desiredVerticalPosition = target.position.y;
        var desiredPosition = new Vector3(desiredHorizontalPosition, desiredVerticalPosition, 0) + offset;

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
