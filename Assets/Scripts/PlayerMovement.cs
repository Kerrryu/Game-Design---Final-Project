using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool debugging = false;

    private Rigidbody rigidbody;

    private int jumps = 2; // Used for double jumps
    private bool bGrounded = false; // Flag for if player is grounded
    private float groundedTimer = 0.0f; // Timer to prevent early check of grounded
    private static float groundedTimerThreshold = 0.5f; // The value grounded timer has to pass to reset grounded
    private bool bStartDrag = false; // Flag if user is dragging from the player sphere
    private Vector2 startMousePos; // The starting mouse position from where the player began dragging
    private Vector2 ballForceDirection; // The direction force should be applied for the ball, this is calculated when dragging

    private void Awake() {
        // Get Rigidbody off player
        rigidbody = GetComponent<Rigidbody>();
    }

    // Triggered upon mouse down on the player sphere
    private void OnMouseDown() {
        // Flag dragging and store starting position
        bStartDrag = true;
        startMousePos = Input.mousePosition;
    }

    private void Update() {
        // Increase grounded timer
        groundedTimer += Time.deltaTime;

        if(bStartDrag) {
            // Get new mouse position from dragging and calculate the drag force direction
            Vector2 newMousePos = Input.mousePosition;
            Vector2 mouseDifference = newMousePos - startMousePos;
            ballForceDirection = -mouseDifference;
        }   
    }

    private void FixedUpdate() {
        // Raycast to check if grounded
        if(Physics.Raycast(transform.position, Vector3.down, 0.7f) && groundedTimer > groundedTimerThreshold) {
            if(!bGrounded) {
                bGrounded = true;
                jumps = 2;
            }
        } else {
            if(bGrounded) {
                bGrounded = false;
            }
        }

        if(debugging) {
            Debug.DrawLine(transform.position, transform.position + (Vector3.down * 0.7f), Color.red, 0.01f);
        }        
    }

    // Whenever the mouse goes up this is triggered
    private void OnMouseUp() {
        // Only apply effects if dragging is currently flagged to avoid unwanted effects
        // Also check for if double jump is available
        if(bStartDrag && jumps > 0) {
            // Unflag and apply force
            groundedTimer = 0.0f;
            bStartDrag = false;
            bGrounded = false;
            rigidbody.AddForce(ballForceDirection);

            // Take away jump
            jumps--;
        }
    }
}
