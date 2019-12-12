using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : BasePowerup
{
    public float laserTimer = 30.0f;
    private float timer = 0.0f;
    public GameObject projectile = null;

    public float fireRate = 1.0f;
    private float fireRateTimer = 0.0f;

    private Transform firePoint;
    
    public void Awake() {
        base.Register("Gun");
        firePoint = GameObject.Find("Firepoint").transform;
    }

    public override void Activate() {
        base.Activate();
    }

    public override void Tick() {
        if(Input.GetMouseButtonDown(0)) {
            Shoot();
        }

        fireRateTimer += Time.deltaTime;
        timer += Time.deltaTime;
        if(timer >= laserTimer) {
            Deactivate();
        }

        PlayerManager.instance.powerupManager.UpdatePowerupProgress(30-timer, laserTimer);
    }

    private void Shoot() {
        if(fireRateTimer <= fireRate) {
            return;
        }

        fireRateTimer = 0;

        var projectileObj = Instantiate(projectile, firePoint.position, firePoint.rotation);
        projectileObj.GetComponent<Rigidbody>().AddForce(projectileObj.transform.up * 500);
    }   

    public override void Deactivate() {
        base.Deactivate();
    }
}
