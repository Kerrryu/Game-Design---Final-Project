using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportEnemy : BaseEnemy
{  
    private float teleportTimer = 0;
    public float teleportTime = 5.0f;
    public float explodeTime = 1.0f;

    public float explosionForce = 2.0f;

    public override void Move() {
        teleportTimer += Time.deltaTime;

        if(teleportTimer >= teleportTime) {
            teleportTimer = 0;
            transform.position = target.position + new Vector3(0, 2, 0);
            StartCoroutine(DoExplode());
        }
    }

    private IEnumerator DoExplode() {
        bInvulnerable = true;

        //TODO Do something to signify explosiion
        yield return new WaitForSeconds(explodeTime);

        bInvulnerable = false;
        
        Collider[] objs = Physics.OverlapSphere(transform.position, 3.0f);
        for(int i = 0; i < objs.Length; i++) {
            var objRbd = objs[i].GetComponent<Rigidbody>();
            if(objRbd != null) {
                Debug.Log("Applying explosion to " + objRbd.gameObject.name);
                objRbd.AddExplosionForce(explosionForce, transform.position, 3.0f);
            }
        }
    }
}
