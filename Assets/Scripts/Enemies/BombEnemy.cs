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

    private bool canDrop = false;

    public GameObject projectileDrop;

    public override void Awake() {
        base.Awake();
        targetPos = transform.position;
    }

    public override void Move() {
        moveTimer += Time.deltaTime;

        if(moveTimer >= 5.0f) {
            moveTimer = 0.0f;
            var goToPos = target.position;
            goToPos.y = randomYOffset;
            targetPos = goToPos;
            canDrop = true;
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
        if(transform.position == targetPos && canDrop) {
            canDrop = false;
            var go = GameObject.Instantiate(projectileDrop, transform.position + new Vector3(0, -1, 0), Quaternion.identity);
            StartCoroutine(DestroyProjectile(go));
        }
    }

    IEnumerator DestroyProjectile(GameObject projectile) {
        yield return new WaitForSeconds(3.0f);
        Destroy(projectile);
    }
}
