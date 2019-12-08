using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEnemy : BaseEnemy
{
    public Vector2 yOffsetRange;
    private float randomYOffset {
        get {
            return Random.Range(yOffsetRange.x,yOffsetRange.y);
        }
    }
    private float moveTimer = 0.0f;
    private Vector3 targetPos;

    public override void Awake() {
        base.Awake();
        targetPos = transform.position;
    }

    public override void Move() {
        moveTimer += Time.deltaTime;

        if(moveTimer >= 5.0f) {
            moveTimer = 0.0f;
            targetPos = target.position + new Vector3(0,randomYOffset,0);
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
    }
}
