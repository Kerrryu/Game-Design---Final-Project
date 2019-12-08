using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Platform : MonoBehaviour
{
    private Rigidbody rigidbody;
    private RaycastHit hit;

    public enum PlatformType { Static, Horizontal, Vertical }
    public PlatformType platformType = PlatformType.Static;

    public bool moveUntilCollide = false;
    public bool moveDirectionPositive = true;
    private float collideTimer = 0;
    public float moveDistance = 0;

    private Vector3 startPostion;
    private Vector3 _endPosition = new Vector3(0,-999,0);
    private Vector3 endPosition { 
        get {
            if(_endPosition.y == -999) {
                Vector3 offset = new Vector3(
                    platformType == PlatformType.Horizontal ? moveDistance : 0, 
                    platformType == PlatformType.Vertical ? moveDistance : 0,
                    0);

                _endPosition = offset + startPostion;
            }
            
            return _endPosition;
        }

        set {
            _endPosition = value;
        }
    }

    [Space]

    public float moveTime = 2.0f;
    public float idleTime = 2.0f;

    [Space]

    public float moveSpeed = 1.0f;

    private void Awake() {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Start() {
        startPostion = transform.position;

        if(platformType != PlatformType.Static) {
            if(moveUntilCollide) {
                if(platformType == PlatformType.Horizontal) {
                    if(Physics.Raycast(transform.position, moveDirectionPositive ? Vector3.right : Vector3.left, out hit)) {
                        endPosition = hit.point + new Vector3(moveDirectionPositive ? -5 : 5, 0, 0);
                    }
                } else if(platformType == PlatformType.Vertical) {
                    if(Physics.Raycast(transform.position, moveDirectionPositive ? Vector3.up : Vector3.down, out hit)) {
                        endPosition = hit.point + new Vector3(0, moveDirectionPositive ? -5 : 5, 0);
                    }
                }
            }

            StartCoroutine(MovePlatform());
        }
    }

    IEnumerator MovePlatform() {
        while(true) {
            yield return new WaitForSeconds(moveTime + idleTime);
            transform.DOMove(endPosition, moveTime);
            yield return new WaitForSeconds(moveTime + idleTime);
            transform.DOMove(startPostion, moveTime);
        }
    }
}
