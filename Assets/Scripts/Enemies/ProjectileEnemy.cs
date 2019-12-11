using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileEnemy : BaseEnemy
{
    public GameObject projectilePrefab;
    public float projectileLaunchSpeed;

    private GameObject lastProjectile;

    public override void Awake() {
        base.Awake();
        StartCoroutine(Shoot());
    }

    public override void Move() {
        // NO MOVEMENT
    }

    private IEnumerator Shoot() {
        while(true) {
            yield return new WaitForSeconds(5.0f);
            if(lastProjectile) Destroy(lastProjectile);
            lastProjectile = GameObject.Instantiate(projectilePrefab, transform.position + new Vector3(0,1,0), Quaternion.identity);
            lastProjectile.transform.LookAt(target);
            var rbd = lastProjectile.GetComponent<Rigidbody>();
            rbd.AddForce(lastProjectile.transform.forward * projectileLaunchSpeed, ForceMode.Impulse);
        }
    }

    public override void DoDeath() {
        if(lastProjectile) Destroy(lastProjectile);
        base.DoDeath();
    }
}
