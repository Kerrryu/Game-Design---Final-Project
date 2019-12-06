using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour
{
    private float health = 100f;
    public float maxHealth = 100f;

    public float speed = 1.0f;

    private Transform _target;
    private Transform target {
        get {
            if(_target == null) {
                var go = GameObject.FindGameObjectWithTag("Player");
                _target = go.transform;
            }

            return _target;
        }
    }

    private void Update() {
        Move();
    }

    public virtual void Move() {
        if(target != null) {
            transform.LookAt(target);

            float step =  speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
    }

    public void Damage(float damage) {
        health -= damage;
        CheckDeath();
    }

    public void CheckDeath() {
        if(health <= 0) {
            DoDeath();
        }
    }

    public virtual void DoDeath() {
        Destroy(gameObject);
    }
}
