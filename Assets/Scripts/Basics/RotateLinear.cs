using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLinear : MonoBehaviour
{
    public enum Direction { x, y, z };
    public Direction direction;

    public float speed = 10.0f;

    private Vector3 rotationVector = Vector3.zero;

    private void Awake() {
        switch(direction) {
            case Direction.x:
                rotationVector = new Vector3(1,0,0);
                break;
            case Direction.y:
                rotationVector = new Vector3(0,1,0);
                break;
            case Direction.z:
                rotationVector = new Vector3(0,0,1);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationVector * speed * Time.deltaTime);
    }
}
