using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rigidbody;

    private bool bStartDrag = false;
    private Vector2 startMousePos;
    private Vector2 ballForceDirection;

    private void Awake() {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void OnMouseDown() {
        bStartDrag = true;
        startMousePos = Input.mousePosition;
    }

    private void Update() {
        if(bStartDrag) {
            Vector2 newMousePos = Input.mousePosition;
            Vector2 mouseDifference = newMousePos - startMousePos;
            ballForceDirection = -mouseDifference;
        }
    }

    private void OnMouseUp() {
        if(bStartDrag) {
            bStartDrag = false;
            rigidbody.AddForce(ballForceDirection);
        }
    }
}
