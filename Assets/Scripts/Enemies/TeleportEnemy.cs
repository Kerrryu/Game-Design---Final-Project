using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportEnemy : BaseEnemy
{  
    private float teleportTimer = 0;
    public float teleportTime = 5.0f;
    public float explodeTime = 1.0f;

    public override void Move() {
        teleportTimer += Time.deltaTime;

        if(teleportTimer >= teleportTime) {
            teleportTimer = 0;
            transform.position = target.position + new Vector3(0, 1, 0);
            StartCoroutine(DoExplode());
        }
    }

    private IEnumerator DoExplode() {
        //TODO Do something to signify explosiion
        yield return new WaitForSeconds(explodeTime);
        //TODO Do explosion and damage
    }
}
