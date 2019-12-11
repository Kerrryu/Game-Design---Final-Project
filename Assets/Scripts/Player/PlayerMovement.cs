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
    private static float groundedTimerThreshold = 0.5f; // The value grounded timer has to pass to reset grounded
    private float moveDirection = 0;

    private float distanceToBottomCollider;
    private bool canResetJumps = true;

    private void Awake() {
        // Get Rigidbody off player
        rbd = GetComponent<Rigidbody>();
        distanceToBottomCollider = GetComponent<Collider>().bounds.extents.y;
    }

    private void Update() {
        moveDirection = Input.GetAxis("Horizontal");

        if(Input.GetButtonDown("Jump") && jumps > 0) {
            rbd.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            jumps--;
        }
    }

    private void FixedUpdate() {
        if(PlayerManager.instance.bDead) 
            return;

        rbd.velocity = new Vector3(moveDirection * moveSpeed, rbd.velocity.y, 0);
        
        // Raycast to check if grounded

        if(IsGrounded() && canResetJumps) {
            canResetJumps = false;
            StartCoroutine(ResetJumpTimer());
            jumps = 2;
        }   
    }

    private bool IsGrounded() {
        return Physics.Raycast(transform.position, -Vector3.up, distanceToBottomCollider + 0.1f);
    }

    private IEnumerator ResetJumpTimer() {
        yield return new WaitForSeconds(0.2f);
        canResetJumps = true;
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
