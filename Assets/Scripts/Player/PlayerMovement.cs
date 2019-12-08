using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rbd;

    public float moveSpeed = 1.0f;
    public float runSpeedModifier = 0.5f;
    public float jumpSpeed = 5.0f;
    public int jumps = 2; // Used for double jumps
    public float jumpDistanceCheck = 1.5f;
    private bool bGrounded = false; // Flag for if player is grounded
    private float groundedTimer = 0; // Timer to prevent early check of grounded
    private static float groundedTimerThreshold = 0.5f; // The value grounded timer has to pass to reset grounded
    private float moveDirection = 0;

    private void Awake() {
        // Get Rigidbody off player
        rbd = GetComponent<Rigidbody>();
    }

    private void Update() {
        // Increase grounded timer
        groundedTimer += Time.deltaTime;
        moveDirection = Input.GetAxis("Horizontal");

        if(Input.GetButtonDown("Jump") && jumps > 0) {
            rbd.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            jumps--;
        }
    }

    private void FixedUpdate() {
        rbd.velocity = new Vector3(moveDirection * moveSpeed, rbd.velocity.y, 0);
        
        // Raycast to check if grounded
        if(Physics.Raycast(transform.position, Vector3.down, jumpDistanceCheck) && groundedTimer > groundedTimerThreshold) {
            if(!bGrounded) {
                bGrounded = true;
                jumps = 2;
            }
        } else {
            if(bGrounded) {
                bGrounded = false;
            }
        }

        if(GameManager.instance.debugging) {
            Debug.DrawLine(transform.position, transform.position + (Vector3.down * jumpDistanceCheck), Color.red, 0.01f);
        }        
    }

    private void LateUpdate() {
        Vector3 pos = transform.position;
        float distance = transform.position.z - Camera.main.transform.position.z;

        float leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance)).x + 0.5f;
        float rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance)).x - 0.5f;

        pos.x = Mathf.Clamp(pos.x, leftBorder, rightBorder);
        transform.position = pos;
    }
}
