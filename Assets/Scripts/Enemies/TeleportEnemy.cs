using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TeleportEnemy : BaseEnemy
{  
    private float teleportTimer = 0;
    public float teleportTime = 5.0f;
    public float explodeTime = 1.0f;

    public float explosionForce = 2.0f;

    public ParticleSystem explosionParticles;
    public MeshRenderer explosionIndicator;

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

        Color fadeColor = new Color(241f/255, 196f/255, 15f/255, 0.0f);
        explosionIndicator.material.DOColor(fadeColor, 0.0f);
        explosionIndicator.gameObject.SetActive(true);
        fadeColor.a = 1.0f;
        explosionIndicator.material.DOColor(fadeColor, explodeTime);

        yield return new WaitForSeconds(explodeTime);

        explosionIndicator.gameObject.SetActive(false);

        bInvulnerable = false;
        
        explosionParticles.Play();
        Collider[] objs = Physics.OverlapSphere(transform.position, 3.0f);
        for(int i = 0; i < objs.Length; i++) {
            var objRbd = objs[i].GetComponent<Rigidbody>();
            if(objRbd != null) {
                objRbd.AddExplosionForce(explosionForce, transform.position, 3.0f, 2.0f, ForceMode.Impulse);
            }

            if(objs[i].GetComponent<PlayerManager>() != null) {
                objs[i].GetComponent<PlayerManager>().LoseLife();
            }
        }
    }
}
